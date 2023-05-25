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
using DNS.BD;
using static DNS.Classes.ClassEntities;

namespace DNS.Pages
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Page
    {
        
        List<BD.Employee> employees = new List<BD.Employee>();
        List<string> ForSort = new List<string>()
        {
            "По умолчанию","Фамилия по возрастанию","Фамилия по убыванию","Адрес по возрастанию","Адрес по убыванию ","Должность по возрастанию","Должность по по убыванию "
        };
        public Employee(AdminWindow adminWindow)
        {
            InitializeComponent();
            lvEmployee.ItemsSource = ClassEntities.context.Employee.ToList();
            cbSort.ItemsSource = ForSort;
            cbSort.SelectedIndex = 0;
            Filter();
        }
        private void Filter()
        {
            employees = context.Employee.ToList();

            employees = employees.Where(i => i.FullName.Contains(tbSearch.Text)).ToList();


            switch (cbSort.SelectedIndex)
            {
                case 0:
                    employees = employees.OrderBy(i => i.IdEmployee).ToList();
                    break;
                case 1:
                    employees = employees.OrderBy(i => i.FullName).ToList();
                    break;
                case 2:
                    employees = employees.OrderByDescending(i => i.FullName).ToList();
                    break;
                case 3:
                    employees = employees.OrderBy(i => i.Address).ToList();
                    break;
                case 4:
                    employees = employees.OrderByDescending(i => i.Address).ToList();
                    break;
                case 5:
                    employees = employees.OrderBy(i => i.IdRole).ToList();
                    break;
                case 6:
                    employees = employees.OrderByDescending(i => i.IdRole).ToList();
                    break;
                default:
                    employees = employees.OrderBy(i => i.IdEmployee).ToList();
                    break;
            }

            if (lvEmployee == null)
            {
                MessageBox.Show("Такой записи нет");
            }
            lvEmployee.ItemsSource = employees;
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
        }


        private void lvEmployee_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (lvEmployee.SelectedItem is BD.Employee employee)
                {
                    var resMass = MessageBox.Show($"Вы хотите удалить сторудника {employee.FullName}", "Предупреждение", MessageBoxButton.YesNo);
                    if (resMass == MessageBoxResult.Yes)
                    {
                        context.Employee.Remove(context.Employee.Where(i => i.IdEmployee == employee.IdEmployee).FirstOrDefault());
                        context.SaveChanges();
                        lvEmployee.ItemsSource = context.Employee.ToList();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show($"Вы не выбрали сторудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Filter();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployee.SelectedItem is BD.Employee employee)
            {
                var resMass = MessageBox.Show($"Вы хотите удалить сторудника {employee.FullName}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMass == MessageBoxResult.Yes)
                {
                    context.Employee.Remove(context.Employee.Where(i => i.IdEmployee == employee.IdEmployee).FirstOrDefault());
                    context.SaveChanges();
                    lvEmployee.ItemsSource = context.Employee.ToList();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали сторудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Filter();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void btnEditing_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployee.SelectedItem is BD.Employee employee)
            {
                var resMass = MessageBox.Show($"Вы хотите изменить сотрудника {employee.FullName}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMass == MessageBoxResult.Yes)
                {
                    AddEmployee addEmployee = new AddEmployee(employee);
                    PersonnelDate.IdEmployee = employee.IdEmployee;
                    addEmployee.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали сотруднка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
