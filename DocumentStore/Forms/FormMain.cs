using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DocumentStore
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.userControlSearchDocument.LoadControlUI();
            this.userControlAddEditDeleteDocument.LoadControlUI();
        }

    

        private void labelInfo_Click(object sender, EventArgs e)
        {
            FormDatabaseScripts formDatabaseScripts = new FormDatabaseScripts();
            formDatabaseScripts.Deactivate += delegate
            {
                formDatabaseScripts.Close();
            };
            formDatabaseScripts.Show(this);
        }

        private void ShowMessageBox(string message, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            MessageBox.Show(message, "Document Store", buttons, icon);
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.userControlSearchDocument.LoadControlUI();
            this.userControlAddEditDeleteDocument.LoadControlUI();
        }
    }
}
