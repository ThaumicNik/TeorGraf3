using System;
using System.Diagnostics;

namespace HeapSort
{
    public class HeapSort
    {
        public void Sort(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
                //PrintArray(arr);
            }
            //PrintArray(arr);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
                //PrintArray(arr);
            }
        }

        void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && array[l] > array[largest])
                largest = l;

            if (r < n && array[r] > array[largest])
                largest = r;

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                Heapify(array, n, largest);
            }
        }

        private static void Quick_Sort(int[] arr, int left, int right)
        {
            // Check if there are elements to sort
            if (left < right)
            {
                // Find the pivot index
                int pivot = Partition(arr, left, right);

                // Recursively sort elements on the left and right of the pivot
                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            // Select the pivot element
            int pivot = arr[left];

            // Continue until left and right pointers meet
            while (true)
            {
                // Move left pointer until a value greater than or equal to pivot is found
                while (arr[left] < pivot)
                {
                    left++;
                }

                // Move right pointer until a value less than or equal to pivot is found
                while (arr[right] > pivot)
                {
                    right--;
                }

                // If left pointer is still smaller than right pointer, swap elements
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    // Return the right pointer indicating the partitioning position
                    return right;
                }
            }
        }

        static void PrintArray(int[] array)
        {
            int n = array.Length;
            foreach (int i in array)
                Console.Write(i + " ");
            Console.Write("\n");
        }

        public static void Main()
        {
            int[] arr = { 12, 8, 13, 45, 17, 7 };
            int n = arr.Length;
            PrintArray(arr);
            HeapSort sorter = new HeapSort();
            sorter.Sort(arr);
            PrintArray(arr);

            Stopwatch stopWatch = new Stopwatch();
            Random rand = new Random();
            int[] testArr = new int[1000000];
            for (int i = 0; i < testArr.Length; i++)
            {
                testArr[i] = rand.Next() % 1000;
            }
            int[] quickArr = new int[1000000];
            for (int i = 0; i < quickArr.Length; i++)
            {
                quickArr[i] = testArr[i];
            }
            stopWatch.Start();
            sorter.Sort(testArr);
            stopWatch.Stop();
            Console.WriteLine($"HeapSort заняло {stopWatch.ElapsedMilliseconds}");
            stopWatch.Restart();
            HeapSort.Quick_Sort(quickArr, 0, quickArr.Length - 1);
            stopWatch.Stop();
            Console.WriteLine($"QuickSort заняло {stopWatch.ElapsedMilliseconds}");
        }
    }
}