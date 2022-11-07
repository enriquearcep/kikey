using Kikey.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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