using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion region = regionManager.Regions["TabbedRegion"];

            var view = containerProvider.Resolve<TabViewA>();
            region.Add(view);
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(TabViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<TabViewA>(() =>
            {
                return new TabViewAViewModel()
                {
                    Text = "Hello from the celestial plane of factory A"
                };
            });
        }
    }
}
