using System;
using System.Linq;
using System.Windows;

namespace KitchenManager.Windows
{
    public partial class EditOrderWindow : Window
    {
        private Orders _currentOrder; 

        public EditOrderWindow(Orders selectedOrder)
        {
            InitializeComponent();
            _currentOrder = selectedOrder;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            ComboStatus.ItemsSource = KitchenBaseEntities2.GetContext().OrderStatus.ToList();
            ComboClients.ItemsSource = KitchenBaseEntities2.GetContext().Clients.ToList();
            ComboEquipment.ItemsSource = KitchenBaseEntities2.GetContext().Equipment.ToList();
            ComboServices.ItemsSource = KitchenBaseEntities2.GetContext().Services.ToList();
            ComboEmployees.ItemsSource = KitchenBaseEntities2.GetContext().Employees.ToList();

            
            ComboStatus.SelectedValue = _currentOrder.ID_Status;
            ComboClients.SelectedValue = _currentOrder.ID_Client;
            ComboEquipment.SelectedValue = _currentOrder.ID_Equipment;
            ComboServices.SelectedValue = _currentOrder.ID_Service;
            ComboEmployees.SelectedValue = _currentOrder.ID_Employee;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
            if (ComboClients.SelectedItem == null)
            {
                MessageBox.Show("Клиент должен быть выбран!");
                return;
            }

            try
            {
               
                _currentOrder.ID_Status = (int)ComboStatus.SelectedValue;
                _currentOrder.ID_Client = (int)ComboClients.SelectedValue;

                
                if (ComboEquipment.SelectedValue != null)
                    _currentOrder.ID_Equipment = (int)ComboEquipment.SelectedValue;

                if (ComboServices.SelectedValue != null)
                    _currentOrder.ID_Service = (int)ComboServices.SelectedValue;

                if (ComboEmployees.SelectedValue != null)
                    _currentOrder.ID_Employee = (int)ComboEmployees.SelectedValue;

                
                KitchenBaseEntities2.GetContext().SaveChanges();

                MessageBox.Show("Заказ успешно обновлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
        }
    }
}