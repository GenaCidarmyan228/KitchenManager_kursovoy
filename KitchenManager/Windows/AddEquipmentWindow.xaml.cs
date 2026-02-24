using System;
using System.Windows;

namespace KitchenManager.Windows
{
    public partial class AddEquipmentWindow : Window
    {
        private Equipment _currentEquipment = new Equipment();

        // Конструктор 1: Новый товар
        public AddEquipmentWindow()
        {
            InitializeComponent();
            DataContext = _currentEquipment;
        }

        // Конструктор 2: Редактирование
        public AddEquipmentWindow(Equipment selectedEquipment)
        {
            InitializeComponent();
            _currentEquipment = selectedEquipment;
            DataContext = _currentEquipment;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentEquipment.Title))
            {
                MessageBox.Show("Введите название товара!");
                return;
            }

            
            if (_currentEquipment.ID_Equipment == 0)
            {
                KitchenBaseEntities2.GetContext().Equipment.Add(_currentEquipment);
            }

            try
            {
                KitchenBaseEntities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}