using Kikey.ViewModels;
using System;
using System.Windows;

namespace Kikey.Views
{
    public partial class NewPasswordView : Window
    {
        public NewPasswordView()
        {
            InitializeComponent();

            var vm = new NewPasswordViewModel();

            this.DataContext = vm;

            if (vm.CloseAction == null)
            {
                vm.CloseAction = new Action(this.Close);
            }
        }
    }
}