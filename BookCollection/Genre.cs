using System;
using System.Collections.Generic;
using System.Linq;

namespace BookCollection
{
    public class Genre
    {
        // Variables
        private int genreID;
        private string name;
        private string description;
        private List<Book> booksInGenre;

        // Constructor
        public Genre(int genreID, string name, string description = "")
        {
            this.genreID = genreID;
            this.name = name;
            this.description = description ?? string.Empty;
            this.booksInGenre = new List<Book>();
        }

        // Properties
        public int GenreID
        {
            get { return genreID; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        public List<Book> BooksInGenre
        {
            get { return new List<Book>(booksInGenre); } // Return copy to prevent external modification
        }

        // Methods
        public void SetName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                this.name = name;
            }
        }

        public void SetDescription(string description)
        {
            this.description = description ?? string.Empty;
        }

        public void AddBook(Book book)
        {
            if (book != null && !booksInGenre.Contains(book))
            {
                booksInGenre.Add(book);
            }
        }

        public void RemoveBook(Book book)
        {
            if (book != null)
            {
                booksInGenre.Remove(book);
            }
        }

        public string GetName()
        {
            return name;
        }

        public string GetDescription()
        {
            return description;
        }

        public List<Book> ListBooksInGenre()
        {
            return new List<Book>(booksInGenre);
        }

        public string GetGenreInfo()
        {
            string booksList = booksInGenre.Count > 0
                ? string.Join(", ", booksInGenre.Select(b => b.GetTitle()))
                : "No books";
            
            return $"Genre ID: {genreID}\n" +
                   $"Name: {name}\n" +
                   $"Description: {description}\n" +
                   $"Books in Genre: {booksList}\n" +
                   $"Total Books: {booksInGenre.Count}";
        }

        public override string ToString()
        {
            return name;
        }
    }
}

