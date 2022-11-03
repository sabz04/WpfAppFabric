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
using WpfAppFabric.Data;
using WpfAppFabric.Models;

namespace WpfAppFabric.Pages.AppPages
{
    /// <summary>
    /// Логика взаимодействия для NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Window
    {
        public static NavigationPage main;
       
        public NavigationPage(User user)
        {
            InitializeComponent();
            currentSessionTB.Text = $"Сессия: {user.login}\n{user.role1.name}";
            if(user.role1.name == MainClass.StoreKeeper)
            {
                MainNavigationFrame.Navigate(new StoreKeeperPage());
            }
            if (user.role1.name == MainClass.Manager)
                MainNavigationFrame.Navigate(new ManagerPage());
            if (user.role1.name == MainClass.Director)
                MainNavigationFrame.Navigate(new SuperVisorPage());
            if (user.role1.name == MainClass.Customer)
                MainNavigationFrame.Navigate(new CustomerOrdersPage(user));
            main = this;
        }

        private void exitBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Show();
            this.Close();
        }
    }
}
