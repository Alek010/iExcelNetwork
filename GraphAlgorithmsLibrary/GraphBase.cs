// Ignore Spelling: DFS

using GraphAlgorithmsLibrary.Algorithms;
using System.Collections.Generic;

namespace GraphAlgorithmsLibrary
{
    public abstract class GraphBase
    {
        internal readonly Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        public abstract void AddEdge(int u, int v);

        public List<List<int>> DFS_FindAllPaths(int src, int dst)
        {
            List<int> path = new List<int>();
            List<List<int>> allPaths = new List<List<int>>();
            int maxNode = GetMaxNode();

            bool[] visited = new bool[maxNode + 1];

            DeepFirstSearch deepFirstSearch = new DeepFirstSearch(graph);
            deepFirstSearch.Execute(src, dst, visited, path, allPaths);

            return allPaths;
        }

        public Dictionary<int, List<int>> GetGraph()
        {
            return graph;
        }

        private int GetMaxNode()
        {
            int maxNode = -1;
            foreach (var node in graph.Keys)
            {
                if (node > maxNode)
                {
                    maxNode = node;
                }
            }
            return maxNode;
        }
    }
}