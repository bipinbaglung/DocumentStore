﻿using NPOI.XWPF.UserModel;
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
    public partial class UserControlViewDocument : UserControl
    {
        private long _documentId;
        public long DocumentId { get { return _documentId; } set { _documentId = value; } }

        private string _author;
        private string _title;
        private string _createdDate;
        private string _documentType;
        private string _body;

        public delegate void EditClick();
        public event EditClick OnEditClick;
        public UserControlViewDocument()
        {
            InitializeComponent();
        }

        public UserControlViewDocument(long documentId)
            : base()
        {
            _documentId = documentId;
        }

        public void LoadControlUI(List<string> highlightTerms)
        {
            LoadDocumentForView();
            HighlightText(highlightTerms);
        }
        private void LoadDocumentForView()
        {
            try
            {
                string query = @"SELECT Title, AI.Name as Author, Body, DT.Name as DocumentType, DI.CreatedDate, DI.DateUncertain
                                FROM tbl_DocumentInfo DI WITH(NOLOCK),
	                                tbl_AuthorInfo AI WITH(NOLOCK),
									tbl_DocumentType DT WITH (NOLOCK)
                                WHERE DI.Author = AI.Id
									AND DI.DocumentType = DT.Id
                                    AND DI.Id = @documentId";

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.Add("@documentId", SqlDbType.BigInt).Value = _documentId;
                    DataTable dt = DBSupport.ExecuteQueryAndGetDataTable(cmd);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        _title = dt.Rows[0]["Title"].ToString();
                        _author = dt.Rows[0]["Author"].ToString();
                        _documentType = dt.Rows[0]["DocumentType"].ToString();
                        NepaliDateTime nepaliDate = DateConverter.EnglishToNepali(DateTime.Parse(dt.Rows[0]["CreatedDate"].ToString()));
                        bool isUncertain = bool.Parse(dt.Rows[0]["DateUncertain"].ToString());
                        _createdDate = nepaliDate.Year + "-" + nepaliDate.Month.ToString("00") + "-" + nepaliDate.Day.ToString("00") + (isUncertain ? " *" : "");
                        _body = dt.Rows[0]["Body"].ToString();

                        AppendText(richTextBoxDocumentContent, _title, new Font("Arial", 14, FontStyle.Bold), HorizontalAlignment.Center);
                        AppendText(richTextBoxDocumentContent, Environment.NewLine, alignment: HorizontalAlignment.Center);
                        AppendText(richTextBoxDocumentContent, Environment.NewLine);
                        AppendText(richTextBoxDocumentContent, _author, new Font("Arial", 12), HorizontalAlignment.Center);
                        AppendText(richTextBoxDocumentContent, Environment.NewLine, alignment: HorizontalAlignment.Center);
                        AppendText(richTextBoxDocumentContent, Environment.NewLine);
                        AppendText(richTextBoxDocumentContent, _body, new Font("Arial", 12), HorizontalAlignment.Left);
                        AppendText(richTextBoxDocumentContent, Environment.NewLine);
                        AppendText(richTextBoxDocumentContent, Environment.NewLine);
                        AppendText(richTextBoxDocumentContent, _createdDate, new Font("Arial", 12), HorizontalAlignment.Left, isUncertain ? Color.Red : Color.Black);
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

        private void AppendText(RichTextBox textbox, string text, Font font = null, HorizontalAlignment alignment = HorizontalAlignment.Left, Color? color = null)
        {
            int startPosition = textbox.Text.Length;
            int selectionLength = text.Length;
            textbox.AppendText(text);
            textbox.SelectionStart = startPosition;
            textbox.SelectionLength = selectionLength;
            textbox.SelectionAlignment = alignment;
            if (font != null)
                textbox.SelectionFont = font;
            textbox.SelectionColor = color ?? Color.Black;
            textbox.SelectionStart = 0;
            textbox.SelectionLength = 0;
            textbox.ScrollToCaret();
        }

        private void buttonSaveOnFile_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog()
                {
                    FileName = _documentType + "_" + _author + "_" + _createdDate + ".docx",
                    Filter = "Document | *.docx",
                    DefaultExt = "docx"
                };
                if (DialogResult.OK == saveFile.ShowDialog())
                {
                    string saveFileName = saveFile.FileName;
                    if (!Path.GetExtension(saveFile.FileName).Equals("." + saveFile.DefaultExt, StringComparison.InvariantCultureIgnoreCase))
                        saveFileName = saveFile.FileName + "." + saveFile.DefaultExt;

                    using (var fs = new FileStream(saveFileName, FileMode.Create, FileAccess.Write))
                    {
                        XWPFDocument doc = new XWPFDocument();
                        var paraTitle = doc.CreateParagraph();
                        paraTitle.Alignment = ParagraphAlignment.CENTER;
                        paraTitle.SpacingAfter = 15;
                        XWPFRun runTitle = paraTitle.CreateRun();
                        runTitle.IsBold = true;
                        runTitle.SetText(_title);
                        doc.CreateParagraph();
                        doc.CreateParagraph().CreateRun().SetText(_author);
                        doc.CreateParagraph();

                        using (TextReader textReader = new StringReader(_body))
                        {
                            string line;
                            while ((line = textReader.ReadLine()) != null)
                            {
                                var paraBody = doc.CreateParagraph();
                                paraBody.Alignment = ParagraphAlignment.BOTH;
                                paraBody.CreateRun().SetText(line);
                            }
                        }
                        doc.CreateParagraph();

                        doc.Write(fs);
                    }
                    ShowMessageBox("Document created successfully !");
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox("Could not save file." + Environment.NewLine + " Error : " + ex.Message, MessageBoxIcon.Error);
            }
        }

        string textToPrint = string.Empty;

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            textToPrint = _title + Environment.NewLine
                + " - " + _author + Environment.NewLine
                + Environment.NewLine + "    " + _body
                + Environment.NewLine + _createdDate;

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;
                if (DialogResult.OK == printDialog.ShowDialog())
                    printDocument.Print();
            }
            catch (Exception ex)
            {
                ShowMessageBox("Could not print file." + Environment.NewLine + " Error: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.MeasureString(textToPrint, new Font("Times New Roman", 10, FontStyle.Regular),
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out int charactersOnPage, out int linesPerPage);

            e.Graphics.DrawString(textToPrint, new Font("Times New Roman", 10), Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            textToPrint = textToPrint.Substring(charactersOnPage);

            e.HasMorePages = (textToPrint.Length > 0);
        }

        private void HighlightText(List<string> highlightTerms)
        {
            if (highlightTerms.Count>0)
            {
                int totalMatchCount = 0;
                foreach (string text in highlightTerms)
                {
                    Regex regExp = new Regex(text, RegexOptions.IgnoreCase);
                    MatchCollection matches = regExp.Matches(richTextBoxDocumentContent.Text);
                    labelMatchCount.Visible = true;
                    totalMatchCount += matches.Count;
                    foreach (Match match in matches)
                    {
                        richTextBoxDocumentContent.Select(match.Index, match.Length);
                        richTextBoxDocumentContent.SelectionBackColor = Color.Yellow;
                    }
                }
                labelMatchCount.Text = totalMatchCount.ToString();
            }
            else
                labelMatchCount.Visible = false;
        }
        private DialogResult ShowMessageBox(string message, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            return MessageBox.Show(message, "Document Store", buttons, icon);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            OnEditClick?.Invoke();
        }

        private void AddFileToListViewImages(string fullFilePath)
        {
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

                        fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(fullFilePath);
                        imageListLarge.Images.Add(fileName, fileIcon);
                    }
                    listViewItem.ImageKey = fileName;
                }
            }
            listViewItem.SubItems.Add(fullFilePath);
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
    }
}
