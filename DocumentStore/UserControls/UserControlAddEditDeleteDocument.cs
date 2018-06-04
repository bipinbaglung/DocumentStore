using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DocumentStore
{
    public partial class UserControlAddEditDeleteDocument : UserControl
    {
        private Mode _openMode = Mode.ADD;
        private long _documentId;

        public long DocumentId { get { return _documentId; } set { _documentId = value; } }
        public Mode OpenMode { get { return _openMode; } set { _openMode = value; } }

        public delegate void DocumentUpdate();
        public event DocumentUpdate OnDocumentUpdate;

        public UserControlAddEditDeleteDocument()
        {
            InitializeComponent();

        }
        public UserControlAddEditDeleteDocument(long documentId)
            : base()
        {
            _openMode = Mode.UPDATE;
            _documentId = documentId;
        }

        #region Load UI
        public void LoadControlUI()
        {
            LoadDocumentType();
            LoadPublishers();
            LoadNepaliDate();
            LoadAuthors();
            if (_openMode == Mode.UPDATE)
            {
                LoadDocumentForUpdate();
                buttonInsert.Text = "Update";
                buttonClear.Text = "Delete";
                buttonCancel.Visible = true;
            }
            SetTotalCount();
        }

        private void SetTotalCount()
        {
            using (SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM  tbl_DocumentInfo WITH (NOLOCK)"))
            {
                object count = DBSupport.ExecuteScalar(command);
                if (count != null && count != DBNull.Value)
                    labelTotalFileCount.Text = count.ToString();
            }
        }

        private void LoadPublishers()
        {
            comboBoxPublisher.DataSource = GetPublishersForAddDocument();
        }

        private void LoadDocumentType()
        {
            comboBoxDocumentType.DataSource = GetDocumentTypeForAddDocument();
        }

        private void LoadAuthors()
        {
            comboBoxAuthor.DataSource = GetAuthorsForAddDocument();
        }

        private void LoadNepaliDate()
        {
            NepaliDateTime nepaliDate = DateConverter.EnglishToNepNepali(dateTimePickerCreatedDate.Value);
            textBoxNepaliDate.Text = nepaliDate.Year + "." + nepaliDate.Month.ToString("00") + "." + nepaliDate.Day.ToString("00");
        }

        private DataTable GetPublishersForAddDocument()
        {
            DataTable dt = GetPublishers();
            DataRow dr = dt.NewRow();
            dr["Id"] = -1;
            dr["Name"] = "< Add new publisher >";
            dt.Rows.InsertAt(dr, 0);
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Name"] = "Select publisher";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        private DataTable GetDocumentTypeForAddDocument()
        {
            DataTable dt = GetDocumentType();
            DataRow dr = dt.NewRow();
            dr["Id"] = -1;
            dr["Name"] = "< Add new document type >";
            dt.Rows.InsertAt(dr, 0);
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Name"] = "Select document type";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        private DataTable GetPublishers()
        {
            string query = "SELECT Id, Name FROM tbl_PublisherInfo WITH (NOLOCK) ORDER BY Name";
            return DBSupport.GetDataTable(query);
        }
        private DataTable GetDocumentType()
        {
            string query = "SELECT Id, Name FROM tbl_DocumentType WITH (NOLOCK) ORDER BY Name";
            return DBSupport.GetDataTable(query);
        }

        private DataTable GetAuthorsForAddDocument()
        {
            return GetAuthors(0);
        }

        private DataTable GetAuthors(long documentType)
        {
            string query = "SELECT Id, Name FROM tbl_AuthorInfo WITH (NOLOCK) ORDER BY Name";
            if (documentType > 0)
                query = @"SELECT AI.Id, AI.Name 
                        FROM tbl_AuthorInfo AI WITH (NOLOCK)
                        , tbl_DocumentInfo DI WITH (NOLOCK) 
                        WHERE AI.ID = DI.Author AND DI.DocumentType = @DocumentType
                        ORDER BY AI.Name";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@DocumentType", SqlDbType.BigInt).Value = documentType;
                return DBSupport.ExecuteQueryAndGetDataTable(cmd);
            }
        }

        private void LoadDocumentForUpdate()
        {
            try
            {
                string query = "SELECT * FROM tbl_DocumentInfo WITH (NOLOCK) WHERE Id = @documentId";

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.Add("@documentId", SqlDbType.BigInt).Value = _documentId;
                    DataTable dt = DBSupport.ExecuteQueryAndGetDataTable(cmd);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        textBoxName.Text = dt.Rows[0]["Name"].ToString();
                        textBoxTitle.Text = dt.Rows[0]["Title"].ToString();
                        textBoxSummary.Text = dt.Rows[0]["Summary"].ToString();
                        textBoxBody.Text = dt.Rows[0]["Body"].ToString();
                        comboBoxAuthor.SelectedValue = long.Parse(dt.Rows[0]["Author"].ToString());
                        comboBoxDocumentType.SelectedValue = long.Parse(dt.Rows[0]["DocumentType"].ToString());
                        comboBoxPublisher.SelectedValue = long.Parse(dt.Rows[0]["Publisher"].ToString());
                        dateTimePickerCreatedDate.Value = DateTime.Parse(dt.Rows[0]["CreatedDate"].ToString());
                         checkBoxDateUncertain.Checked = bool.Parse(dt.Rows[0]["DateUncertain"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Requested document could not be retrieved from database.");
                        this.ParentForm.Close();
                    }
                    cmd.CommandText = @"SELECT ImageId, ImagePath FROM tbl_DocumentImageAssociation(NOLOCK) DIA, tbl_ImageInfo(NoLock) II 
                                        WHERE DIA.ImageId = II.Id AND DIA.DocumentId = @documentId";
                    dt = DBSupport.ExecuteQueryAndGetDataTable(cmd);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            AddFileToListViewImages(dr["ImagePath"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could load document. Error : " + ex.Message);
                this.ParentForm.Close();
            }
        }

        #endregion

        private void DeleteDocument()
        {
            try
            {
                string query = @"DELETE FROM tbl_DocumentInfo WHERE Id = @documentId;
                                 DELETE FROM II FROM tbl_ImageInfo II, tbl_DocumentImageAssociation DIA  WHERE DIA.ImageId = II.Id AND DIA.DocumentId = @DocumentID
                                 DELETE FROM tbl_DocumentImageAssociation WHERE DocumentId = @documentId";

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.Add("@documentId", SqlDbType.BigInt).Value = _documentId;
                    DBSupport.ExecuteNonQuery(cmd);
                }
                MessageBox.Show("File deleted successfully.");
                OnDocumentUpdate?.Invoke();
                this.ParentForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could load delete document document. Error : " + ex.Message);
            }
        }

        private bool ValidateInsertDocumentInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || textBoxName.Text.Equals("Name"))
            {
                ShowMessageBox("Please enter document name.");
                return false;
            }

            if (comboBoxAuthor.SelectedValue == null || (long)comboBoxAuthor.SelectedValue < 1)
            {
                ShowMessageBox("Please select author.");
                return false;
            }

            if (comboBoxDocumentType.SelectedIndex < 2)
            {
                ShowMessageBox("Please select document type.");
                return false;
            }

            if (comboBoxPublisher.SelectedIndex < 2)
            {
                ShowMessageBox("Please select publisher.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text) || textBoxTitle.Text.Equals("Title"))
            {
                ShowMessageBox("Please enter document title.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxBody.Text) || textBoxBody.Text.Equals("Body"))
            {
                ShowMessageBox("Please enter document body.");
                return false;
            }


            return true;
        }

        private bool DoesPossibleDuplicateExists()
        {
            string query = @"Select TOP 1 1 FROM  tbl_DocumentInfo WITH (NOLOCK) WHERE DocumentType =@DocumentType AND Author = @Author AND CreatedDate = @CreatedDate";

            try
            {
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.Add("@CreatedDate", SqlDbType.NVarChar).Value = dateTimePickerCreatedDate.Value;
                    command.Parameters.Add("@DocumentType", SqlDbType.BigInt).Value = comboBoxDocumentType.SelectedValue;
                    command.Parameters.Add("@Author", SqlDbType.BigInt).Value = comboBoxAuthor.SelectedValue;
                    object value = DBSupport.ExecuteScalar(command);
                    if (value == null || value == DBNull.Value)
                        return false;
                    else
                        return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #region UI Enhancements
        private void ClearDocumentAddUI()
        {
            textBoxName.Text = "Name";
            textBoxTitle.Text = "Title";
            textBoxSummary.Text = "Summary";
            textBoxBody.Text = "Body";
            dateTimePickerCreatedDate.Value = DateTime.Now;
            imageListLarge.Images.Clear();
            listViewImages.Items.Clear();
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Name")
                textBoxName.Text = "";
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
                textBoxName.Text = "Name";
        }

        private void textBoxTitle_Enter(object sender, EventArgs e)
        {
            if (textBoxTitle.Text == "Title")
                textBoxTitle.Text = "";
            if (textBoxName.Text == "Name" && comboBoxDocumentType.SelectedIndex > 1)
                textBoxName.Text = comboBoxDocumentType.Text + "_" + comboBoxAuthor.Text + "_" + textBoxNepaliDate.Text;
        }

        private void textBoxTitle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
                textBoxTitle.Text = "Title";
        }

        private void textBoxSummary_Enter(object sender, EventArgs e)
        {
            if (textBoxSummary.Text == "Summary")
                textBoxSummary.Text = "";
        }

        private void textBoxSummary_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSummary.Text))
                textBoxSummary.Text = "Summary";
        }

        private void textBoxBody_Enter(object sender, EventArgs e)
        {
            if (textBoxBody.Text == "Body")
                textBoxBody.Text = "";
        }

        private void textBoxBody_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBody.Text))
                textBoxBody.Text = "Body";
        }

        private void TextBoxNepaliDate_Leave(object sender, EventArgs e)
        {
            try
            {
                string[] dateFromBox = textBoxNepaliDate.Text.Split('.');
                NepaliDateTime nepaliDateTime = new NepaliDateTime()
                {
                    Year = int.Parse(dateFromBox[0]),
                    Month = int.Parse(dateFromBox[1]),
                    Day = int.Parse(dateFromBox[2])
                };
                DateTime engDate = DateConverter.NepaliToEnglish(nepaliDateTime);
                dateTimePickerCreatedDate.Value = engDate;
            }
            catch
            {
                LoadNepaliDate();
            }
            if (comboBoxDocumentType.SelectedIndex > 1)
                textBoxName.Text = comboBoxDocumentType.Text + "_" + comboBoxAuthor.Text + "_" + textBoxNepaliDate.Text;
        }

        #endregion

        private DialogResult ShowMessageBox(string message, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            return MessageBox.Show(message, "Document Store", buttons, icon);
        }

        #region UI Events

        private void comboBoxDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDocumentType.SelectedIndex == 1)
            {
                FormAddDocumentType formAddDocumentType = new FormAddDocumentType();
                formAddDocumentType.ShowDialog(this);
                LoadDocumentType();
                comboBoxDocumentType.SelectedValue = formAddDocumentType.DocumentId;
            }
            if (comboBoxDocumentType.SelectedIndex > 1)
                textBoxName.Text = comboBoxDocumentType.Text + "_" + comboBoxAuthor.Text + "_" + textBoxNepaliDate.Text;
        }
        private void comboBoxPublisher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPublisher.SelectedIndex == 1)
            {
                FormAddPublisher formAddPublisher = new FormAddPublisher();
                formAddPublisher.ShowDialog(this);
                LoadPublishers();
                comboBoxPublisher.SelectedValue = formAddPublisher.PublisherId;
            }
        }

        private void comboBoxAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDocumentType.SelectedIndex > 1)
                textBoxName.Text = comboBoxDocumentType.Text + "_" + comboBoxAuthor.Text + "_" + textBoxNepaliDate.Text;
        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            if (ValidateInsertDocumentInputs())
            {
                if (_openMode == Mode.ADD)
                {
                    if (DoesPossibleDuplicateExists())
                    {
                        string message = "A file with same Author , Document Type and Created date already exists. This may be a duplicate." + Environment.NewLine + " Are you sure to continue?";
                        if (DialogResult.Yes != ShowMessageBox(message, MessageBoxIcon.Question, MessageBoxButtons.YesNo))
                        {
                            return;
                        }
                    }
                    string query = @"INSERT INTO tbl_DocumentInfo 
                                        (Name, Title, Summary, Body, CreatedDate, DateUncertain, DocumentType, Publisher, Author, InsertedDate)
                                    VALUES (@Name, @Title, @Summary, @Body, @CreatedDate, @DateUncertain, @DocumentType, @Publisher, @Author, GetDate()) 
                                    SELECT SCOPE_IDENTITY();";

                    try
                    {
                        using (SqlCommand command = new SqlCommand(query))
                        {
                            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = textBoxName.Text;
                            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = textBoxTitle.Text;
                            command.Parameters.Add("@Summary", SqlDbType.NVarChar).Value = textBoxSummary.Text.Trim().Equals("Summary") ? "" : textBoxSummary.Text;
                            command.Parameters.Add("@Body", SqlDbType.NVarChar).Value = textBoxBody.Text;
                            command.Parameters.Add("@CreatedDate", SqlDbType.NVarChar).Value = dateTimePickerCreatedDate.Value;
                            command.Parameters.Add("@DateUncertain", SqlDbType.Bit).Value = checkBoxDateUncertain.Checked;
                            command.Parameters.Add("@Publisher", SqlDbType.BigInt).Value = comboBoxPublisher.SelectedValue;
                            command.Parameters.Add("@DocumentType", SqlDbType.BigInt).Value = comboBoxDocumentType.SelectedValue;
                            command.Parameters.Add("@Author", SqlDbType.BigInt).Value = comboBoxAuthor.SelectedValue;
                            object docId = DBSupport.ExecuteScalar(command);
                            InsertImages(long.Parse(docId.ToString()));
                            MessageBox.Show("Document successfully added.");
                            OnDocumentUpdate?.Invoke();
                            ClearDocumentAddUI();
                            SetTotalCount();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (_openMode == Mode.UPDATE)
                {
                    string message = "Once the document is updated it couldn't be reverted to previous. Are you sure you want to update document?";
                    if (DialogResult.Yes == ShowMessageBox(message, MessageBoxIcon.Question, MessageBoxButtons.YesNo))
                    {
                        string query = @"UPDATE tbl_DocumentInfo 
                                            SET Name = @Name, 
                                                Title = @Title, 
                                                Summary = @Summary, 
                                                Body = @Body, 
                                                CreatedDate = @CreatedDate, 
                                                DateUncertain = @DateUncertain, 
                                                DocumentType = @DocumentType, 
                                                Publisher = @Publisher, 
                                                Author = @Author, 
                                                UpdatedDate = GetDate() 
                                        WHERE Id = @documentId";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(query))
                            {
                                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = textBoxName.Text;
                                command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = textBoxTitle.Text;
                                command.Parameters.Add("@Summary", SqlDbType.NVarChar).Value = textBoxSummary.Text.Trim().Equals("Summary") ? "" : textBoxSummary.Text;
                                command.Parameters.Add("@Body", SqlDbType.NVarChar).Value = textBoxBody.Text;
                                command.Parameters.Add("@CreatedDate", SqlDbType.NVarChar).Value = dateTimePickerCreatedDate.Value;
                                command.Parameters.Add("@DateUncertain", SqlDbType.Bit).Value = checkBoxDateUncertain.Checked;
                                command.Parameters.Add("@DocumentType", SqlDbType.BigInt).Value = comboBoxDocumentType.SelectedValue;
                                command.Parameters.Add("@Publisher", SqlDbType.BigInt).Value = comboBoxPublisher.SelectedValue;
                                command.Parameters.Add("@Author", SqlDbType.BigInt).Value = comboBoxAuthor.SelectedValue;
                                command.Parameters.Add("@documentId", SqlDbType.BigInt).Value = _documentId;
                                DBSupport.ExecuteNonQuery(command);
                                InsertImages(DocumentId);
                                MessageBox.Show("Document successfully updated.");
                                OnDocumentUpdate?.Invoke();
                                this.ParentForm.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            string author = comboBoxAuthor.Text.Trim();
            if (string.IsNullOrWhiteSpace(author) || author.Equals("Select author", StringComparison.InvariantCultureIgnoreCase))
            {
                ShowMessageBox("Please add author name.");
                return;
            }
            string query = @" IF NOT EXISTS(SELECT * FROM tbl_AuthorInfo WHERE Name = @Name)
                               INSERT INTO  tbl_AuthorInfo (Name , InsertedDate) values (@Name,GetDate()) ";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = author;
                long authorId = DBSupport.ExecuteNonQueryWithIdentity(cmd);
                if (authorId == -1)
                    ShowMessageBox("Author already exists. Please enter another type.");
                else if (authorId > 0)
                {
                    ShowMessageBox("Author added successfully");
                    LoadAuthors();
                    comboBoxAuthor.SelectedValue = authorId;
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (_openMode == Mode.ADD)
                ClearDocumentAddUI();
            else if (_openMode == Mode.UPDATE)
            {
                string message = "Once the document is deleted it couldn't be recovered. Are you sure you want to delete document?";
                if (DialogResult.Yes == ShowMessageBox(message, MessageBoxIcon.Question, MessageBoxButtons.YesNo))
                {
                    DeleteDocument();
                    SetTotalCount();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void dateTimePickerCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            LoadNepaliDate();
        }
        #endregion

        #region Images
        private void buttonAddImages_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Images| *.bmp; *.gif; *.jpg; *.jpeg; *.png; *.tiff; *.tif | All files | *.*";
            openFileDialog.ShowDialog();

            string[] files = openFileDialog.FileNames;
            foreach (string file in files)
                AddFileToListViewImages(file);
        }

        private void AddFileToListViewImages(string fullFilePath)
        {
            foreach (ListViewItem item in listViewImages.Items)
            {
                if (Path.GetFullPath(fullFilePath).Equals(Path.GetFullPath(item.SubItems[1].Text), StringComparison.InvariantCultureIgnoreCase))
                    return;
            }

            string fileName = Path.GetFileName(fullFilePath);
            ListViewItem listViewItem = listViewImages.Items.Add(fileName);
            if (File.Exists(fullFilePath))
            {
                string extension = Path.GetExtension(fullFilePath);
                Regex fileExtensions = new Regex(@".bmp|.gif|.jpg|.jpeg|.png|.tiff|.tif");
                if (fileExtensions.IsMatch(extension))
                {
                    imageListLarge.Images.Add(fileName, Image.FromFile(fullFilePath));
                    listViewItem.ImageIndex = imageListLarge.Images.Count - 1;
                }
                else
                {
                    Icon fileIcon = SystemIcons.WinLogo;
                    if (!imageListLarge.Images.ContainsKey(fileName))
                    {

                        fileIcon = Icon.ExtractAssociatedIcon(fullFilePath);
                        imageListLarge.Images.Add(fileName, fileIcon);
                    }
                    listViewItem.ImageKey = fileName;
                }
            }
            listViewItem.SubItems.Add(fullFilePath);
        }

        private void listViewImages_DragDrop(object sender, DragEventArgs e)
        {
            string[] handles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string handle in handles)
            {
                if (File.Exists(handle))
                {
                    AddFileToListViewImages(handle);
                }
                else if (Directory.Exists(handle))
                {
                    DirectoryInfo di = new DirectoryInfo(handle);
                    FileInfo[] files = di.GetFiles();
                    foreach (FileInfo file in files)
                        AddFileToListViewImages(file.FullName);
                }
            }
        }

        private void listViewImages_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                string message = "Are you sure to remove the images?";
                if (_openMode == Mode.UPDATE)
                    message = "The images will be deleted permanently. Are you sure to remove the images?";
                if (DialogResult.Yes == MessageBox.Show(this, message, "Delete Images", MessageBoxButtons.YesNo))
                {
                    foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
                    {
                        listViewItem.Remove();
                    }
                }
            }
        }

        private void listViewImages_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void listViewImages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var senderList = (ListView)sender;
            var clickedItem = senderList.HitTest(e.Location).Item;
            if (clickedItem != null)
            {
                System.Diagnostics.Process.Start(clickedItem.SubItems[1].Text);
            }
        }

        private bool InsertImages(long documentId)
        {
            List<long> imageIds = new List<long>();
            foreach (ListViewItem item in listViewImages.Items)
            {
                string sourcePath = item.SubItems[1].Text.Trim();
                string query = "SELECT II.ID FROM tbl_ImageInfo(NoLock) II, tbl_DocumentImageAssociation(NoLock) DIA  WHERE DIA.ImageId = II.Id AND DIA.DocumentId = @DocumentID AND II.ImagePath = @imagePath";
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.Add("@imagePath", SqlDbType.NVarChar).Value = sourcePath;
                    command.Parameters.Add("@DocumentID", SqlDbType.BigInt).Value = documentId;
                    object value = DBSupport.ExecuteScalar(command);
                    string oldDirectory = Path.GetDirectoryName(sourcePath);
                    string documentType = comboBoxDocumentType.Text;
                    string fileName = textBoxNepaliDate.Text + "_" + comboBoxAuthor.Text + "_" + Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(sourcePath);
                    string destinationPath = Path.Combine(ConfigValues.FileSaveRootLocation, documentType, fileName);
                    string newDirectory = Path.GetDirectoryName(destinationPath);
                    if (!oldDirectory.Equals(newDirectory, StringComparison.InvariantCultureIgnoreCase))
                    {
                        try
                        {
                            CopyFileToDestination(sourcePath, destinationPath);

                            command.CommandText = @"DECLARE @ImageID BigInt
                                               INSERT INTO tbl_ImageInfo (Name, ImagePath, InsertedDate) VALUES (@fileName, @imagePath, GetDate());
                                               SET @ImageID =  SCOPE_IDENTITY()
                                               INSERT INTO tbl_DocumentImageAssociation (DocumentId, ImageId , InsertedDate) VALUES(@DocumentID, @ImageID, GetDate())
                                               SELECT @ImageID";
                            command.Parameters.Clear();
                            command.Parameters.Add("@imagePath", SqlDbType.NVarChar).Value = destinationPath;
                            command.Parameters.Add("@DocumentID", SqlDbType.BigInt).Value = documentId;
                            command.Parameters.Add("@fileName", SqlDbType.NVarChar).Value = fileName;
                            object imageId = DBSupport.ExecuteScalar(command);
                            imageIds.Add(long.Parse(imageId.ToString()));
                        }
                        catch (IOException ex)
                        {
                            throw new IOException("Could not save file to disk. Error :" + ex.Message, ex);
                        }
                    }
                    else
                    {
                        imageIds.Add(long.Parse(value.ToString()));
                    }
                }
            }
            DeleteImages(documentId, imageIds);
            return true;
        }

        private void DeleteImages(long documentId, List<long> imageIds)
        {
            imageIds.Add(0);
            string deleteQuery = @"
                                SELECT ImagePath FROM tbl_ImageInfo II, tbl_DocumentImageAssociation DIA  WHERE DIA.ImageId = II.Id AND DIA.DocumentId = @DocumentID AND II.ID NOT IN(" + string.Join(",", imageIds) + @")
                                DELETE FROM II FROM tbl_ImageInfo II, tbl_DocumentImageAssociation DIA  WHERE DIA.ImageId = II.Id AND DIA.DocumentId = @DocumentID AND II.ID NOT IN(" + string.Join(",", imageIds) + @")
                                DELETE FROM tbl_DocumentImageAssociation WHERE DocumentId = @documentId AND ImageId NOT  IN(" + string.Join(",", imageIds) + @")";
            
            using (SqlCommand cmd = new SqlCommand(deleteQuery))
            {
                cmd.Parameters.Add("@documentId", SqlDbType.BigInt).Value = documentId;
                DataTable filesToDelete = DBSupport.ExecuteQueryAndGetDataTable(cmd);
                if (filesToDelete != null && filesToDelete.Rows.Count > 0)
                {
                    foreach (DataRow dr in filesToDelete.Rows)
                    {
                        DeleteFile(dr["ImagePath"].ToString());
                    }
                }
            }
        }

        private void CopyFileToDestination(string sourcePath, string destinationPath, bool deleteOriginal = false)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
            File.Copy(sourcePath, destinationPath);
            if (deleteOriginal)
            {
                DeleteFile(sourcePath);
            }
        }

        private void DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                ShowMessageBox("Could not delete file. Error :" + ex.Message + Environment.NewLine
                    + "Please delete it manually." + Environment.NewLine
                    + filePath, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
