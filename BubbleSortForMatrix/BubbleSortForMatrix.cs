using System;
using System.Collections;
using System.Linq;

namespace BubbleSortForMatrix
{
    /// <summary>
    /// Class that provides methods for sorting matrix strings using a Bubble Sort algorithm
    /// </summary>
    public static class BubbleSortForMatrix
    {
        /// <summary>
        /// Sort matrix using a BubbleSort algorithm based on values of sz-array elements
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="comparator">Comparator</param>
        public static void Sort(int[][] matrix, IComparator comparator)
        {
            if (matrix == null)
                throw new ArgumentNullException();

            for (int i = 0; i < matrix.Length - i; i++)
                for (int j = 0; j < matrix.Length - i - 1; j++)
                    if (comparator.Compare(matrix[j], matrix[j + 1]) == 1)
                        SwapMatrixStrings(ref matrix[j], ref matrix[j + 1]);

        }

        /// <summary>
        /// Swapping matrix strings
        /// </summary>
        /// <param name="a">first string</param>
        /// <param name="b">second string</param>
        private static void SwapMatrixStrings(ref int[] a, ref int[] b)
        {
            int[] tmp = a;
            a = b;
            b = tmp;
        }
    }
}
