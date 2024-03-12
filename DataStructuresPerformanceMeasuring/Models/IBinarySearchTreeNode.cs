using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPerformanceMeasuring.Models
{
    public class IBinarySearchTreeNode
    {
        public int Value;

        public IBinarySearchTreeNode? Left;

        public IBinarySearchTreeNode? Right;

        public int Height;
    }
}
