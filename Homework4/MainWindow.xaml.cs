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

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.PostalCode postCode = new Models.PostalCode();

        public MainWindow()
        {
            InitializeComponent();
            uxPostalCode.DataContext = postCode;
            uxSubmit.DataContext = postCode;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submit Clicked");
        }
    }
}
