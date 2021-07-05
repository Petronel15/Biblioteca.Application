using Biblioteca.WPF.API.Client;
using Biblioteca.WPF.Models;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ModuleB.ViewModels
{
    public class ViewDViewModel : BindableBase
    {
        private ObservableCollection<LoanModel> loansModel = new ObservableCollection<LoanModel>();
        private ObservableCollection<BookModel> booksModel = new ObservableCollection<BookModel>();
        private ObservableCollection<ClientModel> clientsModel = new ObservableCollection<ClientModel>();

        public ViewDViewModel()
        {
            var loanRestService = new LoanRestService();
        }

        public Prism.Commands.DelegateCommand GetLoansCommand
        {
            get
            {
                return new Prism.Commands.DelegateCommand(GetLoansAction);
            }
        }
        public ObservableCollection<LoanModel> LoansModel
        {
            get
            {
                return loansModel;
            }
            set
            {
                if (value != loansModel)
                {
                    loansModel = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<BookModel> BooksModel
        {
            get
            {
                return booksModel;
            }
            set
            {
                if (value != booksModel)
                {
                    booksModel = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<ClientModel> ClientsModel
        {
            get
            {
                return clientsModel;
            }
            set
            {
                if (value != clientsModel)
                {
                    clientsModel = value;
                    OnPropertyChanged();
                }
            }
        }
        public async void GetLoansAction()
        {
            try
            {
                LoansModel.Clear();
                BooksModel.Clear();
                ClientsModel.Clear();
                var loanRestService = new LoanRestService();
                var loans = await loanRestService.GetLoans();
                var bookRestService = new BookRestService();
                var books = await bookRestService.GetBooks();
                var clientRestService = new CustomerRestService();
                var clients = await clientRestService.GetClients();
                foreach (var loan in loans)
                {
                    LoansModel.Add(loan);
                    foreach (var book in books)
                    {
                        if (loan.BookId==book.Id)
                        {
                            BooksModel.Add(book);
                        }
                    }
                    foreach (var client in clients)
                    {
                        if (loan.ClientId == client.Id)
                        {
                            ClientsModel.Add(client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
