using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KitchenManager.Pages
{
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = TxtLogin.Text;
            string password = TxtPassword.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
               
                MessageBox.Show("Введите логин и пароль!", "Внимание!");
                return;
            }

            try
            {
                var userObj = KitchenBaseEntities2.GetContext().Users
                    .FirstOrDefault(u => u.Login == login && u.Password == password);

                if (userObj == null)
                {
                    MessageBox.Show( "Такого пользователя нет или пароль неверный!",
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                   
                    App.CurrentUser = userObj;

                    MessageBox.Show($"Добро пожаловать, {userObj.Roles.RoleName}!",  "Внимание!");
                    NavigationService.Navigate(new OrdersPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка связи с базой: " + ex.Message);
            }
        }
    }
}