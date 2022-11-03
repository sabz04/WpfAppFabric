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
using WpfAppFabric.Data;

namespace WpfAppFabric.Pages.AppPages
{
    /// <summary>
    /// Логика взаимодействия для CustomerOrdersPage.xaml
    /// </summary>
    public partial class CustomerOrdersPage : Page
    {
        private User user;
        public CustomerOrdersPage(User user)
        {
            InitializeComponent();
            this.user = user;
            using(var db = new shveikaDBEntities())
            {
                DgOrders.ItemsSource = db.User.Find(user.login).order.ToList();
               
            }
        }

        private void DgOrders_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void BtnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationPage.main.MainNavigationFrame.Navigate(new CustomerPage(user));
        }
    }
}
