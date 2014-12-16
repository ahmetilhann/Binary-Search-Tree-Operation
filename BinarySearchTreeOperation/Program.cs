using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeOperation
{
    class Program
    {
        static void Main(string[] args)
        {

            AVLOperation avl = new AVLOperation();
            avl.Insert(10);
            avl.Insert(5);
            avl.Insert(15);
            avl.Insert(3);
            avl.Insert(8);
            avl.Insert(7);
            avl.Inorder();


            
        }
    }
}
