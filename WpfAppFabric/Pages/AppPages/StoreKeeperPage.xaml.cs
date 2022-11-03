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

namespace WpfAppFabric.Pages.AppPages
{
    /// <summary>
    /// Логика взаимодействия для StoreKeeperPage.xaml
    /// </summary>
    public partial class StoreKeeperPage : Page
    {
        public StoreKeeperPage()
        {
            InitializeComponent();
            MainDP.Children.Remove(ClotheSV);
            MainDP.Children.Remove(FittingsSV);
        }


        private void ClothesBtn_Click(object sender, RoutedEventArgs e)
        {
            PlaceHoldeSV.Content = ClotheSV.Content;
            //MainDP.Children.Add(ClotheSV);
            //if(MainDP.Children.Contains(FittingsSV))
            //    MainDP.Children.Remove(FittingsSV);
            (sender as Button).Background = new SolidColorBrush(MainClass.System_Background_Secondary_Color);
            FittingsBtn.Background = new SolidColorBrush(MainClass.System_Background_Button_Color);

            using (var db = new shveikaDBEntities())
            {
                var list = new List<string>();
                foreach (var item in db.cloth)
                {
                    list.Add(item.picture.name);
                }
                foreach (var item in db.cloth)
                {
                    list.Add(item.color.name);
                }
                ClothesGrid.ItemsSource = db.cloth.ToList();

            }
        }

        private void FittingsBtn_Click(object sender, RoutedEventArgs e)
        {
            PlaceHoldeSV.Content = FittingsSV.Content;
            (sender as Button).Background = new SolidColorBrush(MainClass.System_Background_Secondary_Color);
            ClothesBtn.Background = new SolidColorBrush(MainClass.System_Background_Button_Color);

            using (var db = new shveikaDBEntities())
            {
                var list = new List<string>();
                foreach (var item in db.fittings)
                {
                    list.Add(item.type.name);
                }
                FurnituresGrid.ItemsSource = db.fittings.ToList();

            }
        }
    } 
}
