using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DocumentStore
{
    public partial class FormUpdateDeleteDocument : Form
    {
        public bool DocumentUpdated = false;
        public List<string> highlightTerms;
        public FormUpdateDeleteDocument(long documentId)
        {
            InitializeComponent();
            this.userControlAddEditDeleteDocument.DocumentId = documentId;
            this.userControlViewDocument.DocumentId = documentId;
            this.userControlAddEditDeleteDocument.OpenMode = Mode.UPDATE;
            this.userControlAddEditDeleteDocument.Enabled = false;
        }

        private void FormUpdateDeleteDocument_Load(object sender, EventArgs e)
        {
            this.userControlAddEditDeleteDocument.LoadControlUI();
            this.userControlAddEditDeleteDocument.OnDocumentUpdate += UserControlAddEditDeleteDocument_OnDocumentUpdate;
            this.userControlViewDocument.LoadControlUI(highlightTerms);
            this.userControlViewDocument.OnEditClick += UserControlViewDocument_OnEditClick;
        }

        private void UserControlAddEditDeleteDocument_OnDocumentUpdate()
        {
            this.DocumentUpdated = true;
        }

        private void UserControlViewDocument_OnEditClick()
        {
            this.userControlAddEditDeleteDocument.Enabled = true;
            this.userControlAddEditDeleteDocument.Visible = true;
            this.userControlViewDocument.Visible = false;
        }
    }
}
