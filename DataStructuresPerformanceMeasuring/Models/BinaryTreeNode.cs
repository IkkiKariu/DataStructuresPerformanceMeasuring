using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataStructuresPerformanceMeasuring.Models
{
    public class BinaryTreeNode //: IBinarySearchTreeNode
    {
        public int? Value;

        public BinaryTreeNode? Left;
        public BinaryTreeNode? Right;

        public BinaryTreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

    }
}
