namespace BookCollection
{
    partial class AuthorManager
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
            this.lblAuthorName = new System.Windows.Forms.Label();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnAddAuthor = new System.Windows.Forms.Button();
            this.btnUpdateAuthor = new System.Windows.Forms.Button();
            this.btnDeleteAuthor = new System.Windows.Forms.Button();
            this.lstAuthors = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAuthorName
            // 
            this.lblAuthorName.AutoSize = true;
            this.lblAuthorName.Location = new System.Drawing.Point(74, 109);
            this.lblAuthorName.Name = "lblAuthorName";
            this.lblAuthorName.Size = new System.Drawing.Size(128, 24);
            this.lblAuthorName.TabIndex = 0;
            this.lblAuthorName.Text = "Author Name:";
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Location = new System.Drawing.Point(74, 148);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(78, 20);
            this.lblBirthdate.TabIndex = 1;
            this.lblBirthdate.Text = "Birthdate:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(78, 184);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.Location = new System.Drawing.Point(86, 240);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(154, 41);
            this.btnAddAuthor.TabIndex = 3;
            this.btnAddAuthor.Text = "Add Author";
            this.btnAddAuthor.UseVisualStyleBackColor = true;
            // 
            // btnUpdateAuthor
            // 
            this.btnUpdateAuthor.Location = new System.Drawing.Point(86, 287);
            this.btnUpdateAuthor.Name = "btnUpdateAuthor";
            this.btnUpdateAuthor.Size = new System.Drawing.Size(154, 41);
            this.btnUpdateAuthor.TabIndex = 4;
            this.btnUpdateAuthor.Text = "Update Author";
            this.btnUpdateAuthor.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAuthor
            // 
            this.btnDeleteAuthor.Location = new System.Drawing.Point(86, 334);
            this.btnDeleteAuthor.Name = "btnDeleteAuthor";
            this.btnDeleteAuthor.Size = new System.Drawing.Size(154, 41);
            this.btnDeleteAuthor.TabIndex = 5;
            this.btnDeleteAuthor.Text = "Delete Author";
            this.btnDeleteAuthor.UseVisualStyleBackColor = true;
            // 
            // lstAuthors
            // 
            this.lstAuthors.FormattingEnabled = true;
            this.lstAuthors.ItemHeight = 20;
            this.lstAuthors.Location = new System.Drawing.Point(86, 391);
            this.lstAuthors.Name = "lstAuthors";
            this.lstAuthors.Size = new System.Drawing.Size(261, 124);
            this.lstAuthors.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(86, 533);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 41);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // AuthorManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 733);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstAuthors);
            this.Controls.Add(this.btnDeleteAuthor);
            this.Controls.Add(this.btnUpdateAuthor);
            this.Controls.Add(this.btnAddAuthor);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblBirthdate);
            this.Controls.Add(this.lblAuthorName);
            this.Name = "AuthorManager";
            this.Text = "BookList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAuthorName;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnAddAuthor;
        private System.Windows.Forms.Button btnUpdateAuthor;
        private System.Windows.Forms.Button btnDeleteAuthor;
        private System.Windows.Forms.ListBox lstAuthors;
        private System.Windows.Forms.Button btnClose;
    }
}