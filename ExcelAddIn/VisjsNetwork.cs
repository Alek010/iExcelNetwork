// Ignore Spelling: Visjs

using System.Data;
using System.IO;
using VisjsNetworkLibrary;
using VisjsNetworkLibrary.Interfaces;

namespace ExcelAddIn
{
    public class VisjsNetwork
    {
        private readonly NetworkDataFactory _networkDataFactory;

        public VisjsNetwork(NetworkDataFactory networkDataFactory)
        {
             _networkDataFactory = networkDataFactory;
        }
        public void BuildNetwork()
        {
            NetworkDataFactory networkDataFactory = _networkDataFactory;
            networkDataFactory.ValidateDataTable();
            INetworkData networkData = networkDataFactory.CreateNetworkData();

            NetworkHtmlContent htmlContent = new NetworkHtmlContent(networkData);

            string filePath = Path.Combine(ConfigManager.GetOutputFolderPath(), ConfigManager.GetNetworkFileName());

            string networkFile = filePath + ".html";
            FileProcessor networkFileProcessor = new FileProcessor(htmlContent, networkFile);
            networkFileProcessor.WriteFile();
            networkFileProcessor.OpenFile();

            string integrityFilePath = filePath + ".txt";
            IntegrityLogContent integrityLogContent = new IntegrityLogContent(networkFile, iExcelNetworkVersion: ConfigManager.GetAddInVersion());
            FileProcessor networkIntegrityFileProcessor = new FileProcessor(integrityLogContent, integrityFilePath);
            networkIntegrityFileProcessor.WriteFile();
        }
    }
}
