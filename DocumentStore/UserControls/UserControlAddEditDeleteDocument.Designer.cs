namespace DocumentStore
{
    partial class UserControlAddEditDeleteDocument
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
            this.buttonAddAuthor = new System.Windows.Forms.Button();
            this.comboBoxAuthor = new System.Windows.Forms.ComboBox();
            this.textBoxNepaliDate = new System.Windows.Forms.TextBox();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxDocumentType = new System.Windows.Forms.ComboBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.textBoxSummary = new System.Windows.Forms.TextBox();
            this.dateTimePickerCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxBody = new System.Windows.Forms.RichTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCountInfo = new System.Windows.Forms.Label();
            this.labelTotalFileCount = new System.Windows.Forms.Label();
            this.comboBoxPublisher = new System.Windows.Forms.ComboBox();
            this.buttonAddImages = new System.Windows.Forms.Button();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelImages = new System.Windows.Forms.Label();
            this.checkBoxDateUncertain = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonAddAuthor
            // 
            this.buttonAddAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddAuthor.Image = global::DocumentStore.Properties.Resources.add;
            this.buttonAddAuthor.Location = new System.Drawing.Point(587, 36);
            this.buttonAddAuthor.Name = "buttonAddAuthor";
            this.buttonAddAuthor.Size = new System.Drawing.Size(27, 23);
            this.buttonAddAuthor.TabIndex = 9;
            this.buttonAddAuthor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddAuthor.UseVisualStyleBackColor = true;
            this.buttonAddAuthor.Click += new System.EventHandler(this.buttonAddAuthor_Click);
            // 
            // comboBoxAuthor
            // 
            this.comboBoxAuthor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxAuthor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxAuthor.DisplayMember = "Name";
            this.comboBoxAuthor.FormattingEnabled = true;
            this.comboBoxAuthor.Location = new System.Drawing.Point(398, 37);
            this.comboBoxAuthor.Name = "comboBoxAuthor";
            this.comboBoxAuthor.Size = new System.Drawing.Size(189, 21);
            this.comboBoxAuthor.TabIndex = 3;
            this.comboBoxAuthor.Text = "Select author";
            this.comboBoxAuthor.ValueMember = "Id";
            this.comboBoxAuthor.SelectedIndexChanged += new System.EventHandler(this.comboBoxAuthor_SelectedIndexChanged);
            // 
            // textBoxNepaliDate
            // 
            this.textBoxNepaliDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxNepaliDate.Location = new System.Drawing.Point(79, 583);
            this.textBoxNepaliDate.Name = "textBoxNepaliDate";
            this.textBoxNepaliDate.Size = new System.Drawing.Size(180, 20);
            this.textBoxNepaliDate.TabIndex = 7;
            this.textBoxNepaliDate.Leave += new System.EventHandler(this.TextBoxNepaliDate_Leave);
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(3, 596);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(70, 13);
            this.labelCreatedDate.TabIndex = 0;
            this.labelCreatedDate.Text = "Created Date";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(6, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(768, 22);
            this.textBoxName.TabIndex = 1000;
            this.textBoxName.Text = "Name";
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxName.Leave += new System.EventHandler(this.textBoxName_Leave);
            // 
            // comboBoxDocumentType
            // 
            this.comboBoxDocumentType.DisplayMember = "Name";
            this.comboBoxDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDocumentType.FormattingEnabled = true;
            this.comboBoxDocumentType.Location = new System.Drawing.Point(202, 37);
            this.comboBoxDocumentType.Name = "comboBoxDocumentType";
            this.comboBoxDocumentType.Size = new System.Drawing.Size(189, 21);
            this.comboBoxDocumentType.TabIndex = 2;
            this.comboBoxDocumentType.ValueMember = "Id";
            this.comboBoxDocumentType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocumentType_SelectedIndexChanged);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(6, 63);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(768, 22);
            this.textBoxTitle.TabIndex = 4;
            this.textBoxTitle.Text = "Title";
            this.textBoxTitle.Enter += new System.EventHandler(this.textBoxTitle_Enter);
            this.textBoxTitle.Leave += new System.EventHandler(this.textBoxTitle_Leave);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsert.Location = new System.Drawing.Point(581, 591);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(62, 23);
            this.buttonInsert.TabIndex = 8;
            this.buttonInsert.Text = "Insert";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSummary.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSummary.Location = new System.Drawing.Point(6, 89);
            this.textBoxSummary.Multiline = true;
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.Size = new System.Drawing.Size(768, 51);
            this.textBoxSummary.TabIndex = 5;
            this.textBoxSummary.Text = "Summary";
            this.textBoxSummary.Enter += new System.EventHandler(this.textBoxSummary_Enter);
            this.textBoxSummary.Leave += new System.EventHandler(this.textBoxSummary_Leave);
            // 
            // dateTimePickerCreatedDate
            // 
            this.dateTimePickerCreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerCreatedDate.Location = new System.Drawing.Point(79, 602);
            this.dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            this.dateTimePickerCreatedDate.Size = new System.Drawing.Size(180, 20);
            this.dateTimePickerCreatedDate.TabIndex = 999;
            this.dateTimePickerCreatedDate.ValueChanged += new System.EventHandler(this.dateTimePickerCreatedDate_ValueChanged);
            // 
            // textBoxBody
            // 
            this.textBoxBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBody.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBody.Location = new System.Drawing.Point(6, 144);
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(768, 306);
            this.textBoxBody.TabIndex = 6;
            this.textBoxBody.Text = "Body";
            this.textBoxBody.Enter += new System.EventHandler(this.textBoxBody_Enter);
            this.textBoxBody.Leave += new System.EventHandler(this.textBoxBody_Leave);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(649, 591);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(62, 23);
            this.buttonClear.TabIndex = 22;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(717, 591);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(62, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelCountInfo
            // 
            this.labelCountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCountInfo.AutoSize = true;
            this.labelCountInfo.Location = new System.Drawing.Point(265, 605);
            this.labelCountInfo.Name = "labelCountInfo";
            this.labelCountInfo.Size = new System.Drawing.Size(64, 13);
            this.labelCountInfo.TabIndex = 26;
            this.labelCountInfo.Text = "Total Entry :";
            // 
            // labelTotalFileCount
            // 
            this.labelTotalFileCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalFileCount.AutoSize = true;
            this.labelTotalFileCount.Location = new System.Drawing.Point(336, 605);
            this.labelTotalFileCount.Name = "labelTotalFileCount";
            this.labelTotalFileCount.Size = new System.Drawing.Size(13, 13);
            this.labelTotalFileCount.TabIndex = 25;
            this.labelTotalFileCount.Text = "0";
            // 
            // comboBoxPublisher
            // 
            this.comboBoxPublisher.DisplayMember = "Name";
            this.comboBoxPublisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPublisher.FormattingEnabled = true;
            this.comboBoxPublisher.Location = new System.Drawing.Point(6, 37);
            this.comboBoxPublisher.Name = "comboBoxPublisher";
            this.comboBoxPublisher.Size = new System.Drawing.Size(189, 21);
            this.comboBoxPublisher.TabIndex = 1;
            this.comboBoxPublisher.ValueMember = "Id";
            this.comboBoxPublisher.SelectedIndexChanged += new System.EventHandler(this.comboBoxPublisher_SelectedIndexChanged);
            // 
            // buttonAddImages
            // 
            this.buttonAddImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddImages.Image = global::DocumentStore.Properties.Resources.add;
            this.buttonAddImages.Location = new System.Drawing.Point(746, 476);
            this.buttonAddImages.Name = "buttonAddImages";
            this.buttonAddImages.Size = new System.Drawing.Size(27, 23);
            this.buttonAddImages.TabIndex = 1004;
            this.buttonAddImages.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddImages.UseVisualStyleBackColor = true;
            this.buttonAddImages.Click += new System.EventHandler(this.buttonAddImages_Click);
            // 
            // listViewImages
            // 
            this.listViewImages.AllowDrop = true;
            this.listViewImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewImages.LargeImageList = this.imageListLarge;
            this.listViewImages.Location = new System.Drawing.Point(6, 475);
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(768, 82);
            this.listViewImages.TabIndex = 1003;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            this.listViewImages.VirtualListSize = 5;
            this.listViewImages.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewImages_DragDrop);
            this.listViewImages.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewImages_DragEnter);
            this.listViewImages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewImages_KeyUp);
            this.listViewImages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewImages_MouseDoubleClick);
            // 
            // imageListLarge
            // 
            this.imageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.FileName = "Image";
            this.openFileDialog.InitialDirectory = "Libraries\\Pictures";
            this.openFileDialog.Multiselect = true;
            // 
            // labelImages
            // 
            this.labelImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelImages.AutoSize = true;
            this.labelImages.Location = new System.Drawing.Point(3, 459);
            this.labelImages.Name = "labelImages";
            this.labelImages.Size = new System.Drawing.Size(44, 13);
            this.labelImages.TabIndex = 1005;
            this.labelImages.Text = "Images:";
            // 
            // checkBoxDateUncertain
            // 
            this.checkBoxDateUncertain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxDateUncertain.AutoSize = true;
            this.checkBoxDateUncertain.Location = new System.Drawing.Point(266, 584);
            this.checkBoxDateUncertain.Name = "checkBoxDateUncertain";
            this.checkBoxDateUncertain.Size = new System.Drawing.Size(101, 17);
            this.checkBoxDateUncertain.TabIndex = 1006;
            this.checkBoxDateUncertain.Text = "Uncertain Date ";
            this.checkBoxDateUncertain.UseVisualStyleBackColor = true;
            // 
            // UserControlAddEditDeleteDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxDateUncertain);
            this.Controls.Add(this.labelImages);
            this.Controls.Add(this.buttonAddImages);
            this.Controls.Add(this.listViewImages);
            this.Controls.Add(this.comboBoxPublisher);
            this.Controls.Add(this.labelCountInfo);
            this.Controls.Add(this.labelTotalFileCount);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonAddAuthor);
            this.Controls.Add(this.comboBoxAuthor);
            this.Controls.Add(this.textBoxNepaliDate);
            this.Controls.Add(this.labelCreatedDate);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.comboBoxDocumentType);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.textBoxSummary);
            this.Controls.Add(this.dateTimePickerCreatedDate);
            this.Controls.Add(this.textBoxBody);
            this.Name = "UserControlAddEditDeleteDocument";
            this.Size = new System.Drawing.Size(782, 629);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddAuthor;
        private System.Windows.Forms.ComboBox comboBoxAuthor;
        private System.Windows.Forms.TextBox textBoxNepaliDate;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxDocumentType;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.TextBox textBoxSummary;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreatedDate;
        private System.Windows.Forms.RichTextBox textBoxBody;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCountInfo;
        private System.Windows.Forms.Label labelTotalFileCount;
        private System.Windows.Forms.ComboBox comboBoxPublisher;
        private System.Windows.Forms.Button buttonAddImages;
        private System.Windows.Forms.ListView listViewImages;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelImages;
        private System.Windows.Forms.CheckBox checkBoxDateUncertain;
    }
}
