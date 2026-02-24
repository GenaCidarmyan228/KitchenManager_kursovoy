using System;
using System.Windows;

namespace KitchenManager
{
    public partial class AddClientWindow : Window
    {
        private Clients _currentClient = new Clients();

        // 1. Конструктор для НОВОГО клиента
        public AddClientWindow()
        {
            InitializeComponent();
            DataContext = _currentClient;
        }

        // 2. Конструктор для РЕДАКТИРОВАНИЯ
        public AddClientWindow(Clients selectedClient)
        {
            InitializeComponent();
            _currentClient = selectedClient;
            DataContext = _currentClient;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentClient.Surname) ||
                string.IsNullOrWhiteSpace(_currentClient.Name) ||
                string.IsNullOrWhiteSpace(_currentClient.Phone))
            {
                MessageBox.Show("Заполните ФИО и телефон!");
                return;
            }

            
            if (_currentClient.ID_Client == 0)
            {
                KitchenBaseEntities2.GetContext().Clients.Add(_currentClient);
            }

            try
            {
                KitchenBaseEntities2.GetContext().SaveChanges();
                MessageBox.Show("Сохранено!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}