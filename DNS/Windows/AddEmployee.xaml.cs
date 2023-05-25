using DNS.BD;
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

namespace DNS.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        string PhotoEmployee = null;
        public AddEmployee()
        {
            InitializeComponent();
            cbPost.ItemsSource = context.Post.ToList();
            cbPost.DisplayMemberPath = "Title";
            cbPost.SelectedIndex = 0;

            cbGender.ItemsSource = context.Gender.ToList();
            cbGender.DisplayMemberPath = "Title";
            cbGender.SelectedIndex = 0;

            btnEdit.Visibility = Visibility.Hidden;
            btnEdit.IsEnabled = false;

        }

        public AddEmployee(Employee employee)
        {
            InitializeComponent();
            tbName.Text = employee.Name;
            tbLName.Text = employee.SurName;
            tbPassSer.Text = employee.PassportSerial;
            tbPassNumber.Text = employee.PassportNumber;
            tbAddress.Text = employee.Address;
            tbPhone.Text = employee.Phone;
            tbExp.Text = employee.Experience.ToString();
            tbEmail.Text = employee.Email;
            tbPass.Text = employee.Password;
            dpBirt.DisplayDate = employee.Birthday;
         //   ImgEmployee.Source = employee.Photo;

            cbGender.ItemsSource = context.Gender.ToList();
            cbGender.DisplayMemberPath = "Title";
            cbGender.SelectedIndex=employee.IdGender - 1;

            cbPost.ItemsSource = context.Post.ToList();
            cbPost.DisplayMemberPath = "Title";
            cbPost.SelectedIndex = employee.IdPost - 1;

            btnReg.Visibility = Visibility.Hidden;
            btnReg.IsEnabled = false;

        }

       

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        private void tbLName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbPassSer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbPassSer_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbPassNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbPassNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') 
                         || (ch >= 'А' && ch <= 'Я') 
                         || ch == 'ё' || ch == 'Ё' 
                         || ch == '.' || ch == ','
                         || (ch >= 'a' && ch <= 'z') 
                         || (ch >= 'A' && ch <= 'Z') 
                         || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }


        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => ch == '+' || ch == '-' || ch == '(' || ch == ')' || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbExp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbExp_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                employee.Name = tbName.Text;
            }
            else
            {
                MessageBox.Show("Не введено имя", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbLName.Text))
            {
                employee.SurName = tbLName.Text;
            }
            else
            {
                MessageBox.Show("Не введена фамилия", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPassSer.Text))
            {
                employee.PassportSerial = tbPassSer.Text;
            }
            else
            {
                MessageBox.Show("Не введена серия паспорта", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPassNumber.Text))
            {
                employee.PassportNumber = tbPassNumber.Text;
            }
            else
            {
                MessageBox.Show("Не введен номер паспорта", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                employee.Address = tbAddress.Text;
            }
            else
            {
                MessageBox.Show("Не введен адрес", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                employee.Phone = tbPhone.Text;
            }
            else
            {
                MessageBox.Show("Не введен номер телефона", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbExp.Text))
            {
                employee.Experience = Convert.ToInt32(tbExp.Text);
            }
            else
            {
                MessageBox.Show("Не введен опыт работы", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                employee.Email = tbEmail.Text;
            }
            else
            {
                MessageBox.Show("Не введена потча", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPass.Text))
            {
                employee.Password = tbPass.Text;
            }
            else
            {
                MessageBox.Show("Не введен пароль", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(dpBirt.Text))
            {
                employee.Birthday = Convert.ToDateTime(dpBirt.Text);
            }
            else
            {
                MessageBox.Show("Не введена дата рождения", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var ChekPass = context.Employee.Where(i => i.PassportNumber == tbPassNumber.Text && i.PassportSerial == tbPassSer.Text).FirstOrDefault();
            if (ChekPass != null)
            {
                MessageBox.Show("Такие паспортные данные уже есть в базе", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            employee.Photo = PhotoEmployee;
            employee.IdRole = 2;
            employee.IdGender = cbGender.SelectedIndex + 1;
            employee.IdPost = cbPost.SelectedIndex + 1;

            MessageBox.Show("Сотрудник добавлен","Уведомление",MessageBoxButton.OK,MessageBoxImage.Information);
            context.Employee.Add(employee);
            context.SaveChanges();

            this.Close();

        }

        private void ChoopePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgEmployee.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                PhotoEmployee = openFileDialog.FileName;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var emp = context.Employee.Where(i => i.IdEmployee == PersonnelDate.IdEmployee).FirstOrDefault();

            emp.Name = tbName.Text.Trim();
            emp.SurName = tbName.Text.Trim();
            emp.PassportSerial = tbPassSer.Text.Trim();
            emp.PassportNumber = tbPassNumber.Text.Trim();
            emp.Address = tbAddress.Text.Trim();
            emp.Phone = tbPhone.Text.Trim();
            emp.Experience = Convert.ToInt32(tbExp.Text.Trim());
            emp.Email = tbEmail.Text.Trim();
            emp.Password = tbPass.Text.Trim();
            emp.Birthday = Convert.ToDateTime(dpBirt.Text.Trim());
            emp.IdPost = cbPost.SelectedIndex + 1;
            emp.IdGender = cbGender.SelectedIndex + 1;


            Employee employee = new Employee();
            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                employee.Name = tbName.Text;
            }
            else
            {
                MessageBox.Show("Не введено имя", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbLName.Text))
            {
                employee.SurName = tbLName.Text;
            }
            else
            {
                MessageBox.Show("Не введена фамилия", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPassSer.Text))
            {
                employee.PassportSerial = tbPassSer.Text;
            }
            else
            {
                MessageBox.Show("Не введена серия паспорта", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPassNumber.Text))
            {
                employee.PassportNumber = tbPassNumber.Text;
            }
            else
            {
                MessageBox.Show("Не введен номер паспорта", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                employee.Address = tbAddress.Text;
            }
            else
            {
                MessageBox.Show("Не введен адрес", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                employee.Phone = tbPhone.Text;
            }
            else
            {
                MessageBox.Show("Не введен номер телефона", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbExp.Text))
            {
                employee.Experience = Convert.ToInt32(tbExp.Text);
            }
            else
            {
                MessageBox.Show("Не введен опыт работы", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                employee.Email = tbEmail.Text;
            }
            else
            {
                MessageBox.Show("Не введена потча", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPass.Text))
            {
                employee.Password = tbPass.Text;
            }
            else
            {
                MessageBox.Show("Не введен пароль", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(dpBirt.Text))
            {
                employee.Birthday = Convert.ToDateTime(dpBirt.Text);
            }
            else
            {
                MessageBox.Show("Не введена дата рождения", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var chek = MessageBox.Show($"Вы хотите изменить данные ", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (chek == MessageBoxResult.Yes)
            {
                context.SaveChanges();

                MessageBox.Show("Данные изменены");

                this.Close();
            }
        }
    }
}
