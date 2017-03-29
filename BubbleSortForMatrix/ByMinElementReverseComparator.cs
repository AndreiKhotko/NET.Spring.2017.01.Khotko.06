using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortForMatrix
{
    public class ByMinElementReverseComparator : IComparator
    {
        public int Compare(int[] a, int[] b) => a.Min() < b.Min() ? 1 : -1;
    }
}
