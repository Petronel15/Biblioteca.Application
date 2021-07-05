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
    public class ViewBViewModel : BindableBase
    {
        private ObservableCollection<BookModel> booksModel = new ObservableCollection<BookModel>();
        private BookModel addBook;
        private BookModel editBook;
        private BookModel updateBook;
        private BookModel selectedBookGrid = new BookModel();
        private DelegateCommand<BookModel> deleteBookCommand;
        private DelegateCommand<BookModel> editBookCommand;
        private DelegateCommand<BookModel> updateBookCommand;

        public ViewBViewModel()
        {
            editBook = new BookModel();
            addBook = new BookModel();
            updateBook = new BookModel();
        }

        public Prism.Commands.DelegateCommand GetBooksCommand
        {
            get
            {
                return new Prism.Commands.DelegateCommand(GetBooksAction);
            }
        }

        public Prism.Commands.DelegateCommand AddBookCommand
        {
            get
            {
                return new Prism.Commands.DelegateCommand(AddBookAction);
            }
        }

        public DelegateCommand<BookModel> UpdateBookCommand =>
            updateBookCommand ?? (updateBookCommand = new DelegateCommand<BookModel>(UpdateBookAction));

        public DelegateCommand<BookModel> EditBookCommand =>
            editBookCommand ?? (editBookCommand = new DelegateCommand<BookModel>(EditBookAction));
        
        public DelegateCommand<BookModel> DeleteBookCommand =>
            deleteBookCommand ?? (deleteBookCommand = new DelegateCommand<BookModel>(DeleteBookAction));

        public BookModel AddBook
        {
            get
            {
                return addBook;
            }
            set
            {
                if (value != addBook)
                {
                    addBook = value;
                    OnPropertyChanged();
                }
            }
        }
        public BookModel EditBook
        {
            get
            {
                return editBook;
            }
            set
            {
                if (value != editBook)
                {
                    editBook = value;
                    OnPropertyChanged();
                }
            }
        }
        public BookModel UpdateBook
        {
            get
            {
                return updateBook;
            }
            set
            {
                if (value != updateBook)
                {
                    updateBook = value;
                    OnPropertyChanged();
                }
            }
        }
        public BookModel SelectedBookGrid
        {
            get
            {
                return selectedBookGrid;
            }
            set
            {
                if (value != selectedBookGrid)
                {
                    selectedBookGrid = value;
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
        public async void GetBooksAction()
        {
            try
            {
                BooksModel.Clear();
                var bookRestService = new BookRestService();
                var books = await bookRestService.GetBooks();
                foreach (var book in books)
                {
                    BooksModel.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }
        public async void AddBookAction()
        {
            try
            {
                BookModel newBookModel = new BookModel()
                {
                    Author = AddBook.Author,
                    Title = AddBook.Title,
                    Publisher = AddBook.Publisher,
                    Year = AddBook.Year
                };
                var bookRestService = new BookRestService();
                await bookRestService.CreateBook(newBookModel);
                newBookModel = new BookModel();
                GetBooksAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }

        public async void UpdateBookAction(BookModel UpdateBook)
        {
            try
            {
                var bookRestService = new BookRestService();
                await bookRestService.UpdateBook(EditBook.Id, EditBook);
                //bookToEdit = null;
                GetBooksAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }

        public void EditBookAction(BookModel SelectedBookGrid)
        {
            try
            {
                EditBook.Id = SelectedBookGrid.Id;
                EditBook.Title = SelectedBookGrid.Title;
                EditBook.Author = SelectedBookGrid.Author;
                EditBook.Publisher = SelectedBookGrid.Publisher;
                EditBook.Year = SelectedBookGrid.Year;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }

        public async void DeleteBookAction(BookModel bookToDelete)
        {
            try
            {
                var bookRestService = new BookRestService();
                await bookRestService.DeleteBook(bookToDelete.Id);
                GetBooksAction();
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
