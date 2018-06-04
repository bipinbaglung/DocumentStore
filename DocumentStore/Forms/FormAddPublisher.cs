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
    public partial class FormAddPublisher : Form
    {
        public FormAddPublisher()
        {
            InitializeComponent();
        }

        public long PublisherId { get; internal set; }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBoxPublisher.Text))
            {
                ShowMessageBox("Please insert publisher.");
                return;
            }
            string publisher = textBoxPublisher.Text.Trim();
            string query = @" IF NOT EXISTS(SELECT * FROM tbl_PublisherInfo WHERE Name = @Name)
                               INSERT INTO  tbl_PublisherInfo (Name , InsertedDate) values (@Name,GetDate()) ";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = publisher;
                long publisherId = DBSupport.ExecuteNonQueryWithIdentity(cmd);
                if (publisherId == -1)
                    ShowMessageBox("Publisher already exists. Please enter another.");
                else if (publisherId > 0)
                {
                    this.PublisherId = publisherId;
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
