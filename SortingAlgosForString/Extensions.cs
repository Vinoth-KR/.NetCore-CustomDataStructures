using System;

namespace SortingAlgosForArrays
{
    public static class Extensions
    {
        #region Array Operations Extended
        public static void PrintElements<T>(this T[] array)
        {
            if (null == array || array.Length == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0) Console.Write($"{array[i]}");             
                else Console.Write($", {array[i]}");               
            }
            Console.WriteLine("]");
        }

        public static void SwapElements<T>(this T[] array, int i, int j)
        {
            if (i < 0 || i >= array.Length) throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j >= array.Length) throw new ArgumentOutOfRangeException(nameof(j));


            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static T[] CreateCopy<T>(this T[] sourceArray)
        {
            T[] array = new T[sourceArray.Length];
            sourceArray.CopyTo(array, 0);

            return array;
        }
        #endregion

        #region Sorting Algorithms for Integer Arrays

        #region BubbleSort
        public static int[] BubbleSort(this int[] sourceArray)
        {
            //Creating a copy of the sourceArray in order to preserve the SourceArray for Sorting purpose
            int[] array = sourceArray.CreateCopy();

            bool swapped = true;
            int lastElement = sourceArray.Length - 1;

            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < lastElement; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        array.SwapElements(i, i + 1);
                        swapped = true;
                    }
                }

                lastElement--;
            }

            return array;
        }
        #endregion

        #region MergeSort
        public static int[] MergeSort(this int[] sourceArray)
        {
            //Creating a copy of the sourceArray in order to preserve the SourceArray for Sorting purpose
            int[] array = sourceArray.CreateCopy();
            int[] temp = new int[array.Length];

            MergeSort(array, temp, 0, array.Length - 1);

            return array;
        }

        static void MergeSort(int[] array, int[] temp, int left, int right)
        {
            if (left >= right) return;

            int middle = (left + right) / 2;

            MergeSort(array, temp, left, middle);
            MergeSort(array, temp, middle + 1, right);

            Merge(array, temp, left, right);
        }

        static void Merge(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            int leftEnd = (leftStart + rightEnd) / 2;
            int rightStart = leftEnd + 1;
            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStart;
            int i = leftStart;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (array[left] <= array[right])
                {
                    temp[i] = array[left];
                    left++;
                }
                else
                {
                    temp[i] = array[right];
                    right++;
                }
                i++;
            }

            // copying the left side elements remaining to be copied
            Array.Copy(array, left, temp, i, leftEnd - left + 1);
            // copying the right side elements remaining to be copied
            Array.Copy(array, right, temp, i, rightEnd - right + 1);
            // copying the sorted elements back to the source array
            Array.Copy(temp, leftStart, array, leftStart, size);
        }
        #endregion

        #region SelectionSort
        public static int[] SelectionSort(this int[] sourceArray)
        {
            //Creating a copy of the sourceArray in order to preserve the SourceArray for Sorting purpose
            int[] array = sourceArray.CreateCopy();

            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min]) min = j;
                }

                if (min == i) continue;

                array.SwapElements(i, min);
            }

            return array;
        }

        #endregion

        #region QuickSort
        public static int[] QuickSort(this int[] sourceArray)
        {
            int[] array = sourceArray.CreateCopy();

            QuickSort(array, 0, array.Length - 1);

            return array;
        }

        static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right) return;

            // ideally the pivot value should be a median value  
            // here we use a random pivot
            var r = new Random();
            int pivot = array[r.Next(left, right)];

            int partition = Partition(array, left, right, pivot);
            QuickSort(array, left, partition - 1);
            QuickSort(array, partition, right);
        }

        static int Partition(int[] array, int leftStart, int rightEnd, int pivot)
        {
            int left = leftStart;
            int right = rightEnd;

            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    array.SwapElements(left, right);
                    left++;
                    right--;
                }
            }

            return left;
        }

        #endregion


        #endregion
    }
}
