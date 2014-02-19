using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BinarySearchTreeTests
{
    public class BinarySearchTree
    {
        public class TreeNode
        {
            public int Element { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

            public TreeNode(int element)
            {
                this.Element = element;
            }

            public override string ToString()
            {
                string nodeString = "[" + this.Element + " ";

                // Leaf node
                if (this.Left == null && this.Right == null)
                {
                    nodeString += " (Leaf) ";
                }

                if (this.Left != null)
                {
                    nodeString += "Left: " + this.Left.ToString();
                }

                if (this.Right != null)
                {
                    nodeString += "Right: " + this.Right.ToString();
                }

                nodeString += "] ";

                return nodeString;
            }
        }
        public TreeNode Root { get; set; }
        private bool deleted;
        public int? DeletedNumber { get; set; }
        public BinarySearchTree()
        {
            this.Root = null;
        }

        public void Insert(int x)
        {
            this.Root = Insert(x, this.Root);
            
        }

        public bool Remove(int x, int k)
        {
            this.Root = Remove(x, k, this.Root);
            if(!deleted)
            {
                return false;
            }
            deleted = false;
            return true;
        }

        public void RemoveMin()
        {
            this.Root = RemoveMin(this.Root);
        }

        public int FindMin()
        {
            return ElementAt(FindMin(this.Root));
        }

        public int FindMax()
        {
            return ElementAt(FindMax(this.Root));
        }

        public int Find(int x)
        {
            return ElementAt(Find(x, this.Root));
        }

        public void MakeEmpty()
        {
            this.Root = null;
        }

        public bool IsEmpty()
        {
            return this.Root == null;
        }

        private int ElementAt(TreeNode t)
        {
            return t == null ? default(int) : t.Element;
        }

        private TreeNode Find(int x, TreeNode t)
        {
            while (t != null)
            {
                if ((x as IComparable).CompareTo(t.Element) < 0)
                {
                    t = t.Left;
                }
                else if ((x as IComparable).CompareTo(t.Element) > 0)
                {
                    t = t.Right;
                }
                else
                {
                    return t;
                }
            }

            return null;
        }

        private TreeNode FindMin(TreeNode t)
        {
            if (t != null)
            {
                while (t.Left != null)
                {
                    t = t.Left;
                }
            }

            return t;
        }

        private TreeNode FindMax(TreeNode t)
        {
            if (t != null)
            {
                while (t.Right != null)
                {
                    t = t.Right;
                }
            }

            return t;
        }

        protected TreeNode Insert(int x, TreeNode t)
        {
            if (t == null)
            {
                t = new TreeNode(x);
            }
            else if ((x as IComparable).CompareTo(t.Element) <= 0)
            {
                t.Left = Insert(x, t.Left);
            }
            else if ((x as IComparable).CompareTo(t.Element) > 0)
            {
                t.Right = Insert(x, t.Right);
            }
            else
            {
                throw new Exception("Duplicate item");
            }

            return t;
        }

        protected TreeNode RemoveMin(TreeNode t)
        {
            if (t == null)
            {
                throw new Exception("Item not found");
            }
            else if (t.Left != null)
            {
                t.Left = RemoveMin(t.Left);
                return t;
            }
            else
            {
                return t.Right;
            }
        }

        protected TreeNode Remove(int x, int k, TreeNode t)
        {
            if (t == null)
            {
                return t;
            }
            else if ((x + t.Element).CompareTo(k) > 0)
            {
                if (t.Left != null)
                    t.Left = Remove(x, k, t.Left);
                else
                {
                    if ((x + t.Element).CompareTo(k) > 0)
                        RemoveNode(ref t);
                }
            }
            else if ((x + t.Element).CompareTo(k) < 0)
            {
                if(t.Right !=null)
                    t.Right = Remove(x, k, t.Right);
                else
                {
                    if ((x + t.Element).CompareTo(k) > 0)
                        RemoveNode(ref t);
                }
            }
            else
            {
                RemoveNode(ref t);
            }
            if (t != null)
            {
                if ((x + t.Element).CompareTo(k) >= 0)
                {
                    var b = false;
                    if (t.Left != null)
                    {
                        if ((x + t.Left.Element).CompareTo(k) < 0)
                        {
                            b = true;
                        }
                    }
                    else if (t.Right != null)
                    {
                        if ((x + t.Right.Element).CompareTo(k) < 0)
                        {
                            b = true;
                        }
                    }
                    if (b)
                    {
                        RemoveNode(ref t);
                    }

                }
            }
            return t;
        }
        private void RemoveNode(ref TreeNode t)
        {
            if (!deleted)
            {
                if (t.Left != null && t.Right != null)
                {
                    t.Element = FindMin(t.Right).Element;
                    t.Right = RemoveMin(t.Right);
                }
                else
                {
                    if (t.Left == null && t.Right == null)
                    {
                        deleted = true;
                        DeletedNumber = t.Element;
                    }

                    t = (t.Left != null) ? t.Left : t.Right;
                }
                if (t != null)
                {
                    deleted = true;
                    DeletedNumber = t.Element;
                }
            }
        }
        public override string ToString()
        {
            return this.Root.ToString();
        }
    }
}
