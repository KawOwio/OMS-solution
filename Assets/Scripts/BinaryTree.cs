using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree : MonoBehaviour
{
    public class Node
    {
        public Node leftNode { get; set; }
        public Node rightNode { get; set; }
        public int data { get; set; }
    }

    public Node root { get; set; }

    public void Add (int value)
    {
        Node before = null;
        Node after = this.root;

        while (after != null)
        {
            before = after;
            if (value < after.data) // If new node is on left
            {
                after = after.leftNode;
            }
            else if (value > after.data) // If new node is on right
            {
                after = after.rightNode;
            }
            else
            {
                return;
            }
        }

        Node newNode = new Node();
        newNode.data = value;

        // If tree is empty
        if (this.root == null)
        {
            this.root = newNode;
        }
        else
        {
            if (value < before.data)
            {
                before.leftNode = newNode;
            }
            else
            {
                before.rightNode = newNode;
            }
        }

        // return true;
    }

    public Node Find (int value)
    {
        return this.Find(value, this.root);
    }

    private Node Find(int value, Node parent)
    {
        if (parent != null)
        {
            if (value == parent.data)
            {
                return parent;
            }
            if (value < parent.data)
            {
                return Find(value, parent.leftNode);
            }
            else
            {
                return Find(value, parent.rightNode);
            }
        }

        return null;
    }

    public Node Remove (int value)
    {
        return this.Remove(value, this.root);
    }

    private Node Remove(int key, Node parent)
    {
        if (parent == null)
        {
            return parent;
        }

        if (key < parent.data)
        {
            parent.leftNode = Remove(key, parent.leftNode);
        }
        else if (key > parent.data)
        {
            parent.rightNode = Remove(key, parent.rightNode);
        }
        // if value is same as parent's value, then this is the node to be deleted  
        else
        {
            // node with only one child or no child  
            if (parent.leftNode == null)
            {
                return parent.rightNode;
            }
            else if (parent.rightNode == null)
            {
                return parent.leftNode;
            }

            // node with two children: Get the inorder successor (smallest in the right subtree)  
            parent.data = MinValue(parent.rightNode);

            // Delete the inorder successor  
            parent.rightNode = Remove(parent.data, parent.rightNode);
        }

        return parent;
    }

    private int MinValue(Node node)
    {
        int minv = node.data;

        while (node.leftNode != null)
        {
            minv = node.leftNode.data;
            node = node.leftNode;
        }

        return minv;
    }

    public int GetTreeDepth()
    {
        return this.GetTreeDepth(this.root);
    }

    private int GetTreeDepth(Node parent)
    {
        if (parent == null)
        {
            return 0;
        }
        else
        {
            return Math.Max(GetTreeDepth(parent.leftNode), GetTreeDepth(parent.rightNode)) + 1;
        }
    }

    public void TraversePreOrder(Node parent)
    {
        if (parent != null)
        {
            Debug.Log(parent.data + " ");
            TraversePreOrder(parent.leftNode);
            TraversePreOrder(parent.rightNode);
        }
    }

    public void TraverseInOrder(Node parent)
    {
        if (parent != null)
        {
            TraverseInOrder(parent.leftNode);
            Debug.Log(parent.data + " ");
            TraverseInOrder(parent.rightNode);
        }
    }

    public void TraversePostOrder(Node parent)
    {
        if (parent != null)
        {
            TraversePostOrder(parent.leftNode);
            TraversePostOrder(parent.rightNode);
            Debug.Log(parent.data + " ");
        }
    }
}
