// Ignore Spelling: DFS

using GraphAlgorithmsLibrary.Algorithms;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphAlgorithmsLibrary
{
    public abstract class GraphBase
    {
        internal readonly Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private int? maxNodeCache = null; // Cache the max node value

        public abstract void AddEdge(int u, int v);

        public async Task<List<List<int>>> DFS_FindAllPathsAsync(int src, int dst)
        {
            ConcurrentBag<List<int>> allPaths = new ConcurrentBag<List<int>>();
            int maxNode = GetMaxNode();

            bool[] visited = new bool[maxNode + 1];

            async Task DFSAsync(int current, List<int> path, bool[] localVisited)
            {
                localVisited[current] = true;

                if (current == dst)
                {
                    allPaths.Add(new List<int>(path));
                }
                else if (graph.ContainsKey(current))
                {
                    var tasks = new List<Task>();
                    foreach (var neighbor in graph[current])
                    {
                        if (!localVisited[neighbor])
                        {
                            var newPath = new List<int>(path) { neighbor };
                            var newVisited = (bool[])localVisited.Clone();
                            tasks.Add(DFSAsync(neighbor, newPath, newVisited));
                        }
                    }
                    await Task.WhenAll(tasks);
                }
            }

            var initialTasks = new List<(int, List<int>, bool[])>();
            Stack<(int, List<int>)> stack = new Stack<(int, List<int>)>();
            stack.Push((src, new List<int> { src }));

            while (stack.Count > 0)
            {
                var (current, path) = stack.Pop();
                if (graph.ContainsKey(current))
                {
                    foreach (var neighbor in graph[current])
                    {
                        if (!visited[neighbor])
                        {
                            var newPath = new List<int>(path) { neighbor };
                            initialTasks.Add((neighbor, newPath, (bool[])visited.Clone()));
                        }
                    }
                }
            }

            // Parallel execution with auto-adjusted chunks
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            var partitioner = Partitioner.Create(initialTasks, EnumerablePartitionerOptions.NoBuffering);
            var tasksParallel = new List<Task>();

            Parallel.ForEach(partitioner, parallelOptions, initialTask =>
            {
                var (current, path, localVisited) = initialTask;
                tasksParallel.Add(DFSAsync(current, path, localVisited));
            });

            await Task.WhenAll(tasksParallel);

            return allPaths.ToList();
        }

        public Dictionary<int, List<int>> GetGraph()
        {
            return graph;
        }

        private int GetMaxNode()
        {
            if (maxNodeCache == null)
            {
                maxNodeCache = graph.Keys.DefaultIfEmpty(-1).Max();
            }
            return maxNodeCache.Value;
        }
    }   
    
}