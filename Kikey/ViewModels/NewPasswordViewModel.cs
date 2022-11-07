using Kikey.Helpers;
using Kikey.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Kikey.ViewModels
{
    public class NewPasswordViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public Action CloseAction { get; set; }

        #region Full properties
        private string _type;

        public string Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
                }
            }
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
                }
            }
        }

        private string _subtitle;

        public string Subtitle
        {
            get => _subtitle;
            set
            {
                if (_subtitle != value)
                {
                    _subtitle = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtitle)));
                }
            }
        }

        private string _server;

        public string Server
        {
            get => _server;
            set
            {
                if (_server != value)
                {
                    _server = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Server)));
                }
            }
        }

        private string _user;

        public string User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(User)));
                }
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
                }
            }
        }
        #endregion

        #region Commands
        public ICommand AddPasswordCommand => new CommandHelper(AddPassword);
        #endregion

        #region Methods
        private void AddPassword()
        {
            try
            {
                if (AreValidFields())
                {
                    var password = new Password()
                    {
                        Type = Type,
                        Title = Title,
                        Server = Server,
                        SubTitle = Subtitle,
                        User = User,
                        PasswordHash = Password
                    };

                    var exists = FileHelper.ExistsPassword(password);

                    if(!exists)
                    {
                        var added = FileHelper.SavePassword(password);

                        if(added)
                        {
                            MessageBox.Show("La contraseña se almacenó con éxito.", "Nueva contraseña", MessageBoxButton.OK, MessageBoxImage.Information);

                            // Actualizar combo
                            var passwords = PasswordsViewModel.GetInstance();

                            passwords?.Reload();

                            CloseAction();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al intentar almacenar la contraseña.", "Oops", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Esta contraseña ya existe en tu listado.", "Oops", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private bool AreValidFields()
        {
            if (string.IsNullOrEmpty(Type))
            {
                MessageBox.Show("Debes ingresar el tipo de contraseña.\n\nEjemplos: SSH, Web Site Account, Database, Remote Desktop, etc.", "Campo vacío", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Title))
            {
                MessageBox.Show("Debes ingresar el título de la contraseña", "Campo vacío", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Subtitle))
            {
                MessageBox.Show("Debes ingresar el subtítulo de la contraseña", "Campo vacío", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Server))
            {
                MessageBox.Show("Debes ingresar el servidor, host o dominio de la contraseña", "Campo vacío", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(User))
            {
                MessageBox.Show("Debes ingresar el usuario de la contraseña", "Campo vacío", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Debes ingresar la contraseña", "Campo vacío", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            return true;
        }
        #endregion
    }
}
