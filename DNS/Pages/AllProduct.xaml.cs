using DNS.BD;
using DNS.Classes;
using DNS.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static DNS.Classes.ClassEntities;

namespace DNS.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllProduct.xaml
    /// </summary>
    public partial class AllProduct : Page
    {
        


        List<BD.Product> products = new List<BD.Product>();
        List<string> ForSort = new List<string>()
        {
            "По умолчанию","Стоимость по возрастанию","Стоимость по убыванию","Наименование по возрастанию","Наименование по убыванию ","Остаток на складе по возрастанию","Остаток на складе по убыванию "
        };
        public AllProduct(Windows.MainWindow mainWindow)
        {
            InitializeComponent();
            lvAllProduct.ItemsSource = ClassEntities.context.Product.ToList();
            cbSort.ItemsSource = ForSort;
            cbSort.SelectedIndex = 0;

            btnRefresh.Visibility = Visibility.Hidden;
            btnRefresh.IsEnabled = false;

            btnAdd.Visibility = Visibility.Hidden;
            btnAdd.IsEnabled = false;

            btnDel.Visibility = Visibility.Hidden;
            btnDel.IsEnabled = false;

            btnEditing.Visibility = Visibility.Hidden;
            btnEditing.IsEnabled = false;


            Filter();
        }
        public AllProduct(Windows.AdminWindow adminWindow)
        {
            InitializeComponent();
            lvAllProduct.ItemsSource = ClassEntities.context.Product.ToList();
            cbSort.ItemsSource = ForSort;
            cbSort.SelectedIndex = 0;

            btnCart.Visibility = Visibility.Hidden;
            btnCart.IsEnabled = false;


            Filter();
        }

        private void Filter()
        {
            products = ClassEntities.context.Product.ToList();

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

            if (lvAllProduct == null)
            {
                MessageBox.Show("Такой записи нет");
            }
            lvAllProduct.ItemsSource = products;
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lvAllProduct.SelectedItem is Product product)
            {
                var resMass = MessageBox.Show($"Вы хотите удалить товар {product.Title}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMass == MessageBoxResult.Yes)
                {
                    context.Product.Remove(context.Product.Where(i => i.IdProduct == product.IdProduct).FirstOrDefault());
                    context.SaveChanges();
                    lvAllProduct.ItemsSource = context.Product.ToList();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали товар", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Filter();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void btnEditing_Click(object sender, RoutedEventArgs e)
        {
            if (lvAllProduct.SelectedItem is Product product)
            {
                var resMass = MessageBox.Show($"Вы хотите изменить товар {product.Title}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMass == MessageBoxResult.Yes)
                {
                    AddProduct addProduct = new AddProduct(product);
                    PersonnelDate.IdProduct = product.IdProduct;
                    addProduct.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали товар", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvAllProduct_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (lvAllProduct.SelectedItem is Product product)
                {
                    var resMass = MessageBox.Show($"Вы хотите удалить товар {product.Title}", "Предупреждение", MessageBoxButton.YesNo);
                    if (resMass == MessageBoxResult.Yes)
                    {
                        context.Product.Remove(context.Product.Where(i => i.IdProduct == product.IdProduct).FirstOrDefault());
                        context.SaveChanges();
                        lvAllProduct.ItemsSource = context.Product.ToList();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show($"Вы не выбрали товар", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            Filter();
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
