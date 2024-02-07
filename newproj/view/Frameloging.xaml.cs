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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace newproj.view
{
    /// <summary>
    /// Interaction logic for Frameloging.xaml
    /// </summary>
    public partial class Frameloging : Window   
    {
        private SharedViewModel _sharedViewModel;
        private UserViewModel _userViewModel;


        public Frameloging()
        {
            InitializeComponent();
            _sharedViewModel = new SharedViewModel();


            _userViewModel = new UserViewModel(_sharedViewModel);

            DataContext = _userViewModel;
            mainFrame.Navigate(new viewlogin(_sharedViewModel));



        }

        private void ClickAdd(object sender, RoutedEventArgs e)
        {
            if (mainFrame != null)
            {
                mainFrame.Visibility = Visibility.Visible;
                mainFrame.Navigate(new Loginstuff(_sharedViewModel));
            }

        }

        private void ClickClose(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            this.Close();
        }
    }
}
