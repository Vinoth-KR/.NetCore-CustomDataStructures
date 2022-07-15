using System;
using System.Collections.Generic;

namespace CustomBinaryTree
{ 
    public class BinaryTree<T>
    {
        private TreeNode<T> _root;

        public BinaryTree()
        {
            _root = null;
        }

        public TreeNode<T> Root { get => _root; }

        public TreeNode<T> AddRootNode(TreeNode<T> node)
        {
            if (_root == null) _root = node;
            else throw new InvalidOperationException("Root Node already exists !");

            return _root;
        }

        public TreeNode<T> AddRootNode(T value, TreeNode<T> left = null, TreeNode<T> right = null)
        {
            if (_root == null) _root = new TreeNode<T>(value, left, right);
            else throw new InvalidOperationException("Root Node already exists !");

            return _root;
        }

        public void Clear()
        {
            _root = null;
        }

        public bool IsSymmetric()
        {
            return IsMirror(_root, _root);
        }

        private bool IsMirror<T>(TreeNode<T> node1, TreeNode<T> node2)
        {
            if (node1 == null && node2 == null) return true;
            if (node1 == null || node2 == null) return false;
            return node1.Value.Equals(node2.Value) && IsMirror(node1.Right, node2.Left) && IsMirror(node1.Left, node2.Right);
        }
        
    }

    public class TreeNode<T>
    {
        public TreeNode(T value, TreeNode<T> left = null, TreeNode<T> right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        public T Value { get; set; }

        public TreeNode <T> Left { get; set; }

        public TreeNode<T> Right { get; set; }
    }

    public enum NodePosition
    {
        Left,
        Right
    }

    public static class BinaryTreeExtensions
    {
        public static void AddNode<T>(this TreeNode<T> node, T value, NodePosition pos, TreeNode<T> left = null, TreeNode<T> right = null)
        {            
            var newNode = new TreeNode<T>(value, left, right);
            switch (pos)
            {
                case NodePosition.Left: node.Left = newNode;
                    break;
                case NodePosition.Right: node.Right = newNode;
                    break;
                default: break;
            }
        }
    }
}
