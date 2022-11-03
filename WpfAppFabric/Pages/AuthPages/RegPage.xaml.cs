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

namespace WpfAppFabric.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            PasswordTB.Background = new SolidColorBrush(MainClass.System_Background_Element_Color);
            LoginTB.Background = new SolidColorBrush(MainClass.System_Background_Element_Color);
            RegisterBTN.Background = new SolidColorBrush(MainClass.System_Background_Button_Color);
        }
        private void RegisterBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new shveikaDBEntities())
                {
                    if (db.User.Any(x => x.login == LoginTB.Text && x.password == PasswordTB.Text))
                    {
                        MessageBox.Show("Такой логин уже существует");
                        return;
                    }
                    db.User.Add(new User { login = LoginTB.Text, password = PasswordTB.Text, role = db.role.First(x => x.name == "Заказчик").id });
                    db.SaveChanges();
                    MessageBox.Show($"Регистрация успешна!\n{db.User.First(x => x.login == LoginTB.Text).role1.name}");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка, проверьте введенные данные.");
            }
        }

        private void AuthLink_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.main.SystemAuthFrame.Navigate(new AuthPage());
        }
    }
}
