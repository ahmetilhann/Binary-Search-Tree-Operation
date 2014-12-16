using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeOperation
{
    class TNode
    {
        public int data { get; set; }
        public TNode right { get; set; }
        public TNode left { get; set; }

        public void DisplayNode()
        {
            Console.WriteLine(data + " ");
        } 
    }
}
