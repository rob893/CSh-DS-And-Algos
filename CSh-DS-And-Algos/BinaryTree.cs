using System;
using System.Collections.Generic;

namespace CSh_DS_And_Algos
{
    public class BinaryTree<T>
    {
        public TreeNode<T> Root { get; }


        public BinaryTree(TreeNode<T> root)
        {
            Root = root;
        }

        public BinaryTree(T rootData)
        {
            Root = new TreeNode<T>(rootData);
        }

        public int Count
        {
            get
            {
                return OrderLevelTraversalIt().Count;
            }
        }

        public bool IsBalanced
        {
            get
            {
                var diff = HeightHelper(Root.Left) - HeightHelper(Root.Right);

                return Math.Abs(diff) <= 1;
            }
        }

        public bool IsComplete
        {
            get
            {
                if (Root == null)
                {
                    return true;
                }

                var curr = Root;
                var q = new Queue<TreeNode<T>>();
                bool seenNonFullNode = false;
                q.Enqueue(curr);

                while (q.Count > 0)
                {
                    curr = q.Dequeue();

                    if (curr.Left != null)
                    {
                        if (seenNonFullNode)
                        {
                            return false;
                        }

                        q.Enqueue(curr.Left);
                    }
                    else
                    {
                        seenNonFullNode = true;
                    }

                    if (curr.Right != null)
                    {
                        if (seenNonFullNode)
                        {
                            return false;
                        }
                        
                        q.Enqueue(curr.Right);
                    }
                    else
                    {
                        seenNonFullNode = true;
                    }
                }

                return true;
            }
        }

        public int Height
        {
            get
            {
                return HeightHelper(Root);
            }
        }

        private int HeightHelper(TreeNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Math.Max(HeightHelper(root.Left), HeightHelper(root.Right));
        }

        public static BinaryTree<T> From(IList<T> collection)
        {
            if (collection == null || collection.Count == 0)
            {
                throw new ArgumentException("collection must have at least 1 value");
            }

            var tree = new BinaryTree<T>(collection[0]);

            for (int i = 1; i < collection.Count; i++)
            {
                tree.OrderLevelInsert(collection[i]);
            }

            return tree;
        }

        public void OrderLevelInsert(T data)
        {
            if (Root == null)
            {
                throw new Exception("Root is null");
            }

            var newNode = new TreeNode<T>(data);
            var q = new Queue<TreeNode<T>>();
            var curr = Root;

            q.Enqueue(curr);

            while (q.Count > 0)
            {
                curr = q.Dequeue();

                if (curr.Left == null)
                {
                    curr.Left = newNode;
                    return;
                }
                else
                {
                    q.Enqueue(curr.Left);
                }

                if (curr.Right == null)
                {
                    curr.Right = newNode;
                    return;
                }
                else
                {
                    q.Enqueue(curr.Right);
                }
            }
        }

        public List<T> InOrderTraversalIt() //Left, root, right
        {
            var results = new List<T>();

            if (Root == null)
            {
                return results;
            }

            var stack = new Stack<TreeNode<T>>();
            var curr = Root;

            while (stack.Count > 0 || curr != null)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();
                    results.Add(curr.Data);
                    curr = curr.Right;
                }
            }

            return results;
        }

        public List<T> InOrderTraversalRec()
        {
            var results = new List<T>();
            InOrderTraversalRec(Root, results);

            return results;
        }

        private void InOrderTraversalRec(TreeNode<T> node, List<T> results)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversalRec(node.Left, results);
            results.Add(node.Data);
            InOrderTraversalRec(node.Right, results);
        }

        public List<T> PreOrderTraversalIt() //Root, left, right
        {
            var results = new List<T>();

            if (Root == null)
            {
                return results;
            }

            var stack = new Stack<TreeNode<T>>();
            var curr = Root;
            
            while (stack.Count > 0 || curr != null)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    results.Add(curr.Data);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();
                    curr = curr.Right;
                }
            }

            return results;
        }

        public List<T> PreOrderTraversalRec()
        {
            var results = new List<T>();

            PreOrderTraversalRec(Root, results);

            return results;
        }

        private void PreOrderTraversalRec(TreeNode<T> root, List<T> results)
        {
            if (root == null)
            {
                return;
            }

            results.Add(root.Data);
            PreOrderTraversalRec(root.Left, results);
            PreOrderTraversalRec(root.Right, results);
        }

        public List<T> PostOrderTraversalIt() //Left, right, root
        {
            var results = new List<T>();

            if (Root == null)
            {
                return results;
            }

            var stack = new Stack<TreeNode<T>>();
            var curr = Root;

            while (stack.Count > 0 || curr != null)
            {
                if (curr != null)
                {
                    if (curr.Right != null)
                    {
                        stack.Push(curr.Right);
                    }

                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();

                    if (stack.Count > 0 && curr.Right == stack.Peek())
                    {
                        var right = stack.Pop();
                        stack.Push(curr);
                        curr = right;
                    }
                    else
                    {
                        results.Add(curr.Data);
                        curr = null;
                    }
                }
            }

            return results;
        }

        public List<T> PostOrderTraversalRec()
        {
            var results = new List<T>();

            PostOrderTraversalRec(Root, results);

            return results;
        }

        private void PostOrderTraversalRec(TreeNode<T> root, List<T> results)
        {
            if (root == null)
            {
                return;
            }

            PostOrderTraversalRec(root.Left, results);
            PostOrderTraversalRec(root.Right, results);
            results.Add(root.Data);
        }

        public List<T> OrderLevelTraversalIt()
        {
            var results = new List<T>();

            if (Root == null)
            {
                return results;
            }

            var q = new Queue<TreeNode<T>>();
            var curr = Root;

            q.Enqueue(curr);

            while (q.Count > 0)
            {
                curr = q.Dequeue();

                results.Add(curr.Data);

                if (curr.Left != null)
                {
                    q.Enqueue(curr.Left);
                }
                
                if (curr.Right != null)
                {
                    q.Enqueue(curr.Right);
                }
            }

            return results;
        }

        public List<T> OrderLevelTraversalRec()
        {
            var results = new List<T>();

            for (int i = 1; i <= Height; i++)
            {
                results.AddRange(GetLevel(i));
            }

            return results;
        }

        public List<T> GetLevel(int level)
        {
            var results = new List<T>();

            GetLevel(level, Root, results);

            return results;
        }

        private void GetLevel(int level, TreeNode<T> root, List<T> results)
        {
            if (root == null)
            {
                return;
            }

            if (level == 1)
            {
                results.Add(root.Data);
            }
            else if (level > 1)
            {
                GetLevel(level - 1, root.Left, results);
                GetLevel(level - 1, root.Right, results);
            }
        }
    }

    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }


        public TreeNode(T data)
        {
            Data = data;
        }
    }
}