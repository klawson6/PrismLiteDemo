using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class TabViewAViewModel : BindableBase
    {
        private string text = "Hello from the ethereal plane! ooo";
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        public DelegateCommand ClickCommand { get; private set; }

        private bool canExecute = false;
        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                SetProperty(ref canExecute, value);
            }
        }
        public TabViewAViewModel()
        {
            ClickCommand = new DelegateCommand(Click)
                .ObservesCanExecute(() => CanExecute);
        }

        private bool CanClick()
        {
            return canExecute;
        }

        private void Click()
        {
            Text = "You clicked me!";
        }

        private string header = "Celestial";
        public string Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }
    }
}
