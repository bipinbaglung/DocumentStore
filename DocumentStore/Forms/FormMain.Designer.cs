namespace DocumentStore
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageAddDocuments = new System.Windows.Forms.TabPage();
            this.userControlAddEditDeleteDocument = new DocumentStore.UserControlAddEditDeleteDocument();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.userControlSearchDocument = new DocumentStore.UserControlSearchDocument();
            this.imageListTabImages = new System.Windows.Forms.ImageList(this.components);
            this.labelInfo = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPageAddDocuments.SuspendLayout();
            this.tabPageSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageAddDocuments);
            this.tabControlMain.Controls.Add(this.tabPageSearch);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.ImageList = this.imageListTabImages;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1021, 662);
            this.tabControlMain.TabIndex = 2;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageAddDocuments
            // 
            this.tabPageAddDocuments.Controls.Add(this.userControlAddEditDeleteDocument);
            this.tabPageAddDocuments.ImageIndex = 1;
            this.tabPageAddDocuments.Location = new System.Drawing.Point(4, 23);
            this.tabPageAddDocuments.Name = "tabPageAddDocuments";
            this.tabPageAddDocuments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddDocuments.Size = new System.Drawing.Size(1013, 635);
            this.tabPageAddDocuments.TabIndex = 1;
            this.tabPageAddDocuments.Text = "Add Document";
            this.tabPageAddDocuments.ToolTipText = "Add Document";
            this.tabPageAddDocuments.UseVisualStyleBackColor = true;
            // 
            // userControlAddEditDeleteDocument
            // 
            this.userControlAddEditDeleteDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAddEditDeleteDocument.DocumentId = ((long)(0));
            this.userControlAddEditDeleteDocument.Location = new System.Drawing.Point(3, 3);
            this.userControlAddEditDeleteDocument.Name = "userControlAddEditDeleteDocument";
            this.userControlAddEditDeleteDocument.OpenMode = DocumentStore.Mode.ADD;
            this.userControlAddEditDeleteDocument.Size = new System.Drawing.Size(1007, 629);
            this.userControlAddEditDeleteDocument.TabIndex = 0;
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.Controls.Add(this.userControlSearchDocument);
            this.tabPageSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPageSearch.ImageIndex = 0;
            this.tabPageSearch.Location = new System.Drawing.Point(4, 23);
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearch.Size = new System.Drawing.Size(1013, 635);
            this.tabPageSearch.TabIndex = 2;
            this.tabPageSearch.Text = "Search";
            this.tabPageSearch.ToolTipText = "Search";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // userControlSearchDocument
            // 
            this.userControlSearchDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSearchDocument.Location = new System.Drawing.Point(3, 3);
            this.userControlSearchDocument.Name = "userControlSearchDocument";
            this.userControlSearchDocument.Size = new System.Drawing.Size(1007, 629);
            this.userControlSearchDocument.TabIndex = 0;
            // 
            // imageListTabImages
            // 
            this.imageListTabImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabImages.ImageStream")));
            this.imageListTabImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTabImages.Images.SetKeyName(0, "Search16.png");
            this.imageListTabImages.Images.SetKeyName(1, "AddDocument16.png");
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.AutoSize = true;
            this.labelInfo.Image = global::DocumentStore.Properties.Resources.info;
            this.labelInfo.Location = new System.Drawing.Point(1005, 3);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(13, 13);
            this.labelInfo.TabIndex = 4;
            this.labelInfo.Text = "  ";
            this.labelInfo.Click += new System.EventHandler(this.labelInfo_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 662);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.tabControlMain);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Document Store";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageAddDocuments.ResumeLayout(false);
            this.tabPageSearch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.TabPage tabPageAddDocuments;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ImageList imageListTabImages;
        private UserControlAddEditDeleteDocument userControlAddEditDeleteDocument;
        private UserControlSearchDocument userControlSearchDocument;
    }
}

