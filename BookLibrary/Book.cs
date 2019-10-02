using System;
using System.Data;

namespace BookLibrary
{
    public class Book
    {
        private string _title;
        private int _numberOfPages;
        private string _iSBN;

        public Book()
        {
            
        }

        public Book(string title, int numberOfPages, string iSbn, string author)
        {
            // Konstruktøren refererer til klassens properties (i stedet for instansfelterne) så den dermed overholder de constraints, der er sat 
            Title = title;
            NumberOfPages = numberOfPages;
            ISbn = iSbn;
            Author = author;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value.Length < 2)
                {
                    // Der bruges argumentexception, da der her er tale om en string, der skal overholder nogle krav
                    throw new ArgumentException("Title cannot be less than 2 characters long");
                }
                _title = value;
            }
        }

        public string Author { get; set; }

        public int NumberOfPages
        {
            get { return _numberOfPages; }
            set
            {
                if (value >= 10 && value <= 1000)
                {
                   _numberOfPages = value; 
                }
                // Her kastes argumentOutOfRangeException, da vi arbejder med tal, der skal være inden for en range
                else throw new ArgumentOutOfRangeException("Number of pages must be more than 9 and less than 1001");
            }
        }

        public string ISbn
        {
            get { return _iSBN; }
            set
            {
                if (value.Length != 13)
                {
                    // Der bruges argumentexception, da der her er tale om en string, der skal overholder nogle krav
                    throw new ArgumentException("ISBN must be 13 characters long");
                }
                _iSBN = value;
            }
        }
    }
}
