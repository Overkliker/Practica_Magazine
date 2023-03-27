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
    /// Логика взаимодействия для Buy.xaml
    /// </summary>
    public partial class Buy : Page
    {
        productTableAdapter prod = new productTableAdapter();
        checkListTableAdapter checks = new checkListTableAdapter();
        boughtProdTableAdapter bought = new boughtProdTableAdapter();
        purchaseHistoryTableAdapter purchase = new purchaseHistoryTableAdapter();

        int idProd;
        string prodName;
        int price;
        int userID;
        public Buy(int idProd, int userID)
        {
            InitializeComponent();
            this.idProd = idProd;
            this.userID = userID;
            var prObj = prod.GetData().Where(prodLocal => prodLocal.id == idProd).FirstOrDefault();
            price = prObj.sell;
            prodName = prObj.discription;
            PriceBox.Content = price;
        }

        private void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PriceCt.Text != null)
            {
                int ct = 0;
                for (int i = 0; i < PriceCt.Text.Length; i++)
                {
                    if (char.IsDigit(Convert.ToChar(PriceCt.Text[i])))
                    {
                        ct++;
                    }
                }

                if (ct == PriceCt.Text.Length)
                {
                    //Writing check
                    int allprice = price;
                    checks.InsertQuery(idProd, userID, allprice);
                    int newCheckID = checks.GetData()[checks.GetData().Count - 1].id;
                    HelpFunctions.MakeCheck(newCheckID, prodName, allprice, Convert.ToInt32(PriceCt.Text));

                    //Writing history
                    bought.InsertQuery(idProd, true);
                    int lastBought = bought.GetData()[bought.GetData().Count - 1].id;
                    purchase.InsertQuery(userID, lastBought);

                    (((Application.Current.MainWindow as MainWindow).AllFrame.Content as User_Profile).UserFrame.Content as Basket).BasketFrame.Content = null;
                }
            }

        }

        private void CountBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PriceCt.Text != null)
            {
                int ct = 0;
                for (int i = 0; i < PriceCt.Text.Length; i++)
                {
                    if (char.IsDigit(Convert.ToChar(PriceCt.Text[i])))
                    {
                        ct++;
                    }
                }

                if (ct == PriceCt.Text.Length)
                {
                    PriceBox.Content = price * Convert.ToInt32(PriceCt.Text);
                }
            }
        }
    }
}
