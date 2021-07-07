using System;

namespace Biblioteca.WPF.Models
{
    public class LoanModel : BaseModel
    {
        private Guid clientId;
        private Guid bookId;
        private DateTime loanDate;
        private DateTime? returnDate;
        private string clientName;
        private string bookName;

        public Guid ClientId
        {
            get
            {
                return clientId;
            }
            set
            {
                if (clientId != value)
                {
                    clientId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Guid BookId
        {
            get
            {
                return bookId;
            }
            set
            {
                if (bookId != value)
                {
                    bookId = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime LoanDate
        {
            get
            {
                return loanDate;
            }
            set
            {
                if (loanDate != value)
                {
                    loanDate = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime? ReturnDate
        {
            get
            {
                return returnDate;
            }
            set
            {
                if (returnDate != value)
                {
                    returnDate = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ClientName
        {
            get
            {
                return clientName;
            }
            set
            {
                if (clientName != value)
                {
                    clientName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string BookName
        {
            get
            {
                return bookName;
            }
            set
            {
                if (bookName != value)
                {
                    bookName = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
