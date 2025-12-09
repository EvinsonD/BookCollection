using System;
using System.Collections.Generic;
using System.Linq;

namespace BookCollection
{
    public class Author
    {
        // Variables
        private int authorID;
        private string name;
        private List<Book> booksWritten;

        // Constructor
        public Author(int authorID, string name)
        {
            this.authorID = authorID;
            this.name = name;
            this.booksWritten = new List<Book>();
        }

        // Properties
        public int AuthorID
        {
            get { return authorID; }
        }

        public string Name
        {
            get { return name; }
        }

        public List<Book> BooksWritten
        {
            get { return new List<Book>(booksWritten); } // Return copy to prevent external modification
        }

        // Methods
        public void SetName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                this.name = name;
            }
        }

        public void AddBook(Book book)
        {
            if (book != null && !booksWritten.Contains(book))
            {
                booksWritten.Add(book);
            }
        }

        public void RemoveBook(Book book)
        {
            if (book != null)
            {
                booksWritten.Remove(book);
            }
        }

        public string GetName()
        {
            return name;
        }

        public List<Book> ListBooksWritten()
        {
            return new List<Book>(booksWritten);
        }

        public string GetAuthorInfo()
        {
            string booksList = booksWritten.Count > 0 
                ? string.Join(", ", booksWritten.Select(b => b.GetTitle()))
                : "No books";
            
            return $"Author ID: {authorID}\n" +
                   $"Name: {name}\n" +
                   $"Books Written: {booksList}\n" +
                   $"Total Books: {booksWritten.Count}";
        }

        public override string ToString()
        {
            return name;
        }
    }
}

