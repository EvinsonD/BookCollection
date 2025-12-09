using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookCollection
{
    public partial class BookCollection : Form
    {
        private BookCollectionManager collectionManager;

        public BookCollection()
        {
            InitializeComponent();
            collectionManager = new BookCollectionManager();

            InitializeForm();
        }

        private void InitializeForm()
        {
            // Populate search filter dropdown
            cboSearchFilter.Items.AddRange(new string[] { "Title", "Author", "Genre", "All" });
            cboSearchFilter.SelectedIndex = 3; // Default to "All"

            // Set placeholder text for search
            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;

            // Wire up event handlers for book entry buttons
            btnAddBook.Click += BtnAddBook_Click;
            btnUpdateBook.Click += BtnUpdateBook_Click;
            btnDeleteBook.Click += BtnDeleteBook_Click;
            btnMarkRead.Click += BtnMarkRead_Click;
            btnClearFields.Click += BtnClearFields_Click;

            // Wire up other event handlers
            btnViewBookDetails.Click += BtnViewBookDetails_Click;
            btnSearch.Click += BtnSearch_Click;
            btnSearchClear.Click += BtnSearchClear_Click;

            // Wire up list box selection changed event
            lstBooks.SelectedIndexChanged += lstBooks_SelectedIndexChanged;

            // Menu items
            saveCollectionToolStripMenuItem.Click += SaveCollectionToolStripMenuItem_Click;
            loadCollectionToolStripMenuItem.Click += LoadCollectionToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            authorsToolStripMenuItem.Click += AuthorsToolStripMenuItem_Click;
            genresToolStripMenuItem.Click += GenresToolStripMenuItem_Click;
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;

            RefreshBookList();
            RefreshDropdowns();
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void RefreshDropdowns()
        {
            cboAuthor.Items.Clear();
            cboGenre.Items.Clear();

            foreach (Author author in collectionManager.ListAllAuthors())
            {
                cboAuthor.Items.Add(author);
            }

            foreach (Genre genre in collectionManager.ListAllGenres())
            {
                cboGenre.Items.Add(genre);
            }

            // Add a default empty item
            if (cboAuthor.Items.Count > 0)
                cboAuthor.SelectedIndex = -1;
            if (cboGenre.Items.Count > 0)
                cboGenre.SelectedIndex = -1;
        }

        private void RefreshBookList()
        {
            lstBooks.Items.Clear();
            foreach (Book book in collectionManager.ListAllBooks())
            {
                lstBooks.Items.Add(book);
            }
        }

        // Book Entry Panel Button Handlers
        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Please enter a book title.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTitle.Focus();
                    return;
                }

                if (cboAuthor.SelectedItem == null)
                {
                    MessageBox.Show("Please select an author.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboAuthor.Focus();
                    return;
                }

                if (cboGenre.SelectedItem == null)
                {
                    MessageBox.Show("Please select a genre.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboGenre.Focus();
                    return;
                }

                // Parse year
                int year = 0;
                if (!string.IsNullOrWhiteSpace(txtYearPublished.Text))
                {
                    if (!int.TryParse(txtYearPublished.Text, out year))
                    {
                        MessageBox.Show("Please enter a valid year.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtYearPublished.Focus();
                        return;
                    }
                }

                // Get selected author and genre
                Author selectedAuthor = cboAuthor.SelectedItem as Author;
                Genre selectedGenre = cboGenre.SelectedItem as Genre;

                // Create new book
                int newBookID = collectionManager.GetNextBookID();
                Book newBook = new Book(
                    newBookID,
                    txtTitle.Text.Trim(),
                    selectedAuthor,
                    selectedGenre,
                    txtISBN.Text.Trim(),
                    year
                );

                // Set notes if provided
                if (!string.IsNullOrWhiteSpace(txtNotes.Text))
                {
                    newBook.SetNotes(txtNotes.Text.Trim());
                }

                // Add book to collection
                collectionManager.AddBook(newBook);

                // Refresh UI
                RefreshBookList();

                // Show success message
                MessageBox.Show($"Book '{newBook.Title}' added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields
                ClearEntryFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateBook_Click(object sender, EventArgs e)
        {
            if (lstBooks.SelectedItem == null)
            {
                MessageBox.Show("Please select a book to update from the list.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get selected book
                Book selectedBook = lstBooks.SelectedItem as Book;

                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Please enter a book title.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTitle.Focus();
                    return;
                }

                if (cboAuthor.SelectedItem == null)
                {
                    MessageBox.Show("Please select an author.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboAuthor.Focus();
                    return;
                }

                if (cboGenre.SelectedItem == null)
                {
                    MessageBox.Show("Please select a genre.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboGenre.Focus();
                    return;
                }

                // Parse year
                int year = 0;
                if (!string.IsNullOrWhiteSpace(txtYearPublished.Text))
                {
                    if (!int.TryParse(txtYearPublished.Text, out year))
                    {
                        MessageBox.Show("Please enter a valid year.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtYearPublished.Focus();
                        return;
                    }
                }

                // Get selected author and genre
                Author selectedAuthor = cboAuthor.SelectedItem as Author;
                Genre selectedGenre = cboGenre.SelectedItem as Genre;

                // Update book properties
                selectedBook.SetTitle(txtTitle.Text.Trim());
                selectedBook.SetISBN(txtISBN.Text.Trim());
                selectedBook.SetYearPublished(year);
                selectedBook.SetNotes(txtNotes.Text.Trim());
                selectedBook.SetAuthor(selectedAuthor);
                selectedBook.SetGenre(selectedGenre);

                // Refresh UI
                RefreshBookList();

                // Show success message
                MessageBox.Show($"Book '{selectedBook.Title}' updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields
                ClearEntryFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            if (lstBooks.SelectedItem == null)
            {
                MessageBox.Show("Please select a book to delete from the list.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Book selectedBook = lstBooks.SelectedItem as Book;

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete '{selectedBook.Title}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Remove book from collection
                    bool removed = collectionManager.RemoveBook(selectedBook.BookID);

                    if (removed)
                    {
                        // Refresh UI
                        RefreshBookList();
                        RefreshDropdowns();

                        // Show success message
                        MessageBox.Show($"Book '{selectedBook.Title}' deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear fields
                        ClearEntryFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the book.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMarkRead_Click(object sender, EventArgs e)
        {
            if (lstBooks.SelectedItem == null)
            {
                MessageBox.Show("Please select a book from the list.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Book selectedBook = lstBooks.SelectedItem as Book;

                // Toggle read status
                if (selectedBook.IsRead)
                {
                    selectedBook.MarkAsUnread();
                    MessageBox.Show($"'{selectedBook.Title}' marked as unread.", "Status Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    selectedBook.MarkAsRead();
                    MessageBox.Show($"'{selectedBook.Title}' marked as read.", "Status Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Refresh UI
                RefreshBookList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating book status: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearFields_Click(object sender, EventArgs e)
        {
            ClearEntryFields();
        }

        // Helper method to clear entry fields
        private void ClearEntryFields()
        {
            txtTitle.Clear();
            txtISBN.Clear();
            txtYearPublished.Clear();
            txtNotes.Clear();
            cboAuthor.SelectedIndex = -1;
            cboGenre.SelectedIndex = -1;
            txtTitle.Focus();
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBooks.SelectedItem != null)
            {
                Book selectedBook = lstBooks.SelectedItem as Book;
                if (selectedBook != null)
                {
                    // Load book details into entry fields
                    txtTitle.Text = selectedBook.Title;
                    txtISBN.Text = selectedBook.ISBN;
                    txtYearPublished.Text = selectedBook.YearPublished > 0 ?
                        selectedBook.YearPublished.ToString() : "";
                    txtNotes.Text = selectedBook.Notes;

                    // Select the author in the combo box
                    if (selectedBook.Author != null)
                    {
                        foreach (Author author in cboAuthor.Items)
                        {
                            if (author.AuthorID == selectedBook.Author.AuthorID)
                            {
                                cboAuthor.SelectedItem = author;
                                break;
                            }
                        }
                    }

                    // Select the genre in the combo box
                    if (selectedBook.Genre != null)
                    {
                        foreach (Genre genre in cboGenre.Items)
                        {
                            if (genre.GenreID == selectedBook.Genre.GenreID)
                            {
                                cboGenre.SelectedItem = genre;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void BtnViewBookDetails_Click(object sender, EventArgs e)
        {
            if (lstBooks.SelectedItem == null)
            {
                MessageBox.Show("Please select a book to view details.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book selectedBook = lstBooks.SelectedItem as Book;
            if (selectedBook != null)
            {
                BookDetails detailsForm = new BookDetails(selectedBook, collectionManager);
                detailsForm.ShowDialog();
                RefreshBookList();
                RefreshDropdowns();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            if (searchTerm == "Search..." || string.IsNullOrWhiteSpace(searchTerm))
            {
                RefreshBookList();
                return;
            }

            string searchType = cboSearchFilter.SelectedItem?.ToString() ?? "All";
            List<Book> results = collectionManager.SearchBooks(searchTerm, searchType);

            lstBooks.Items.Clear();
            foreach (Book book in results)
            {
                lstBooks.Items.Add(book);
            }
        }

        private void BtnSearchClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;
            cboSearchFilter.SelectedIndex = 3; // "All"
            RefreshBookList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Optional: Implement real-time search here if desired
        }

        // Menu Item Handlers
        private void SaveCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveDialog.DefaultExt = "txt";
            saveDialog.FileName = "BookCollection";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Simple text-based save (can be enhanced with JSON/XML serialization)
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(saveDialog.FileName);
                    writer.WriteLine("=== Book Collection ===");
                    writer.WriteLine($"Collection ID: {collectionManager.CollectionID}");
                    writer.WriteLine();

                    writer.WriteLine("=== Authors ===");
                    foreach (Author author in collectionManager.ListAllAuthors())
                    {
                        writer.WriteLine($"Author ID: {author.AuthorID}, Name: {author.GetName()}");
                    }
                    writer.WriteLine();

                    writer.WriteLine("=== Genres ===");
                    foreach (Genre genre in collectionManager.ListAllGenres())
                    {
                        writer.WriteLine($"Genre ID: {genre.GenreID}, Name: {genre.GetName()}, Description: {genre.GetDescription()}");
                    }
                    writer.WriteLine();

                    writer.WriteLine("=== Books ===");
                    foreach (Book book in collectionManager.ListAllBooks())
                    {
                        writer.WriteLine(book.GetBookInfo());
                        writer.WriteLine("---");
                    }

                    writer.Close();
                    MessageBox.Show("Collection saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving collection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Note: This is a basic implementation. For full persistence, use serialization
                    MessageBox.Show("Load functionality would require proper serialization.\nFor now, please use the Author and Genre managers to add data.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading collection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AuthorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorManager authorForm = new AuthorManager(collectionManager);
            authorForm.ShowDialog();
            RefreshDropdowns();
            RefreshBookList();
        }

        private void GenresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenreManager genreForm = new GenreManager(collectionManager);
            genreForm.ShowDialog();
            RefreshDropdowns();
            RefreshBookList();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Book Collection Manager\n\n" +
                "Version 1.0\n" +
                "Group 9\n" +
                "Elmer Ponce\n" +
                "Evinson Davilien\n\n" +
                "A simple application to manage your book collection.",
                "About Book Collection",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Public method to allow other forms to refresh this form's data
        public void RefreshData()
        {
            RefreshDropdowns();
            RefreshBookList();
        }
    }
}
