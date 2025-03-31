using Mebel.View;
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

namespace Mebel
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрывает текущее окно
        }
        private void BaceWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close(); // Закрывает текущее окно
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            BDOrders bDOrders = new BDOrders();
            bDOrders.Show();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            BDClients bDClients = new BDClients();
            bDClients.Show();
        }

        private void Providers_Click(object sender, RoutedEventArgs e)
        {
            BDProviders bDProviders = new BDProviders();
            bDProviders.Show();
        }

        private void Personal_Click(object sender, RoutedEventArgs e)
        {
            BDPersonal bDPersonal = new BDPersonal();
            bDPersonal.Show();
        }

        private void Mebel_Click(object sender, RoutedEventArgs e)
        {
            BDProducts bDProducts = new BDProducts();
            bDProducts.Show();
        }
    }
}
