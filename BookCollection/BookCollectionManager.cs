using System;
using System.Collections.Generic;
using System.Linq;

namespace BookCollection
{
    public class BookCollectionManager
    {
        // Variables
        private int collectionID;
        private List<Book> books;
        private List<Author> authors;
        private List<Genre> genres;
        private int nextBookID;
        private int nextAuthorID;
        private int nextGenreID;

        // Constructor
        public BookCollectionManager(int collectionID = 1)
        {
            this.collectionID = collectionID;
            this.books = new List<Book>();
            this.authors = new List<Author>();
            this.genres = new List<Genre>();
            this.nextBookID = 1;
            this.nextAuthorID = 1;
            this.nextGenreID = 1;
        }

        // Properties
        public int CollectionID
        {
            get { return collectionID; }
        }

        public List<Book> Books
        {
            get { return new List<Book>(books); }
        }

        public List<Author> Authors
        {
            get { return new List<Author>(authors); }
        }

        public List<Genre> Genres
        {
            get { return new List<Genre>(genres); }
        }

        // Book Methods
        public void AddBook(Book book)
        {
            if (book != null && !books.Contains(book))
            {
                books.Add(book);
                
                // Update author's book list
                if (book.GetAuthor() != null)
                {
                    book.GetAuthor().AddBook(book);
                }
                
                // Update genre's book list
                if (book.GetGenre() != null)
                {
                    book.GetGenre().AddBook(book);
                }
            }
        }

        public bool RemoveBook(int bookID)
        {
            Book bookToRemove = books.FirstOrDefault(b => b.BookID == bookID);
            if (bookToRemove != null)
            {
                // Remove from author's list
                if (bookToRemove.GetAuthor() != null)
                {
                    bookToRemove.GetAuthor().RemoveBook(bookToRemove);
                }
                
                // Remove from genre's list
                if (bookToRemove.GetGenre() != null)
                {
                    bookToRemove.GetGenre().RemoveBook(bookToRemove);
                }
                
                books.Remove(bookToRemove);
                return true;
            }
            return false;
        }

        public Book FindBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return null;
                
            return books.FirstOrDefault(b => 
                b.GetTitle().Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public List<Book> FindBookByAuthor(string authorName)
        {
            if (string.IsNullOrWhiteSpace(authorName))
                return new List<Book>();
                
            return books.Where(b => 
                b.GetAuthor() != null && 
                b.GetAuthor().GetName().Equals(authorName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Book> ListAllBooks()
        {
            return new List<Book>(books);
        }

        // Author Methods
        public void AddAuthor(Author author)
        {
            if (author != null && !authors.Contains(author))
            {
                authors.Add(author);
            }
        }

        public List<Author> ListAllAuthors()
        {
            return new List<Author>(authors);
        }

        public bool RemoveAuthor(int authorID)
        {
            Author authorToRemove = authors.FirstOrDefault(a => a.AuthorID == authorID);
            if (authorToRemove != null)
            {
                // Check if author has books
                if (authorToRemove.BooksWritten.Count > 0)
                {
                    return false; // Cannot delete author with books
                }
                
                authors.Remove(authorToRemove);
                return true;
            }
            return false;
        }

        public Author FindAuthorByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;
                
            return authors.FirstOrDefault(a => 
                a.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Author FindAuthorByID(int authorID)
        {
            return authors.FirstOrDefault(a => a.AuthorID == authorID);
        }

        // Genre Methods
        public void AddGenre(Genre genre)
        {
            if (genre != null && !genres.Contains(genre))
            {
                genres.Add(genre);
            }
        }

        public List<Genre> ListAllGenres()
        {
            return new List<Genre>(genres);
        }

        public bool RemoveGenre(int genreID)
        {
            Genre genreToRemove = genres.FirstOrDefault(g => g.GenreID == genreID);
            if (genreToRemove != null)
            {
                // Check if genre has books
                if (genreToRemove.BooksInGenre.Count > 0)
                {
                    return false; // Cannot delete genre with books
                }
                
                genres.Remove(genreToRemove);
                return true;
            }
            return false;
        }

        public Genre FindGenreByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;
                
            return genres.FirstOrDefault(g => 
                g.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Genre FindGenreByID(int genreID)
        {
            return genres.FirstOrDefault(g => g.GenreID == genreID);
        }

        // ID Generation Methods
        public int GetNextBookID()
        {
            return nextBookID++;
        }

        public int GetNextAuthorID()
        {
            return nextAuthorID++;
        }

        public int GetNextGenreID()
        {
            return nextGenreID++;
        }

        // Search Methods
        public List<Book> SearchBooks(string searchTerm, string searchType)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return ListAllBooks();

            searchTerm = searchTerm.ToLower();

            switch (searchType.ToLower())
            {
                case "title":
                    return books.Where(b => 
                        b.GetTitle().ToLower().Contains(searchTerm)).ToList();
                
                case "author":
                    return books.Where(b => 
                        b.GetAuthor() != null && 
                        b.GetAuthor().GetName().ToLower().Contains(searchTerm)).ToList();
                
                case "genre":
                    return books.Where(b => 
                        b.GetGenre() != null && 
                        b.GetGenre().GetName().ToLower().Contains(searchTerm)).ToList();
                
                default:
                    // Search all fields
                    return books.Where(b => 
                        b.GetTitle().ToLower().Contains(searchTerm) ||
                        (b.GetAuthor() != null && b.GetAuthor().GetName().ToLower().Contains(searchTerm)) ||
                        (b.GetGenre() != null && b.GetGenre().GetName().ToLower().Contains(searchTerm)) ||
                        b.GetNotes().ToLower().Contains(searchTerm)).ToList();
            }
        }
    }
}

