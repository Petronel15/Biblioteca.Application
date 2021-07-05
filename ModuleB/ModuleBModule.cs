using ModuleB.ViewModels;
using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<ViewC>();
            containerRegistry.RegisterForNavigation<ViewD>();
            containerRegistry.Register<ViewBViewModel>();
            containerRegistry.Register<ViewCViewModel>();
            containerRegistry.Register<ViewDViewModel>();
        }
    }
}