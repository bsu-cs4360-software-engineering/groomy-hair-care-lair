using System.Text;
using System.Security.Cryptography;

namespace Groomy
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    public class Helpers
        {
            public static string GenerateSHA256Hash(string input)
            {
                // Create a new SHA256 instance
                using var sha256 = SHA256.Create();

                // Convert the input string to a byte array
                var inputBytes = Encoding.UTF8.GetBytes(input);

                // Compute the hash
                var hashBytes = sha256.ComputeHash(inputBytes);

                // Convert the hash bytes to a hexadecimal string
                var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return hashString;
            }
        }
    }
}