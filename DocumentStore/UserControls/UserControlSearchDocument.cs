using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Xceed.Words.NET;

namespace DocumentStore
{
    public partial class UserControlSearchDocument : UserControl
    {
        string highlightText;
        public UserControlSearchDocument()
        {
            InitializeComponent();
        }

        #region Load UI
        public void LoadControlUI()
        {
            LoadDocumentTypes();
            LoadPublishers();
            LoadAuthors();
        }

        private void LoadPublishers()
        {
            DataTable dt = GetPublishers();
            DataRow dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Name"] = "All";
            dt.Rows.InsertAt(dr, 0);
            comboBoxPublisherScope.DataSource = dt;
        }

        private DataTable GetPublishers()
        {
            string query = "SELECT Id, Name FROM tbl_PublisherInfo WITH (NOLOCK) ORDER BY Name";
            return DBSupport.GetDataTable(query);
        }


        private void LoadDocumentTypes()
        {
            long publisher = comboBoxPublisherScope.SelectedValue == null ? 0 : (long)comboBoxPublisherScope.SelectedValue;
            DataTable dt = GetDocumentType(publisher);
            DataRow dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Name"] = "All";
            dt.Rows.InsertAt(dr, 0);
            comboBoxDocumentTypeScope.DataSource = dt;
        }

        private DataTable GetDocumentType(long publisher)
        {
            string query = "SELECT Id, Name FROM tbl_DocumentType WITH (NOLOCK) ORDER BY Name";
            if (publisher > 0)
                query = @"SELECT DISTINCT DT.Id, DT.Name 
                        FROM tbl_DocumentType DT WITH (NOLOCK)
                        , tbl_DocumentInfo DI WITH (NOLOCK) 
                        WHERE DT.ID = DI.DocumentType AND DI.Publisher = @Publisher
                        ORDER BY DT.Name";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@Publisher", SqlDbType.BigInt).Value = publisher;
                return DBSupport.ExecuteQueryAndGetDataTable(cmd);
            }
        }

        private void LoadAuthors()
        {
            long publisher = comboBoxPublisherScope.SelectedValue == null ? 0 : (long)comboBoxPublisherScope.SelectedValue;
            long documentType = comboBoxDocumentTypeScope.SelectedValue == null ? 0 : (long)comboBoxDocumentTypeScope.SelectedValue;
            DataTable dt = GetAuthors(publisher, documentType);
            DataRow dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Name"] = "All";
            dt.Rows.InsertAt(dr, 0);
            comboBoxSearchAuthor.DataSource = dt;
        }

        private DataTable GetAuthors(long publisher, long documentType)
        {
            string query = "SELECT Id, Name FROM tbl_AuthorInfo WITH (NOLOCK)";

            if (publisher > 0 && documentType > 0)
                query = @"SELECT DISTINCT AI.Id, AI.Name 
                        FROM tbl_AuthorInfo AI WITH (NOLOCK)
                        , tbl_DocumentInfo DI WITH (NOLOCK) 
                        WHERE AI.ID = DI.Author AND DI.Publisher = @Publisher AND  DI.DocumentType = @DocumentType 
                        ORDER BY AI.Name";
            else if (documentType > 0)
                query = @"SELECT DISTINCT AI.Id, AI.Name 
                        FROM tbl_AuthorInfo AI WITH (NOLOCK)
                        , tbl_DocumentInfo DI WITH (NOLOCK) 
                        WHERE AI.ID = DI.Author AND DI.DocumentType = @DocumentType
                        ORDER BY AI.Name";
            else if (publisher > 0)
                query = @"SELECT DISTINCT AI.Id, AI.Name 
                        FROM tbl_AuthorInfo AI WITH (NOLOCK)
                        , tbl_DocumentInfo DI WITH (NOLOCK) 
                        WHERE AI.ID = DI.Author AND DI.Publisher = @Publisher
                        ORDER BY AI.Name";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@DocumentType", SqlDbType.BigInt).Value = documentType;
                cmd.Parameters.Add("@Publisher", SqlDbType.BigInt).Value = publisher;
                return DBSupport.ExecuteQueryAndGetDataTable(cmd);
            }
        }

        #endregion

        #region UI Enhancements

        private void textBoxSearchText_Enter(object sender, EventArgs e)
        {
            if (textBoxSearchText.Text == "Insert text to search")
                textBoxSearchText.Text = "";
        }

        private void textBoxSearchText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearchText.Text))
                textBoxSearchText.Text = "Insert text to search";
        }
        #endregion

        private void ShowMessageBox(string message, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            MessageBox.Show(message, "Document Store", buttons, icon);
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (ValidateSearchInputs())
            {
                Search();
            }
        }

        private void Search()
        {
            string searchText = textBoxSearchText.Text;
            long publisher = (long)comboBoxPublisherScope.SelectedValue;
            long documentType = (long)comboBoxDocumentTypeScope.SelectedValue;
            long author = (long)comboBoxSearchAuthor.SelectedValue;

            string whereClause = string.Empty;
            if (publisher != 0)
                whereClause = " Publisher = " + publisher;

            if (documentType != 0)
            {
                if (!string.IsNullOrWhiteSpace(whereClause))
                    whereClause += " AND DocumentType =" + documentType;
                else
                    whereClause = " DocumentType = " + documentType;

            }
            if (author != 0)
            {
                if (!string.IsNullOrWhiteSpace(whereClause))
                    whereClause += " AND Author =" + author;
                else
                    whereClause = " Author = " + author;
            }

            string stringClause = string.Empty;

            if (checkBoxSearchTitle.Checked)
                stringClause = " CONTAINS(Title, N'\"" + searchText + "\"') ";

            if (checkBoxSearchSummary.Checked)
                if (string.IsNullOrWhiteSpace(stringClause))
                    stringClause = " CONTAINS(Summary,  N'\"" + searchText + "\"') ";
                else
                    stringClause += " OR CONTAINS(Summary, N'\"" + searchText + "\"') ";

            if (checkBoxSearchBody.Checked)
                if (string.IsNullOrWhiteSpace(stringClause))
                    stringClause = " CONTAINS(Body, N'\"" + searchText + "\"') ";
                else
                    stringClause += " OR CONTAINS(Body, N'\"" + searchText + "\"') ";

            if (string.IsNullOrWhiteSpace(whereClause))
                whereClause = stringClause;
            else if (!string.IsNullOrWhiteSpace(stringClause))
                whereClause += " AND (" + stringClause + ")";

            if (!string.IsNullOrWhiteSpace(whereClause))
                whereClause = " WHERE " + whereClause;

            string query = @"SELECT ROW_NUMBER() OVER (ORDER BY DI.CreatedDate DESC, DI.Id DESC) AS SN, DI.Id, AI.Name AS Author, Title, DT.Name as DocumentType,  '' AS NepaliDate, CreatedDate AS EnglishDate, DateUncertain
                                FROM tbl_DocumentInfo DI WITH (NOLOCK)
	                                 LEFT JOIN tbl_PublisherInfo PI WITH (NOLOCK) ON DI.Publisher = PI.Id
	                                 LEFT JOIN tbl_DocumentType DT WITH (NOLOCK) ON DI.DocumentType = DT.Id
	                                 LEFT JOIN tbl_AuthorInfo AI WITH (NOLOCK) ON AI.Id = DI.Author
                                 " + whereClause;

            DataTable dt = DBSupport.GetDataTable(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime engDate = DateTime.Parse(dr["EnglishDate"].ToString());
                    NepaliDateTime nepaliDate = DateConverter.EnglishToNepNepali(engDate);
                    bool isUncertain = bool.Parse(dr["DateUncertain"].ToString());
                    dr["NepaliDate"] = nepaliDate.ToString() + (isUncertain ? " *" : "");
                }
                labelResultCount.Text = dt.Rows.Count.ToString();
            }
            else
                labelResultCount.Text = "0";

            dataGridViewDocumentSearchResult.DataSource = dt;
            dataGridViewDocumentSearchResult.AutoResizeColumns();
            if (!string.IsNullOrWhiteSpace(stringClause))
                highlightText = searchText;

        }

        private bool ValidateSearchInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxSearchText.Text) || textBoxSearchText.Text.Equals("Insert text to search"))
            {
                if (checkBoxSearchTitle.Checked || checkBoxSearchSummary.Checked || checkBoxSearchBody.Checked)
                {
                    ShowMessageBox("Please enter search text.");
                    return false;
                }
            }
            return true;
        }

        private void comboBoxPublisherScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDocumentTypes();
            LoadAuthors();
        }

        private void comboBoxDocumentTypeScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAuthors();
        }

        private void SearchScopeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchBody.Checked || checkBoxSearchSummary.Checked || checkBoxSearchTitle.Checked)
                textBoxSearchText.Enabled = true;
            else
            {
                textBoxSearchText.Text = "Insert text to search";
                textBoxSearchText.Enabled = false;
            }
        }

        private void dataGridViewDocumentSearchResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                long documentId = long.Parse(dataGridViewDocumentSearchResult["ColumnID", e.RowIndex].Value.ToString());
                FormUpdateDeleteDocument formUpdateDocument = new FormUpdateDeleteDocument(documentId);
                formUpdateDocument.highlightText = highlightText;
                formUpdateDocument.ShowDialog(this);
                if (formUpdateDocument.DocumentUpdated)
                    ButtonSearch_Click(null, null);
            }
        }

        private void buttonSaveOnFile_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable resultTable = (dataGridViewDocumentSearchResult.DataSource as DataTable);

                if (resultTable != null && resultTable.Rows.Count > 0)
                {
                    SaveFileDialog saveFile = new SaveFileDialog()
                    {
                        FileName = comboBoxSearchAuthor.Text + "_" + comboBoxDocumentTypeScope.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx"
                    };
                    if (DialogResult.OK == saveFile.ShowDialog())
                    {
                        Microsoft.Office.Interop.Excel.Application excel = null;
                        Microsoft.Office.Interop.Excel.Workbooks workbooks = null;
                        Microsoft.Office.Interop.Excel.Workbook workbook = null;
                        Microsoft.Office.Interop.Excel.Worksheet searchResultSheet = null;
                        try
                        {
                            excel = new Microsoft.Office.Interop.Excel.Application();
                            excel.Visible = false;

                            workbooks = excel.Workbooks;
                            workbook = workbooks.Add();
                            searchResultSheet = workbook.ActiveSheet;

                            int i = 1;
                            foreach (DataColumn column in resultTable.Columns)
                            {
                                if (!column.Caption.Equals("ID", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    searchResultSheet.Cells[2, i] = column.Caption;
                                    i++;
                                }
                            }

                            long rowIndex = 3;
                            foreach (DataRow row in resultTable.Rows)
                            {
                                int columnIndex = 1;

                                foreach (DataColumn column in row.Table.Columns)
                                {
                                    if (!column.Caption.Equals("ID", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        searchResultSheet.Cells[rowIndex, columnIndex] = row[column.ColumnName];
                                        columnIndex++;
                                    }
                                }
                                rowIndex++;
                            }

                            object saveFileName = saveFile.FileName;
                            workbook.Close(true, saveFileName);
                            excel.Workbooks.Close();
                            ShowMessageBox("Document created successfully !");
                        }
                        finally
                        {
                            if (searchResultSheet != null)
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(searchResultSheet);
                            if (workbook != null)
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                            if (workbooks != null)
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
                            excel.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                            searchResultSheet = null;
                            workbook = null;
                            workbooks = null;
                            excel = null;

                        }
                    }
                }
                else
                    ShowMessageBox("Nothing found to save.");
            }
            catch (Exception ex)
            {
                ShowMessageBox("Could not save file. Error : " + ex.Message);
            }
        }

        private void exportAsDocxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewDocumentSearchResult.SelectedRows;
            if (selectedRows.Count > 0)
            {
                try
                {
                    SaveFileDialog saveFile = new SaveFileDialog()
                    {
                        FileName = "FileFromSearch.docx",
                        Filter = "Document | *.docx",
                        DefaultExt = "docx"
                    };

                    if (DialogResult.OK == saveFile.ShowDialog())
                    {
                        string saveFileName = saveFile.FileName;
                        if (!Path.GetExtension(saveFile.FileName).Equals("." + saveFile.DefaultExt, StringComparison.InvariantCultureIgnoreCase))
                            saveFileName = saveFile.FileName + "." + saveFile.DefaultExt;
                        DocX newDocument = DocX.Create(saveFileName);

                        for (int i = selectedRows.Count - 1; i >= 0; i--)
                        {
                            object fileId = selectedRows[i].Cells["ColumnID"].Value;


                            string query = @"SELECT DI.Title, DI.Body, DI.CreatedDate AS EnglishDate, AI.Name as Author
                                FROM tbl_DocumentInfo DI WITH (NOLOCK),
	                                tbl_AuthorInfo AI WITH(NOLOCK) 
                                WHERE DI.Author = AI.Id
									AND DI.Id = @Id";

                            using (SqlCommand command = new SqlCommand(query))
                            {
                                command.Parameters.Add("@Id", SqlDbType.BigInt).Value = fileId;
                                DataTable dt = DBSupport.ExecuteQueryAndGetDataTable(command);
                                if (dt != null)
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        DateTime engDate = DateTime.Parse(dr["EnglishDate"].ToString());
                                        NepaliDateTime nepaliDate = DateConverter.EnglishToNepNepali(engDate);
                                        AppendInfoToDocument(newDocument, dr["Title"].ToString(), dr["Author"].ToString(), dr["Body"].ToString()
                                            , nepaliDate.ToString());
                                    }
                            }
                        }

                        newDocument.Save();
                        ShowMessageBox("Document created successfully !");
                    }
                }
                catch (Exception ex)
                {
                    ShowMessageBox("Could not save file. Error : " + ex.Message);
                }
            }
            else
            { }
        }

        private void exportSelectedFilesAsSeparateDocxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewDocumentSearchResult.SelectedRows;
            if (selectedRows.Count > 0)
            {
                int incrementValue = 100 / selectedRows.Count;
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                try
                {
                    if (DialogResult.OK == folderBrowserDialog.ShowDialog())
                    {
                        progressBarExport.Show();
                        string today = NepaliDateTime.Now.ToDateTimeString();
                        for (int i = selectedRows.Count - 1; i >= 0; i--)
                        {
                            try
                            {
                                object fileId = selectedRows[i].Cells["ColumnID"].Value;

                                string query = @"SELECT DI.Title, DI.Body, DI.CreatedDate AS EnglishDate, AI.Name as Author
                                FROM tbl_DocumentInfo DI WITH (NOLOCK),
	                                tbl_AuthorInfo AI WITH(NOLOCK) 
                                WHERE DI.Author = AI.Id
									AND DI.Id = @Id";

                                using (SqlCommand command = new SqlCommand(query))
                                {
                                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = fileId;
                                    DataTable dt = DBSupport.ExecuteQueryAndGetDataTable(command);
                                    if (dt != null)
                                    {
                                        string folderPath = Path.Combine(folderBrowserDialog.SelectedPath, today);
                                        if (!Directory.Exists(folderPath))
                                            Directory.CreateDirectory(folderPath);

                                        DateTime engDate = DateTime.Parse(dt.Rows[0]["EnglishDate"].ToString());
                                        NepaliDateTime nepaliDate = DateConverter.EnglishToNepNepali(engDate);
                                        string filename = dt.Rows[0]["Title"].ToString() + "_" + nepaliDate.ToString();
                                        string saveFileName = Path.Combine(folderPath, filename + ".docx");
                                        using (DocX newDocument = DocX.Create(saveFileName))
                                        {
                                            AppendInfoToDocument(newDocument, dt.Rows[0]["Title"].ToString(), dt.Rows[0]["Author"].ToString()
                                                , dt.Rows[0]["Body"].ToString(), nepaliDate.ToString());
                                            newDocument.Save();
                                        }
                                    }
                                }

                                progressBarExport.Increment(incrementValue);
                            }
                            catch (Exception ex)
                            {
                                ShowMessageBox("Could not save files. Error : " + ex.Message);
                            }
                        }
                        ShowMessageBox("Documents created successfully !");
                    }
                }
                catch (Exception ex)
                {
                    ShowMessageBox("Could not save files. Error : " + ex.Message);
                }
                finally
                {
                    progressBarExport.Hide();
                }
            }
            else
            { }
        }

        private void AppendInfoToDocument(DocX newDocument, string title, string author, string body, string dateString)
        {
            Formatting titleFormat = new Formatting();
            titleFormat.Bold = true;
            Paragraph paraTitle = newDocument.InsertParagraph(title, false, titleFormat);
            paraTitle.Alignment = Alignment.center;
            paraTitle.LineSpacingAfter = 15;
            newDocument.InsertParagraph(author);
            newDocument.InsertParagraph();
            newDocument.InsertParagraph(body);
            newDocument.InsertParagraph();
            newDocument.InsertParagraph(dateString + Environment.NewLine);
            newDocument.InsertParagraph();
        }
    }
}
