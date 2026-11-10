using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DSA.Lab05
{
    /// <summary>
    /// Iterative graph traversals.
    ///
    /// Complete these methods after the adjacency representation is working.
    /// Think in terms of:
    /// frontier + visited + neighbors.
    /// </summary>
    public static class GraphTraversal
    {
        public static IReadOnlyList<string> BreadthFirstOrder(AdjacencyGraph graph, string start)
        {
            Queue<string> frontier = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            frontier.Enqueue(start);

            while (frontier.Count > 0)
            {
                string current = frontier.Dequeue();
                visited.Add(current);
                var neighbors = graph.GetNeighbors(current);
                foreach (var neighbor in neighbors)
                {
                    if (visited.Add(neighbor))
                    {
                        frontier.Enqueue(neighbor);
                    }
                }
            }
            return visited.ToList();
        }

        public static IReadOnlyList<string> DepthFirstOrder(AdjacencyGraph graph, string start)
        {
            Queue<string> frontier = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            return visited.ToList();
        }

        public static bool IsReachableBfs(AdjacencyGraph graph, string start, string target)
        {
            throw new NotImplementedException();
        }
    }
}
