using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Warehouse_Print.xaml
    /// </summary>
    public partial class Warehouse_Print : Page
    {
        citiesTableAdapter cities = new citiesTableAdapter();
        warehouseTableAdapter warehouse = new warehouseTableAdapter();
        public Warehouse_Print()
        {
            InitializeComponent();
            WaresGrid.ItemsSource = warehouse.GetData();

            CitiesInBox.ItemsSource = cities.GetData();
            CitiesUpBox.ItemsSource = cities.GetData();

            CitiesInBox.DisplayMemberPath = "cityID";
            CitiesUpBox.DisplayMemberPath = "cityID";
            WareDelBox.ItemsSource = warehouse.GetData();
            WareDelBox.DisplayMemberPath = "id";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).AllFrame.Content as Profile_Admin).AdminFrame.Content = null;
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CitiesInBox.SelectedIndex != -1)
            {
                warehouse.InsertQuery(cities.GetData()[CitiesInBox.SelectedIndex].id);
                WaresGrid.ItemsSource = warehouse.GetData();
                WareDelBox.ItemsSource = warehouse.GetData();
            }
        }

        private void DelWareBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WareDelBox.SelectedIndex != -1)
            {
                warehouse.InsertQuery(warehouse.GetData()[WareDelBox.SelectedIndex].id);
                WaresGrid.ItemsSource = warehouse.GetData();
                WareDelBox.ItemsSource = warehouse.GetData();

            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CitiesUpBox.SelectedIndex != -1)
            {
                warehouse.UpdateQuery(warehouse.GetData()[WareDelBox.SelectedIndex].id, Convert.ToInt32((WaresGrid.SelectedItem as DataRowView).Row[0]));
                WaresGrid.ItemsSource = warehouse.GetData();
            }
        }

        private void WaresGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if ((WaresGrid.SelectedItem as DataRowView) != null)
            {

            }
        }
    }
}
