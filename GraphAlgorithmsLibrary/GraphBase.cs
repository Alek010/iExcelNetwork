// Ignore Spelling: DFS

using GraphAlgorithmsLibrary.Algorithms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphAlgorithmsLibrary
{
    public abstract class GraphBase
    {
        internal readonly Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        public abstract void AddEdge(int u, int v);

        public async Task<List<List<int>>> DFS_FindAllPathsAsync(int src, int dst)
        {
            DeepFirstSearch deepFirstSearch = new DeepFirstSearch(graph);
            return await deepFirstSearch.Execute(src, dst);
        }

        public Dictionary<int, List<int>> GetGraph()
        {
            return graph;
        }

        public int CountCircularEdges()
        {
            CircularEdgesCounter counter = new CircularEdgesCounter(graph);

            return counter.CountCircularEdges();
        }
    }   
    
}