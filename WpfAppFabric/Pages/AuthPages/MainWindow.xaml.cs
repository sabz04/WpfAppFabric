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
using WpfAppFabric.Pages;

namespace WpfAppFabric
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow main;
        public MainWindow()
        {
            InitializeComponent();
            Background = new SolidColorBrush(MainClass.System_Background_Color);
            SystemAuthFrame.Navigate(new RegPage());
            main = this;


        }

        private void RegisterBTN_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
