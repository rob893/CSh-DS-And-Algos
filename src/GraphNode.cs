using System.Collections.Generic;

namespace CSh_DS_And_Algos
{
    public class GraphNode<T>
    {
        public T Data { get; set; }
        public bool Visited { get; set; }
        public List<GraphNode<T>> Connections { get; set; } = new List<GraphNode<T>>();


        public GraphNode(T data)
        {
            Data = data;
        }
    }

    public static class GraphUtil
    {
        public static GraphNode<T> DFS<T>(GraphNode<T> start, T target)
        {
            var stack = new Stack<GraphNode<T>>();

            stack.Push(start);

            while (stack.Count != 0)
            {
                var node = stack.Pop();
                node.Visited = true;

                if (node.Data.Equals(target))
                {
                    return node;
                }

                for (int i = 0; i < node.Connections.Count; i++)
                {
                    if (!node.Connections[i].Visited)
                    {
                        stack.Push(node.Connections[i]);
                    }
                }
            }

            return null;
        }
    }
}