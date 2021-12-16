using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FIrstMVVMProg.Client.ViewModels;

namespace FIrstMVVMProg.Client.Model
{
    class Sorts
    {

        public void InsertionSort(ObservableCollection<Data> collection)
        {
            for (var i = 1; i < collection.Count; i++) {

                var x = collection[i].Value;
                var j = i - 1;
                while (j >= 0&& x < collection[j].Value){

                    collection[j + 1] = collection[j];
                    j -= 1;
                }
                collection[j + 1].Value = x;
            }
        }//Вставками

        public void SelectionSort(ObservableCollection<Data> collection)//Выборками
        {
            for (int i = 0; i < collection.Count-1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].Value < collection[min].Value)
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = collection[min].Value;
                collection[min].Value = collection[i].Value;
                collection[i].Value = temp;
            }

        }

        public void RadixSort(ObservableCollection<Data> collection)
        {
            int n = collection.Count;
            int m = getMax(collection, n);

            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(collection, n, exp);
        }//Поразрядная




        public void MergeSort(ObservableCollection<Data> collection, int l, int r)
        {


            if (l < r)
            {
                // Find the middle
                // point
                int m = l + (r - l) / 2;
                // Sort first and
                // second halves
                MergeSort(collection, l, m);
                MergeSort(collection, m + 1, r);
                // Merge the sorted halves
                merge(collection, l, m, r);
            }
        }//Слиянием

        public void Heapsort(ObservableCollection<Data> collection)
        {
            int n = collection.Count;

            // Build heap (rearrange array)
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(collection, n, i);

            // One by one extract an element from heap
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = collection[0].Value;
                collection[0].Value = collection[i].Value;
                collection[i].Value = temp;

                // call max heapify on the reduced heap
                heapify(collection, i, 0);
            }
        }//Пирамидальная





        // To heapify a subtree rooted with node i which is
        // an index in arr[]. n is size of heap
        private void heapify(ObservableCollection<Data> collection, int n, int i)
        {
            int largest = i; // Initialize largest as root
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // If left child is larger than root
            if (l < n && collection[l].Value > collection[largest].Value)
                largest = l;

            // If right child is larger than largest so far
            if (r < n && collection[r].Value > collection[largest].Value)
                largest = r;

            // If largest is not root
            if (largest != i)
            {
                int swap = collection[i].Value;
                collection[i].Value = collection[largest].Value;
                collection[largest].Value = swap;

                // Recursively heapify the affected sub-tree
                heapify(collection, n, largest);
            }
        }
        private int getMax(ObservableCollection<Data> collection, int n)
        {
            int mx = collection[0].Value;
            for (int i = 1; i < n; i++)
                if (collection[i].Value > mx)
                    mx = collection[i].Value;
            return mx;
        }
        private static void countSort(ObservableCollection<Data> collection, int n, int exp)
        {
            int[] output = new int[n]; // output array
            int i;
            int[] count = new int[10];

            // initializing all elements of count to 0
            for (i = 0; i < 10; i++)
                count[i] = 0;


            // Store count of occurrences in count[]
            for (i = 0; i < n; i++)
                count[(collection[i].Value / exp) % 10]++;

            // Change count[i] so that count[i] now contains
            // actual
            //  position of this digit in output[]
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(collection[i].Value / exp) % 10] - 1] = collection[i].Value;
                count[(collection[i].Value / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now
            // contains sorted numbers according to current
            // digit
            for (i = 0; i < n; i++)
                collection[i].Value = output[i];
        }
        private void merge(ObservableCollection<Data> collection, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = collection[l + i].Value;
            for (j = 0; j < n2; ++j)
                R[j] = collection[m + 1 + j].Value;

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    collection[k].Value = L[i];
                    i++;
                }
                else
                {
                    collection[k].Value = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                collection[k].Value = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                collection[k].Value = R[j];
                j++;
                k++;
            }
        }
    }
}
