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
    /// Логика взаимодействия для AddPositionWindow.xaml
    /// </summary>
    public partial class AddPositionWindow : Window
    {
        public AddPositionWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                MessageBox.Show("Введите название!");
                return;
            }

            try
            {
                
                Positions newPos = new Positions { PositionName = TxtName.Text };

                
                KitchenBaseEntities2.GetContext().Positions.Add(newPos);
                KitchenBaseEntities2.GetContext().SaveChanges();

                MessageBox.Show("Должность успешно добавлена!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
