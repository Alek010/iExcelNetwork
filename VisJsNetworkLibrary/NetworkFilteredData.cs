﻿using System.Collections.Generic;
using System.Linq;
using VisJsNetworkLibrary.Interfaces;
using VisJsNetworkLibrary.Models;

namespace VisJsNetworkLibrary
{
    public class NetworkFilteredData : INetworkData
    {
        private readonly List<Node> NodesList = new List<Node>();
        private readonly List<Edge> EdgesList = new List<Edge>();
        private readonly List<List<int>> FoundPaths = new List<List<int>>();

        public NetworkFilteredData(List<List<int>> foundPaths, INetworkData networkData)
        {
            FoundPaths = foundPaths;
            NodesList = networkData.GetNodes();
            EdgesList = networkData.GetEdges();
        }

        public List<Node> GetNodes()
        {
            var searchIDs = FoundPaths.SelectMany(list => list).ToList().Distinct();

            return NodesList.Where(d => searchIDs.Contains(d.Id)).ToList();
        }

        public List<Edge> GetEdges()
        {
            var searchIDs = FoundPaths.SelectMany(list => list).ToList().Distinct();

            var result = EdgesList
                .Where(edge => searchIDs.Contains(edge.From) || searchIDs.Contains(edge.To))
                .ToList();

            return result;
        }
    }
}
