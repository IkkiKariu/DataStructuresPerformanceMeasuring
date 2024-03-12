using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPerformanceMeasuring.Models
{
    public class BinaryTree //: IBinarySearchTree
    {
        public BinaryTreeNode? _root;

        public void Insert(int value)
        {
            _root = _insert(_root, value);

        }

        private BinaryTreeNode _insert(BinaryTreeNode currentRoot, int value)
        {
            if (currentRoot == null)
            {
                currentRoot = new BinaryTreeNode(value);
                return currentRoot;
            }
            if (value < currentRoot.Value)
            {
                currentRoot.Left = _insert(currentRoot.Left, value);
            }
            else if (value > currentRoot.Value)
            {
                currentRoot.Right = _insert(currentRoot.Right, value);
            }
            return currentRoot;
        }
    
        private BinaryTreeNode? _search(BinaryTreeNode currentRoot, int value)
        {
            if (currentRoot == null)
                return null;

            var node = currentRoot;

            if (value < currentRoot.Value)
            {
                node = _search(currentRoot.Left, value);
            }
            else if (value > currentRoot.Value)
            {
                node = _search(currentRoot.Right, value);
            }

            return node;
        }

        public BinaryTreeNode? Search(int value)
        {
            BinaryTreeNode? result = null;

            if (_root != null)
                result = _search(_root, value);

            return result;
        }

        public void Remove(int value)
        {
            _root = _remove(_root, value);
        }

        private BinaryTreeNode? _remove(BinaryTreeNode currentRoot, int? value)
        {
            if (currentRoot == null)
                return null;

            if (value == currentRoot.Value)
            {
                if (currentRoot.Left == null)
                {
                    return currentRoot.Right;
                }
                else if (currentRoot.Right == null)
                {
                    return currentRoot.Left;
                }

                currentRoot.Value = MinValue(currentRoot.Right);
                currentRoot.Right = _remove(currentRoot.Right, currentRoot.Value);
            }
            else if (value < currentRoot.Value)
            {
                currentRoot.Left = _remove(currentRoot.Left, value);
            }
            else
            {
                currentRoot.Right = _remove(currentRoot.Right, value);

            }

            return currentRoot;
        }

        private int? MinValue(BinaryTreeNode node)
        {
            int? minValue = node.Value;
            while (node.Left != null)
            {
                minValue = node.Left.Value;
                node = node.Left;
            }
            return minValue;
        }

        public void GoAroundInDepth()
        {
            _goAroundInDepth(_root);
            Console.WriteLine();
        }

        private void _goAroundInDepth(BinaryTreeNode node)
        {
            if (node != null)
            {
                Console.Write(node.Value + " ");
                _goAroundInDepth(node.Left);
                _goAroundInDepth(node.Right);
            }
        }
    }
}
