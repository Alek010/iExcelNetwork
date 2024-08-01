﻿using System.Collections.Generic;

namespace GraphAlgorithmsLibrary
{
    public class GraphNonDirectionalEdges : GraphBase
    {
        public override void AddEdge(int u, int v)
        {
            if (!graph.ContainsKey(u))
            {
                graph[u] = new List<int>();
            }
            graph[u].Add(v);

            if (!graph.ContainsKey(v))
            {
               graph[v] = new List<int>();
            }
            // line where non directional edge added.
            graph[v].Add(u);
        }
    }
}
