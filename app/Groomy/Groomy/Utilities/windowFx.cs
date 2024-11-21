namespace Groomy.Utilities
{
    public class windowFx
    {
        public static void OpenForm(string formName, bool asDialog)
        {
            // Use reflection to create an instance of the form
            Type formType = Type.GetType(formName);

            if (formType == null)
            {
                MessageBox.Show("Form not found: " + formName);
                return;
            }

            // Create the form instance
            Form frm = (Form)Activator.CreateInstance(formType);

            // Optional: Center the dialog
            frm.StartPosition = FormStartPosition.CenterParent;

            // If the form is NOT a dialog, hide all currently open forms
            if (!asDialog)
            {
                foreach (Form openForm in Application.OpenForms)
                {
                    openForm.Hide();
                }

                frm.Show(); // Opens the form as a regular form
            }
            else
            {
                frm.ShowDialog(); // Opens the form as a modal dialog
            }
        }

    }
}
