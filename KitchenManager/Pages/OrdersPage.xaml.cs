using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using KitchenManager.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KitchenManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateOrders();
        }

        private void UpdateOrders()
        {
            DGridOrders.ItemsSource = KitchenBaseEntities2.GetContext().Orders.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            AddOrderWindow addWindow = new AddOrderWindow();
            addWindow.ShowDialog();
            UpdateOrders();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = DGridOrders.SelectedItem as Orders;
            if (selectedOrder != null && MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    KitchenBaseEntities2.GetContext().Orders.Remove(selectedOrder);
                    KitchenBaseEntities2.GetContext().SaveChanges();
                    UpdateOrders();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

       
        private void BtnEmployees_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeesPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
          
            NavigationService.Navigate(new AuthPage());
        }

       
        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientsPage());
        }

       
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = DGridOrders.SelectedItem as Orders;
            if (selectedOrder == null)
            {
                MessageBox.Show("Выберите заказ для редактирования!");
                return;
            }

            
            EditOrderWindow editWindow = new EditOrderWindow(selectedOrder);
            editWindow.ShowDialog();

            
            UpdateOrders();
        }
        private void BtnEquipment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EquipmentPage());
        }

        private void BtnServices_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicesPage());
        }
    }
    }
    

