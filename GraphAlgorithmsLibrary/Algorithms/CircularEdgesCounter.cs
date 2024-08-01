using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphAlgorithmsLibrary.Algorithms
{
    public class CircularEdgesCounter
    {

        private readonly Dictionary<int, List<int>> _graph;

        public CircularEdgesCounter(Dictionary<int, List<int>> graph)
        {
            _graph = graph;
        }

        public int CountCircularEdges()
        {
            int circularEdgeCount = 0;
            HashSet<int> visited = new HashSet<int>();
            HashSet<int> recursionStack = new HashSet<int>();

            bool HasCycle(int node)
            {
                if (recursionStack.Contains(node))
                    return true;
                if (visited.Contains(node))
                    return false;

                visited.Add(node);
                recursionStack.Add(node);

                if (_graph.ContainsKey(node))
                {
                    foreach (var neighbor in _graph[node])
                    {
                        if (HasCycle(neighbor))
                        {
                            circularEdgeCount++;
                            return true;
                        }
                    }
                }

                recursionStack.Remove(node);
                return false;
            }

            foreach (var node in _graph.Keys)
            {
                if (HasCycle(node))
                {
                    // Continue searching even after finding a cycle to count all circular edges
                }
            }

            return circularEdgeCount;
        }
    }
}
