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
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        int id;
        productTableAdapter prods = new productTableAdapter();
        basketTableAdapter basket = new basketTableAdapter();
        public Catalog(int id)
        {
            InitializeComponent();
            this.id = id;
            CatalogGrid.ItemsSource = prods.GetData();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).AllFrame.Content as User_Profile).UserFrame.Content = null;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            int prodId = Convert.ToInt32((CatalogGrid.SelectedItem as DataRowView).Row[0]);
            basket.InsertQuery(id, prodId);
        }
    }
}
