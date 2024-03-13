using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPerformanceMeasuring.Models;

namespace DataStructuresPerformanceMeasuring
{
    internal class Test
    {
        public static void MakeTast()
        {
            //-> Base Binary Tree testing
            //BinaryTree _tree = new BinaryTree();

            //-> Inserting

            /*_tree.Insert(20);
            _tree.Insert(15);
            _tree.Insert(13);
            _tree.Insert(17);
            _tree.Insert(25);
            _tree.Insert(30);
            _tree.Insert(23);
            _tree.Insert(35);
            _tree.Insert(36);

            Console.WriteLine("asd");*/

            //<-


            //-> AVLBinaryTreeTesting
            AVLBinaryTree _avlTree = new AVLBinaryTree();

            //-> Inserting

            _avlTree.Insert(20);
            _avlTree.Insert(15);
            _avlTree.Insert(13);
            _avlTree.Insert(17);
            _avlTree.Insert(25);
            _avlTree.Insert(30);
            _avlTree.Insert(23);
            _avlTree.Insert(35);
            _avlTree.Insert(36);
            _avlTree.Insert(37);
            _avlTree.Insert(27);
            _avlTree.Insert(40);
            _avlTree.Insert(24);
            _avlTree.Insert(37);
            _avlTree.Insert(100);
            _avlTree.Insert(101);

            Console.WriteLine("cmpltd!");
        }
    }
}
