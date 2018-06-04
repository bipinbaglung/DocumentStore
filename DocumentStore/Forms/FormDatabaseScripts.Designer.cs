namespace DocumentStore
{
    partial class FormDatabaseScripts
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
            this.textBoxScripts = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxScripts
            // 
            this.textBoxScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScripts.Location = new System.Drawing.Point(13, 13);
            this.textBoxScripts.Multiline = true;
            this.textBoxScripts.Name = "textBoxScripts";
            this.textBoxScripts.ReadOnly = true;
            this.textBoxScripts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxScripts.Size = new System.Drawing.Size(430, 416);
            this.textBoxScripts.TabIndex = 0;
            // 
            // FormDatabaseScripts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 441);
            this.Controls.Add(this.textBoxScripts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDatabaseScripts";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormDatabaseScripts";
            this.Load += new System.EventHandler(this.FormDatabaseScripts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxScripts;
    }
}