using System;
using System.Linq;
using System.Windows;

namespace KitchenManager
{
    public partial class AddEmployeeWindow : Window
    {
        private Employees _currentEmployee = new Employees();

        // 1. Конструктор для НОВОГО сотрудника
        public AddEmployeeWindow()
        {
            InitializeComponent();
            LoadPositions();
            DataContext = _currentEmployee;
        }

        // 2. Конструктор для РЕДАКТИРОВАНИЯ 
        public AddEmployeeWindow(Employees selectedEmp)
        {
            InitializeComponent();
            LoadPositions();
            _currentEmployee = selectedEmp; 
            DataContext = _currentEmployee; 
        }

        private void LoadPositions()
        {
            ComboPosition.ItemsSource = KitchenBaseEntities2.GetContext().Positions.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(_currentEmployee.Surname) ||
                string.IsNullOrWhiteSpace(_currentEmployee.Name) ||
                ComboPosition.SelectedItem == null)
            {
                MessageBox.Show("Заполните ФИО и должность!");
                return;
            }

           
            if (_currentEmployee.ID_Employee == 0)
            {
                KitchenBaseEntities2.GetContext().Employees.Add(_currentEmployee);
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