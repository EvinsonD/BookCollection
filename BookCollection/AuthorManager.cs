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
    public partial class AuthorManager : Form
    {
        private BookCollectionManager collectionManager;
        private Author selectedAuthor;

        public AuthorManager(BookCollectionManager manager)
        {
            InitializeComponent();
            collectionManager = manager;
            selectedAuthor = null;
            
            InitializeForm();
        }

        private void InitializeForm()
        {
            btnAddAuthor.Click += BtnAddAuthor_Click;
            btnUpdateAuthor.Click += BtnUpdateAuthor_Click;
            btnDeleteAuthor.Click += BtnDeleteAuthor_Click;
            btnClose.Click += BtnClose_Click;
            lstAuthors.SelectedIndexChanged += LstAuthors_SelectedIndexChanged;
            
            RefreshAuthorList();
        }

        private void RefreshAuthorList()
        {
            lstAuthors.Items.Clear();
            foreach (Author author in collectionManager.ListAllAuthors())
            {
                lstAuthors.Items.Add(author);
            }
        }

        private void LstAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAuthors.SelectedItem != null)
            {
                selectedAuthor = lstAuthors.SelectedItem as Author;
                if (selectedAuthor != null)
                {
                    txtAuthorName.Text = selectedAuthor.GetName();
                    // Note: Birthdate not in Author class, so we'll leave DateTimePicker as is
                }
            }
        }

        private void BtnAddAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAuthorName.Text))
                {
                    MessageBox.Show("Please enter an author name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if author already exists
                Author existingAuthor = collectionManager.FindAuthorByName(txtAuthorName.Text.Trim());
                if (existingAuthor != null)
                {
                    MessageBox.Show("An author with this name already exists.", "Duplicate Author", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Author newAuthor = new Author(
                    collectionManager.GetNextAuthorID(),
                    txtAuthorName.Text.Trim()
                );
                
                collectionManager.AddAuthor(newAuthor);
                RefreshAuthorList();
                ClearFields();
                
                MessageBox.Show("Author added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding author: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateAuthor_Click(object sender, EventArgs e)
        {
            if (selectedAuthor == null)
            {
                MessageBox.Show("Please select an author to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtAuthorName.Text))
                {
                    MessageBox.Show("Please enter an author name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if another author with this name exists
                Author existingAuthor = collectionManager.FindAuthorByName(txtAuthorName.Text.Trim());
                if (existingAuthor != null && existingAuthor.AuthorID != selectedAuthor.AuthorID)
                {
                    MessageBox.Show("Another author with this name already exists.", "Duplicate Author", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedAuthor.SetName(txtAuthorName.Text.Trim());
                RefreshAuthorList();
                
                // Reselect the updated author
                for (int i = 0; i < lstAuthors.Items.Count; i++)
                {
                    if (lstAuthors.Items[i] is Author author && author.AuthorID == selectedAuthor.AuthorID)
                    {
                        lstAuthors.SelectedIndex = i;
                        break;
                    }
                }
                
                MessageBox.Show("Author updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating author: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteAuthor_Click(object sender, EventArgs e)
        {
            if (selectedAuthor == null)
            {
                MessageBox.Show("Please select an author to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if author has books
            if (selectedAuthor.BooksWritten.Count > 0)
            {
                MessageBox.Show(
                    $"Cannot delete author '{selectedAuthor.GetName()}' because they have {selectedAuthor.BooksWritten.Count} book(s) in the collection.\nPlease remove or reassign the books first.",
                    "Cannot Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete '{selectedAuthor.GetName()}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                if (collectionManager.RemoveAuthor(selectedAuthor.AuthorID))
                {
                    selectedAuthor = null;
                    RefreshAuthorList();
                    ClearFields();
                    MessageBox.Show("Author deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete author. Please ensure the author has no books in the collection.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            txtAuthorName.Clear();
            dateTimePicker1.Value = DateTime.Now;
            selectedAuthor = null;
            lstAuthors.ClearSelected();
        }
    }
}
