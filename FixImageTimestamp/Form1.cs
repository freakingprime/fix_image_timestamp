using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FixImageTimestamp {
    public partial class Form1 : Form {
        private CustomLog log = new CustomLog(typeof(Form1).Name);
        private List<string> listFile = new List<string>();
        private List<ImageInfo> listImageInfo = new List<ImageInfo>();
        private MyListViewSorter sorter = new MyListViewSorter();

        public Form1() {
            InitializeComponent();
            this.Text = Properties.Resources.APP_NAME + " " + Properties.Resources.VERSION_CODE + "." + Properties.Resources.BuildTime;
            txtFolderPath.Text = Properties.Settings.Default.LastFolderPath;
            //chkIncludeSubfolders.Checked = Properties.Settings.Default.IncludeSubfolders;
            //chkUseTimePattern.Checked = Properties.Settings.Default.UseTimePattern;
            chkShowFailOnly.Checked = Properties.Settings.Default.ShowFailOnly;
            lvwPreview.ListViewItemSorter = sorter;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Visible = false;
        }

        private void enableButtons(Control parentControl, bool status) {
            foreach (Control subControl in parentControl.Controls) {
                if (subControl is Button) {
                    subControl.Enabled = status;
                }
                else {
                    enableButtons(subControl, status);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            log.d("Browse for image folder");
            string lastPath = txtFolderPath.Text;
            if (!Directory.Exists(lastPath)) {
                lastPath = Properties.Settings.Default.LastFolderPath;
                if (lastPath.Length < 1 || !Directory.Exists(lastPath)) {
                    lastPath = null;
                }
            }
            lastPath = Properties.Settings.Default.LastFolderPath;
            FolderBrowserDialog dlg = new FolderBrowserDialog {
                SelectedPath = lastPath
            };
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult.Equals(DialogResult.OK)) {
                string selectedPath = dlg.SelectedPath;
                Properties.Settings.Default.LastFolderPath = selectedPath;
                Properties.Settings.Default.Save();
                txtFolderPath.Text = selectedPath;
                log.d("Selected path: " + selectedPath);
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e) {
            string folderPath = txtFolderPath.Text.Trim();
            log.d("Analyze: " + folderPath);
            if (!Directory.Exists(folderPath)) {
                log.e("Folder not found: " + folderPath);
                return;
            }
            analyze(folderPath);
        }

        private void analyze(string folderPath) {
            enableButtons(this, false);
            lvwPreview.Enabled = false;
            progressBar.Visible = true;
            progressBar.Value = 0;
            txtStatus.Clear();
            BackgroundWorker worker = new BackgroundWorker {
                WorkerReportsProgress = true,
            };
            worker.DoWork += (wSender, wEvent) => {
                findFiles(folderPath, (BackgroundWorker)wSender);
            };
            worker.RunWorkerCompleted += (wSender, wEvent) => {
                fillListView(listImageInfo);
                enableButtons(this, true);
                lvwPreview.Enabled = true;
                progressBar.Visible = false;
            };
            worker.ProgressChanged += (wSender, wEvent) => {
                progressBar.Value = wEvent.ProgressPercentage;
            };
            worker.RunWorkerAsync();
        }

        private void findFiles(string folderPath, BackgroundWorker worker) {
            log.d("Start searching for files in: " + folderPath);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            listFile.Clear();
            listImageInfo.Clear();
            if (chkIncludeSubfolders.Checked) {
                getFiles_recursive(folderPath);
            }
            else {
                getFiles(folderPath);
            }
            log.d("Found: " + listFile.Count + " files");
            log.d("Time searching for files: " + stopWatch.ElapsedMilliseconds + " ms");
            stopWatch.Restart();

            int size = listFile.Count;
            int progress = 0;
            int lastProgress = 0;
            for (int i = 0; i < size; ++i) {
                listImageInfo.Add(new ImageInfo(listFile[i]));
                progress = (i + 1) * 100 / size;
                if (worker != null && progress > lastProgress) {
                    worker.ReportProgress(progress);
                    lastProgress = progress;
                }
            }
            log.d("Time generate image list: " + stopWatch.ElapsedMilliseconds + " ms");
        }

        private void fillListView(List<ImageInfo> list) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool showFailOnly = chkShowFailOnly.Checked;
            int failCount = 0;

            List<ListViewItem> arrTemp = new List<ListViewItem>();
            for (int i = 0; i < list.Count; ++i) {
                ImageInfo info = list[i];
                if (!info.IsOkay || (info.IsOkay && !showFailOnly)) {
                    string status = "OK";
                    if (!info.IsOkay) {
                        status = "Mismatch";
                        ++failCount;
                    }
                    string type = "";
                    if (info.HasExif) type = "EXIF";
                    else if (info.HasTimePattern) type = "Filename";
                    ListViewItem item = new ListViewItem(new string[] { info.RawFile.Name, info.StrModificationTime, info.StrExpectedTime, type, status, info.DiffSecond + "", info.RawFile.FullName });
                    if (item.SubItems[headerType.Index].Text.Length < 2) item.BackColor = Color.LightYellow;
                    item.Tag = info;
                    arrTemp.Add(item);
                }
            }
            log.d("Time create listviewitem array: " + stopwatch.ElapsedMilliseconds + " ms");
            stopwatch.Restart();

            lvwPreview.BeginUpdate();
            lvwPreview.Items.Clear();
            lvwPreview.Items.AddRange(arrTemp.ToArray());
            if (arrTemp.Count > 0) lvwPreview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            else lvwPreview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwPreview.EndUpdate();
            log.d("Time fill listview: " + stopwatch.ElapsedMilliseconds + " ms");
            stopwatch.Stop();

            txtStatus.Text = "Fail: " + failCount + " / " + listImageInfo.Count;
        }

        private void getFiles(string path) {
            string[] temp = Directory.GetFiles(path);
            foreach (string s in temp) {
                string t = s.ToLower();
                if (t.EndsWith(".jpg") || t.EndsWith(".jpeg") || t.EndsWith(".png") || t.EndsWith(".gif")) listFile.Add(s);
            }
        }

        private void getFiles_recursive(string path) {
            getFiles(path);
            foreach (string folder in Directory.EnumerateDirectories(path)) {
                getFiles_recursive(folder);
            }
        }

        private void chkUseTimePattern_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.UseTimePattern = chkUseTimePattern.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkIncludeSubfolders_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.IncludeSubfolders = chkIncludeSubfolders.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnProcess_Click(object sender, EventArgs e) {
            DialogResult dlgResult = MessageBox.Show("Do you want to change timestamp for those files?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgResult != DialogResult.Yes) return;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            log.d("Change timestamp for " + listImageInfo.Count + " files");
            bool useFilename = chkUseTimePattern.Checked;
            enableButtons(this, false);
            lvwPreview.Enabled = false;
            txtStatus.Text = "Processing...";
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (wSender, wEvent) => {
                foreach (ImageInfo info in listImageInfo) {
                    if (info.IsOkay) continue;
                    if (info.HasExif || (info.HasTimePattern && useFilename)) {
                        info.RawFile.LastWriteTime = info.ExpectedTime;
                    }
                }
            };
            worker.RunWorkerCompleted += (wSender, wEvent) => {
                log.d("Time change timestamp: " + stopwatch.ElapsedMilliseconds + " ms");
                analyze(txtFolderPath.Text.Trim());
            };
            worker.RunWorkerAsync();
        }

        private void lvwPreview_ColumnClick(object sender, ColumnClickEventArgs e) {
            sorter.SortColumn = e.Column;
            switch (sorter.Order) {
                case SortOrder.None:
                case SortOrder.Descending:
                    sorter.Order = SortOrder.Ascending;
                    break;
                case SortOrder.Ascending:
                    sorter.Order = SortOrder.Descending;
                    break;
            }
            lvwPreview.Sort();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            log.Finish();
        }

        private void chkShowFailOnly_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.ShowFailOnly = chkShowFailOnly.Checked;
            Properties.Settings.Default.Save();
            fillListView(listImageInfo);
        }

        private void menuLvwPreview_Opening(object sender, CancelEventArgs e) {

        }

        private void menuItem_openImage_Click(object sender, EventArgs e) {
            ImageInfo info = (ImageInfo)lvwPreview.SelectedItems[0].Tag;
            log.d("Open: " + info.RawFile.FullName);
            Process.Start(info.RawFile.FullName);
        }
    }
}
