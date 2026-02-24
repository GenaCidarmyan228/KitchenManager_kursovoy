using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KitchenManager.Windows; 

namespace KitchenManager.Pages
{
    public partial class EquipmentPage : Page
    {
        public EquipmentPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            DGridEquipment.ItemsSource = KitchenBaseEntities2.GetContext().Equipment.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEquipmentWindow win = new AddEquipmentWindow();
            win.ShowDialog();
            UpdateData();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            
            var selectedItem = DGridEquipment.SelectedItem as Equipment;
            if (selectedItem == null)
            {
                MessageBox.Show("Выберите товар для редактирования!");
                return;
            }

            
            AddEquipmentWindow win = new AddEquipmentWindow(selectedItem);
            win.ShowDialog();
            UpdateData();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DGridEquipment.SelectedItem as Equipment;
            if (selectedItem != null && MessageBox.Show("Удалить товар?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    KitchenBaseEntities2.GetContext().Equipment.Remove(selectedItem);
                    KitchenBaseEntities2.GetContext().SaveChanges();
                    UpdateData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }
}