using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPerformanceMeasuring.Models
{
    class AVLBinaryTreeNode
    {
        public int Value;
        public AVLBinaryTreeNode Left;
        public AVLBinaryTreeNode Right;
        public AVLBinaryTreeNode(int value)
        {
            this.Value = value;
        }
    }
}
