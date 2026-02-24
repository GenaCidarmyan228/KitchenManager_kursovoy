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
using KitchenManager.Windows;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KitchenManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            DGridServices.ItemsSource = KitchenBaseEntities2.GetContext().Services.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow win = new AddServiceWindow();
            win.ShowDialog();
            UpdateData();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DGridServices.SelectedItem as Services;
            if (selectedItem != null && MessageBox.Show("Удалить услугу?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    KitchenBaseEntities2.GetContext().Services.Remove(selectedItem);
                    KitchenBaseEntities2.GetContext().SaveChanges();
                    UpdateData();
                }
                catch (Exception ex) { MessageBox.Show("Ошибка (услуга используется в заказах): " + ex.Message); }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) NavigationService.GoBack();
        }
    }
}
