using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPerformanceMeasuring.Models
{
    public interface IBinarySearchTree
    {
        public void Insert(int value);

        public IBinarySearchTreeNode Search(int value);

        public void Remove(int value);

        public void GoAroundInDepth();
    }
}
