namespace BookCollection
{
    partial class BookCollection
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
            this.lblBookEntry = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnUpdateBook = new System.Windows.Forms.Button();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnMarkRead = new System.Windows.Forms.Button();
            this.btnClearFields = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtYearPublished = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.cboAuthor = new System.Windows.Forms.ComboBox();
            this.lblBooks = new System.Windows.Forms.Label();
            this.lstBooks = new System.Windows.Forms.ListBox();
            this.btnViewBookDetails = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboSearchFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSearchClear = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBookEntry
            // 
            this.lblBookEntry.AutoSize = true;
            this.lblBookEntry.Location = new System.Drawing.Point(70, 100);
            this.lblBookEntry.Name = "lblBookEntry";
            this.lblBookEntry.Size = new System.Drawing.Size(131, 20);
            this.lblBookEntry.TabIndex = 0;
            this.lblBookEntry.Text = "Book Entry Panel";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(70, 143);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(42, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title:";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(70, 183);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(51, 20);
            this.lblISBN.TabIndex = 2;
            this.lblISBN.Text = "ISBN:";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(70, 228);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(58, 20);
            this.lblGenre.TabIndex = 3;
            this.lblGenre.Text = "Genre:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(67, 279);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(61, 20);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "Author:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(70, 325);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(47, 20);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "Year:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(70, 369);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(55, 20);
            this.lblNotes.TabIndex = 6;
            this.lblNotes.Text = "Notes:";
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(95, 425);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(91, 39);
            this.btnAddBook.TabIndex = 7;
            this.btnAddBook.Text = "Add";
            this.btnAddBook.UseVisualStyleBackColor = true;
            // 
            // btnUpdateBook
            // 
            this.btnUpdateBook.Location = new System.Drawing.Point(205, 425);
            this.btnUpdateBook.Name = "btnUpdateBook";
            this.btnUpdateBook.Size = new System.Drawing.Size(91, 39);
            this.btnUpdateBook.TabIndex = 8;
            this.btnUpdateBook.Text = "Update";
            this.btnUpdateBook.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(95, 481);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(91, 39);
            this.btnDeleteBook.TabIndex = 9;
            this.btnDeleteBook.Text = "Delete";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            // 
            // btnMarkRead
            // 
            this.btnMarkRead.Location = new System.Drawing.Point(206, 481);
            this.btnMarkRead.Name = "btnMarkRead";
            this.btnMarkRead.Size = new System.Drawing.Size(90, 39);
            this.btnMarkRead.TabIndex = 10;
            this.btnMarkRead.Text = "Read";
            this.btnMarkRead.UseVisualStyleBackColor = true;
            // 
            // btnClearFields
            // 
            this.btnClearFields.Location = new System.Drawing.Point(130, 537);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(132, 39);
            this.btnClearFields.TabIndex = 11;
            this.btnClearFields.Text = "Clear Fields";
            this.btnClearFields.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(136, 137);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(186, 26);
            this.txtTitle.TabIndex = 12;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(136, 177);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(186, 26);
            this.txtISBN.TabIndex = 13;
            // 
            // txtYearPublished
            // 
            this.txtYearPublished.Location = new System.Drawing.Point(136, 319);
            this.txtYearPublished.Name = "txtYearPublished";
            this.txtYearPublished.Size = new System.Drawing.Size(186, 26);
            this.txtYearPublished.TabIndex = 16;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(136, 363);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(186, 26);
            this.txtNotes.TabIndex = 17;
            // 
            // cboGenre
            // 
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(136, 220);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(186, 28);
            this.cboGenre.TabIndex = 18;
            // 
            // cboAuthor
            // 
            this.cboAuthor.FormattingEnabled = true;
            this.cboAuthor.Location = new System.Drawing.Point(136, 271);
            this.cboAuthor.Name = "cboAuthor";
            this.cboAuthor.Size = new System.Drawing.Size(186, 28);
            this.cboAuthor.TabIndex = 19;
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Location = new System.Drawing.Point(685, 153);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(143, 20);
            this.lblBooks.TabIndex = 20;
            this.lblBooks.Text = "Books in Collection";
            // 
            // lstBooks
            // 
            this.lstBooks.FormattingEnabled = true;
            this.lstBooks.ItemHeight = 20;
            this.lstBooks.Location = new System.Drawing.Point(689, 188);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(470, 164);
            this.lstBooks.TabIndex = 21;
            // 
            // btnViewBookDetails
            // 
            this.btnViewBookDetails.Location = new System.Drawing.Point(689, 484);
            this.btnViewBookDetails.Name = "btnViewBookDetails";
            this.btnViewBookDetails.Size = new System.Drawing.Size(147, 36);
            this.btnViewBookDetails.TabIndex = 22;
            this.btnViewBookDetails.Text = "View Details";
            this.btnViewBookDetails.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(689, 388);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(267, 26);
            this.txtSearch.TabIndex = 23;
            this.txtSearch.Text = "Search...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cboSearchFilter
            // 
            this.cboSearchFilter.FormattingEnabled = true;
            this.cboSearchFilter.Location = new System.Drawing.Point(689, 436);
            this.cboSearchFilter.Name = "cboSearchFilter";
            this.cboSearchFilter.Size = new System.Drawing.Size(267, 28);
            this.cboSearchFilter.TabIndex = 24;
            this.cboSearchFilter.Text = "Search by: Title / Author / Genre";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1012, 382);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(147, 38);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnSearchClear
            // 
            this.btnSearchClear.Location = new System.Drawing.Point(1012, 430);
            this.btnSearchClear.Name = "btnSearchClear";
            this.btnSearchClear.Size = new System.Drawing.Size(147, 38);
            this.btnSearchClear.TabIndex = 26;
            this.btnSearchClear.Text = "Clearch Search";
            this.btnSearchClear.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1189, 33);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCollectionToolStripMenuItem,
            this.loadCollectionToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveCollectionToolStripMenuItem
            // 
            this.saveCollectionToolStripMenuItem.Name = "saveCollectionToolStripMenuItem";
            this.saveCollectionToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveCollectionToolStripMenuItem.Text = "Save Collection";
            // 
            // loadCollectionToolStripMenuItem
            // 
            this.loadCollectionToolStripMenuItem.Name = "loadCollectionToolStripMenuItem";
            this.loadCollectionToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.loadCollectionToolStripMenuItem.Text = "Load Collection";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorsToolStripMenuItem,
            this.genresToolStripMenuItem});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // authorsToolStripMenuItem
            // 
            this.authorsToolStripMenuItem.Name = "authorsToolStripMenuItem";
            this.authorsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.authorsToolStripMenuItem.Text = "Authors";
            // 
            // genresToolStripMenuItem
            // 
            this.genresToolStripMenuItem.Name = "genresToolStripMenuItem";
            this.genresToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.genresToolStripMenuItem.Text = "Genres";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(864, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Book List Panel";
            // 
            // BookCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 718);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboSearchFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnViewBookDetails);
            this.Controls.Add(this.lstBooks);
            this.Controls.Add(this.lblBooks);
            this.Controls.Add(this.cboAuthor);
            this.Controls.Add(this.cboGenre);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtYearPublished);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnClearFields);
            this.Controls.Add(this.btnMarkRead);
            this.Controls.Add(this.btnDeleteBook);
            this.Controls.Add(this.btnUpdateBook);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblBookEntry);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BookCollection";
            this.Text = "Book Collection";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBookEntry;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnUpdateBook;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnMarkRead;
        private System.Windows.Forms.Button btnClearFields;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtYearPublished;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.ComboBox cboAuthor;
        private System.Windows.Forms.Label lblBooks;
        private System.Windows.Forms.ListBox lstBooks;
        private System.Windows.Forms.Button btnViewBookDetails;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboSearchFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSearchClear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

