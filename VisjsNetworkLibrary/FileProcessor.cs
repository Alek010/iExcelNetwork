// Ignore Spelling: Visjs

using System.Diagnostics;
using System.IO;
using VisjsNetworkLibrary.Interfaces;

namespace VisjsNetworkLibrary
{
    public class FileProcessor
    {
        private string _fileContent { get; set; }
        private string _filePath { get; set; }

        public FileProcessor(IFileContent fileContent)
        {
            _fileContent = fileContent.GenerateFileContent();
            _filePath = fileContent.GetFilePath();
        }

        public void WriteFile()
        {
            File.WriteAllText(_filePath, _fileContent);
        }

        public void OpenFile()
        {
            Process.Start(_filePath);
        }

    }
}
