using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree t = new BinarySearchTree();
            t.Add(2);
            t.Add(7);
            t.Add(9);
            t.Add(10);
            t.Add(1);
            t.Add(5);
            t.Add(16);
            t.Add(19);
            t.Add(8);
            t.Add(4);

            t.TraverseInOrder();
            Console.WriteLine();
            t.ToString();
        }
    }

class BinarySearchTree
{
    private BinaryTreeNode head;
    private int size;
    //private int depth;
    ///
    /// Constructor ‐ Creates a new instance of a Binary Tree
    ///
    public BinarySearchTree()
    {
        head = null;
        size = 0;
    }
    ///
    /// Gets or sets the root of the tree (the top‐most node)
    ///
    public BinaryTreeNode Root
    {
        get { return head; }
        set { head = value; }
    }
    ///
    /// Gets the number of elements stored in the tree
    ///
    public int Count
    {
        get { return size; }
    }
    ///
    /// Adds a new element to the tree
    ///
    public void Add(Int32 value)
    {
        BinaryTreeNode node = new BinaryTreeNode(value);
        this.Add(node);
    }
    ///
    /// Adds a node to the tree
    ///
    public void Add(BinaryTreeNode node) //Do I need to invoke the balance method for this?
    {
        if (this.head == null) //'this' is the tree, check if empty
        {
            this.head = node; //set node as root of the tree
            //node.Parent = this.head; //its parent points to itself
            size++;
        }
           
        else
        {
            if (node.Parent == null)
                node.Parent = head; //start at head
            //Node is inserted on the left side if it is smaller or equal to the parent
            bool insertLeftSide = false;
            if (node.Value < node.Parent.Value)
            {
                insertLeftSide = true;
            }
            if (insertLeftSide) //insert on the left
            {
                if (node.Parent.LeftChild == null)
                {
                    node.Parent.LeftChild = node; //insert in left
                    size++;
                }
                else
                {
                    node.Parent = node.Parent.LeftChild; //scan down to left child
                    this.Add(node); //recursive call
                }
            }
            else //insert on the right
            {
                if (node.Parent.RightChild == null)
                {
                    node.Parent.RightChild = node; //insert in right
                    size++;
                }
                else
                {
                    node.Parent = node.Parent.RightChild;
                    this.Add(node);
                }
            }
        }
    }
    ///
    /// Returns the first node in the tree with the parameter value.
    ///
    public BinaryTreeNode Find(Int32 value)
    {
        BinaryTreeNode node = this.head; //start at head
        while (node != null)
        {
            if (node.Value.Equals(value)) //parameter value found
                return node;
            else
            {
                //Search left if the value is smaller than the current node
                bool searchLeft = false;
                if (node.Value > value)
                {
                    searchLeft = true;
                }
                if (searchLeft)
                    node = node.LeftChild; //search left
                else
                    node = node.RightChild; //search right
            }
        }
        return null; //not found
    }
    ///
    /// Removes a value from the tree and returns whether the removal was successful.
    ///
    public bool Remove(Int32 value)
    {
    BinaryTreeNode removeNode = Find(value);
    return this.Remove(removeNode);
    }
    ///
    /// Removes a node from the tree and returns whether the removal was successful.
    ///>
    ///
    public bool Remove(BinaryTreeNode removeNode)
    {
        if (removeNode == null)
            return false; //value doesn't exist or not of this tree
        //Note whether the node to be removed is the root of the tree
        bool wasHead = (removeNode == head);
        if (this.Count == 1)
        {
            this.head = null; //only element was the root
            size--; //decrease total element count
        }
        else if (removeNode.IsLeaf) //Case 1: No Children
        {
            //Remove node from its parent
            if (removeNode.IsLeftChild)
            {
                removeNode.Parent.LeftChild = null;
            }
            else
            {
                removeNode.Parent.RightChild = null;
            }
            removeNode.Parent = null;
            size--; //decrease total element count
        }
        else if (removeNode.ChildCount == 1) //Case 2: One Child
        {
            if (removeNode.HasLeftChild)
            {
                //Put left child node in place of the node to be removed
                removeNode.LeftChild.Parent = removeNode.Parent; //update parent
                if (wasHead)
                {
                    this.Root = removeNode.LeftChild; //update root reference if needed
                }
                if (removeNode.IsLeftChild) //update the parent's child reference
                {
                    removeNode.Parent.LeftChild = removeNode.LeftChild;
                }
                else
                {
                    removeNode.Parent.RightChild = removeNode.LeftChild;
                }
            }
            else //Has right child
            {
                //Put left node in place of the node to be removed
                removeNode.RightChild.Parent = removeNode.Parent; //update parent
                if (wasHead)
                {
                    this.Root = removeNode.RightChild; //update root reference if needed
                }
                if (removeNode.IsLeftChild) //update the parent's child reference
                {
                    removeNode.Parent.LeftChild = removeNode.RightChild;
                }
                else
                {
                    removeNode.Parent.RightChild = removeNode.RightChild;
                }
            }
            removeNode.Parent = null;
            removeNode.LeftChild = null;
            removeNode.RightChild = null;
            size--; //decrease total element count
        }
        else //Case 3: Two Children
        {
            //Find inorder predecessor (right‐most node in left subtree)
            BinaryTreeNode successorNode = removeNode.LeftChild;
            while (successorNode.RightChild != null)
            {
                successorNode = successorNode.RightChild;
            }
            removeNode.Value = successorNode.Value; //replace value
            this.Remove(successorNode); //recursively remove the inorder predecessor
        }
        return true;
    }
    //-----------------------------------
    // balancing the binary tree
    // after the tree has been built
    //
    // WARNING! This code has not been checked...
    // and you may need to change it
    // depending on your tree design
    //------------------------------------
    public void balance(BinaryTreeNode node)
    {
        if (node == null)
        {

        }
        if (node != null)
        {
            BinarySearchTree tree = new BinarySearchTree();
            
            if (node.RightChild.level - node.LeftChild.level > 1)
            {
                if (node.RightChild.level > node.LeftChild.level)
                {
                    node = rotateL(node);
                    node = rotateR(node);
                }
                else
                {
                    node = rotateL(node);
                }
            }
            else
            {
                if (node.LeftChild.level > node.RightChild.level)
                {
                    node = rotateR(node);
                    node = rotateL(node);
                }
                else
                {
                    node = rotateR(node);
                }
            }
            balance(node.LeftChild);
            balance(node.RightChild);
        }
    }
    // depth from node to left
    public int heightL(BinaryTreeNode node)
    {
        if (node == null)
            return 0;
        return node.LeftChild.level + 1;
    }
    // depth from node from the right
    public int heightR(BinaryTreeNode node)
    {
        if (node == null)
            return 0;
        return node.RightChild.level + 1;
    }
    // left rotation around node
    public BinaryTreeNode rotateL(BinaryTreeNode node)
    {
        if (node == null)
            return null;
        else
        {
            BinaryTreeNode newRoot = node.RightChild;
            node.RightChild = newRoot.leftChild;
            newRoot.leftChild = node;
            return newRoot;
        }
    }
    // right rotation around node
    public BinaryTreeNode rotateR(BinaryTreeNode node)
    {
        if (node == null)
            return null;
        else
        {
            BinaryTreeNode newRoot = node.LeftChild;
            node.LeftChild = newRoot.RightChild;
            newRoot.RightChild = node;
            return newRoot;
        }
    }
    //-------------------------------------
    // TraverseInOrder
    // Traverses the tree in this order:
    // Left, Root, Right
    // Calls the private function InOrder
    //-------------------------------------
    public void TraverseInOrder()
    {
        InOrder(ref head);
    }
    private void InOrder(ref BinaryTreeNode node)
    {
        balance(node); //Where I was attempting to balance before traversing which I think is what throws the error.
        if (node == null)
            return;
        if (node.LeftChild != null)
        {
            InOrder(ref node.leftChild);
        }
        Console.WriteLine(node.value);
        if (node.RightChild != null)
        {
            InOrder(ref node.rightChild);
        }
    }

    public override string ToString()
    {
        InOrder(ref head);
        return null;
    }
    public void TraversePreOrder()
    {
        PreOrder(ref head);
    }
    private void PreOrder(ref BinaryTreeNode node)
    {
        if (node == null)
            return;
        Console.WriteLine(node.value);
        if (node.LeftChild != null)
        {
            InOrder(ref node.leftChild);
        }
        if (node.RightChild != null)
        {
            InOrder(ref node.rightChild);
        }
    }
    //-------------------------------------
    // TraversePostOrder
    // Traverses the tree in this order:
    // Left, Right, Root
    //-------------------------------------
    public void TraversePostOrder()
    {
        PostOrder(ref head);
    }
    private void PostOrder(ref BinaryTreeNode node)
    {
        if (node == null)
            return;
        if (node.LeftChild != null)
        {
            InOrder(ref node.leftChild);
        }
        if (node.RightChild != null)
        {
            InOrder(ref node.rightChild);
        }
        Console.WriteLine(node.value);
    }
}

    ///
    /// A Binary Tree node that holds an element and references to other tree nodes
    ///
    /// Binary Tree Node class
    class BinaryTreeNode
    {
        public Int32 value;
        internal int level;
        public BinaryTreeNode leftChild;
        public BinaryTreeNode rightChild;
        public BinaryTreeNode parent;
      
        ///
        /// Creates a new instance of an empty node
        ///
        public BinaryTreeNode()
        {
            this.level = 0;
            this.parent = null;
            this.leftChild = null;
            this.rightChild = null;
            //deleted = null;
        }
        ///
        /// Create a new instance of a Binary Tree node
        ///
        public BinaryTreeNode(Int32 value)
        {
            this.level = 1;
            this.value = value;
            this.parent = null;
            this.leftChild = null;
            this.rightChild = null;
        }
        ///
        /// The value stored at the node
        ///
        public Int32 Value
        {
            get { return value; }
            set { this.value = value; }
        }
        ///
        /// Gets or sets the left child node
        ///
        public BinaryTreeNode LeftChild
        {
            get { return leftChild; }
            set { leftChild = value; }
        }
        ///
        /// Gets or sets the right child node
        ///
        public BinaryTreeNode RightChild
        {
            get { return rightChild; }
            set { rightChild = value; }
        }
        ///
        /// Gets or sets the parent node
        ///
        public BinaryTreeNode Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        ///
        /// Gets whether the node is a leaf (has no children)
        ///
        public bool IsLeaf
        {
            get { return this.ChildCount == 0; }
        }
        ///
        /// Gets whether the node is internal (has children nodes)
        ///
        public bool IsInternal
        {
            get { return this.ChildCount > 0; }
        }
        ///
        /// Gets whether the node is the left child of its parent
        ///
        public virtual bool IsLeftChild
        {
            get { return this.Parent != null && this.Parent.LeftChild == this; }
        }
        ///
        /// Gets whether the node is the right child of its parent
        ///
        public virtual bool IsRightChild
        {
            get { return this.Parent != null && this.Parent.RightChild == this; }
        }
        ///
        /// Gets the number of children this node has
        ///
        public int ChildCount
        {
            get
            {
                int count = 0;
                if (this.LeftChild != null)
                    count++;
                if (this.RightChild != null)
                    count++;
                return count;
            }
        }
        ///
        /// Gets whether the current node has a left child node
        ///
        public bool HasLeftChild
        {
            get { return (this.LeftChild != null); }
        }
        ///
        /// Gets whether the current node has a right child node
        ///
        public bool HasRightChild
        {
            get { return (this.RightChild != null); }
        }
    }

}
