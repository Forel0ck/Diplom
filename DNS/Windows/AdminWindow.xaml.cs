using DNS.Pages;
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

namespace DNS.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            Catalog.Content = new AllProduct(this);
        }

        private void btnAllProduct_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new AllProduct(this);
        }

        private void btnEmploe_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new Employee(this);
        }
    }
}
