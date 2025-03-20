// Ignore Spelling: Visjs

using System.Data;
using VisjsNetworkLibrary.Interfaces;

namespace VisjsNetworkLibrary.NetworkDataClasses
{
    public class NetworkDataWithNodesIconsAndLinkIsConfirmed : NetworkData, INetworkData
    {
        public NetworkDataWithNodesIconsAndLinkIsConfirmed(DataTable dataTable) : base(dataTable)
        {
        }
    }
}
