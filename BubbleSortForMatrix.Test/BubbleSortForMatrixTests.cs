using System;
using NUnit.Framework;

namespace BubbleSortForMatrix.Test
{
    [TestFixture]
    public class BubbleSortForMatrixTests
    {
        [TestCase(
            //=== TestInput ====
            new int[10] {5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
            new int[4] {2, 2, 2, 2},
            new int[5] {20, 20, 20, 20, 20},
            new int[3] {1, 2, 1},
            new int[4] { 2, 3, 4, 5 },
            //=== end TestInput ===

            //=== Expected =======
            new int[3] { 1, 2, 1 },
            new int[4] { 2, 2, 2, 2 },
            new int[4] { 2, 3, 4, 5 },
            new int[10] {5, 5, 5, 5, 5, 5, 5, 5, 5, 5},  
            new int[5] {20, 20, 20, 20, 20}
            //=== end Expected ===
        )]
        public void SortStringsBySumOfElements_PositiveTest(params int[][] matrix)
        {
            int[][] expected = CopyMatrix(matrix, matrix.Length / 2, matrix.Length - 1);
            int[][] actual = CopyMatrix(matrix, 0, (matrix.Length / 2) - 1);
            BubbleSortForMatrix.SortStringsBySumOfElements(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(
            new int[10] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
            
            new int[10] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }
        )]
        [TestCase(
            new int[1] { 5 },

            new int[1] { 5 }
        )]
        public void SortStringsBySumOfElements_OneStringArray_ReturnsTheSameArray(params int[][] matrix)
        {
            int[][] expected = CopyMatrix(matrix, matrix.Length / 2, matrix.Length - 1);
            int[][] actual = CopyMatrix(matrix, 0, (matrix.Length / 2) - 1);
            BubbleSortForMatrix.SortStringsBySumOfElements(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(
            new int[4] { -1, -1, -1, -1 },
            new int[3] { -1000, -150, -200 },
            new int[5] { 20, 10, 5, 21, 20 },
            new int[3] { 1, 2, 1 },
            new int[4] { 0, 0, 0, 0 },

            new int[3] { -1000, -150, -200 },
            new int[4] { -1, -1, -1, -1 },
            new int[4] { 0, 0, 0, 0 },
            new int[3] { 1, 2, 1 },
            new int[5] { 20, 10, 5, 21, 20 }
        )]
        public void SortStringsByMaxElement_PositiveTest(params int[][] matrix)
        {
            int[][] expected = CopyMatrix(matrix, matrix.Length / 2, matrix.Length - 1);
            int[][] actual = CopyMatrix(matrix, 0, (matrix.Length / 2) - 1);
            BubbleSortForMatrix.SortStringsByMaxElement(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(
            new int[3] { -1000, -150, -200 },
            new int[4] { -1, -1, -1, -2 },
            new int[4] { 0, 0, 0, 0 },
            new int[3] { 1, 2, -3 },
            new int[5] { 20, 10, 5, 21, 20 },

            new int[3] { -1000, -150, -200 },
            new int[3] { 1, 2, -3 },
            new int[4] { -1, -1, -1, -2 },
            new int[4] { 0, 0, 0, 0 },
            new int[5] { 20, 10, 5, 21, 20 }
        )]
        public void SortStringsByMinElement_PositiveTest(params int[][] matrix)
        {
            int[][] expected = CopyMatrix(matrix, matrix.Length / 2, matrix.Length - 1);
            int[][] actual = CopyMatrix(matrix, 0, (matrix.Length / 2) - 1);
            BubbleSortForMatrix.SortStringsByMinElement(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Copy matrix of Int32-values into new matrix from one index to another
        /// </summary>
        /// <param name="src">Source matrix</param>
        /// <param name="from">Start index</param>
        /// <param name="to">End index</param>
        /// <returns>Deep copy of source matrix</returns>
        /// <remarks>This method was created only for tests</remarks>
        private static int[][] CopyMatrix(int[][] src, int from, int to)
        {
            if (src == null)
                return null;

            if (from > to)
                throw new ArgumentException("Parameter <from> is more than <to>");

            int[][] result = new int[to - from + 1][];
            int indexResult = 0;

            for (int i = from; i <= to; i++)
            {
                result[indexResult] = new int[src[i].Length];

                for (int j = 0; j < src[i].Length; j++)
                    result[indexResult][j] = src[i][j];

                indexResult++;
            }

            return result;
        }
    }
}
