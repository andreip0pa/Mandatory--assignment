using System;

namespace BookClassLib
{
    public class Book
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { if (value.Length < 2) { throw new Exception("Title should be at least 2 letters long!"); } _title = value; }
        }

        private string _author;

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        private int _pageNumber;

        public int PageNumber
        {
            get { return _pageNumber; }
            set { if (value <= 10 || value > 1000) { throw new Exception("Number of pages invalid!"); } _pageNumber = value; }

        }

        private string _isbn13;

        public string Isbn13
        {
            get { return _isbn13; }
            set { if (value.Length != 13) { throw new Exception("Isbn should be 13 characters long!"); } _isbn13 = value; }
        }

        public Book(string title, string author, int pageNumber, string isbn13)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
            PageNumber = pageNumber;
            Isbn13 = isbn13 ?? throw new ArgumentNullException(nameof(isbn13));
        }




    }
}
