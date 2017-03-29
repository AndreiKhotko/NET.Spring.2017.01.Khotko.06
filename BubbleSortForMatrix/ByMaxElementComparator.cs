using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortForMatrix
{
    public class ByMaxElementComparator : IComparator
    {
        public int Compare(int[] a, int[] b) => a.Max() > b.Max() ? 1 : -1;
    }
}
