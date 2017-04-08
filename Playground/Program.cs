using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    /***********/
    /* BSTNode */
    /***********/
    public class BSTNode
    {
        private int _value;
        private BSTNode _parent;
        private BSTNode _left;
        private BSTNode _right;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public BSTNode Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public BSTNode LeftChild
        {
            get { return _left; }
            set { _left = value; }
        }

        public BSTNode RightChild
        {
            get { return _right; }
            set { _right = value; }
        }

        public BSTNode()
            : this(0, null, null, null)
        {}

        public BSTNode(int item)
            : this(item, null, null, null)
        { }

        public BSTNode(int value, BSTNode parent, BSTNode left, BSTNode right)
        {
            _value = value;
            _parent = parent;
            _left = left;
            _right = right;
        }

        public virtual bool HasLeftChild
        {
            get { return _left != null; }
        }

        public virtual bool HasRightChild
        {
            get { return _right != null; }
        }

        public virtual bool IsLeftChild
        {
            get { return Parent != null && Parent.LeftChild == this; }
        }

        public virtual bool IsRightChild
        {
            get { return Parent != null && Parent.RightChild == this; }
        }

        public virtual bool IsLeafNode
        {
            get { return TotalChildren == 0; }
        }

        public virtual bool HasChildren
        {
            get { return TotalChildren > 0; }
            //get { return HasLeftChild || HasRightChild; }
        }

        public virtual int TotalChildren
        {
            get
            {
                int count = 0;
                if (HasLeftChild)
                    ++count;
                if (HasRightChild)
                    ++count;

                return count;
            }
        }

        public virtual int CompareTo(BSTNode node)
        {
            if (node == null)
                return -1;

            return this.Value.CompareTo(node.Value);
        }
    }
    
    /*******/
    /* BST */
    /*******/

    public class BST
    {
        public int _count { get; set; }
        public BSTNode _root { get; set; }
        public BSTNode Root
        {
            get { return _root; }
            set { _root = value; }
        }

        public BST()
        {
            _count = 0;
            Root = null;
        }

        // used during recursive remove
        public void _replaceNodeInParent(BSTNode node, BSTNode newNode = null)
        {
            if(node.Parent != null)
            {
                if (node.IsLeftChild)
                    node.Parent.LeftChild = newNode;
                if (node.IsRightChild)
                    node.Parent.RightChild = newNode;
            }

            if(newNode != null)
            {
                newNode.Parent = node.Parent; // but a parent can't be null..?
            }
        }

        public bool _remove(BSTNode node)
        {
            // can't remove a node that doesn't exist
            if (node == null)
                return false;

            BSTNode parent = node.Parent;

            if(node.TotalChildren == 2) // when both children are present
            {
                BSTNode _rightChild = node.RightChild;
                node.Value = _rightChild.Value;
                return (true && _remove(_rightChild));
            }
            else if(node.HasLeftChild) // node only has left child
            {
                _replaceNodeInParent(node, node.LeftChild);
                --_count;
            }
            else if(node.HasRightChild) // node only has right child
            {
                _replaceNodeInParent(node, node.RightChild);
                --_count;
            }
            else // node has no children
            {
                _replaceNodeInParent(node, null);
                --_count;
            }

            return true;
        }

        public bool _insertNode(BSTNode newNode)
        {
            if (Root == null)
            {
                Root = newNode;
                ++_count;
                return true;
            }
            else
            {
                if (newNode.Parent == null) // node should be adopted temporarily.
                    newNode.Parent = Root;

                // By default, duplicates are not allowed in my tree.
                //
                if (newNode.Value == newNode.Parent.Value)
                    return false;

                if (newNode.Parent.Value > newNode.Value) // node goes to the left
                {
                    if (!newNode.Parent.HasLeftChild) // i guess I can adopt you.
                    {
                        newNode.Parent.LeftChild = newNode; // the node writes on his adoption parents that he's the left child of the parent.
                        ++_count;
                        return true;
                    }
                    else
                    {
                        newNode.Parent = newNode.Parent.LeftChild; // uh, my left child can be your parent.
                        return _insertNode(newNode); // verify acceptance or continue being passed down the family tree.
                    }
                }
                else
                {
                    if(!newNode.Parent.HasRightChild)
                    {
                        newNode.Parent.RightChild = newNode;
                        ++_count;
                        return true;
                    }
                    else
                    {
                        newNode.Parent = newNode.Parent.RightChild;
                        return _insertNode(newNode);
                    }
                }
            }           
        } // _insertNode function

        public int _getTreeHeight(BSTNode node)
        {
            if (node == null)
                return 0;
            else if (node.IsLeafNode) // the node is the last and only node.
                return 1;
            else if (node.TotalChildren == 2)
                return (1 + Math.Max(_getTreeHeight(node.LeftChild), _getTreeHeight(node.RightChild)));
            else if (node.HasLeftChild)
                return (1 + _getTreeHeight(node.LeftChild));
            else 
                return 1 + _getTreeHeight(node.RightChild);
        }

        public BSTNode _findNode(BSTNode currentNode, int item)
        {
            if (currentNode == null)
                return currentNode;

            if (item == currentNode.Value)
                return currentNode;
            else if (item < currentNode.Value && currentNode.HasLeftChild)
                return _findNode(currentNode.LeftChild, item);
            else if (item > currentNode.Value && currentNode.HasRightChild)
                return _findNode(currentNode.RightChild, item);

            return null; // this should be fixed.
        }

        public BSTNode _findMinNode(BSTNode node)
        {
            if (node == null)
                return null;

            BSTNode currentNode = node;

            while (currentNode.HasLeftChild)
                currentNode = currentNode.LeftChild;

            return currentNode;
        }

        public BSTNode _findMaxNode(BSTNode node)
        {
            if (node == null)
                return null;

            BSTNode currentNode = node;
            while (currentNode.HasRightChild)
                currentNode = currentNode.RightChild;

            return currentNode;
        }

        public BSTNode _findNextSmaller(BSTNode node)
        {
            if (node == null)
                return null;

            if (node.HasLeftChild)
                return _findMaxNode(node.LeftChild);

            BSTNode currentNode = node;
            while (currentNode.Parent != null && currentNode.IsLeftChild)
                currentNode = currentNode.Parent;

            return currentNode.Parent;
        }

        public BSTNode _findNextLarger(BSTNode node)
        {
            if (node == null)
                return null;

            if (node.HasRightChild)
                return _findMinNode(node.RightChild);

            BSTNode currentNode = node;
            while (currentNode.Parent != null && currentNode.IsRightChild) // I don't think this is right.. should be isLeftChild
                currentNode = currentNode.Parent;

            return currentNode.Parent;
        }



        public void Insert(int item)
        {
            BSTNode newNode = new BSTNode(item);

            bool success = _insertNode(newNode);

            if (success == false)
                Console.WriteLine("Inserting node was not successful");
        }

        public void Clear()
        {
            Root = null;
            _count = 0;
        }

        public bool Contains(int item)
        {
            return _findNode(_root, item) != null;
        }


    }

    public class Program
    {
        static void Main(string[] args)
        {
            //GridLandMetro.GridLandMetro.Run();
            //SimilarPair.SimilarPair similarPairProgram = new SimilarPair.SimilarPair();
            //similarPairProgram.Run();

            DijkstraShortestReach.DijkstraShortestReach dijShortestReachProgram = new DijkstraShortestReach.DijkstraShortestReach();
            dijShortestReachProgram.Run();

        }
    }
}
