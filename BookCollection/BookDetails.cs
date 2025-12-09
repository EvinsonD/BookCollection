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
    public partial class BookDetails : Form
    {
        private Book book;
        private BookCollectionManager collectionManager;

        public BookDetails(Book selectedBook, BookCollectionManager manager)
        {
            InitializeComponent();
            book = selectedBook;
            collectionManager = manager;
            
            InitializeForm();
        }

        private void InitializeForm()
        {
            btnSaveNotes.Click += BtnSaveNotes_Click;
            btnMarkReadDetail.Click += BtnMarkReadDetail_Click;
            btnClose.Click += BtnClose_Click;
            
            LoadBookDetails();
        }

        private void LoadBookDetails()
        {
            if (book == null)
            {
                MessageBox.Show("No book selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Display book information
            lblTitleValue.Text = book.GetTitle();
            lblISBNValue.Text = !string.IsNullOrWhiteSpace(book.ISBN) ? book.ISBN : "N/A";
            lblAuthorValue.Text = book.GetAuthor() != null ? book.GetAuthor().GetName() : "Unknown";
            lblGenreValue.Text = book.GetGenre() != null ? book.GetGenre().GetName() : "Unknown";
            lblYearValue.Text = book.YearPublished > 0 ? book.YearPublished.ToString() : "N/A";
            lblStatusValue.Text = book.IsReadStatus() ? "Read" : "Unread";
            txtDetailsNotes.Text = book.GetNotes();
            
            // Update button text based on read status
            if (book.IsReadStatus())
            {
                btnMarkReadDetail.Text = "Mark as Unread";
            }
            else
            {
                btnMarkReadDetail.Text = "Mark as Read";
            }
        }

        private void BtnSaveNotes_Click(object sender, EventArgs e)
        {
            if (book == null)
                return;

            try
            {
                book.SetNotes(txtDetailsNotes.Text);
                MessageBox.Show("Notes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving notes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMarkReadDetail_Click(object sender, EventArgs e)
        {
            if (book == null)
                return;

            try
            {
                if (book.IsReadStatus())
                {
                    book.MarkAsUnread();
                    lblStatusValue.Text = "Unread";
                    btnMarkReadDetail.Text = "Mark as Read";
                    MessageBox.Show("Book marked as unread.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    book.MarkAsRead();
                    lblStatusValue.Text = "Read";
                    btnMarkReadDetail.Text = "Mark as Unread";
                    MessageBox.Show("Book marked as read!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating read status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
