using DNS.BD;
using DNS.Classes;
using DNS.Windows;
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

namespace DNS.Pages
{
    /// <summary>
    /// Логика взаимодействия для Accessories.xaml
    /// </summary>
    public partial class Accessories : Page
    {
        List<BD.Product> products = new List<BD.Product>();
        List<string> ForSort = new List<string>()
        {
            "По умолчанию","Стоимость по возрастанию","Стоимость по убыванию","Наименование по возрастанию","Наименование по убыванию ","Остаток на складе по возрастанию","Остаток на складе по убыванию "
        };
        public Accessories(Windows.MainWindow mainWindow)
        {
            InitializeComponent();
            lvAccessories.ItemsSource = ClassEntities.context.Product.Where(i => i.IdCategoty == 11).ToList();
            cbSort.ItemsSource = ForSort;
            cbSort.SelectedIndex = 0;
            Filter();
        }
        private void Filter()
        {
            products = ClassEntities.context.Product.Where(i => i.IdCategoty == 11).ToList();

            products = products.Where(i => i.Title.Contains(tbSearch.Text)).ToList();


            switch (cbSort.SelectedIndex)
            {
                case 0:
                    products = products.OrderBy(i => i.IdProduct).ToList();
                    break;
                case 1:
                    products = products.OrderBy(i => i.Cost).ToList();
                    break;
                case 2:
                    products = products.OrderByDescending(i => i.Cost).ToList();
                    break;
                case 3:
                    products = products.OrderBy(i => i.Title).ToList();
                    break;
                case 4:
                    products = products.OrderByDescending(i => i.Title).ToList();
                    break;
                case 5:
                    products = products.OrderBy(i => i.Qty).ToList();
                    break;
                case 6:
                    products = products.OrderByDescending(i => i.Qty).ToList();
                    break;
                default:
                    products = products.OrderBy(i => i.IdProduct).ToList();
                    break;
            }

            if (lvAccessories == null)
            {
                MessageBox.Show("Такой записи нет");
            }
            lvAccessories.ItemsSource = products;
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.ShowDialog();
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
                return;
            var product = button.DataContext as Product;

            if (product == null)
                return;
            foreach (var item in BasketClass.goods)
            {
                if (item == product)
                {
                    item.QtyOrder++;
                    return;
                }
            }

            BasketClass.goods.Add(product);
        }
    }
}
