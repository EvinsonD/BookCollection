using System;

namespace BookCollection
{
    public class Book
    {
        // Variables
        private int bookID;
        private string title;
        private string isbn;
        private Author author;
        private Genre genre;
        private int yearPublished;
        private string notes;
        private bool isRead;

        // Constructor
        public Book(int bookID, string title, Author author, Genre genre, string isbn = "", int yearPublished = 0)
        {
            this.bookID = bookID;
            this.title = title;
            this.isbn = isbn ?? string.Empty;
            this.author = author;
            this.genre = genre;
            this.yearPublished = yearPublished;
            this.notes = string.Empty;
            this.isRead = false;
        }

        // Properties
        public int BookID
        {
            get { return bookID; }
        }

        public string Title
        {
            get { return title; }
        }

        public string ISBN
        {
            get { return isbn; }
        }

        public int YearPublished
        {
            get { return yearPublished; }
        }

        public Author Author
        {
            get { return author; }
        }

        public Genre Genre
        {
            get { return genre; }
        }

        public string Notes
        {
            get { return notes; }
        }

        public bool IsRead
        {
            get { return isRead; }
        }

        // Methods
        public void SetTitle(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                this.title = title;
            }
        }

        public void SetISBN(string isbn)
        {
            this.isbn = isbn ?? string.Empty;
        }

        public void SetYearPublished(int year)
        {
            if (year >= 0 && year <= DateTime.Now.Year + 10) // Reasonable year range
            {
                this.yearPublished = year;
            }
        }

        public void SetNotes(string notes)
        {
            this.notes = notes ?? string.Empty;
        }

        public void SetAuthor(Author author)
        {
            if (author != null)
            {
                this.author = author;
            }
        }

        public void SetGenre(Genre genre)
        {
            if (genre != null)
            {
                this.genre = genre;
            }
        }

        public void MarkAsRead()
        {
            this.isRead = true;
        }

        public void MarkAsUnread()
        {
            this.isRead = false;
        }

        public string GetTitle()
        {
            return title;
        }

        public Author GetAuthor()
        {
            return author;
        }

        public Genre GetGenre()
        {
            return genre;
        }

        public string GetNotes()
        {
            return notes;
        }

        public bool IsReadStatus()
        {
            return isRead;
        }

        public string GetBookInfo()
        {
            string authorName = author != null ? author.GetName() : "Unknown";
            string genreName = genre != null ? genre.GetName() : "Unknown";
            string readStatus = isRead ? "Read" : "Unread";
            string yearStr = yearPublished > 0 ? yearPublished.ToString() : "N/A";
            string isbnStr = !string.IsNullOrWhiteSpace(isbn) ? isbn : "N/A";
            
            return $"ID: {bookID}\n" +
                   $"Title: {title}\n" +
                   $"ISBN: {isbnStr}\n" +
                   $"Author: {authorName}\n" +
                   $"Genre: {genreName}\n" +
                   $"Year Published: {yearStr}\n" +
                   $"Status: {readStatus}\n" +
                   $"Notes: {notes}";
        }

        public override string ToString()
        {
            string authorName = author != null ? author.GetName() : "Unknown";
            string readStatus = isRead ? "[Read]" : "[Unread]";
            return $"{title} by {authorName} {readStatus}";
        }
    }
}

