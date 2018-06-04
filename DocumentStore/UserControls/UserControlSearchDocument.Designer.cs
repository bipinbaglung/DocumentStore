namespace DocumentStore
{
    partial class UserControlSearchDocument
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
            this.labelSearchScope = new System.Windows.Forms.Label();
            this.dataGridViewDocumentSearchResult = new System.Windows.Forms.DataGridView();
            this.ColumnSn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDocumentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreatedDateNepali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateUncertain = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportAsDocxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSelectedFilesAsSeparateDocxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearchText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxPublisherScope = new System.Windows.Forms.ComboBox();
            this.comboBoxSearchAuthor = new System.Windows.Forms.ComboBox();
            this.comboBoxDocumentTypeScope = new System.Windows.Forms.ComboBox();
            this.checkBoxSearchTitle = new System.Windows.Forms.CheckBox();
            this.checkBoxSearchBody = new System.Windows.Forms.CheckBox();
            this.checkBoxSearchSummary = new System.Windows.Forms.CheckBox();
            this.buttonSaveOnFile = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelResultCount = new System.Windows.Forms.Label();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocumentSearchResult)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSearchScope
            // 
            this.labelSearchScope.AutoSize = true;
            this.labelSearchScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchScope.Location = new System.Drawing.Point(9, 56);
            this.labelSearchScope.Name = "labelSearchScope";
            this.labelSearchScope.Size = new System.Drawing.Size(104, 15);
            this.labelSearchScope.TabIndex = 13;
            this.labelSearchScope.Text = "Search Scope :";
            this.labelSearchScope.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewDocumentSearchResult
            // 
            this.dataGridViewDocumentSearchResult.AllowUserToAddRows = false;
            this.dataGridViewDocumentSearchResult.AllowUserToDeleteRows = false;
            this.dataGridViewDocumentSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDocumentSearchResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDocumentSearchResult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDocumentSearchResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSn,
            this.ColumnID,
            this.ColumnTitle,
            this.ColumnAuthor,
            this.ColumnDocumentType,
            this.ColumnCreatedDateNepali,
            this.ColumnCreatedDate,
            this.DateUncertain});
            this.dataGridViewDocumentSearchResult.ContextMenuStrip = this.contextMenuStripGrid;
            this.dataGridViewDocumentSearchResult.Location = new System.Drawing.Point(9, 96);
            this.dataGridViewDocumentSearchResult.Name = "dataGridViewDocumentSearchResult";
            this.dataGridViewDocumentSearchResult.ReadOnly = true;
            this.dataGridViewDocumentSearchResult.RowHeadersVisible = false;
            this.dataGridViewDocumentSearchResult.RowHeadersWidth = 4;
            this.dataGridViewDocumentSearchResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewDocumentSearchResult.RowTemplate.ReadOnly = true;
            this.dataGridViewDocumentSearchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDocumentSearchResult.ShowEditingIcon = false;
            this.dataGridViewDocumentSearchResult.Size = new System.Drawing.Size(696, 385);
            this.dataGridViewDocumentSearchResult.TabIndex = 12;
            this.dataGridViewDocumentSearchResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocumentSearchResult_CellDoubleClick);
            // 
            // ColumnSn
            // 
            this.ColumnSn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnSn.DataPropertyName = "SN";
            this.ColumnSn.FillWeight = 20F;
            this.ColumnSn.Frozen = true;
            this.ColumnSn.HeaderText = "S.N.";
            this.ColumnSn.MinimumWidth = 50;
            this.ColumnSn.Name = "ColumnSn";
            this.ColumnSn.ReadOnly = true;
            this.ColumnSn.Width = 50;
            // 
            // ColumnID
            // 
            this.ColumnID.DataPropertyName = "Id";
            this.ColumnID.FillWeight = 1F;
            this.ColumnID.HeaderText = "Id";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Visible = false;
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTitle.DataPropertyName = "Title";
            this.ColumnTitle.FillWeight = 219.7945F;
            this.ColumnTitle.HeaderText = "Title";
            this.ColumnTitle.MinimumWidth = 150;
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.ReadOnly = true;
            // 
            // ColumnAuthor
            // 
            this.ColumnAuthor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnAuthor.DataPropertyName = "Author";
            this.ColumnAuthor.FillWeight = 75F;
            this.ColumnAuthor.HeaderText = "Author";
            this.ColumnAuthor.MinimumWidth = 100;
            this.ColumnAuthor.Name = "ColumnAuthor";
            this.ColumnAuthor.ReadOnly = true;
            // 
            // ColumnDocumentType
            // 
            this.ColumnDocumentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnDocumentType.DataPropertyName = "DocumentType";
            this.ColumnDocumentType.FillWeight = 50F;
            this.ColumnDocumentType.HeaderText = "Document Type";
            this.ColumnDocumentType.MinimumWidth = 75;
            this.ColumnDocumentType.Name = "ColumnDocumentType";
            this.ColumnDocumentType.ReadOnly = true;
            this.ColumnDocumentType.Width = 108;
            // 
            // ColumnCreatedDateNepali
            // 
            this.ColumnCreatedDateNepali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnCreatedDateNepali.DataPropertyName = "NepaliDate";
            this.ColumnCreatedDateNepali.FillWeight = 50F;
            this.ColumnCreatedDateNepali.HeaderText = "Nepali Date";
            this.ColumnCreatedDateNepali.MinimumWidth = 75;
            this.ColumnCreatedDateNepali.Name = "ColumnCreatedDateNepali";
            this.ColumnCreatedDateNepali.ReadOnly = true;
            this.ColumnCreatedDateNepali.Width = 88;
            // 
            // ColumnCreatedDate
            // 
            this.ColumnCreatedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnCreatedDate.DataPropertyName = "EnglishDate";
            this.ColumnCreatedDate.FillWeight = 50F;
            this.ColumnCreatedDate.HeaderText = "English Date";
            this.ColumnCreatedDate.MinimumWidth = 75;
            this.ColumnCreatedDate.Name = "ColumnCreatedDate";
            this.ColumnCreatedDate.ReadOnly = true;
            this.ColumnCreatedDate.Width = 92;
            // 
            // DateUncertain
            // 
            this.DateUncertain.DataPropertyName = "DateUncertain";
            this.DateUncertain.HeaderText = "DateUncertain";
            this.DateUncertain.Name = "DateUncertain";
            this.DateUncertain.ReadOnly = true;
            this.DateUncertain.Visible = false;
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSelectedFilesAsSeparateDocxToolStripMenuItem,
            this.exportAsDocxToolStripMenuItem});
            this.contextMenuStripGrid.Name = "contextMenuStripGrid";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(248, 48);
            // 
            // exportAsDocxToolStripMenuItem
            // 
            this.exportAsDocxToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exportAsDocxToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportAsDocxToolStripMenuItem.Name = "exportAsDocxToolStripMenuItem";
            this.exportAsDocxToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.exportAsDocxToolStripMenuItem.Text = "Export selected files in single doc";
            this.exportAsDocxToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportAsDocxToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.exportAsDocxToolStripMenuItem.Click += new System.EventHandler(this.exportAsDocxToolStripMenuItem_Click);
            // 
            // exportSelectedFilesAsSeparateDocxToolStripMenuItem
            // 
            this.exportSelectedFilesAsSeparateDocxToolStripMenuItem.Name = "exportSelectedFilesAsSeparateDocxToolStripMenuItem";
            this.exportSelectedFilesAsSeparateDocxToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.exportSelectedFilesAsSeparateDocxToolStripMenuItem.Text = "Export selected files";
            this.exportSelectedFilesAsSeparateDocxToolStripMenuItem.Click += new System.EventHandler(this.exportSelectedFilesAsSeparateDocxToolStripMenuItem_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(599, 65);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(72, 23);
            this.buttonSearch.TabIndex = 11;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // textBoxSearchText
            // 
            this.textBoxSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchText.Enabled = false;
            this.textBoxSearchText.Location = new System.Drawing.Point(9, 11);
            this.textBoxSearchText.Name = "textBoxSearchText";
            this.textBoxSearchText.Size = new System.Drawing.Size(696, 20);
            this.textBoxSearchText.TabIndex = 10;
            this.textBoxSearchText.Text = "Insert text to search";
            this.textBoxSearchText.Enter += new System.EventHandler(this.textBoxSearchText_Enter);
            this.textBoxSearchText.Leave += new System.EventHandler(this.textBoxSearchText_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxPublisherScope);
            this.panel1.Controls.Add(this.comboBoxSearchAuthor);
            this.panel1.Controls.Add(this.comboBoxDocumentTypeScope);
            this.panel1.Controls.Add(this.checkBoxSearchTitle);
            this.panel1.Controls.Add(this.checkBoxSearchBody);
            this.panel1.Controls.Add(this.checkBoxSearchSummary);
            this.panel1.Location = new System.Drawing.Point(119, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 53);
            this.panel1.TabIndex = 14;
            // 
            // comboBoxPublisherScope
            // 
            this.comboBoxPublisherScope.DisplayMember = "Name";
            this.comboBoxPublisherScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPublisherScope.FormattingEnabled = true;
            this.comboBoxPublisherScope.Location = new System.Drawing.Point(3, 28);
            this.comboBoxPublisherScope.Name = "comboBoxPublisherScope";
            this.comboBoxPublisherScope.Size = new System.Drawing.Size(137, 21);
            this.comboBoxPublisherScope.TabIndex = 9;
            this.comboBoxPublisherScope.ValueMember = "Id";
            this.comboBoxPublisherScope.SelectedIndexChanged += new System.EventHandler(this.comboBoxPublisherScope_SelectedIndexChanged);
            // 
            // comboBoxSearchAuthor
            // 
            this.comboBoxSearchAuthor.DisplayMember = "Name";
            this.comboBoxSearchAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchAuthor.FormattingEnabled = true;
            this.comboBoxSearchAuthor.Location = new System.Drawing.Point(317, 28);
            this.comboBoxSearchAuthor.Name = "comboBoxSearchAuthor";
            this.comboBoxSearchAuthor.Size = new System.Drawing.Size(150, 21);
            this.comboBoxSearchAuthor.TabIndex = 8;
            this.comboBoxSearchAuthor.ValueMember = "Id";
            // 
            // comboBoxDocumentTypeScope
            // 
            this.comboBoxDocumentTypeScope.DisplayMember = "Name";
            this.comboBoxDocumentTypeScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDocumentTypeScope.FormattingEnabled = true;
            this.comboBoxDocumentTypeScope.Location = new System.Drawing.Point(160, 28);
            this.comboBoxDocumentTypeScope.Name = "comboBoxDocumentTypeScope";
            this.comboBoxDocumentTypeScope.Size = new System.Drawing.Size(137, 21);
            this.comboBoxDocumentTypeScope.TabIndex = 7;
            this.comboBoxDocumentTypeScope.ValueMember = "Id";
            this.comboBoxDocumentTypeScope.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocumentTypeScope_SelectedIndexChanged);
            // 
            // checkBoxSearchTitle
            // 
            this.checkBoxSearchTitle.AutoSize = true;
            this.checkBoxSearchTitle.Location = new System.Drawing.Point(7, 5);
            this.checkBoxSearchTitle.Name = "checkBoxSearchTitle";
            this.checkBoxSearchTitle.Size = new System.Drawing.Size(46, 17);
            this.checkBoxSearchTitle.TabIndex = 3;
            this.checkBoxSearchTitle.Text = "Title";
            this.checkBoxSearchTitle.UseVisualStyleBackColor = true;
            this.checkBoxSearchTitle.CheckedChanged += new System.EventHandler(this.SearchScopeCheckBox_CheckedChanged);
            // 
            // checkBoxSearchBody
            // 
            this.checkBoxSearchBody.AutoSize = true;
            this.checkBoxSearchBody.Location = new System.Drawing.Point(172, 5);
            this.checkBoxSearchBody.Name = "checkBoxSearchBody";
            this.checkBoxSearchBody.Size = new System.Drawing.Size(50, 17);
            this.checkBoxSearchBody.TabIndex = 3;
            this.checkBoxSearchBody.Text = "Body";
            this.checkBoxSearchBody.UseVisualStyleBackColor = true;
            this.checkBoxSearchBody.CheckedChanged += new System.EventHandler(this.SearchScopeCheckBox_CheckedChanged);
            // 
            // checkBoxSearchSummary
            // 
            this.checkBoxSearchSummary.AutoSize = true;
            this.checkBoxSearchSummary.Location = new System.Drawing.Point(78, 5);
            this.checkBoxSearchSummary.Name = "checkBoxSearchSummary";
            this.checkBoxSearchSummary.Size = new System.Drawing.Size(69, 17);
            this.checkBoxSearchSummary.TabIndex = 3;
            this.checkBoxSearchSummary.Text = "Summary";
            this.checkBoxSearchSummary.UseVisualStyleBackColor = true;
            this.checkBoxSearchSummary.CheckedChanged += new System.EventHandler(this.SearchScopeCheckBox_CheckedChanged);
            // 
            // buttonSaveOnFile
            // 
            this.buttonSaveOnFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveOnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveOnFile.Image = global::DocumentStore.Properties.Resources.Save16;
            this.buttonSaveOnFile.Location = new System.Drawing.Point(677, 65);
            this.buttonSaveOnFile.Name = "buttonSaveOnFile";
            this.buttonSaveOnFile.Size = new System.Drawing.Size(27, 23);
            this.buttonSaveOnFile.TabIndex = 28;
            this.buttonSaveOnFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSaveOnFile.UseVisualStyleBackColor = true;
            this.buttonSaveOnFile.Click += new System.EventHandler(this.buttonSaveOnFile_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(3, 3);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(97, 15);
            this.labelResult.TabIndex = 29;
            this.labelResult.Text = "Result Count :";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.labelResultCount);
            this.panel2.Controls.Add(this.labelResult);
            this.panel2.Location = new System.Drawing.Point(257, 484);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 22);
            this.panel2.TabIndex = 30;
            // 
            // labelResultCount
            // 
            this.labelResultCount.AutoSize = true;
            this.labelResultCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultCount.Location = new System.Drawing.Point(100, 3);
            this.labelResultCount.Name = "labelResultCount";
            this.labelResultCount.Size = new System.Drawing.Size(0, 15);
            this.labelResultCount.TabIndex = 30;
            this.labelResultCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBarExport
            // 
            this.progressBarExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarExport.Location = new System.Drawing.Point(9, 284);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(695, 23);
            this.progressBarExport.TabIndex = 31;
            this.progressBarExport.Visible = false;
            // 
            // UserControlSearchDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBarExport);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonSaveOnFile);
            this.Controls.Add(this.labelSearchScope);
            this.Controls.Add(this.dataGridViewDocumentSearchResult);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearchText);
            this.Controls.Add(this.panel1);
            this.Name = "UserControlSearchDocument";
            this.Size = new System.Drawing.Size(713, 506);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocumentSearchResult)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSearchScope;
        private System.Windows.Forms.DataGridView dataGridViewDocumentSearchResult;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearchText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxSearchAuthor;
        private System.Windows.Forms.ComboBox comboBoxDocumentTypeScope;
        private System.Windows.Forms.CheckBox checkBoxSearchTitle;
        private System.Windows.Forms.CheckBox checkBoxSearchBody;
        private System.Windows.Forms.CheckBox checkBoxSearchSummary;
        private System.Windows.Forms.Button buttonSaveOnFile;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelResultCount;
        private System.Windows.Forms.ComboBox comboBoxPublisherScope;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem exportAsDocxToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDocumentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreatedDateNepali;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreatedDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DateUncertain;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedFilesAsSeparateDocxToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBarExport;
    }
}
