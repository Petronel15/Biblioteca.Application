using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.WPF.Models
{
    public class BookModel : BaseModel
    {
        private string title;
        private string author;
        private string publisher;
        private int year;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (author != value)
                {
                    author = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Publisher
        {
            get
            {
                return publisher;
            }
            set
            {
                if (publisher != value)
                {
                    publisher = value;
                    RaisePropertyChanged();
                }
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (year != value)
                {
                    year = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
