using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSh_DS_And_Algos.Test
{
    public class TreeTests
    {
        /// <summary>
        ///    5
        ///   / \
        ///  3   6
        /// / \   \
        ///2   4   8
        /// </summary>
        private BinaryTree<int> GetTree()
        {
            var root = new TreeNode<int>(5);
            var left = new TreeNode<int>(3);
            var right = new TreeNode<int>(6);
            var lLeft = new TreeNode<int>(2);
            var lRight = new TreeNode<int>(4);
            var rRight = new TreeNode<int>(8);

            root.Left = left;
            root.Right = right;
            left.Left = lLeft;
            left.Right = lRight;
            right.Right = rRight;

            var tree = new BinaryTree<int>(root);

            return tree;
        }

        /// <summary>
        ///    5
        ///   / \
        ///  3   6
        /// / \ 
        ///2   4
        /// </summary>
        private BinaryTree<int> GetTree2()
        {
            var root = new TreeNode<int>(5);
            var left = new TreeNode<int>(3);
            var right = new TreeNode<int>(6);
            var lLeft = new TreeNode<int>(2);
            var lRight = new TreeNode<int>(4);

            root.Left = left;
            root.Right = right;
            left.Left = lLeft;
            left.Right = lRight;

            var tree = new BinaryTree<int>(root);

            return tree;
        }

        [Fact]
        public void IsBST()
        {
            //Arrange
            var tree = GetTree();
            var tree2 = GetTree2();
            var tree3 = BinaryTree<int>.From(new int[] { 1, 2, 3, 4, 5 });

            //Act
            var isBST = BinarySearchTree<int>.IsBinarySearchTree(tree, int.MinValue, int.MaxValue);
            var isBST2 = BinarySearchTree<int>.IsBinarySearchTree(tree2, int.MinValue, int.MaxValue);
            var isBST3 = BinarySearchTree<int>.IsBinarySearchTree(tree3, int.MinValue, int.MaxValue);

            //Assert
            Assert.True(isBST);
            Assert.True(isBST2);
            Assert.False(isBST3);
        }

        [Fact]
        public void Height()
        {
            //Arrange
            var tree = GetTree();
            var tree2 = GetTree2();

            //Act
            var height = tree.Height;
            var height2 = tree2.Height;

            //Assert
            Assert.Equal(3, height);
            Assert.Equal(3, height2);
        }

        [Fact]
        public void Count()
        {
            //Arrange
            var tree = GetTree();
            var tree2 = GetTree2();

            //Act
            var count = tree.Count;
            var count2 = tree2.Count;

            //Assert
            Assert.Equal(6, count);
            Assert.Equal(5, count2);
        }

        [Fact]
        public void BuildTree()
        {
            //Arrange
            var arrayToBuildTreeFrom = new int[] { 1, 2, 3, 4, 5 };
            
            //Act
            var tree = BinaryTree<int>.From(arrayToBuildTreeFrom);
            var orderLevel = tree.OrderLevelTraversalIt();

            //Assert
            Assert.Equal(3, tree.Height);
            Assert.Equal(5, tree.Count);

            Assert.Equal(1, orderLevel[0]);
            Assert.Equal(2, orderLevel[1]);
            Assert.Equal(3, orderLevel[2]);
            Assert.Equal(4, orderLevel[3]);
            Assert.Equal(5, orderLevel[4]);
        }

        [Fact]
        public void OrderLevelInsert()
        {
            //Arrange
            var tree = new BinaryTree<int>(1);
            
            //Act
            tree.OrderLevelInsert(2);
            tree.OrderLevelInsert(3);
            tree.OrderLevelInsert(4);
            var orderLevel = tree.OrderLevelTraversalIt();

            //Assert
            Assert.Equal(3, tree.Height);
            Assert.Equal(4, tree.Count);

            Assert.Equal(1, orderLevel[0]);
            Assert.Equal(2, orderLevel[1]);
            Assert.Equal(3, orderLevel[2]);
            Assert.Equal(4, orderLevel[3]);
        }

        [Fact]
        public void OrderLevelTraversals()
        {
            //Arrange
            var tree = GetTree();

            //Act
            var orderLevel = tree.OrderLevelTraversalIt();
            var orderLevelRec = tree.OrderLevelTraversalRec();

            //Assert
            Assert.Equal(5, orderLevel[0]);
            Assert.Equal(3, orderLevel[1]);
            Assert.Equal(6, orderLevel[2]);
            Assert.Equal(2, orderLevel[3]);
            Assert.Equal(4, orderLevel[4]);
            Assert.Equal(8, orderLevel[5]);

            Assert.Equal(5, orderLevelRec[0]);
            Assert.Equal(3, orderLevelRec[1]);
            Assert.Equal(6, orderLevelRec[2]);
            Assert.Equal(2, orderLevelRec[3]);
            Assert.Equal(4, orderLevelRec[4]);
            Assert.Equal(8, orderLevelRec[5]);
        }

        [Fact]
        public void PreOrderTraversals()
        {
            //Arrange
            var tree = GetTree();

            //Act
            var preOrder = tree.PreOrderTraversalIt();
            var preOrderRec = tree.PreOrderTraversalRec();

            //Assert
            Assert.Equal(5, preOrder[0]);
            Assert.Equal(3, preOrder[1]);
            Assert.Equal(2, preOrder[2]);
            Assert.Equal(4, preOrder[3]);
            Assert.Equal(6, preOrder[4]);
            Assert.Equal(8, preOrder[5]);

            Assert.Equal(5, preOrderRec[0]);
            Assert.Equal(3, preOrderRec[1]);
            Assert.Equal(2, preOrderRec[2]);
            Assert.Equal(4, preOrderRec[3]);
            Assert.Equal(6, preOrderRec[4]);
            Assert.Equal(8, preOrderRec[5]);
        }

        [Fact]
        public void PostOrderTraversals()
        {
            //Arrange
            var tree = GetTree();

            //Act
            var postOrder = tree.PostOrderTraversalIt();
            var postOrderRec = tree.PostOrderTraversalRec();

            //Assert
            Assert.Equal(2, postOrder[0]);
            Assert.Equal(4, postOrder[1]);
            Assert.Equal(3, postOrder[2]);
            Assert.Equal(8, postOrder[3]);
            Assert.Equal(6, postOrder[4]);
            Assert.Equal(5, postOrder[5]);

            Assert.Equal(2, postOrderRec[0]);
            Assert.Equal(4, postOrderRec[1]);
            Assert.Equal(3, postOrderRec[2]);
            Assert.Equal(8, postOrderRec[3]);
            Assert.Equal(6, postOrderRec[4]);
            Assert.Equal(5, postOrderRec[5]);
        }

        [Fact]
        public void InOrderTraversals()
        {
            //Arrange
            var tree = GetTree();

            //Act
            var inOrder = tree.InOrderTraversalIt();
            var inOrderRec = tree.InOrderTraversalRec();

            //Assert
            Assert.Equal(2, inOrder[0]);
            Assert.Equal(3, inOrder[1]);
            Assert.Equal(4, inOrder[2]);
            Assert.Equal(5, inOrder[3]);
            Assert.Equal(6, inOrder[4]);
            Assert.Equal(8, inOrder[5]);

            Assert.Equal(2, inOrderRec[0]);
            Assert.Equal(3, inOrderRec[1]);
            Assert.Equal(4, inOrderRec[2]);
            Assert.Equal(5, inOrderRec[3]);
            Assert.Equal(6, inOrderRec[4]);
            Assert.Equal(8, inOrderRec[5]);
        }
    }
}
