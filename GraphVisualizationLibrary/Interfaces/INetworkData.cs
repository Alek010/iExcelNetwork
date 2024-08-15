// Ignore Spelling: Json


using System.Collections.Generic;
using GraphVisualizationLibrary.Models;

namespace GraphVisualizationLibrary.Interfaces
{
    public interface INetworkData
    {
        List<Edge> GetEdges();
        List<Node> GetNodes();
    }
}