using System;
using System.Collections.Generic;

namespace CSh_DS_And_Algos
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new GraphNode<int>(5);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);

            node1.Connections.Add(node2);
            node1.Connections.Add(node3);
            node2.Connections.Add(node3);
            node3.Connections.Add(node1);
            node3.Connections.Add(node2);

            var foundNode = GraphUtil.DFS(node1, 5);

            Console.WriteLine(foundNode == null ? "none" : foundNode.Data.ToString());
        }
    }
}
