using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class Credentials : INotifyPropertyChanged
    {
        private string _username;       
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                } 
            } 
        }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Platform { get; set; }
        public string CreationDate { get; set; }
        public string Notes { get; set; }
        public string LastModified { get; set; }
        public string TwoFactorEnabled { get; set; }
        public string Category { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Debug.WriteLine($"PropertyChanged fired for: {propertyName}");
        }
    }
}
