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
    /// Логика взаимодействия для Prods_Page.xaml
    /// </summary>
    public partial class Prods_Page : Page
    {
        int id;
        productTableAdapter prods = new productTableAdapter();
        typeProductTableAdapter typesProd = new typeProductTableAdapter();
        public Prods_Page(int id)
        {
            InitializeComponent();
            this.id = id;
            ProdsGrid.ItemsSource = prods.GetData();

            TypeInBox.ItemsSource = typesProd.GetData();
            TypeInBox.DisplayMemberPath = "typing";
            DelBox.ItemsSource = prods.GetData();
            DelBox.DisplayMemberPath = "id";
            TypeUpBox.ItemsSource = typesProd.GetData();
            TypeUpBox.DisplayMemberPath = "id";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).AllFrame.Content as Profile_Admin).AdminFrame.Content = null;
        }

        private void ProdsGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if ((ProdsGrid.SelectedItem as DataRowView) != null)
            {
                DiscUpBox.Text = (ProdsGrid.SelectedItem as DataRowView).Row[2].ToString();
            }
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TypeInBox.SelectedIndex != -1 && DiscInBox.Text != null && SellInBox.Text != null)
            {
                int type = typesProd.GetData()[TypeInBox.SelectedIndex].id;
                prods.InsertQuery(type, DiscInBox.Text, Convert.ToInt32(SellInBox.Text));

                ProdsGrid.ItemsSource = prods.GetData();
                DelBox.ItemsSource = prods.GetData();
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DelBox.SelectedIndex != -1)
            {
                prods.DeleteQuery(prods.GetData()[DelBox.SelectedIndex].id);

                ProdsGrid.ItemsSource = prods.GetData();
                DelBox.ItemsSource = prods.GetData();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DiscUpBox.Text != null && TypeUpBox.SelectedIndex != -1)
            {
                int type = typesProd.GetData()[TypeUpBox.SelectedIndex].id;
                int id = Convert.ToInt32((ProdsGrid.SelectedItem as DataRowView).Row[0]);
                prods.UpdateQuery(type, DiscUpBox.Text, id);

                ProdsGrid.ItemsSource = prods.GetData();
            }
        }
    }
}
