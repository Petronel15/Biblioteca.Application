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
    public class ViewCViewModel : BindableBase
    {
        private ObservableCollection<ClientModel> clientsModel = new ObservableCollection<ClientModel>();
        ClientModel newClientModel = new ClientModel();
        private ClientModel addClient;
        private ClientModel editClient;
        private ClientModel selectedClientGrid;
        private DelegateCommand<ClientModel> deleteClientCommand;
        private DelegateCommand<ClientModel> updateClientCommand;
        private DelegateCommand<ClientModel> editClientCommand;
        public ViewCViewModel()
        {
            var customerRestService = new CustomerRestService();
            addClient = new ClientModel();
            editClient = new ClientModel();
        }

        public Prism.Commands.DelegateCommand GetClientsCommand
        {
            get
            {
                return new Prism.Commands.DelegateCommand(GetClientsAction);
            }
        }

        public Prism.Commands.DelegateCommand AddClientCommand
        {
            get
            {
                return new Prism.Commands.DelegateCommand(AddClientAction);
            }
        }

        public DelegateCommand<ClientModel> UpdateClientCommand =>
            updateClientCommand ?? (updateClientCommand = new DelegateCommand<ClientModel>(UpdateClientAction));

        public DelegateCommand<ClientModel> EditClientCommand =>
            editClientCommand ?? (editClientCommand = new DelegateCommand<ClientModel>(EditClientAction));
        public DelegateCommand<ClientModel> DeleteClientCommand =>
           deleteClientCommand ?? (deleteClientCommand = new DelegateCommand<ClientModel>(DeleteClientAction));
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

        public ClientModel AddClient
        {
            get
            {
                return addClient;
            }
            set
            {
                if (value != addClient)
                {
                    addClient = value;
                    OnPropertyChanged();
                }
            }
        }
        public ClientModel EditClient
        {
            get
            {
                return editClient;
            }
            set
            {
                if (value != editClient)
                {
                    editClient = value;
                    OnPropertyChanged();
                }
            }
        }
        public ClientModel SelectedClientGrid
        {
            get
            {
                return selectedClientGrid;
            }
            set
            {
                if (value != selectedClientGrid)
                {
                    selectedClientGrid = value;
                    OnPropertyChanged();
                }
            }
        }
        public async void GetClientsAction()
        {
            try
            {
                ClientsModel.Clear();
                var clientRestService = new CustomerRestService();
                var clients = await clientRestService.GetClients();
                foreach (var client in clients)
                {
                    ClientsModel.Add(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }

        public async void AddClientAction()
        {
            try
            {
                ClientModel newClientModel = new ClientModel()
                {
                    FirstName = AddClient.FirstName,
                    LastName = AddClient.LastName,
                    Phone = AddClient.Phone,
                    Adress = AddClient.Adress
                };
                var customerRestService = new CustomerRestService();
                await customerRestService.CreateClient(newClientModel);
                newClientModel = new ClientModel();
                GetClientsAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }

        public async void UpdateClientAction(ClientModel UpdateClient)
        {
            try
            {
                var customerRestService = new CustomerRestService();
                await customerRestService.UpdateClient(EditClient.Id, EditClient);
                //bookToEdit = null;
                GetClientsAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }

        public void EditClientAction(ClientModel SelectedClientGrid)
        {
            try
            {
                EditClient.Id = SelectedClientGrid.Id;
                EditClient.FirstName = SelectedClientGrid.FirstName;
                EditClient.LastName = SelectedClientGrid.LastName;
                EditClient.Phone = SelectedClientGrid.Phone;
                EditClient.Adress = SelectedClientGrid.Adress;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }
        public async void DeleteClientAction(ClientModel clientToDelete)
        {
            try
            {
                var customerRestService = new CustomerRestService();
                await customerRestService.DeleteClient(clientToDelete.Id);
                GetClientsAction();
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
