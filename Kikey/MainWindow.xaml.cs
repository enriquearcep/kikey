using Kikey.Helpers;
using Kikey.Models;
using System.Windows;

namespace Kikey
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            FileHelper.SetEnvironment();
        }

        private void AddPassword()
        {
            

            FileHelper.SavePassword(new Models.Password()
            {
                Title = "San Pedro Garza García",
                SubTitle = "Decide San Pedro",
                Type = "SSH",
                Server = "192.168.195.131",
                User = "daltum",
                PasswordHash = "JBFjLx-9KMD42P3G8uif4@Zq"
            });

            FileHelper.SavePassword(new Models.Password()
            {
                Title = "San Pedro Garza García",
                SubTitle = "Decide San Pedro",
                Type = "Web Site Account",
                Server = "decidepruebas.sanpedro.gob.mx",
                User = "admin@consul.dev",
                PasswordHash = "M2075v89isp1"
            });

            FileHelper.SavePassword(new Models.Password()
            {
                Title = "Herimsa",
                SubTitle = "Dogotuls",
                Type = "Remote Desktop",
                Server = "64.202.191.89",
                User = "adminherimsa",
                PasswordHash = "godo!@83Part"
            });

            FileHelper.SavePassword(new Models.Password()
            {
                Title = "Herimsa",
                SubTitle = "Dogotuls",
                Type = "Microsoft SQL",
                Server = "64.202.191.89\\sqlexpress",
                User = "dogouser",
                PasswordHash = "sw50svma@aj022($@als482#_"
            });
        }
    }
}