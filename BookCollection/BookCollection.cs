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
            
            // Wire up event handlers (book entry functionality handled by another developer)
            btnViewBookDetails.Click += BtnViewBookDetails_Click;
            btnSearch.Click += BtnSearch_Click;
            btnSearchClear.Click += BtnSearchClear_Click;
            
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
        }

        private void RefreshBookList()
        {
            lstBooks.Items.Clear();
            foreach (Book book in collectionManager.ListAllBooks())
            {
                lstBooks.Items.Add(book);
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
