using System;

namespace Biblioteca.WPF.Models
{
    public class LoanModel : BaseModel
    {
        private Guid clientId;
        private Guid bookId;
        private DateTime loanDate;
        private DateTime? returnDate;

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
    }
}
