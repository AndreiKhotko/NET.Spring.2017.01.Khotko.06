using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortForMatrix
{
    public class BySumReverseComparator : IComparator
    {
        public int Compare(int[] a, int[] b) => a.Sum() < b.Sum() ? 1 : -1;
    }
}
