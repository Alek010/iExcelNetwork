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

        private string ComputeSha256HashFromFile()
        {
            // Read the file as bytes
            byte[] fileBytes = File.ReadAllBytes(Path.Combine(_networkProperties.OutputFolder, _networkProperties.OutputFileName));

            // Create a SHA256 instance
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute the hash
                byte[] bytes = sha256Hash.ComputeHash(fileBytes);

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
