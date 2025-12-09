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
    public partial class GenreManager : Form
    {
        private BookCollectionManager collectionManager;
        private Genre selectedGenre;

        public GenreManager(BookCollectionManager manager)
        {
            InitializeComponent();
            collectionManager = manager;
            selectedGenre = null;
            
            InitializeForm();
        }

        private void InitializeForm()
        {
            btnAddGenre.Click += BtnAddGenre_Click;
            btnUpdateGenre.Click += BtnUpdateGenre_Click;
            btnDeleteGenre.Click += BtnDeleteGenre_Click;
            btnClose.Click += BtnClose_Click;
            lstGenres.SelectedIndexChanged += LstGenres_SelectedIndexChanged;
            
            RefreshGenreList();
        }

        private void RefreshGenreList()
        {
            lstGenres.Items.Clear();
            foreach (Genre genre in collectionManager.ListAllGenres())
            {
                lstGenres.Items.Add(genre);
            }
        }

        private void LstGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGenres.SelectedItem != null)
            {
                selectedGenre = lstGenres.SelectedItem as Genre;
                if (selectedGenre != null)
                {
                    txtGenreName.Text = selectedGenre.GetName();
                    txtGenreDescription.Text = selectedGenre.GetDescription();
                }
            }
        }

        private void BtnAddGenre_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtGenreName.Text))
                {
                    MessageBox.Show("Please enter a genre name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if genre already exists
                Genre existingGenre = collectionManager.FindGenreByName(txtGenreName.Text.Trim());
                if (existingGenre != null)
                {
                    MessageBox.Show("A genre with this name already exists.", "Duplicate Genre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Genre newGenre = new Genre(
                    collectionManager.GetNextGenreID(),
                    txtGenreName.Text.Trim(),
                    txtGenreDescription.Text ?? string.Empty
                );
                
                collectionManager.AddGenre(newGenre);
                RefreshGenreList();
                ClearFields();
                
                MessageBox.Show("Genre added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding genre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateGenre_Click(object sender, EventArgs e)
        {
            if (selectedGenre == null)
            {
                MessageBox.Show("Please select a genre to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtGenreName.Text))
                {
                    MessageBox.Show("Please enter a genre name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if another genre with this name exists
                Genre existingGenre = collectionManager.FindGenreByName(txtGenreName.Text.Trim());
                if (existingGenre != null && existingGenre.GenreID != selectedGenre.GenreID)
                {
                    MessageBox.Show("Another genre with this name already exists.", "Duplicate Genre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedGenre.SetName(txtGenreName.Text.Trim());
                selectedGenre.SetDescription(txtGenreDescription.Text ?? string.Empty);
                RefreshGenreList();
                
                // Reselect the updated genre
                for (int i = 0; i < lstGenres.Items.Count; i++)
                {
                    if (lstGenres.Items[i] is Genre genre && genre.GenreID == selectedGenre.GenreID)
                    {
                        lstGenres.SelectedIndex = i;
                        break;
                    }
                }
                
                MessageBox.Show("Genre updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating genre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteGenre_Click(object sender, EventArgs e)
        {
            if (selectedGenre == null)
            {
                MessageBox.Show("Please select a genre to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if genre has books
            if (selectedGenre.BooksInGenre.Count > 0)
            {
                MessageBox.Show(
                    $"Cannot delete genre '{selectedGenre.GetName()}' because it has {selectedGenre.BooksInGenre.Count} book(s) in the collection.\nPlease remove or reassign the books first.",
                    "Cannot Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete '{selectedGenre.GetName()}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                if (collectionManager.RemoveGenre(selectedGenre.GenreID))
                {
                    selectedGenre = null;
                    RefreshGenreList();
                    ClearFields();
                    MessageBox.Show("Genre deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete genre. Please ensure the genre has no books in the collection.", 
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
            txtGenreName.Clear();
            txtGenreDescription.Clear();
            selectedGenre = null;
            lstGenres.ClearSelected();
        }
    }
}
