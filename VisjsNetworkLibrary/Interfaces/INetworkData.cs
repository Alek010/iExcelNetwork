﻿// Ignore Spelling: Visjs

using System.Collections.Generic;
using VisjsNetworkLibrary.Models;

namespace VisjsNetworkLibrary.Interfaces
{
    public interface INetworkData
    {
        List<Edge> GetEdges();
        List<Node> GetNodes();
        bool NodesEdgesAreScalable { get; set; }
        bool EdgesLinksHasTitle { get; set; }
    }
}