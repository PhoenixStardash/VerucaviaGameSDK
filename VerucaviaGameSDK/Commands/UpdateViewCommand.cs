using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VerucavaGameSDK.ViewModels;
using VerucavaGameSDK.Views;

namespace VerucavaGameSDK.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Unreal Engine 4")
            {
                viewModel.SelectedViewModel = new UE4ViewModel();
            }
            if (parameter.ToString() == "Apps")
            {
                viewModel.SelectedViewModel = new AppsViewModel();
            }
            if (parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new HomeViewModel();
            }
            if (parameter.ToString() == "About")
            {
                viewModel.SelectedViewModel = new AboutViewModel();
            }
        }

    }
}
