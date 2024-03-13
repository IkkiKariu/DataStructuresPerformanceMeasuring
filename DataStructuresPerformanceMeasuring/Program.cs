using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPerformanceMeasuring.Models;
using DataStructuresPerformanceMeasuring.Services;

namespace DataStructuresPerformanceMeasuring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pm = new PerfomanceMeasuring();

            Random rand = new Random();

            //int[] inputData = new int[] { 23, 44, 103, 1, 22, 65, 88, 34, 111, 98, 30, 71, 89, 100, 300, 211, 66, 91, 143, 233 };
            int[] inputData = new int[30];

            for (int i = 0; i < inputData.Length; i++)
            {
                inputData[i] = rand.Next(1, 1501);
            }

            int[] notContainedInputData = new int[30];

            for (int i = 0; i < inputData.Length; i++)
            {
                inputData[i] = GenerateNumExcept(rand, inputData);
            }


            var tree = new BinaryTree();
            var avlTree = new AVLBinaryTree();
            List<int> list = new List<int>();

            double? res;

            Console.Write("Входные данные: ");
            for (int i = 0; i < inputData.Length; i++)
            {
                Console.Write(inputData[i] + " ");
            }
            Console.WriteLine("\n");


            res = pm.MeasureInsertings(avlTree, inputData, inputData.Length);
            Console.WriteLine($"Среднее время добавления {inputData.Length} элементов в АВЛ дерево: {res} ms");

            res = pm.MeasureInsertings(tree, inputData, inputData.Length);
            Console.WriteLine($"Среднее время добавления {inputData.Length} элементов в обычное дерево: {res} ms");

            res = pm.MeasureListInsertings(list, inputData, inputData.Length);
            Console.WriteLine($"Среднее время добавления {inputData.Length} элементов в список: {res} ms");

            res = pm.MeasureSearching(avlTree, inputData, inputData.Length);
            Console.WriteLine($"Среднее время поиска случайного существующего элемента в АВЛ дереве: {res}  ms");

            res = pm.MeasureSearching(tree, inputData, inputData.Length);
            Console.WriteLine($"Среднее время поиска существующего элемента в обычном дереве: {res}  ms");

            res = pm.MeasureListBinSearches(list, inputData, inputData.Length);
            Console.WriteLine($"Среднее время бинарного поиска существующего элемента в списке: {res}  ms");

            res = pm.MeasureSearching(avlTree, notContainedInputData, notContainedInputData.Length);
            Console.WriteLine($"Среднее время поиска случайного НЕ существующего элемента в АВЛ дереве: {res}  ms");

            res = pm.MeasureSearching(tree, notContainedInputData, notContainedInputData.Length);
            Console.WriteLine($"Среднее время поиска НЕ существующего элемента в обычном дереве: {res}  ms");

            res = pm.MeasureListBinSearches(list, notContainedInputData, notContainedInputData.Length);
            Console.WriteLine($"Среднее время бинарного поиска НЕ существующего элемента в списке: {res}  ms");


            Console.WriteLine();

            Console.WriteLine("Обход бинарного АВЛ дерева в глубину: ");
            res = pm.MeasureTreeGoAround(avlTree).TotalMilliseconds;
            Console.WriteLine($"Время в ms: {res}");


            Console.WriteLine();

            Console.WriteLine("Обход обычного бинарного дерева в ширину: ");
            res = pm.MeasureTreeGoAround(tree).TotalMilliseconds;
            Console.WriteLine($"Время в ms: {res}");
            Console.WriteLine();


            res = pm.MeasureRemovings(avlTree, inputData, inputData.Length);
            Console.WriteLine($"Среднее время удаления всех элементов АВЛ дерева: {res}  ms");

            res = pm.MeasureRemovings(tree, inputData, inputData.Length);
            Console.WriteLine($"Среднее время удаления всех элементов обычного дерева: {res}  ms");

            res = pm.MeasureListRemoving(list, inputData, inputData.Length);
            Console.WriteLine($"Среднее время удаления всех элементов списка: {res}  ms");

            //Test.MakeTast();
        }

        static int GenerateNumExcept(Random rand, int[] inputData)
        {
            int randNum;

            do
            {
                randNum = rand.Next(1, 1501);
            } while (inputData.Contains(randNum));
            
            return randNum;
        }
    }
}
