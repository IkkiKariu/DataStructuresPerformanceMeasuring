using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructuresPerformanceMeasuring.Models
{
    class AVLBinaryTree
    {
        public AVLBinaryTreeNode root;
        public AVLBinaryTree()
        {
        }
        public void Insert(int data)
        {
            AVLBinaryTreeNode newItem = new AVLBinaryTreeNode(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = _insert(root, newItem);
            }
        }
        private AVLBinaryTreeNode _insert(AVLBinaryTreeNode current, AVLBinaryTreeNode n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.Value < current.Value)
            {
                current.Left = _insert(current.Left, n);
                current = balance_tree(current);
            }
            else if (n.Value > current.Value)
            {
                current.Right = _insert(current.Right, n);
                current = balance_tree(current);
            }
            return current;
        }
        private AVLBinaryTreeNode balance_tree(AVLBinaryTreeNode current)
        {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        public void Remove(int target)
        {
            root = _remove(root, target);
        }
        private AVLBinaryTreeNode _remove(AVLBinaryTreeNode current, int target)
        {
            AVLBinaryTreeNode parent;
            if (current == null)
            { return null; }
            else
            {
                
                if (target < current.Value)
                {
                    current.Left = _remove(current.Left, target);
                    if (balance_factor(current) == -2)
                    {
                        if (balance_factor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                
                else if (target > current.Value)
                {
                    current.Right = _remove(current.Right, target);
                    if (balance_factor(current) == 2)
                    {
                        if (balance_factor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                
                else
                {
                    if (current.Right != null)
                    {
                        
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Value = parent.Value;
                        current.Right = _remove(current.Right, parent.Value);
                        if (balance_factor(current) == 2)
                        {
                            if (balance_factor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {   
                        return current.Left;
                    }
                }
            }
            return current;
        }
        public AVLBinaryTreeNode? Search(int value)
        {
            return _search(value, root);

            
        }
        private AVLBinaryTreeNode? _search(int value, AVLBinaryTreeNode current)
        {
            if (current == null)
                return null;

            if (value < current.Value)
            {
                /*if (value == current.Value)
                {
                    return current;
                }
                else*/
                    return _search(value, current.Left);
            }
            else
            {
                if (value == current.Value)
                {
                    return current;
                }
                else
                    return _search(value, current.Right);
            }

        }
        public void GoAroundInDepth()
        {
            _goAroundInDepth(root);
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
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int getHeight(AVLBinaryTreeNode current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.Left);
                int r = getHeight(current.Right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int balance_factor(AVLBinaryTreeNode current)
        {
            int l = getHeight(current.Left);
            int r = getHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }
        private AVLBinaryTreeNode RotateRR(AVLBinaryTreeNode parent)
        {
            AVLBinaryTreeNode pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private AVLBinaryTreeNode RotateLL(AVLBinaryTreeNode parent)
        {
            AVLBinaryTreeNode pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private AVLBinaryTreeNode RotateLR(AVLBinaryTreeNode parent)
        {
            AVLBinaryTreeNode pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private AVLBinaryTreeNode RotateRL(AVLBinaryTreeNode parent)
        {
            AVLBinaryTreeNode pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}