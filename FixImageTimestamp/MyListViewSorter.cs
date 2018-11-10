using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FixImageTimestamp {
    class MyListViewSorter : IComparer {

        public SortOrder Order = SortOrder.Ascending;
        public int SortColumn = 0;
        private static readonly CaseInsensitiveComparer insensitiveComparer = new CaseInsensitiveComparer();

        public int Compare(object x, object y) {
            if (Order == SortOrder.None) return 0;
            string sx = ((ListViewItem)x).SubItems[SortColumn].Text;
            string sy = ((ListViewItem)y).SubItems[SortColumn].Text;
            int a, b;
            int result = 0;
            if (int.TryParse(sx, out a) && int.TryParse(sy, out b)) {
                result = (a - b);
            }
            else {
                result = (insensitiveComparer.Compare(sx, sy));
            }
            return (Order == SortOrder.Ascending ? result : -result);
        }
    }
}
