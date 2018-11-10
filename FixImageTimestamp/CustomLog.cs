using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FixImageTimestamp {
    class CustomLog {
        public string TAG;
        public string ERROR_TAG;
        private const string LOG_FILE_NAME = "LogFixTimestamp.txt";
        private static StreamWriter w = null;
        private static bool initialized = false;

        public CustomLog(string s) {
            try {
                if (w == null) {
                    w = new StreamWriter(LOG_FILE_NAME, true);
                    w.AutoFlush = true;
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            this.TAG = "[" + s + "] ";
            this.ERROR_TAG = TAG + "[ERROR] ";
            if (!initialized) {
                string log = "=== LOG BEGIN *** " + DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss.fff ===");
                Console.WriteLine(log);
                if (w != null) w.WriteLine(log);
                initialized = true;
            }
        }

        public void Finish() {
            string log = "=== LOG FINISH === " + DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss.fff ===\n");
            Console.WriteLine(log);
            if (w != null) {
                w.WriteLine(log);
                w.Flush();
                w.Close();
                w.Dispose();
            }
        }

        public void d(string message) {
            Console.WriteLine(TAG + message);
            if (w != null) w.WriteLine(TAG + message);
        }

        public void e(string message) {
            Console.WriteLine(ERROR_TAG + message);
            if (w != null) w.WriteLine(ERROR_TAG + message);
        }

        public void e(string message, Exception exception) {
            string msg = ERROR_TAG + message + (exception.Message == null ? "" : " | " + exception.Message + Environment.NewLine + exception.ToString());
            Console.WriteLine(msg);
            if (w != null) w.WriteLine(msg);
        }

        public void ShowErrorBox(string message) {
            e(message);
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInfoBox(string message) {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ClearLog() {
            DialogResult result = MessageBox.Show("Do you want to clear log?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                if (w != null) w.Close();
                File.WriteAllText(LOG_FILE_NAME, String.Empty);
                w = new StreamWriter(LOG_FILE_NAME, true);
                w.AutoFlush = true;
            }
        }
    }
}
