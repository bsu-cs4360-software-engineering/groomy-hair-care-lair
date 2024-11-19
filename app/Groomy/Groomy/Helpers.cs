using System.Security.Cryptography;
using System.Text;


public class Helpers
{
    public static string RandomSHA256Hash()
    {
        return GenerateSHA256Hash(Guid.NewGuid().ToString());
    }
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
    public static string createUserJson(string firstName, string lastName, string email)
    {
        return $@"{{
        ""{Helpers.GenerateSHA256Hash(email)}"": {{
            ""FirstName"": ""{firstName}"",
            ""LastName"": ""{lastName}"",
            ""Email"": ""{email}""
        }}
    }}";
    }
    public static string createPasswordJson(string email, string password)
    {
        return $@"{{
        ""{Helpers.GenerateSHA256Hash(email)}"": {{
            ""Password"": ""{Helpers.GenerateSHA256Hash(password)}""
        }}
    }}";
    }
    public static void messageBoxError(string message)
    {
        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static void messageBoxSuccess(string message)
    {
        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    public static bool messageBoxConfirm(string message)
    {
        return MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }
}
