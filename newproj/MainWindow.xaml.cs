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

namespace newproj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Button Start { get; set; }

        public MainWindow()
        {
            InitializeComponent();

        }




        private void Start_Click(object sender, RoutedEventArgs e)
        {
            string Name1 = Place.Text;
            Window1 hadash = new Window1(Name1);
            hadash.Show();
            this.Close();

        }

        
    }
}
