using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarking.Benchmarks
{
    public class ArraySortIntQuick : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

        public override string InitializationDescription => "Generates an array of random ints.";
        public override string BenchmarkDescription => "Sorts the array with a custom implemented Middle Point Pivot Quicksort <a href='https://github.com/TheAlgorithms/C-Sharp'>(source)</a>.";

        public override string ResultDescription => "The middle value of the sorted array.";
        public override string ParameterDescription => "The length of the array that is sorted.";

        public Random Random = null!;
        public int[] NumberArray = null!;

        public override void Initialize(int parameter)
        {
            var n = (int)parameter;
            NumberArray = new int[n];
            Random = new Random(0);

            for (var i = 0; i < n; i++)
            {
                NumberArray[i] = (int)(Random.NextDouble() * 1000000);
            }
        }

        public override object Execute()
        {
            SortMain(NumberArray);

            return NumberArray[NumberArray.Length / 2];
        }

        // Code extracted from https://github.com/TheAlgorithms/C-Sharp/blob/master/Algorithms/Sorters/Comparison/QuickSorter.cs and
        // https://github.com/TheAlgorithms/C-Sharp/blob/master/Algorithms/Sorters/Comparison/MiddlePointQuickSorter.cs
        // This code is slightly edited so that no abstractions are used.

        public void SortMain(int[] array) 
        {
            Sort(array, 0, array.Length - 1);
        } 

        private void Sort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var p = Partition(array, left, right);
            Sort(array, left, p);
            Sort(array, p + 1, right);
        }

        private int SelectPivot(int[] array, int left, int right) 
        {
            return array[left + (right - left) / 2];
        }

        private int Partition(int[] array, int left, int right)
        {
            var pivot = SelectPivot(array, left, right);
            var nleft = left;
            var nright = right;
            while (true)
            {
                while (array[nleft] - pivot < 0)
                {
                    nleft++;
                }

                while (array[nright] - pivot > 0)
                {
                    nright--;
                }

                if (nleft >= nright)
                {
                    return nright;
                }

                var t = array[nleft];
                array[nleft] = array[nright];
                array[nright] = t;

                nleft++;
                nright--;
            }
        }

    }
}
