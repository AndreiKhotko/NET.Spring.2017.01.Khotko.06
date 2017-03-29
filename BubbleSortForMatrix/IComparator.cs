using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortForMatrix
{
    public interface IComparator
    {
        int Compare(int[] a, int[] b);
    }
}
