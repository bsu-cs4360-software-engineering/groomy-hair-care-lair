using System.Data;
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
    public static void activatePanel(Panel panel, Size size, Point location)
    {
        panel.Size = size;
        panel.Location = location;
        panel.BringToFront();
    }
    public static DataTable ConvertToDataTable(List<Dictionary<string, string>> items)
    {
        DataTable table = new DataTable();

        if (items.Count == 0)
            return table;
        if (items[0] != null)
        {
            foreach (var key in items[0].Keys)
            {
                table.Columns.Add(key);
            }
        } else
        {
            return table;
        }
        foreach (var item in items)
        {
            var row = table.NewRow();
            foreach (var key in item.Keys)
            {
                row[key] = item[key];
            }
            table.Rows.Add(row);
        }

        return table;
    }
    public static string GetFieldFromSelection(string field, DataGridView dgv)
    {
        string val = null;

        if (dgv.SelectedRows.Count > 0)
        {
            var selectedRow = dgv.SelectedRows[0];
            if (selectedRow.Cells[field].Value != null)
            {
                val = selectedRow.Cells[field].Value.ToString();
            }
        }
        else if (dgv.SelectedCells.Count > 0)
        {
            var selectedCell = dgv.SelectedCells[0];
            var selectedRow = dgv.Rows[selectedCell.RowIndex];
            if (selectedRow.Cells[field].Value != null)
            {
                val = selectedRow.Cells[field].Value.ToString();
            }
        }
        return val;
    }
    public static List<string> ExtractValuesFromJson(string key, List<Dictionary<string, string>> jsons)
    {
        var items = new List<string>();
        foreach (var item in jsons)
        {
            if (item.ContainsKey(key))
            {
                items.Add(item[key]);
            }
        }
        return items;
    }
}
