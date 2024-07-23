
using System.Collections.Generic;

namespace GraphAlgorithmsLibrary.Algorithms
{
    public class DeepFirstSearch
    {
        private readonly Dictionary<int, List<int>> _graph;

        public DeepFirstSearch(Dictionary<int, List<int>> graph)
        {
            _graph = graph;   
        }
        
        // Recursive DFS function to find all paths
        public void Execute(int current, int destination, bool[] visited, List<int> path, List<List<int>> allPaths)
        {
            visited[current] = true;
            path.Add(current);

            // If destination is reached, add the path to allPaths
            if (current == destination)
            {
                allPaths.Add(new List<int>(path));
            }
            else
            {
                // Recur for all the vertices adjacent to the current vertex
                if (_graph.ContainsKey(current))
                {
                    foreach (var neighbor in _graph[current])
                    {
                        if (!visited[neighbor])
                        {
                            Execute(neighbor, destination, visited, path, allPaths);
                        }
                    }
                }
            }

            // Remove current node from path and mark it as unvisited (backtrack)
            path.RemoveAt(path.Count - 1);
            visited[current] = false;
        }
    }
}
