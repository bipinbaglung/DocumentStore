using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentStore
{
    public partial class FormAddDocumentType : Form
    {
        public FormAddDocumentType()
        {
            InitializeComponent();
        }

        public long DocumentId { get; internal set; }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBoxDocumentType.Text))
            {
                ShowMessageBox("Please insert document type.");
                return;
            }
            string documentType = textBoxDocumentType.Text.Trim();
            string query = @" IF NOT EXISTS(SELECT * FROM tbl_DocumentType WHERE Name = @Name)
                               INSERT INTO  tbl_DocumentType (Name , InsertedDate) values (@Name,GetDate()) ";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = documentType;
                long documentTypeId = DBSupport.ExecuteNonQueryWithIdentity(cmd);
                if (documentTypeId == -1)
                    ShowMessageBox("Document type already exists. Please enter another type.");
                else if (documentTypeId > 0)
                {
                    this.DocumentId = documentTypeId;
                    this.Close();
                }
            }
        }

        private void ShowMessageBox(string message, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            MessageBox.Show(message, "Document Store", buttons, icon);
        }
    }
}
