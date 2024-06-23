// Ignore Spelling: Sha

using iExcelNetwork.NetworkProperty;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace iExcelNetwork.VisJsNetwork
{
    public class NetworkIntegrityLog
    {
        private readonly NetworkProperties _networkProperties;

        public NetworkIntegrityLog(NetworkProperties networkProperties)
        {
            _networkProperties = networkProperties;
        }

        public void WriteLog()
        {
            string networkHtmlFileSha256 = ComputeSha256HashFromFile(_networkProperties.OutputFolder, _networkProperties.OutputFileName);
            
            string networkHtmlFilePath = BuildFullFilePath(_networkProperties.OutputFolder,_networkProperties.OutputFileName);

            string logFilePath = SubstituteFileExtention(networkHtmlFilePath, ".txt");

            File.WriteAllText(logFilePath, networkHtmlFileSha256);
        }

        private string ComputeSha256HashFromFile(string pathToFolder, string fileName)
        {
            byte[] fileBytes = File.ReadAllBytes(BuildFullFilePath(pathToFolder, fileName));

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(fileBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private string SubstituteFileExtention(string filePath, string fileExtention)
        {
            return Path.ChangeExtension(filePath, fileExtention);
        }

        private string BuildFullFilePath(string folderPath, string fileName)
        {
            return Path.Combine(folderPath, fileName);
        }
    }
}
