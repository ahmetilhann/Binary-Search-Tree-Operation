using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeOperation
{
    class BSTOperation
    {
        public TNode root;

        public BSTOperation()
        {
            root = null;
        }

        public void Insert(int i)
        {
            TNode newNode = new TNode() { data = i };
            if (root == null)
                root = newNode;
            else
            {
                TNode current = root;
                TNode parent;
                while (true)
                {
                    parent = current;
                    if (i < current.data)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public void InOrder() { InOrder(root); }
        public void InOrder(TNode theRoot)
        {
            if (theRoot != null)
            {
                InOrder(theRoot.left);
                theRoot.DisplayNode();
                InOrder(theRoot.right);
            }
        }

        public void PostOrder() { PostOrder(root); }
        public void PostOrder(TNode theRoot)
        {
            if (!(theRoot==null))
            {
                PostOrder(theRoot.left);
                PostOrder(theRoot.right);
                theRoot.DisplayNode();
            }
        }

        public void PreOrder() { PreOrder(root); }
        public void PreOrder(TNode theRoot)
        {
            if (!(theRoot == null))
            {
                theRoot.DisplayNode();
                PreOrder(theRoot.left);
                PreOrder(theRoot.right);
            }
        }

        public int FindMin()
        {
            TNode current = root;
            while (current.left != null)
                current = current.left;
            return current.data;
        }

        public int FindMax()
        {
            TNode current = root;
            while (current.right != null)
                current = current.right;
            return current.data;
        }

        public TNode Find(int key)
        {
            TNode current = root;
            while (current.data != key)
            {
                if (key < current.data)
                    current = current.left;
                else
                    current = current.right;
                if (current == null)
                    return null;
            }
            return current;
        }

        public bool Delete(int key)
        {
            TNode current = root;
            TNode parent = root;
            bool isLeftChild = true;
            while (current.data != key)
            {
                parent = current;
                if (key < current.data)
                {
                    isLeftChild = true;
                    current = current.left;
                }
                else
                {
                    isLeftChild = false;
                    current = current.right;
                }
                if (current == null)
                    return false;
            }

            if ((current.left == null) && (current.right == null))
            {
                if (current == root)
                    root = null;
                else if (isLeftChild)
                    parent.left = null;
                else
                    parent.right = null;
            }
            else if (current.right == null)
            {
                if (current == root)
                    root = current.left;
                else if (isLeftChild)
                    parent.left = current.left;
                else
                    parent.right = current.left;
            }
            else if (current.left == null)
            {
                if (current == root)
                    root = current.right;
                else if (isLeftChild)
                    parent.left = current.right;
                else
                    parent.right = current.right;
            }
            else
            {
                TNode successor = GetSuccessor(current);
                if (current == root)
                    root = successor;
                else if (isLeftChild)
                {
                    parent.left = successor;
                    successor.right = current.right;
                }
                else
                {
                    parent.right = successor;
                    successor.right = current.right;

                } 
                successor.left = current.left;
                
            }
            return true;
        }

        //Aranan degerden buyuklerin en kucugunu hesaplar
        //Hesapladıgi degeri geri dondererek agactan siler
        public TNode GetSuccessor(TNode delNode)
        {
            TNode successor = delNode.right;
            TNode successorParent = delNode;

            while (successor.left != null)
            {
                successorParent = successor;
                successor = successor.left;
            }
            if (successor != delNode.right)
            {
                successorParent.left = successor.right;
            }
            return successor;  
        }
    }
}
