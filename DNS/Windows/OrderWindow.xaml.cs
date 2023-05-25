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
using DNS.Classes;
using DNS.BD;
using static DNS.Classes.BasketClass;

namespace DNS.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
            lvOrder.ItemsSource = BasketClass.goods.ToList();
            SummCost();
        }
        public void SummCost()
        {
            double summ = 0;

            foreach (var item in BasketClass.goods)
            {
                summ += Convert.ToDouble(item.Cost * item.QtyOrder);
            }

            var res = summ;

            tbCost.Text = res.ToString() + '₽';
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            if (lvOrder.SelectedItem is Product product)
            {

                if (product.QtyOrder == 1)
                {
                    var resMass = MessageBox.Show($"Вы точно хотите убрать товар {product.Title} ?", "Предупреждение", MessageBoxButton.YesNo);
                    if (resMass == MessageBoxResult.Yes)
                    {
                        goods.Remove(goods.Where(i => i.IdProduct == product.IdProduct).FirstOrDefault());
                        lvOrder.ItemsSource = goods.ToList();

                        double summ = 0;
                        foreach (var item in BasketClass.goods)
                        {
                            summ += Convert.ToDouble(item.Cost.ToString());
                        }
                        tbCost.Text = summ.ToString() + '₽';
                        lvOrder.ItemsSource = BasketClass.goods.ToList();
                        SummCost();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    product.QtyOrder--;
                    lvOrder.ItemsSource = BasketClass.goods.ToList();
                    SummCost();
                    return;
                }


            }
            else
            {
                MessageBox.Show($"Вы не выбрали товар", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (lvOrder.SelectedItem is Product product)
            {
                product.QtyOrder++;
                lvOrder.ItemsSource = BasketClass.goods.ToList();
                SummCost();
                return;

            }
            else
            {
                MessageBox.Show($"Вы не выбрали товар", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lvOrder.SelectedItem is BD.Product product)
            {
                var resMass = MessageBox.Show($"Вы точно хотите убрать товар {product.Title} ?", "Предупреждение", MessageBoxButton.YesNo);
                if (resMass == MessageBoxResult.Yes)
                {
                    goods.Remove(goods.Where(i => i.IdProduct == product.IdProduct).FirstOrDefault());
                    lvOrder.ItemsSource = goods.ToList();

                    double summ = 0;
                    foreach (var item in BasketClass.goods)
                    {
                        summ += Convert.ToDouble(item.Cost.ToString());
                    }
                    tbCost.Text = summ.ToString() + '₽';
                    lvOrder.ItemsSource = BasketClass.goods.ToList();
                    SummCost();
                }
                else
                {
                    SummCost();
                    lvOrder.ItemsSource = BasketClass.goods.ToList();
                    return;

                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали товар", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            PayWindow payWindow = new PayWindow();
            payWindow.ShowDialog();
        }
    }
}
