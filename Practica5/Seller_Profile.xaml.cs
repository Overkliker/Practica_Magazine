using Microsoft.Win32;
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
    /// Логика взаимодействия для Seller_Profile.xaml
    /// </summary>
    public partial class Seller_Profile : Page
    {
        citiesTableAdapter cities = new citiesTableAdapter();
        usersTableAdapter users = new usersTableAdapter();
        warehouseTableAdapter warehouse = new warehouseTableAdapter();

        int id;
        public Seller_Profile(int id)
        {
            InitializeComponent();

            var myUser = users.GetData().Where(userLocal => userLocal.id == id).FirstOrDefault();
            NameLb.Content = myUser.nameUser.ToString();
            AgeLb.Content = $"Age: {myUser.age}";
            MailLb.Content = myUser.mail.ToString();

            CitiesGrid.ItemsSource = cities.GetData();
            WareGrid.ItemsSource = warehouse.GetData();

            this.id = id;
        }

        private void AddCityBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<AddCity> addCity = Converter.Desirealize<List<AddCity>>();
                foreach (var i in addCity)
                {
                    cities.InsertQuery(i.nameCity);
                }
                CitiesGrid.ItemsSource = cities.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AlertBtn_Click(object sender, RoutedEventArgs e)
        {
            users.DeleteQuery(id);
            (Application.Current.MainWindow as MainWindow).AllFrame.Content = null;
        }

        private void AddWareBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<AddWare> addCity = Converter.Desirealize<List<AddWare>>();
                foreach (var i in addCity)
                {
                    cities.InsertQuery(i.cityID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).AllFrame.Content = null;
        }
    }
}
