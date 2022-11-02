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

namespace WpfAppFabric
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Background = new SolidColorBrush(MainClass.System_Background_Color);
            PasswordTB.Background = new SolidColorBrush(MainClass.System_Background_Element_Color);
            LoginTB.Background = new SolidColorBrush(MainClass.System_Background_Element_Color);
            RegisterBTN.Background = new SolidColorBrush(MainClass.System_Background_Button_Color);

        }

        private void RegisterBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using(var db = new ModelFabricContainer())
                {
                    if (db.UserSet.Any(x => x.Login == LoginTB.Text))
                    {
                        MessageBox.Show("Такой логин уже существует");
                        return;
                    }
                    db.UserSet.Add(new User { Login = LoginTB.Text, Password = PasswordTB.Text });
                    db.SaveChanges();
                    MessageBox.Show($"Регистрация успешна!\n{db.UserSet.First(x=>x.Login == LoginTB.Text).Login}\n{db.UserSet.First(x=>x.Login == LoginTB.Text).Password}");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка, проверьте введенные данные.");
            }
        }
    }
}
