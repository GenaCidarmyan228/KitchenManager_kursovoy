using KitchenManager.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KitchenManager
{
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateEmployees();
        }

        private void UpdateEmployees()
        {
            DGridEmployees.ItemsSource = KitchenBaseEntities2.GetContext().Employees.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow win = new AddEmployeeWindow();
            win.ShowDialog();
            UpdateEmployees();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmp = DGridEmployees.SelectedItem as Employees;
            if (selectedEmp == null)
            {
                MessageBox.Show("Выберите сотрудника для изменения!");
                return;
            }

            
            AddEmployeeWindow win = new AddEmployeeWindow(selectedEmp);
            win.ShowDialog();
            UpdateEmployees();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmp = DGridEmployees.SelectedItem as Employees;
            if (selectedEmp != null && MessageBox.Show("Удалить сотрудника?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    KitchenBaseEntities2.GetContext().Employees.Remove(selectedEmp);
                    KitchenBaseEntities2.GetContext().SaveChanges();
                    UpdateEmployees();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void BtnAddPosition_Click(object sender, RoutedEventArgs e)
        {
            AddPositionWindow win = new AddPositionWindow();
            win.ShowDialog();
        }
    }
}