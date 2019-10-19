using System;

namespace BookClassLib
{
    public class Book
    {
        private string _title;

        /// <summary>
        /// Title of the book, should be at least 2 characters long
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { if (value.Length < 2) { throw new Exception("Title should be at least 2 letters long!"); } _title = value; }
        }

        private string _author;
        /// <summary>
        /// Author of the book
        /// </summary>
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        private int _pageNumber;
        /// <summary>
        /// Number of pages
        /// </summary>
        public int PageNumber
        {
            get { return _pageNumber; }
            set { if (value <= 10 || value > 1000) { throw new Exception("Number of pages invalid!"); } _pageNumber = value; }

        }

        private string _isbn13;
        /// <summary>
        /// Unique identifier for a book, should be 13 characters long
        /// </summary>
        public string Isbn13
        {
            get { return _isbn13; }
            set { if (value.Length != 13) { throw new Exception("Isbn should be 13 characters long!"); } _isbn13 = value; }
        }
        /// <summary>
        /// Basic book class
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="pageNumber">Number of pages</param>
        /// <param name="isbn13">ISBN of the book, unique identifier </param>
        public Book(string title, string author, int pageNumber, string isbn13)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
            PageNumber = pageNumber;
            Isbn13 = isbn13 ?? throw new ArgumentNullException(nameof(isbn13));
        }




    }
}
