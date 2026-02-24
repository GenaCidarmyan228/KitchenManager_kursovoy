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
using System.Windows.Shapes;

namespace KitchenManager.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            ComboClients.ItemsSource = KitchenBaseEntities2.GetContext().Clients.ToList();
            ComboEquipment.ItemsSource = KitchenBaseEntities2.GetContext().Equipment.ToList();
            ComboServices.ItemsSource = KitchenBaseEntities2.GetContext().Services.ToList();
            ComboEmployees.ItemsSource = KitchenBaseEntities2.GetContext().Employees.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
            if (ComboClients.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента!");
                return;
            }

            try
            {
               
                Orders newOrder = new Orders();
                newOrder.OrderDate = DateTime.Now;
                newOrder.ID_Client = (int)ComboClients.SelectedValue;

                
                newOrder.ID_Status = 1;

                
                if (ComboEmployees.SelectedValue != null)
                    newOrder.ID_Employee = (int)ComboEmployees.SelectedValue;

                if (ComboEquipment.SelectedValue != null)
                    newOrder.ID_Equipment = (int)ComboEquipment.SelectedValue;

                if (ComboServices.SelectedValue != null)
                    newOrder.ID_Service = (int)ComboServices.SelectedValue;

                
                KitchenBaseEntities2.GetContext().Orders.Add(newOrder);
                KitchenBaseEntities2.GetContext().SaveChanges();

                MessageBox.Show("Заказ создан!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}

