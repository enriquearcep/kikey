using Kikey.Helpers;
using Kikey.Models;
using Kikey.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Kikey.ViewModels
{
    public class PasswordsViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Full properties
        private List<Password> _passwords;

        public List<Password> Passwords
        {
            get => _passwords ?? (_passwords = new List<Password>());
            set
            {
                if (_passwords != value)
                {
                    _passwords = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Passwords)));
                }
            }
        }

        private Password _selectedPassword;

        public Password SelectedPassword
        {
            get => _selectedPassword ?? (_selectedPassword = new Password());
            set
            {
                if (_selectedPassword != value)
                {
                    _selectedPassword = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPassword)));
                    Clipboard.SetText(value.PasswordHash);
                }
            }
        }
        #endregion

        #region Commands
        public ICommand ToNewPasswordCommand => new CommandHelper(ToNewPassword);
        #endregion

        public static PasswordsViewModel _instance;

        public static PasswordsViewModel GetInstance()
        {
            if(_instance is null)
            {
                return new PasswordsViewModel();
            }

            return _instance;
        }

        #region Constructors
        public PasswordsViewModel()
        {
            Passwords = FileHelper.GetPasswords();

            _instance = this;
        }
        #endregion

        #region Methods
        private void ToNewPassword()
        {
            var newPassword = new NewPasswordView();

            newPassword.Show();
        }

        public void Reload()
        {
            Passwords = FileHelper.GetPasswords();
        }
        #endregion
    }
}