using ModuleC.ViewModels;
using ModuleC.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleC
{
    public class ModuleCModule : IModule
    {
        private readonly IRegionManager regionManager;

        public ModuleCModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion region = regionManager.Regions["TabbedRegion"];

            var view = containerProvider.Resolve<TabViewC>();
            region.Add(view);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<TabViewC>(() =>
            {
                return new TabViewCViewModel()
                {
                    Title = "Hello from the psionic plane of factory C!"
                };
            });
        }
    }
}
