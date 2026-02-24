using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KitchenManager
{
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateClients();
        }

        private void UpdateClients()
        {
            DGridClients.ItemsSource = KitchenBaseEntities2.GetContext().Clients.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow win = new AddClientWindow();
            win.ShowDialog();
            UpdateClients();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = DGridClients.SelectedItem as Clients;
            if (selectedClient == null)
            {
                MessageBox.Show("Выберите клиента для редактирования!");
                return;
            }

           
            AddClientWindow win = new AddClientWindow(selectedClient);
            win.ShowDialog();
            UpdateClients();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = DGridClients.SelectedItem as Clients;
            if (selectedClient != null && MessageBox.Show("Удалить клиента?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    KitchenBaseEntities2.GetContext().Clients.Remove(selectedClient);
                    KitchenBaseEntities2.GetContext().SaveChanges();
                    UpdateClients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }
}