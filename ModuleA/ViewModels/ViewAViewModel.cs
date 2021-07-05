using Biblioteca.WPF.API.Client;
using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase, INotifyPropertyChanged
    {
        public ViewAViewModel()
        {
            var customerRestService = new CustomerRestService();
        }

        public RelayCommand GetClients
        {
            get
            {
                return new RelayCommand(GetClientsAction, true);
            }
        }

        public async void GetClientsAction()
        {
            try
            {
                var customerRestService = new CustomerRestService();
                var clients = await customerRestService.GetClients();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
        }
    }
}
