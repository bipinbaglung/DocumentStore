namespace DocumentStore
{
    partial class FormUpdateDeleteDocument
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdateDeleteDocument));
            this.userControlAddEditDeleteDocument = new DocumentStore.UserControlAddEditDeleteDocument();
            this.userControlViewDocument = new DocumentStore.UserControlViewDocument();
            this.SuspendLayout();
            // 
            // userControlAddEditDeleteDocument
            // 
            this.userControlAddEditDeleteDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAddEditDeleteDocument.DocumentId = ((long)(0));
            this.userControlAddEditDeleteDocument.Location = new System.Drawing.Point(0, 0);
            this.userControlAddEditDeleteDocument.Name = "userControlAddEditDeleteDocument";
            this.userControlAddEditDeleteDocument.OpenMode = DocumentStore.Mode.ADD;
            this.userControlAddEditDeleteDocument.Size = new System.Drawing.Size(962, 502);
            this.userControlAddEditDeleteDocument.TabIndex = 0;
            // 
            // userControlViewDocument
            // 
            this.userControlViewDocument.BackColor = System.Drawing.SystemColors.Control;
            this.userControlViewDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlViewDocument.DocumentId = ((long)(0));
            this.userControlViewDocument.Location = new System.Drawing.Point(0, 0);
            this.userControlViewDocument.Name = "userControlViewDocument";
            this.userControlViewDocument.Size = new System.Drawing.Size(962, 502);
            this.userControlViewDocument.TabIndex = 1;
            // 
            // FormUpdateDeleteDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 502);
            this.Controls.Add(this.userControlViewDocument);
            this.Controls.Add(this.userControlAddEditDeleteDocument);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUpdateDeleteDocument";
            this.Text = "Update Document";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormUpdateDeleteDocument_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlAddEditDeleteDocument userControlAddEditDeleteDocument;
        private UserControlViewDocument userControlViewDocument;
    }
}