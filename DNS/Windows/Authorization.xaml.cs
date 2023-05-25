using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using DNS.Classes;
using static DNS.Classes.ClassEntities;

namespace DNS.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            Register register = new Register();
            register.ShowDialog();
            Close();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var User = context.Client.ToList().
                Where(p => p.Email == this.tbLog.Text && p.Password == tbPass.Text).FirstOrDefault();
            var Emploe = context.Employee.ToList().
                Where(p => p.Email == this.tbLog.Text && p.Password == tbPass.Text).FirstOrDefault();
            if ((Emploe != null) || (User != null ))
            {
                var login = Convert.ToString(tbLog.Text);
                if (User != null)
                {
                    ContClass.mainWindow.Close();
                    MainWindow userWindow = new MainWindow();
                    this.Close();
                    userWindow.ShowDialog();
                    
                    
                }
                else
                {
                    switch (Emploe.IdRole)
                    {
                        case 1:
                            this.Hide();
                            
                            ContClass.mainWindow.Close();
                            AdminWindow adminWindow = new AdminWindow();
                            ContClass.mainWindow = adminWindow;
                            this.Close();
                            adminWindow.Show();
                            
                            break;

                        case 2:
                            this.Hide();
                            ContClass.mainWindow.Close();
                            ManegerWindow manegerWindow = new ManegerWindow();
                            this.Close();
                            ContClass.mainWindow = manegerWindow;
                            
                            
                            break;

                        default:
                            break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Вы ввели не правильно пароль или логин");
                tbLog.Clear();
                tbPass.Clear();
                return;
                

            }
            



        }
    }
}
