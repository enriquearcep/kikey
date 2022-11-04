using Kikey.Helpers;
using Kikey.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

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
                    TitleText = $"Copiado en portapapeles [{SelectedPassword.PasswordHash}]";
                }
            }
        }

        private string _titleText;

        public string TitleText
        {
            get => _titleText;
            set
            {
                if (_titleText != value)
                {
                    _titleText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TitleText)));
                }
            }
        }
        #endregion

        #region Constructors
        public PasswordsViewModel()
        {
            Passwords = FileHelper.GetPasswords();
        } 
        #endregion
    }
}