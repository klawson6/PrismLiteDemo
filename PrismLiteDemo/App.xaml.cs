using ModuleA;
using ModuleB;
using ModuleC;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismLiteDemo.Core.Regions;
using PrismLiteDemo.Views;
using System.Windows;
using System.Windows.Controls;

namespace PrismLiteDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            //regionAdapterMappings.RegisterMapping(
            //    typeof(StackPanel),
            //    Container.Resolve<StackPanelRegionAdapter>()
            //    );
            regionAdapterMappings.RegisterMapping(typeof(TabControl), Container.Resolve<TabControlRegionAdapter>());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleAModule>();
            moduleCatalog.AddModule<ModuleBModule>();
            moduleCatalog.AddModule<ModuleCModule>();
        }
    }
}
