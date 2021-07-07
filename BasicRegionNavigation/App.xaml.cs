using System;
using System.Windows;
using BasicRegionNavigation.Views;
using ModuleB;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

namespace BasicRegionNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App() : base()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

        }
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleA.ModuleAModule>();
            moduleCatalog.AddModule<ModuleB.ModuleBModule>();
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string errorMessage = string.Format("An unhandled exception occurred: {0}", e.ExceptionObject.ToString());

            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
