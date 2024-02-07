using newproj.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace newproj.viewmodel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private SharedViewModel _sharedViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshUsers()
        {
            // Don't need to reload data, just notify UI
            OnPropertyChanged(nameof(Users));
        }
        public UserViewModel(SharedViewModel sharedViewModel)
        {
            _sharedViewModel = sharedViewModel;

            if (_sharedViewModel.UsersList == null || _sharedViewModel.UsersList.Count == 0)
            {
                _sharedViewModel.UsersList = new List<Login>
{
                 new Login
                {
                    FirstrName ="Nadav",
                    SecondName = "Vallish",
                    ChildsFirstName = "Dani",
                    ChildsSecondName = "Vallish",
                    Age = 12,
                    Password = "A8as523",
                    Email = "yairkokia6@gmail.com"

                },
                new Login
                {
                    FirstrName = "Another",
                    SecondName = "Person",
                    ChildsFirstName = "John",
                    ChildsSecondName = "Doe",
                    Age = 25,
                    Password = "B8as25",
                    Email = "john.doe@example.com"

                },
                new Login
                {
                    FirstrName ="Roei",
                     SecondName = "Smith",
                    ChildsFirstName = "Emma",
                    ChildsSecondName = "Smith",
                    Age = 30,
                    Password = "b8as52",
                    Email = "alice.smith@example.com"

                },
                 new Login
                {
                    FirstrName ="yair",
                     SecondName = "kokia",
                    ChildsFirstName = "bobstar",
                    ChildsSecondName = "kokia",
                    Age = 30,
                    Password = "A3e862",
                    Email = "yairnokia32@gmail.com"

                },
                    new Login
                {
                    FirstrName = "",
                    SecondName = "",
                    ChildsFirstName = "",
                    ChildsSecondName = "",
                    Age = 25,
                    Password = "aa3",
                    Email = ""

                }
};

            }
        }

        public List<Login> Users
        {
            get { return _sharedViewModel.UsersList; }
        }
      
    }
}
