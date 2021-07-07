using Biblioteca.WPF.API.Client;
using Biblioteca.WPF.Models;
using Prism.Commands;
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
        private ObservableCollection<ClientModel> clientsModelComboBox = new ObservableCollection<ClientModel>();
        private ObservableCollection<BookModel> booksModelComboBox = new ObservableCollection<BookModel>();
        private ObservableCollection<string> clientsModelComboBoxDisplay = new ObservableCollection<string>();
        private ObservableCollection<string> booksModelComboBoxDisplay = new ObservableCollection<string>();
        private BookModel comboBoxSelectedBook;
        private ClientModel comboBoxSelectedClient;
        private string comboBoxSelectedBookDisplay;
        private string comboBoxSelectedClientDisplay;
        private LoanModel addLoan;
        private LoanModel editLoan;
        private LoanModel selectedLoanGrid;
        private DelegateCommand<LoanModel> deleteLoanCommand;
        private DelegateCommand<LoanModel> updateLoanCommand;
        private DelegateCommand<LoanModel> editLoanCommand;
        public ViewDViewModel()
        {
            addLoan = new LoanModel();
            editLoan = new LoanModel();
            GetClientsAction();
            GetBooksAction();
        }

        public DelegateCommand GetLoansCommand
        {
            get
            {
                return new Prism.Commands.DelegateCommand(GetLoansAction);
            }
        }
        public DelegateCommand AddLoanCommand
        {
            get
            {
                return new Prism.Commands.DelegateCommand(AddLoanAction);
            }
        }
        public DelegateCommand<LoanModel> UpdateLoanCommand =>
            updateLoanCommand ?? (updateLoanCommand = new DelegateCommand<LoanModel>(UpdateLoanAction));
        public DelegateCommand<LoanModel> EditLoanCommand =>
            editLoanCommand ?? (editLoanCommand = new DelegateCommand<LoanModel>(EditLoanAction));
        public DelegateCommand<LoanModel> DeleteLoanCommand =>
           deleteLoanCommand ?? (deleteLoanCommand = new DelegateCommand<LoanModel>(DeleteLoanAction));
        public LoanModel AddLoan
        {
            get
            {
                return addLoan;
            }
            set
            {
                if (value != addLoan)
                {
                    addLoan = value;
                    OnPropertyChanged();
                }
            }
        }

        public LoanModel EditLoan
        {
            get
            {
                return editLoan;
            }
            set
            {
                if (value != editLoan)
                {
                    editLoan = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<ClientModel> ClientsModelComboBox
        {
            get
            {
                return clientsModelComboBox;
            }
            set
            {
                if (value != clientsModelComboBox)
                {
                    clientsModelComboBox = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<BookModel> BooksModelComboBox
        {
            get
            {
                return booksModelComboBox;
            }
            set
            {
                if (value != booksModelComboBox)
                {
                    booksModelComboBox = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<string> ClientsModelComboBoxDisplay
        {
            get
            {
                return clientsModelComboBoxDisplay;
            }
            set
            {
                if (value != clientsModelComboBoxDisplay)
                {
                    clientsModelComboBoxDisplay = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<string> BooksModelComboBoxDisplay
        {
            get
            {
                return booksModelComboBoxDisplay;
            }
            set
            {
                if (value != booksModelComboBoxDisplay)
                {
                    booksModelComboBoxDisplay = value;
                    OnPropertyChanged();
                }
            }
        }
        public BookModel ComboBoxSelectedBook
        {
            get
            {
                return comboBoxSelectedBook;
            }
            set
            {
                if (value != comboBoxSelectedBook)
                {
                    comboBoxSelectedBook = value;
                    OnPropertyChanged();
                }
            }
        }

        public ClientModel ComboBoxSelectedClient
        {
            get
            {
                return comboBoxSelectedClient;
            }
            set
            {
                if (value != comboBoxSelectedClient)
                {
                    comboBoxSelectedClient = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ComboBoxSelectedBookDisplay
        {
            get
            {
                return comboBoxSelectedBookDisplay;
            }
            set
            {
                if (value != comboBoxSelectedBookDisplay)
                {
                    comboBoxSelectedBookDisplay = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ComboBoxSelectedClientDisplay
        {
            get
            {
                return comboBoxSelectedClientDisplay;
            }
            set
            {
                if (value != comboBoxSelectedClientDisplay)
                {
                    comboBoxSelectedClientDisplay = value;
                    OnPropertyChanged();
                }
            }
        }
        public async void GetClientsAction()
        {
            try
            {
                ClientsModelComboBox.Clear();
                ClientsModelComboBoxDisplay.Clear();
                var clientRestService = new CustomerRestService();
                var clients = await clientRestService.GetClients();
                foreach (var client in clients)
                {
                    ClientsModelComboBox.Add(client);
                    ClientsModelComboBoxDisplay.Add(client.FirstName + " " + client.LastName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }

        public async void GetBooksAction()
        {
            try
            {
                BooksModelComboBox.Clear();
                BooksModelComboBoxDisplay.Clear();
                var bookRestService = new BookRestService();
                var books = await bookRestService.GetBooks();
                foreach (var book in books)
                {
                    BooksModelComboBox.Add(book);
                    BooksModelComboBoxDisplay.Add(book.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }
        public LoanModel SelectedLoanGrid
        {
            get
            {
                return selectedLoanGrid;
            }
            set
            {
                if (value != selectedLoanGrid)
                {
                    selectedLoanGrid = value;
                    OnPropertyChanged();
                }
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
       
        public async void GetLoansAction()
        {
            try
            {
                LoansModel.Clear();    
                var loanRestService = new LoanRestService();
                var loans = await loanRestService.GetLoans(); 
                foreach (var loan in loans)
                {
                    LoansModel.Add(loan);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }

        public async void AddLoanAction()
        {
            try
            {
                Guid clientId=new Guid();
                Guid bookId = new Guid();
                foreach (var book in BooksModelComboBox)
                {
                    if (book.Title==ComboBoxSelectedBookDisplay)
                    {
                        bookId = book.Id;
                    }
                }
                foreach (var client in ClientsModelComboBox)
                {
                    if ((client.FirstName+" "+ client.LastName) == ComboBoxSelectedClientDisplay)
                    {
                        clientId = client.Id;
                    }
                }
                LoanModel newLoanModel = new LoanModel()
                {
                    ClientId = clientId,
                    BookId = bookId,
                    LoanDate = AddLoan.LoanDate,
                    ReturnDate = AddLoan.ReturnDate
                };
                var loanRestService = new LoanRestService();
                await loanRestService.CreateLoan(newLoanModel);
                newLoanModel = new LoanModel();
                GetLoansAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }

        public async void UpdateLoanAction(LoanModel UpdateLoan)
        {
            try
            {
                Guid clientId = new Guid();
                Guid bookId = new Guid();
                foreach (var book in BooksModelComboBox)
                {
                    if (book.Title == ComboBoxSelectedBookDisplay)
                    {
                        bookId = book.Id;
                    }
                }
                foreach (var client in ClientsModelComboBox)
                {
                    if ((client.FirstName + " " + client.LastName) == ComboBoxSelectedClientDisplay)
                    {
                        clientId = client.Id;
                    }
                }

                EditLoan.BookId = bookId;
                EditLoan.ClientId = clientId;

                var loanRestService = new LoanRestService();
                await loanRestService.UpdateLoan(EditLoan.Id, EditLoan);

                //bookToEdit = null;
                GetLoansAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }
        public void EditLoanAction(LoanModel SelectedLoanGrid)
        {
            try
            {
                ComboBoxSelectedClientDisplay = SelectedLoanGrid.ClientName;
                ComboBoxSelectedBookDisplay = SelectedLoanGrid.BookName;
                EditLoan.Id = SelectedLoanGrid.Id;
                EditLoan.BookId = SelectedLoanGrid.BookId;
                EditLoan.BookName = SelectedLoanGrid.BookName;
                EditLoan.ClientId = SelectedLoanGrid.ClientId;
                EditLoan.ClientName = SelectedLoanGrid.ClientName;
                EditLoan.LoanDate = SelectedLoanGrid.LoanDate;
                EditLoan.ReturnDate = SelectedLoanGrid.ReturnDate;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }
        public async void DeleteLoanAction(LoanModel loanToDelete)
        {
            try
            {
                var loanRestService = new LoanRestService();
                await loanRestService.DeleteLoan(loanToDelete.Id);
                GetLoansAction();
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
