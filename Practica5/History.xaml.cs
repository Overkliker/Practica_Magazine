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
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Page
    {
        purchaseHistoryTableAdapter purchase = new purchaseHistoryTableAdapter();
        public History(int userID)
        {
            InitializeComponent();
            HistoryGrid.ItemsSource = purchase.GetDataBy1(userID);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).AllFrame.Content as User_Profile).UserFrame.Content = null;
        }
    }
}
