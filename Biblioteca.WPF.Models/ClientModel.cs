using System;

namespace Biblioteca.WPF.Models
{
    public class ClientModel : BaseModel
    {
        private string firstName;
        private string lastName;
        private string phone;
        private string adress;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (phone != value)
                {
                    phone = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                if (adress != value)
                {
                    adress = value;
                    RaisePropertyChanged();
                }
            }
        }

    }
}
