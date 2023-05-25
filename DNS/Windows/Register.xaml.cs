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
using DNS.BD;
using static DNS.Classes.ClassEntities;

namespace DNS.Windows
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();

        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.IdRole = 3;

            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                client.Name = tbName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbLName.Text))
            {
                client.SurName = tbLName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели фамилию");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                client.Email = tbEmail.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели почту");
                return;
            }


            if (!string.IsNullOrWhiteSpace(tbPass.Text))
            {
                client.Password = tbPass.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели пароль");
                return;
            }

            var query = context.Client.Where(p => p.Email == tbEmail.Text).FirstOrDefault();
            if (query != null)
            {
                MessageBox.Show("Пользователь с такой почтой уже есть");
            }
            else
            {
                
                context.Client.Add(client);
                context.SaveChanges();

                MessageBox.Show("Вы зарегестрировались", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                Close();
            }

            
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Authorization authorization = new Authorization();
            authorization.ShowDialog();
            
        }


        private void tbLName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')).ToArray()
                    );
            }
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')).ToArray()
                    );
            }
        }

        private void tbName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbLName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbPass_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
