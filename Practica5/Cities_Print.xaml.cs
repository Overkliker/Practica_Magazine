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
    /// Логика взаимодействия для Cities_Print.xaml
    /// </summary>
    public partial class Cities_Print : Page
    {
        citiesTableAdapter cities = new citiesTableAdapter();
        public Cities_Print()
        {
            InitializeComponent();
            CitiesGrid.ItemsSource = cities.GetData();
            CityDelBox.ItemsSource = cities.GetData();
            CityDelBox.DisplayMemberPath = "id";
        }

        private void CitiesGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if ((CitiesGrid.SelectedItem as DataRowView) != null)
            {
                CitiesUpBox.Text = (CitiesGrid.SelectedItem as DataRowView).Row[1].ToString();
            }
        }
        
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).AllFrame.Content as Profile_Admin).AdminFrame.Content = null;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CitiesUpBox.Text != null)
            {
                cities.UpdateQuery(CitiesUpBox.Text, Convert.ToInt32((CitiesGrid.SelectedItem as DataRowView).Row[0]));
                CitiesGrid.ItemsSource = cities.GetData(); 
            }
        }

        private void DelCityBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CityDelBox.SelectedIndex != -1)
            {
                cities.DeleteQuery(cities.GetData()[CityDelBox.SelectedIndex].id);
                CitiesGrid.ItemsSource = cities.GetData();
                CityDelBox.ItemsSource = cities.GetData();
            }
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CitiesInBox.Text != null)
            {
                cities.InsertQuery(CitiesInBox.Text);
                CitiesGrid.ItemsSource = cities.GetData();
                CityDelBox.ItemsSource = cities.GetData();
            }
        }
    }
}
