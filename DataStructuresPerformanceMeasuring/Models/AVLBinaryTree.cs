using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPerformanceMeasuring.Models
{
    public class AVLBinaryTree //: IBinarySearchTree
    {
        private AVLBinaryTreeNode _root;

        private int Height(AVLBinaryTreeNode node)
        {
            if (node == null)
                return 0;

            return node.Height;
        }


        // Разница высот поддеревьев узла
        private int HeightDifference(AVLBinaryTreeNode node)
        {
            if (node == null)
                return 0;

            return Height(node.Left) - Height(node.Right);
        }

        // Высота узла на основе выстот его поддеревьев
        private void UpdateHeight(AVLBinaryTreeNode node)
        {
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private AVLBinaryTreeNode RotateRight(AVLBinaryTreeNode y)
        {
            AVLBinaryTreeNode x = y.Left;
            AVLBinaryTreeNode T = x.Right;

            x.Right = y;
            y.Left = T;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        private AVLBinaryTreeNode RotateLeft(AVLBinaryTreeNode x)
        {
            AVLBinaryTreeNode y = x.Right;
            AVLBinaryTreeNode T = y.Left;

            y.Left = x;
            x.Right = T;

            UpdateHeight(x);
            UpdateHeight(y);

            return y;
        }

        public void Insert(int data)
        {
            _root = _insert(_root, data);
        }

        private AVLBinaryTreeNode _insert(AVLBinaryTreeNode node, int data)
        {
            if (node == null)
                return new AVLBinaryTreeNode(data);

            if (data < node.Value)
                node.Left = _insert(node.Left, data);
            else if (data > node.Value)
                node.Right = _insert(node.Right, data);
            else
                return node;

            UpdateHeight(node);

            int balance = HeightDifference(node);

            // LL:  Левая часть левого дерева перевешивает
            if (balance > 1 && data < node.Left.Value)
                return RotateRight(node);

            // RR:  Правая часть правого дерева перевешивает
            if (balance < -1 && data > node.Right.Value)
                return RotateLeft(node);

            // LR
            if (balance > 1 && data > node.Left.Value)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // RL
            if (balance < -1 && data < node.Right.Value)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public AVLBinaryTreeNode Search(int data)
        {
            return _search(_root, data);
        }

        private AVLBinaryTreeNode _search(AVLBinaryTreeNode node, int data)
        {
            if (node == null || node.Value == data)
                return node;

            if (data < node.Value)
                return _search(node.Left, data);

            return _search(node.Right, data);
        }

        public void Remove(int data)
        {
            _root = _remove(_root, data);
        }

        private AVLBinaryTreeNode _remove(AVLBinaryTreeNode node, int data)
        {
            if (node == null)
                return node;

            if (data < node.Value)
                node.Left = _remove(node.Left, data);
            else if (data > node.Value)
                node.Right = _remove(node.Right, data);
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    AVLBinaryTreeNode temp = null;
                    if (temp == node.Left)
                        temp = node.Right;
                    else
                        temp = node.Left;

                    if (temp == null)
                    {
                        temp = node;
                        node = null;
                    }
                    else
                        node = temp;
                }
                else
                {
                    AVLBinaryTreeNode temp = MinValueNode(node.Right);
                    node.Value = temp.Value;

                    node.Right = _remove(node.Right, temp.Value);
                }
            }

            if (node == null)
                return node;

            UpdateHeight(node);

            int balance = HeightDifference(node);

            // LL
            if (balance > 1 && HeightDifference(node.Left) >= 0)
                return RotateRight(node);

            // LR
            if (balance > 1 && HeightDifference(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // RR
            if (balance < -1 && HeightDifference(node.Right) <= 0)
                return RotateLeft(node);

            // RL
            if (balance < -1 && HeightDifference(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        private AVLBinaryTreeNode MinValueNode(AVLBinaryTreeNode node)
        {
            AVLBinaryTreeNode current = node;

            while (current.Left != null)
                current = current.Left;

            return current;
        }
        public void GoAroundInDepth()
        {
            _goAroundInDepth(_root);
            Console.WriteLine();
        }

        private void _goAroundInDepth(AVLBinaryTreeNode node)
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