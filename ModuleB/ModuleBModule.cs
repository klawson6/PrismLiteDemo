using ModuleB.ViewModels;
using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        private readonly IRegionManager regionManager;

        public ModuleBModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion region = regionManager.Regions["TabbedRegion"];

            var view = containerProvider.Resolve<TabViewB>();
            region.Add(view);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<TabViewB>(() =>
            {
                return new TabViewBViewModel()
                {
                    Title = "Hello from the elemenatal plane of factory B"
                };
            });
        }
    }
}
