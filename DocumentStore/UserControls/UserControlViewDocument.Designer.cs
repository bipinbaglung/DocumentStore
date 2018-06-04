namespace DocumentStore
{
    partial class UserControlViewDocument
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBoxDocumentContent = new System.Windows.Forms.RichTextBox();
            this.panelDocumentContent = new System.Windows.Forms.Panel();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonSaveOnFile = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.labelMatchCount = new System.Windows.Forms.Label();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.panelImages = new System.Windows.Forms.Panel();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.panelDocumentContent.SuspendLayout();
            this.panelImages.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxDocumentContent
            // 
            this.richTextBoxDocumentContent.BackColor = System.Drawing.Color.White;
            this.richTextBoxDocumentContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDocumentContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDocumentContent.Location = new System.Drawing.Point(20, 20);
            this.richTextBoxDocumentContent.Name = "richTextBoxDocumentContent";
            this.richTextBoxDocumentContent.ReadOnly = true;
            this.richTextBoxDocumentContent.Size = new System.Drawing.Size(731, 462);
            this.richTextBoxDocumentContent.TabIndex = 0;
            this.richTextBoxDocumentContent.Text = "";
            // 
            // panelDocumentContent
            // 
            this.panelDocumentContent.BackColor = System.Drawing.Color.White;
            this.panelDocumentContent.Controls.Add(this.richTextBoxDocumentContent);
            this.panelDocumentContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDocumentContent.Location = new System.Drawing.Point(0, 29);
            this.panelDocumentContent.Name = "panelDocumentContent";
            this.panelDocumentContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelDocumentContent.Size = new System.Drawing.Size(771, 502);
            this.panelDocumentContent.TabIndex = 1;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Image = global::DocumentStore.Properties.Resources.Edit16;
            this.buttonEdit.Location = new System.Drawing.Point(3, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(27, 23);
            this.buttonEdit.TabIndex = 30;
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonSaveOnFile
            // 
            this.buttonSaveOnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveOnFile.Image = global::DocumentStore.Properties.Resources.Save16;
            this.buttonSaveOnFile.Location = new System.Drawing.Point(36, 3);
            this.buttonSaveOnFile.Name = "buttonSaveOnFile";
            this.buttonSaveOnFile.Size = new System.Drawing.Size(27, 23);
            this.buttonSaveOnFile.TabIndex = 29;
            this.buttonSaveOnFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSaveOnFile.UseVisualStyleBackColor = true;
            this.buttonSaveOnFile.Click += new System.EventHandler(this.buttonSaveOnFile_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.Image = global::DocumentStore.Properties.Resources.print16;
            this.buttonPrint.Location = new System.Drawing.Point(69, 3);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(27, 23);
            this.buttonPrint.TabIndex = 28;
            this.buttonPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // labelMatchCount
            // 
            this.labelMatchCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMatchCount.AutoSize = true;
            this.labelMatchCount.Location = new System.Drawing.Point(709, 9);
            this.labelMatchCount.Name = "labelMatchCount";
            this.labelMatchCount.Size = new System.Drawing.Size(0, 13);
            this.labelMatchCount.TabIndex = 31;
            this.labelMatchCount.Visible = false;
            // 
            // listViewImages
            // 
            this.listViewImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewImages.LargeImageList = this.imageListLarge;
            this.listViewImages.Location = new System.Drawing.Point(0, 0);
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(771, 121);
            this.listViewImages.TabIndex = 1004;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            this.listViewImages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewImages_MouseDoubleClick);
            // 
            // imageListLarge
            // 
            this.imageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListLarge.ImageSize = new System.Drawing.Size(64, 64);
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelImages
            // 
            this.panelImages.Controls.Add(this.listViewImages);
            this.panelImages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelImages.Location = new System.Drawing.Point(0, 531);
            this.panelImages.Name = "panelImages";
            this.panelImages.Size = new System.Drawing.Size(771, 121);
            this.panelImages.TabIndex = 1005;
            // 
            // panelOptions
            // 
            this.panelOptions.Controls.Add(this.labelMatchCount);
            this.panelOptions.Controls.Add(this.buttonPrint);
            this.panelOptions.Controls.Add(this.buttonEdit);
            this.panelOptions.Controls.Add(this.buttonSaveOnFile);
            this.panelOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOptions.Location = new System.Drawing.Point(0, 0);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(771, 29);
            this.panelOptions.TabIndex = 1;
            // 
            // UserControlViewDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelDocumentContent);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.panelImages);
            this.Name = "UserControlViewDocument";
            this.Size = new System.Drawing.Size(771, 652);
            this.panelDocumentContent.ResumeLayout(false);
            this.panelImages.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxDocumentContent;
        private System.Windows.Forms.Panel panelDocumentContent;
        private System.Windows.Forms.Button buttonSaveOnFile;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Label labelMatchCount;
        private System.Windows.Forms.ListView listViewImages;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Panel panelImages;
    }
}
