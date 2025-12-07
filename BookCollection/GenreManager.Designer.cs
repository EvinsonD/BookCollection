namespace BookCollection
{
    partial class GenreManager
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
            this.lblGenreName = new System.Windows.Forms.Label();
            this.txtGenreName = new System.Windows.Forms.TextBox();
            this.lblGenreDescription = new System.Windows.Forms.Label();
            this.txtGenreDescription = new System.Windows.Forms.TextBox();
            this.btnAddGenre = new System.Windows.Forms.Button();
            this.btnUpdateGenre = new System.Windows.Forms.Button();
            this.btnDeleteGenre = new System.Windows.Forms.Button();
            this.lstGenres = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGenreName
            // 
            this.lblGenreName.AutoSize = true;
            this.lblGenreName.Location = new System.Drawing.Point(52, 56);
            this.lblGenreName.Name = "lblGenreName";
            this.lblGenreName.Size = new System.Drawing.Size(58, 20);
            this.lblGenreName.TabIndex = 0;
            this.lblGenreName.Text = "Genre:";
            // 
            // txtGenreName
            // 
            this.txtGenreName.Location = new System.Drawing.Point(56, 96);
            this.txtGenreName.Name = "txtGenreName";
            this.txtGenreName.Size = new System.Drawing.Size(275, 26);
            this.txtGenreName.TabIndex = 1;
            // 
            // lblGenreDescription
            // 
            this.lblGenreDescription.AutoSize = true;
            this.lblGenreDescription.Location = new System.Drawing.Point(52, 161);
            this.lblGenreDescription.Name = "lblGenreDescription";
            this.lblGenreDescription.Size = new System.Drawing.Size(93, 20);
            this.lblGenreDescription.TabIndex = 2;
            this.lblGenreDescription.Text = "Description:";
            // 
            // txtGenreDescription
            // 
            this.txtGenreDescription.Location = new System.Drawing.Point(56, 202);
            this.txtGenreDescription.Name = "txtGenreDescription";
            this.txtGenreDescription.Size = new System.Drawing.Size(275, 26);
            this.txtGenreDescription.TabIndex = 3;
            // 
            // btnAddGenre
            // 
            this.btnAddGenre.Location = new System.Drawing.Point(54, 246);
            this.btnAddGenre.Name = "btnAddGenre";
            this.btnAddGenre.Size = new System.Drawing.Size(151, 45);
            this.btnAddGenre.TabIndex = 4;
            this.btnAddGenre.Text = "Add Genre";
            this.btnAddGenre.UseVisualStyleBackColor = true;
            // 
            // btnUpdateGenre
            // 
            this.btnUpdateGenre.Location = new System.Drawing.Point(55, 319);
            this.btnUpdateGenre.Name = "btnUpdateGenre";
            this.btnUpdateGenre.Size = new System.Drawing.Size(150, 45);
            this.btnUpdateGenre.TabIndex = 5;
            this.btnUpdateGenre.Text = "Update Genre";
            this.btnUpdateGenre.UseVisualStyleBackColor = true;
            // 
            // btnDeleteGenre
            // 
            this.btnDeleteGenre.Location = new System.Drawing.Point(55, 390);
            this.btnDeleteGenre.Name = "btnDeleteGenre";
            this.btnDeleteGenre.Size = new System.Drawing.Size(151, 45);
            this.btnDeleteGenre.TabIndex = 6;
            this.btnDeleteGenre.Text = "Delete Genre";
            this.btnDeleteGenre.UseVisualStyleBackColor = true;
            // 
            // lstGenres
            // 
            this.lstGenres.FormattingEnabled = true;
            this.lstGenres.ItemHeight = 20;
            this.lstGenres.Location = new System.Drawing.Point(54, 463);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.Size = new System.Drawing.Size(277, 104);
            this.lstGenres.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(54, 594);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 45);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // GenreManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 673);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstGenres);
            this.Controls.Add(this.btnDeleteGenre);
            this.Controls.Add(this.btnUpdateGenre);
            this.Controls.Add(this.btnAddGenre);
            this.Controls.Add(this.txtGenreDescription);
            this.Controls.Add(this.lblGenreDescription);
            this.Controls.Add(this.txtGenreName);
            this.Controls.Add(this.lblGenreName);
            this.Name = "GenreManager";
            this.Text = "GenreManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGenreName;
        private System.Windows.Forms.TextBox txtGenreName;
        private System.Windows.Forms.Label lblGenreDescription;
        private System.Windows.Forms.TextBox txtGenreDescription;
        private System.Windows.Forms.Button btnAddGenre;
        private System.Windows.Forms.Button btnUpdateGenre;
        private System.Windows.Forms.Button btnDeleteGenre;
        private System.Windows.Forms.ListBox lstGenres;
        private System.Windows.Forms.Button btnClose;
    }
}