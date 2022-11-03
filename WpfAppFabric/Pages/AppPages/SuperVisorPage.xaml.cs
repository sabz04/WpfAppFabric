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
    /// Логика взаимодействия для SuperVisorPage.xaml
    /// </summary>
    public partial class SuperVisorPage : Page
    {
        public SuperVisorPage()
        {
            InitializeComponent();
        }

        private void ProductBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new shveikaDBEntities())
            {
                var list = new List<string>();
                foreach (var item in db.fittings)
                {
                    list.Add(item.type.name);
                }
                ProductsDG.ItemsSource = db.fittings.ToList();

            }
        }
    }
}
