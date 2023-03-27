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
    /// Логика взаимодействия для Point_Print.xaml
    /// </summary>
    public partial class Point_Print : Page
    {
        pointOfIssueTableAdapter points = new pointOfIssueTableAdapter();
        workersTableAdapter workers = new workersTableAdapter();
        citiesTableAdapter cities = new citiesTableAdapter();
        public Point_Print()
        {
            InitializeComponent();
            PointsGrid.ItemsSource = points.GetData();
            CityBox.ItemsSource = cities.GetData();
            WorkerBox.ItemsSource = workers.GetData();
            IdBox.ItemsSource = points.GetData();
            CityUpBox.ItemsSource = cities.GetData();
            WorkerUpBox.ItemsSource = workers.GetData();

            WorkerBox.DisplayMemberPath = "id";
            CityBox.DisplayMemberPath = "id";
            CityUpBox.DisplayMemberPath = "id";
            WorkerUpBox.DisplayMemberPath = "id";
            IdBox.DisplayMemberPath = "id";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).AllFrame.Content as Profile_Admin).AdminFrame.Content = null;
        }

        private void UsersGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if ((PointsGrid.SelectedItem as DataRowView) != null)
            {
                AdressUpBox.Text = (PointsGrid.SelectedItem as DataRowView).Row[2].ToString();
            }
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CityBox.SelectedIndex != -1 && WorkerBox.SelectedIndex != -1
                && AdressBox.Text != null)
            {
                int city = cities.GetData()[CityBox.SelectedIndex].id;
                int worker = workers.GetData()[WorkerBox.SelectedIndex].id;
                points.InsertQuery(city, AdressBox.Text, worker);
                PointsGrid.ItemsSource = points.GetData();
                IdBox.ItemsSource = points.GetData();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CityUpBox.SelectedIndex != -1 && WorkerUpBox.SelectedIndex != -1
                && AdressUpBox.Text != null)
            {
                int city = cities.GetData()[CityUpBox.SelectedIndex].id;
                int worker = workers.GetData()[WorkerUpBox.SelectedIndex].id;
                int id = Convert.ToInt32((PointsGrid.SelectedItem as DataRowView).Row[0]);
                points.UpdateQuery(city, AdressUpBox.Text, worker, id);
                PointsGrid.ItemsSource = points.GetData();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IdBox.SelectedIndex != -1)
            {
                int ids = points.GetData()[IdBox.SelectedIndex].id;
                points.DeleteQuery(ids);
                IdBox.ItemsSource = points.GetData();
                PointsGrid.ItemsSource = points.GetData();
            }
            
        }
    }
}
