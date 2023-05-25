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
using DNS.BD;
using  DNS.Classes;
using DNS.Pages;


namespace DNS.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Catalog.Content = new AllProduct(this);
            ContClass.mainWindow = this; 

        }

        private void btnAppliances_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new Appliances(this);
        }

        private void btnBeautyAndHealth_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new Beautyandhealth(this);
        }

        private void btnSmartphones_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new Smartphones(this);
        }

        private void btnTV_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new TV(this);
        }

        private void btnPCs_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new PCs(this);
        }

        private void btnPCAccessories_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new PCAccessories(this);
        }

        private void btnOfficeAndFurniture_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new Officeandfurniture(this);
        }

        private void btnNetworkEquipment_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new NetworkEquipment(this);
        }

        private void btnTools_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new Tools(this);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new Home(this);
        }

        private void tbnAccessories_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new Accessories(this);
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.ShowDialog();

        }

        private void btnAllProduct_Click(object sender, RoutedEventArgs e)
        {
            Catalog.Content = new AllProduct(this);
        }
    }
}
