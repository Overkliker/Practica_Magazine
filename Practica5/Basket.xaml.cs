using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Page
    {
        basketTableAdapter basket = new basketTableAdapter();
        int id;
        public Basket(int id)
        {
            InitializeComponent();
            BasketGrid.ItemsSource = basket.GetDataBy2(id);
            this.id = id;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).AllFrame.Content as User_Profile).UserFrame.Content = null;
        }

        private void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            int idPr = Convert.ToInt32((BasketGrid.SelectedItem as DataRowView).Row[2]);
            BasketFrame.Content = new Buy(idPr, id);
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            basket.DeleteQuery(Convert.ToInt32((BasketGrid.SelectedItem as DataRowView).Row[1]));
            BasketGrid.ItemsSource = basket.GetDataBy2(id);
        }
    }
}
