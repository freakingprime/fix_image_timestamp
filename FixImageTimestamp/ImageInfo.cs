using ExifLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FixImageTimestamp {
    class ImageInfo {
        private static readonly CustomLog log = new CustomLog(typeof(ImageInfo).Name);
        private static readonly Regex regexTime = new Regex(@"(20\d{6})[-_.:]?(\d{6})");

        public FileInfo RawFile;
        public DateTime ExpectedTime;
        public double DiffSecond;
        public bool HasExif = false;
        public bool HasTimePattern = false;

        public ImageInfo(string path) {
            this.RawFile = new FileInfo(path.Trim());
            this._strOriginalModificationTime = RawFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            try {
                using (ExifReader reader = new ExifReader(RawFile.FullName)) {
                    if (reader.GetTagValue<DateTime>(ExifTags.DateTime, out ExpectedTime) || reader.GetTagValue<DateTime>(ExifTags.DateTimeOriginal, out ExpectedTime) || reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out ExpectedTime)) {
                        this.HasExif = true;
                    }
                    else {
                        log.e("No date EXIF: " + RawFile.FullName);
                    }
                }
            }
            catch (ExifLibException e) {
                log.e("Cannot get EXIF: " + RawFile.FullName + " | " + (e.Message == null ? "" : e.Message));
            }
            if (!HasExif) {
                Match match = regexTime.Match(RawFile.Name);
                if (match.Success) {
                    string time = match.Groups[1].Value + match.Groups[2].Value;
                    if (DateTime.TryParseExact(time, @"yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out ExpectedTime)) {
                        this.HasTimePattern = true;
                    }
                    else {
                        log.e("Cannot get time from filename: " + RawFile.FullName);
                    }
                }
            }
            _strExpectedTime = ExpectedTime.ToString("yyyy-MM-dd HH:mm:ss");
            DiffSecond = 0;
            if (HasExif || HasTimePattern) {
                DiffSecond = (RawFile.LastWriteTime - ExpectedTime).TotalSeconds;
                _isOkay = DiffSecond < 2.1;
            }            
        }

        private bool _isOkay;

        public bool IsOkay {
            get { return _isOkay; }
        }

        private string _strOriginalModificationTime;

        public string StrModificationTime {
            get { return _strOriginalModificationTime; }
        }

        private string _strExpectedTime;

        public string StrExpectedTime {
            get { return _strExpectedTime; }
        }
    }
}
