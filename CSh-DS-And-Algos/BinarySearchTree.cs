using System;

namespace CSh_DS_And_Algos
{
    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
    {
        public BinarySearchTree(TreeNode<T> root) : base(root) {}

        public static bool IsBinarySearchTree(BinaryTree<T> tree, T minDataValue, T maxDataValue)
        {
            return IsBinarySearchTreeHelper(tree.Root, minDataValue, maxDataValue);
        }

        private static bool IsBinarySearchTreeHelper(TreeNode<T> root, T min, T max)
        {
            if (root == null)
            {
                return true;
            }

            if (root.Data.CompareTo(max) >= 0 || root.Data.CompareTo(min) <= 0)
            {
                return false;
            }

            return IsBinarySearchTreeHelper(root.Right, root.Data, max) && IsBinarySearchTreeHelper(root.Left, min, root.Data);
        }
    }
}