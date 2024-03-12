using DataStructuresPerformanceMeasuring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataStructuresPerformanceMeasuring.Services
{
    internal class PerfomanceMeasuring
    {
        private Stopwatch _stopwatch = new Stopwatch();
        
        public TimeSpan MeasureInsertingOnce(AVLBinaryTree tree, int value)
        {
            _stopwatch.Reset();


            _stopwatch.Start();
            tree.Insert(value);
            _stopwatch.Stop();

            return _stopwatch.Elapsed;
            
        }

        public double? MeasureInsertings(AVLBinaryTree tree, int[] values, int times)
        {
            if (values.Length != times)
            {
                Console.WriteLine("Входные данные не соответствуют колечеству замеров...");
                return null;
            }


            double[] measures = new double[times];

            for (int i = 0; i < times; i++)
            {
                var elapsed = MeasureInsertingOnce(tree, values[i]);

                measures[i] = elapsed.TotalMilliseconds;
            }

            return measures.Sum() / times;
        }



        public TimeSpan MeasureInsertingOnce(BinaryTree tree, int value)
        {
            _stopwatch.Reset();


            _stopwatch.Start();
            tree.Insert(value);
            _stopwatch.Stop();

            return _stopwatch.Elapsed;

        }

        public double? MeasureInsertings(BinaryTree tree, int[] values, int times)
        {
            if (values.Length != times)
            {
                Console.WriteLine("Входные данные не соответствуют колечеству замеров...");
                return null;
            }


            double[] measures = new double[times];

            for (int i = 0; i < times; i++)
            {
                var elapsed = MeasureInsertingOnce(tree, values[i]);

                measures[i] = elapsed.TotalMilliseconds;
            }

            return measures.Sum() / times;
        }



        public double? MeasureSearching(AVLBinaryTree tree, int[] values, int times)
        {
            if (values.Length != times)
            {
                Console.WriteLine("Входные данные не соответствуют колечеству замеров...");
                return null;
            }


            double[] measures = new double[times];

            for (int i = 0; i < times; i++)
            {
                var elapsed = MeasureSearchingOnce(tree, values[i]);

                measures[i] = elapsed.TotalMilliseconds;
            }

            return measures.Sum() / times;
        }

        public TimeSpan MeasureSearchingOnce(AVLBinaryTree tree, int value)
        {
            _stopwatch.Reset();
            
            _stopwatch.Start();
            tree.Search(value);
            _stopwatch.Stop();

            return _stopwatch.Elapsed;
        }

        

        public double? MeasureSearching(BinaryTree tree, int[] values, int times)
        {
            if (values.Length != times)
            {
                Console.WriteLine("Входные данные не соответствуют колечеству замеров...");
                return null;
            }


            double[] measures = new double[times];

            for (int i = 0; i < times; i++)
            {
                var elapsed = MeasureSearchingOnce(tree, values[i]);

                measures[i] = elapsed.TotalMilliseconds;
            }

            return measures.Sum() / times;
        }

        public TimeSpan MeasureSearchingOnce(BinaryTree tree, int value)
        {
            _stopwatch.Reset();
            
            _stopwatch.Start();
            tree.Search(value);
            _stopwatch.Stop();

            return _stopwatch.Elapsed;
        }



        public TimeSpan MeasureTreeGoAround(AVLBinaryTree tree)
        {
            _stopwatch.Reset();

            _stopwatch.Start();
            tree.GoAroundInDepth();
            _stopwatch.Stop();

            return _stopwatch.Elapsed;
        }

        public TimeSpan MeasureTreeGoAround(BinaryTree tree)
        {
            _stopwatch.Reset();

            _stopwatch.Start();
            tree.GoAroundInDepth();
            _stopwatch.Stop();

            return _stopwatch.Elapsed;
        }

        public void MeasureRemoves(int times)
        {

        }

        public int? ListBinarySearch(List<int> list, int target)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (list[mid] == target)
                {
                    return list[mid];
                }
                else if (list[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return null;
        }


        public double? MeasureListBinSearches(List<int> list, int[] forSearch, int times)
        {
            if (forSearch.Length != times)
            {
                Console.WriteLine("Входные данные не соответствуют колечеству замеров...");
                return null;
            }


            double[] measures = new double[times];

            for (int i = 0; i < times; i++)
            {
                var elapsed = MeasureListBinSearch(list, forSearch[i]);

                measures[i] = elapsed.TotalMilliseconds;
            }

            return measures.Sum() / times;
        }

        public TimeSpan MeasureListBinSearch(List<int> list, int value)
        {
            _stopwatch.Reset();

            _stopwatch.Start();
            ListBinarySearch(list, value);
            _stopwatch.Stop();

            return _stopwatch.Elapsed;
        }


        public TimeSpan MeasureListInsertingOnce(List<int> list, int value)
        {
            _stopwatch.Reset();


            _stopwatch.Start();
            list.Add(value);
            _stopwatch.Stop();

            return _stopwatch.Elapsed;

        }

        public double? MeasureListInsertings(List<int> list, int[] values, int times)
        {
            if (values.Length != times)
            {
                Console.WriteLine("Входные данные не соответствуют колечеству замеров...");
                return null;
            }


            double[] measures = new double[times];

            for (int i = 0; i < times; i++)
            {
                var elapsed = MeasureListInsertingOnce(list, values[i]);

                measures[i] = elapsed.TotalMilliseconds;
            }

            return measures.Sum() / times;
        }

        public TimeSpan MeasureListRemovingOnce(List<int> list, int value)
        {
            _stopwatch.Reset();


            _stopwatch.Start();
            list.Remove(value);
            _stopwatch.Stop();

            return _stopwatch.Elapsed;

        }

        public double? MeasureListRemoving(List<int> list, int[] values, int times)
        {
            if (values.Length != times)
            {
                Console.WriteLine("Входные данные не соответствуют колечеству замеров...");
                return null;
            }


            double[] measures = new double[times];

            for (int i = 0; i < times; i++)
            {
                var elapsed = MeasureListRemovingOnce(list, values[i]);

                measures[i] = elapsed.TotalMilliseconds;
            }

            return measures.Sum() / times;
        }

        public TimeSpan MeasureRemovingOnce(AVLBinaryTree tree, int value)
        {
            _stopwatch.Reset();


            _stopwatch.Start();
            tree.Remove(value);
            _stopwatch.Stop();

            return _stopwatch.Elapsed;

        }

        public double? MeasureRemovings(AVLBinaryTree tree, int[] values, int times)
        {
            if (values.Length != times)
            {
                Console.WriteLine("Входные данные не соответствуют колечеству замеров...");
                return null;
            }


            double[] measures = new double[times];

            for (int i = 0; i < times; i++)
            {
                var elapsed = MeasureRemovingOnce(tree, values[i]);

                measures[i] = elapsed.TotalMilliseconds;
            }

            return measures.Sum() / times;
        }


        public TimeSpan MeasureRemovingOnce(BinaryTree tree, int value)
        {
            _stopwatch.Reset();


            _stopwatch.Start();
            tree.Remove(value);
            _stopwatch.Stop();

            return _stopwatch.Elapsed;

        }

        public double? MeasureRemovings(BinaryTree tree, int[] values, int times)
        {
            if (values.Length != times)
            {
                Console.WriteLine("Входные данные не соответствуют колечеству замеров...");
                return null;
            }


            double[] measures = new double[times];

            for (int i = 0; i < times; i++)
            {
                var elapsed = MeasureRemovingOnce(tree, values[i]);

                measures[i] = elapsed.TotalMilliseconds;
            }

            return measures.Sum() / times;
        }
    }
}
