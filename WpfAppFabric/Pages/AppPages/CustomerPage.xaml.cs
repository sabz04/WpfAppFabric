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
    /// Логика взаимодействия для CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        private User currentUser;
        public CustomerPage(User user)
        {
            InitializeComponent();
            RefreshComboBox();
            currentUser = user; 

        }
        string selectedItemId = "";
        string selectedClothId = "";
        string selectedFittingId = "";
        public void RefreshComboBox()
        {
            using(var db = new shveikaDBEntities())
            {
                foreach(var item in db.item)
                {
                    var cbi = new ComboBoxItem() { Content = item.name };
                    cbi.Selected += (s, e) =>
                    {
                        selectedItemId = item.code;
                        TbWidth.Text = item.width.ToString();
                        TbHeight.Text = item.length.ToString();
                    };
                    CbProduct.Items.Add(cbi);
                }
                foreach (var item in db.cloth)
                {
                    var cbi = new ComboBoxItem() { Content = item.name };
                    cbi.Selected += (s, e) => selectedClothId = item.code;
                    CbFabric.Items.Add(cbi);
                }
                //CbProduct.ItemsSource = db.item.Select(x => new ComboBoxItem() { Content = x.name });
                foreach (var item in db.fittings)
                {
                    var cbi = new ComboBoxItem() { Content = item.name };
                    cbi.Selected += (s, e) => selectedFittingId = item.code;
                    CbFurniture.Items.Add(cbi);
                }
            }
            
        }

        private void CbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbFabric_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbFurniture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbHeightUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new shveikaDBEntities())
            {
                var user = db.User.Find(currentUser.login);
                if (user == null)
                {
                    MessageBox.Show("НЕЛЬЗЯ! ВАС ЗАБАНИЛИ!");
                    return;
                }

                List<orderedItems> orderedItemsSet = new List<orderedItems>();
                foreach(var itemObj in ProductsDG.Items)
                {
                    var item = db.item.Find((itemObj as item).code);
                    orderedItems oi = new orderedItems()
                    {
                        IdItem = item.code,
                        count = orderedItemCountDictionary[itemObj as item],
                    };
                    orderedItemsSet.Add(oi);
                }

                user.order.Add(new order()
                {
                    number = db.order.Count(),
                    date = DateTime.Now,
                    statusid = db.status.First(x=>x.name=="Новый").id,
                    orderedItems = orderedItemsSet,
                    status = db.status.First(x => x.name == "Новый").name,
                    manager = db.User.First(x=>x.role1.name == MainClass.Manager).login

                });
                db.SaveChanges();
            }
        }

        private void BtnAddToList_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new shveikaDBEntities())
            {
                var item = db.item.Find(selectedItemId);
                ProductsDG.Items.Add(item);

                orderedItemCountDictionary[item] = Int32.Parse(TbProductAmount.Text);
            }
        }

        private void BtnDeleteFromList_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItem != null && ProductsDG.Items.Contains(selectedItem))
                ProductsDG.Items.Remove(selectedItem);
        }

        Dictionary<item, int> orderedItemCountDictionary = new Dictionary<item, int>();

        item selectedItem = null;
        private void ProductsDG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selectedItem = ProductsDG.SelectedItem as item;
            
        }

        private void BtnBackPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationPage.main.MainNavigationFrame.Navigate(new CustomerOrdersPage(currentUser));
        }
    }
}
