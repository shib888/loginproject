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
    /// <summary>
    /// Interaction logic for Loginstuff.xaml
    /// </summary>
    public partial class Loginstuff : Page
    {
        private SharedViewModel _sharedViewModel;
        private UserViewModel _userViewModel;

        public Loginstuff(SharedViewModel SharedViewModel)
        {
            InitializeComponent();
            _sharedViewModel =  SharedViewModel;

        }

        public bool ValidatePassword(string password)
        {
            // בדיקת אורך הסיסמה
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }

            // בדיקת כלול אות גדולה
            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            // בדיקת כלול ספרה
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            // הסיסמה עומדת בכל התנאים
            return true;
        }

        private void AddUserButton(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get data from textboxes

                string firstName = FirstNameClass.Text;
                string lastName = SecomdNameClass.Text;
                string password = Passwordclass.Text;
                string email = EmaileClass.Text;
                int Age = int.Parse(AgeClass.Text);
                string ChildsFirstName = ChildsFirstNameClass.Text;
                string ChildsSecondName = ChildsSecondNameClass.Text;

                // Create a new user
                Login newUser = new Login
                {
                    FirstrName = firstName,
                    SecondName = lastName,
                    ChildsFirstName = ChildsFirstName,
                    ChildsSecondName = ChildsSecondName,
                    Age = Age,
                    Password = password,
                    Email = email,



                };
                if (ValidatePassword(password))
                {
                    bool flag = true ;
                    foreach (Login user in _sharedViewModel.UsersList)
                    {
                        if (user.Email == email )
                        {
                            MessageBox.Show("This email alredy exist");
                            flag= false ;
                            break;

                        }
                    }
                    if(flag ==true)
                    {
                        _sharedViewModel.UsersList.Add(newUser);
                        MessageBox.Show("User added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        viewlogin newviewlogin = new viewlogin(_sharedViewModel);
                        NavigationService.GoBack();

                    }
                    


                }
                else
                {
                    MessageBox.Show("Password is not strong enough");
                }




            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RestoreDefaultText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                switch (textBox.Name)
                {
                    case "FirstNameClass":
                        textBox.Text = "First Name";
                      
                        break;
                    case "Passwordclass":
                        textBox.Text = "Password";
                        break;
                    case "SecomdNameClass":
                        textBox.Text = "Second Name";
                        break;
                    case "EmaileClass":
                        textBox.Text = "Email";
                        break;
                    case "AgeClass":
                        textBox.Text = "Age";
                        break;
                    case "ChildsFirstNameClass":
                        textBox.Text = "Child's First Name";
                        break;
                    case "ChildsSecondNameClass":
                        textBox.Text = "Child's Second Name";
                        break;
                    default:
                        break;
                }
            }
        }

        private void ClearTextBoxText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = string.Empty;
        }


    }
}
