// Ignore Spelling: Visjs

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

        public void BuildNetwork(bool removeEdgesData = false)
        {
            _networkDataFactory.ValidateDataTable();
            INetworkData networkData = _networkDataFactory.CreateNetworkData();

            NetworkHtmlContent htmlContent = new NetworkHtmlContent(networkData);
            htmlContent.RemoveEdgesDataFromHtml = removeEdgesData;

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
