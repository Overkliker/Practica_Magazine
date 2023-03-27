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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practica5.practshopDataSetTableAdapters;

namespace Practica5
{
    /// <summary>
    /// Логика взаимодействия для User_Profile.xaml
    /// </summary>
    public partial class User_Profile : Page
    {
        usersTableAdapter users = new usersTableAdapter();
        int id;
        public User_Profile(int id)
        {
            InitializeComponent();
            var myUser = users.GetData().Where(userLocal => userLocal.id == id).FirstOrDefault();
            NameLb.Content = myUser.nameUser.ToString();
            AgeLb.Content = $"Age: {myUser.age}";
            MailLb.Content = myUser.mail.ToString();
            this.id = id;
        }

        private void BasketBtn_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.Content = new Basket(id);
        }

        private void HystoryBtn_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.Content = new History(id);
        }

        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.Content = new Catalog(id);
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).AllFrame.Content = null;
        }
    }
}
