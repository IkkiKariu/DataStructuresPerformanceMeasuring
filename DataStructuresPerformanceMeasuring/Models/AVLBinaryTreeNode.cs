using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPerformanceMeasuring.Models
{
    public class AVLBinaryTreeNode //: IBinarySearchTreeNode
    {
        public int Value;

        public AVLBinaryTreeNode Left;

        public AVLBinaryTreeNode Right;

        public int Height;


        public AVLBinaryTreeNode(int data)
        {
            Value = data;
            Height = 1;
        }
    }
}
