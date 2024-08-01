// Ignore Spelling: Json


using System.Collections.Generic;
using VisJsNetworkLibrary.Models;

namespace VisJsNetworkLibrary.Interfaces
{
    public interface INetworkData
    {
        List<Edge> GetEdges();
        List<Node> GetNodes();
    }
}