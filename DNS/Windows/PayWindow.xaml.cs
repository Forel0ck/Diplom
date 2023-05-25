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
    /// Логика взаимодействия для PayWindow.xaml
    /// </summary>
    public partial class PayWindow : Window
    {
        public PayWindow()
        {
            InitializeComponent();
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Покупка оплачена","Уведомление",MessageBoxButton.OK);

        }

        private void btnMoney_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Покупка оплачена", "Уведомление", MessageBoxButton.OK);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
