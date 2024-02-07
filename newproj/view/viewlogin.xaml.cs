using newproj.model;
using newproj.viewmodel;
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
using System.Windows.Shapes;

namespace newproj.view
{
   
    public partial class viewlogin : Page
    {
        private SharedViewModel _sharedViewModel;
        private UserViewModel _userViewModel;
        private string usernametofind; 
        public viewlogin(SharedViewModel SharedViewModel)
        {
            InitializeComponent();
            _sharedViewModel =  SharedViewModel;
          


        }




        private void Loginclick(object sender, RoutedEventArgs e)
        {
            try
            {
                string enteredEmail = UserName.Text;
                string enteredPassword = Passwordclass.Password;
                string userName = UserName.Text;
                Login matchedUser = null;
                string usernamehadash ="";

                foreach (Login user in _sharedViewModel.UsersList)
                {
                    if (user.Email == enteredEmail && user.Password == enteredPassword)
                    {
                        matchedUser = user;
                        usernamehadash = user.FirstrName;

                        break;
                    }
                }


                if (matchedUser != null)
                {

                    Window1 Window1 = new Window1(usernamehadash);  
                    Window1.Show();
                }

                else
                {
                    // No match found, display an error message
                    MessageBox.Show("Invalid email or password. Please try again.");

                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur

                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }



      



        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            Loginstuff loginstuffgo = new Loginstuff(_sharedViewModel);
            NavigationService.Navigate(loginstuffgo);
        }

      










    }
}

