using System.Linq;

namespace BubbleSortForMatrix
{
    /// <summary>
    /// Class that provides methods for sorting matrix strings using a Bubble Sort algorithm
    /// </summary>
    public static class BubbleSortForMatrix
    {
        /// <summary>
        /// Sorts strings in matrix by sum of the string elements
        /// </summary>
        /// <param name="matrix">Sorted step array</param>
        /// <param name="isReverseSort">Determines reverse or straight sorting</param>
        /// <remarks>isReverseSort = true - Reverse sort will be use</remarks>
        public static void SortStringsBySumOfElements(int[][] matrix, bool isReverseSort = false)
        {
            int[] sums = new int[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
                sums[i] = matrix[i].Sum();

            if (isReverseSort)
                BubbleReverseSort(sums, matrix);
            else
                BubbleSort(sums, matrix);
        }

        /// <summary>
        /// Sorts strings in matrix by maximal element in the string
        /// </summary>
        /// <param name="matrix">Sorted step array</param>
        /// <param name="isReverseSort">Determines reverse or straight sorting</param>
        /// <remarks>isReverseSort = true - Reverse sort will be use</remarks>
        public static void SortStringsByMaxElement(int[][] matrix, bool isReverseSort = false)
        {
            int[] maxElements = new int[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
                maxElements[i] = matrix[i].Max();

            if (isReverseSort)
                BubbleReverseSort(maxElements, matrix);
            else
                BubbleSort(maxElements, matrix);

        }

        /// <summary>
        /// Sorts strings in matrix by minimal element in the string
        /// </summary>
        /// <param name="matrix">Sorted step array</param>
        /// <param name="isReverseSort">Determines reverse or straight sorting</param>
        /// <remarks>isReverseSort = true - Reverse sort will be use</remarks>
        public static void SortStringsByMinElement(int[][] matrix, bool isReverseSort = false)
        {
            int[] minElements = new int[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
                minElements[i] = matrix[i].Min();

            if (isReverseSort)
                BubbleReverseSort(minElements, matrix);
            else
                BubbleSort(minElements, matrix);
        }

        /// <summary>
        /// Sort matrix using a BubbleSort algorithm based on values of sz-array elements
        /// </summary>
        /// <param name="based">Sz-array base</param>
        /// <param name="matrix">Matrix</param>
        private static void BubbleSort(int[] based, int[][] matrix)
        {
            for (int i = 0; i < based.Length - i; i++)
                for (int j = 0; j < based.Length - i - 1; j++)
                    if (based[j] > based[j + 1])
                    {
                        Swap(ref based[j], ref based[j + 1]);
                        SwapMatrixStrings(ref matrix[j], ref matrix[j + 1]);
                    }
        }

        /// <summary>
        /// Reverse sort matrix using a BubbleSort algorithm based on values of sz-array elements
        /// </summary>
        /// <param name="based">Sz-array base</param>
        /// <param name="matrix">Matrix</param>
        private static void BubbleReverseSort(int[] based, int[][] matrix)
        {
            for (int i = 0; i < based.Length - i; i++)
                for (int j = 0; j < based.Length - i - 1; j++)
                    if (based[j] < based[j + 1])
                    {
                        Swap(ref based[j], ref based[j + 1]);
                        SwapMatrixStrings(ref matrix[j], ref matrix[j + 1]);
                    }
        }

        /// <summary>
        /// Swapping int values in array by ref
        /// </summary>
        /// <param name="a">ref first</param>
        /// <param name="b">ref second</param>
        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
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
