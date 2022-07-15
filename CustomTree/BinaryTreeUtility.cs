using System;
using System.Collections.Generic;
using System.Text;

namespace CustomBinaryTree
{
    public static class BinaryTreeUtility
    {
        static List<string> _traversalList = new List<string>();

        public static List<string> TraverseTreePreOrder<T>(TreeNode<T> node)
        {
            _traversalList.Clear();
            TraverseTreePreOrder(node, 0);
            return _traversalList;
        }

        private static void TraverseTreePreOrder<T>(TreeNode<T> node, int level)
        {            
            if (node == null) return;

            string separator = new string('-', level);
            _traversalList.Add($"{separator}{node.Value} : Level {level}");

            TraverseTreePreOrder(node.Left, level + 1);
            TraverseTreePreOrder(node.Right, level + 1);
        }

        public static List<string> TraverseTreeInOrder<T>(TreeNode<T> node)
        {
            _traversalList.Clear();
            TraverseTreeInOrder(node, 0);
            return _traversalList;
        }

        private static void TraverseTreeInOrder<T>(TreeNode<T> node, int level)
        {
            if (node == null) return;

            TraverseTreeInOrder(node.Left, level + 1);

            string separator = new string('-', level);
            _traversalList.Add($"{separator}{node.Value} : Level {level}");

            TraverseTreeInOrder(node.Right, level + 1);
        }

        public static List<string> TraverseTreePostOrder<T>(TreeNode<T> node)
        {
            _traversalList.Clear();
            TraverseTreePostOrder(node, 0);
            return _traversalList;
        }

        private static void TraverseTreePostOrder<T>(TreeNode<T> node, int level)
        {
            if (node == null) return;

            TraverseTreePostOrder(node.Left, level + 1);
            TraverseTreePostOrder(node.Right, level + 1);

            string separator = new string('-', level);
            _traversalList.Add($"{separator}{node.Value} : Level {level}");
        }
    }
}
