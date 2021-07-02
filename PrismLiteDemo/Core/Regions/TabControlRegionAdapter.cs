using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismLiteDemo.Core.Regions
{
    class TabControlRegionAdapter : RegionAdapterBase<TabControl>
    {

        public TabControlRegionAdapter(IRegionBehaviorFactory behaviourFactory) : base(behaviourFactory)
        {

        }
        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement item in e.NewItems)
                    {
                        var tab = new TabItem() {
                            Header =  "Tab " + (regionTarget.Items.Count + 1) 
                        };
                        tab.Content = item;
                        regionTarget.Items.Add(tab);
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement item in e.OldItems)
                    {
                        regionTarget.Items.Remove(
                            regionTarget.Items.OfType<TabItem>().FirstOrDefault(
                                i => i.Content == item
                                ));
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
