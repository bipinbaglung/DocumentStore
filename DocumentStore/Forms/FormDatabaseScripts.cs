using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentStore
{
    public partial class FormDatabaseScripts : Form
    {
        public FormDatabaseScripts()
        {
            InitializeComponent();
        }

        private void FormDatabaseScripts_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            textBoxScripts.Text = @"
CREATE TABLE [dbo].[tbl_DocumentInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[Title] [nvarchar](1024) NULL,
	[Summary] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[DocumentType] [bigint] NOT NULL,
	[Publisher] [bigint] NOT NULL,
    [Author] [bigint] NOT NULL,
	[CreatedDate] [datetime] NULL,
    [DateUncertain] [bit] NOT NULL CONSTRAINT DF_tbl_DocumentInfo_DateUncertain DEFAULT(0),
	[InsertedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]

CREATE TABLE [dbo].[tbl_DocumentType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[InsertedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]

CREATE TABLE [dbo].[tbl_AuthorInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[InsertedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]

CREATE TABLE [dbo].[tbl_PublisherInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[InsertedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]

CREATE TABLE [dbo].[tbl_ImageInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
	[Caption] [nvarchar](1024) NULL,
	[Summary] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[InsertedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[tbl_DocumentImageAssociation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DocumentId] [bigint] NOT NULL,
	[ImageId] [bigint] NOT NULL,
	[InsertedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]
";
        }
    }
}
