using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practica5.practshopDataSetTableAdapters;

namespace Practica5
{
    /// <summary>
    /// Логика взаимодействия для Profile_Admin.xaml
    /// </summary>
    public partial class Profile_Admin : Page
    {
        usersTableAdapter users = new usersTableAdapter();
        int id;

        public Profile_Admin(int id)
        {
            InitializeComponent();
            var myUser = users.GetData().Where(userLocal => userLocal.id == id).FirstOrDefault();
            UsNameLb.Content = myUser.nameUser.ToString();
            AgeLb.Content = $"Age: {myUser.age}";
            MailLb.Content = myUser.mail.ToString();
            this.id = id;
        }

        private void UsersBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Users_Print(id);
        }

        private void ProdsBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Prods_Page(id);
        }

        private void WarehousesBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Warehouse_Print();
        }

        private void CitiesBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Cities_Print();
        }

        private void RolesBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Roles_Print();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Registration(id);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
           ( Application.Current.MainWindow as MainWindow).AllFrame.Content = null;
        }

        private void PointsBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Point_Print();
        }
    }
}
