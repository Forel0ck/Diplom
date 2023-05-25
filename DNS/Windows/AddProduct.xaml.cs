using Microsoft.Win32;
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
using static DNS.Classes.ClassEntities;
using DNS.Classes;
using DNS.BD;

namespace DNS.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        string PhotoProduct = null;
        public AddProduct()
        {
            InitializeComponent();
            cbCategory.ItemsSource = context.Category.ToList();
            cbCategory.DisplayMemberPath = "Title";
            cbCategory.SelectedIndex = 0;

            btnEdit.Visibility = Visibility.Hidden;
            btnEdit.IsEnabled = false;


        }

        public AddProduct(BD.Product product)
        {
            InitializeComponent();
            cbCategory.ItemsSource = context.Category.ToList();
            cbCategory.DisplayMemberPath = "Title";
            cbCategory.SelectedIndex = product.IdCategoty - 1;

            tbTitle.Text = product.Title;
            tbDesc.Text = product.Description;
            tbCost.Text = product.Cost.ToString();
            tbQty.Text = product.Qty.ToString();
            tbWidth.Text = product.Width.ToString();
            tbHeight.Text = product.Height.ToString();
            tbLength.Text = product.Length.ToString();
           // ImgProduct = product.MainPhoto.ToString();

            btnReg.Visibility = Visibility.Hidden;
            btnReg.IsEnabled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void ChoopePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                PhotoProduct = openFileDialog.FileName;
            }
        }


        private void tbCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbCost_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }


        private void tbQty_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbQty_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbHeight_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbWidth_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }

        }

        private void tbLength_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            BD.Product product = new BD.Product();

            if (!string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                product.Title = tbTitle.Text;
            }
            else
            {
                MessageBox.Show("Не введено название", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbDesc.Text))
            {
                product.Description = tbDesc.Text;
            }
            else
            {
                MessageBox.Show("Не введен описание", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbCost.Text))
            {
                product.Cost = Convert.ToDecimal(tbCost.Text);
            }
            else
            {
                MessageBox.Show("Не введена цена", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbQty.Text))
            {
                product.Qty = Convert.ToInt32(tbQty.Text);
            }
            else
            {
                MessageBox.Show("Не введено колличество", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbHeight.Text))
            {
                product.Height = Convert.ToDouble(tbHeight.Text);
            }
            else
            {
                MessageBox.Show("Не введена высота", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbWidth.Text))
            {
                product.Width = Convert.ToDouble(tbWidth.Text);
            }
            else
            {
                MessageBox.Show("Не введена ширина", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbLength.Text))
            {
                product.Length = Convert.ToDouble(tbLength.Text);
            }
            else
            {
                MessageBox.Show("Не введена длина", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            product.MainPhoto = PhotoProduct;
            product.IdCategoty = cbCategory.SelectedIndex + 1;

            MessageBox.Show("Товар добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            context.Product.Add(product);
            context.SaveChanges();

            this.Close();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var prod = context.Product.Where(i => i.IdProduct == PersonnelDate.IdProduct).FirstOrDefault();
            prod.Title = tbTitle.Text.Trim();
            prod.Description = tbDesc.Text.Trim();
            prod.Cost = Convert.ToDecimal(tbCost.Text.Trim());
            prod.Qty = Convert.ToInt32(tbQty.Text.Trim());
            prod.Length = Convert.ToInt32(tbLength.Text.Trim()); 
            prod.Width = Convert.ToInt32(tbWidth.Text.Trim());
            prod.Height = Convert.ToInt32(tbHeight.Text.Trim());
            prod.IdCategoty = cbCategory.SelectedIndex + 1;

            BD.Product product = new BD.Product();

            if (!string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                product.Title = tbTitle.Text;
            }
            else
            {
                MessageBox.Show("Не введено название", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbDesc.Text))
            {
                product.Description = tbDesc.Text;
            }
            else
            {
                MessageBox.Show("Не введен описание", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbCost.Text))
            {
                product.Cost = Convert.ToDecimal(tbCost.Text);
            }
            else
            {
                MessageBox.Show("Не введена цена", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbQty.Text))
            {
                product.Qty = Convert.ToInt32(tbQty.Text);
            }
            else
            {
                MessageBox.Show("Не введено колличество", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbHeight.Text))
            {
                product.Height = Convert.ToDouble(tbHeight.Text);
            }
            else
            {
                MessageBox.Show("Не введена высота", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbWidth.Text))
            {
                product.Width = Convert.ToDouble(tbWidth.Text);
            }
            else
            {
                MessageBox.Show("Не введена ширина", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbLength.Text))
            {
                product.Length = Convert.ToDouble(tbLength.Text);
            }
            else
            {
                MessageBox.Show("Не введена длина", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var chek = MessageBox.Show($"Вы хотите изменить данные ", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (chek == MessageBoxResult.Yes)
            {
                context.SaveChanges();

                MessageBox.Show("Данные изменены","Уведомление",MessageBoxButton.OK,MessageBoxImage.Information);

                this.Close();
            }
        }
    }
}
