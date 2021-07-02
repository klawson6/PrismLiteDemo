using Prism.Commands;
using Prism.Mvvm;
using System;

namespace ModuleB.ViewModels
{
    public class TabViewBViewModel : BindableBase
    {
        private string title = "TabViewB has landed!";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private bool canUpdate = true;
        public bool CanUpdate
        {
            get { return canUpdate; }
            set { SetProperty(ref canUpdate, value); }
        }

        private string updatedText = "Default";
        public string UpdateText
        {
            get { return updatedText; }
            set { SetProperty(ref updatedText, value); }
        }

        public DelegateCommand UpdateCommand { get; private set; }

        public TabViewBViewModel()
        {
            UpdateCommand = new DelegateCommand(Update)
                .ObservesCanExecute(() => CanUpdate);
        }

        private void Update()
        {
            UpdateText = $"Updated: {DateTime.Now}";
        }
    }


}
