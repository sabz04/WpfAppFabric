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
using WpfAppFabric.Models;
using WpfAppFabric.Pages.AppPages;

namespace WpfAppFabric.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            PasswordTB.Background = new SolidColorBrush(MainClass.System_Background_Element_Color);
            LoginTB.Background = new SolidColorBrush(MainClass.System_Background_Element_Color);
            LoginBTN.Background = new SolidColorBrush(MainClass.System_Background_Button_Color);
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new shveikaDBEntities())
                {
                    var user = db.User.FirstOrDefault(x => x.login == LoginTB.Text && x.password == PasswordTB.Text);
                    if (user == null)
                    {
                        MessageBox.Show("Такого пользователя не найдено!");
                        return;
                    }
                    MessageBox.Show($"Авторизация успешна!\n{user.role1.name}");
                    
                    NavigationPage nav = new NavigationPage(user);
                    nav.Show();
                    MainWindow.main.Hide();
                    //(Parent as Frame).Navigate(nav);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка, проверьте введенные данные.");
            }
        }

        private void RegLink_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.main.SystemAuthFrame.Navigate(new RegPage());
        }
    }
}
