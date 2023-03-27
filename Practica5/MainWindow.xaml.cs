using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        usersTableAdapter users = new usersTableAdapter();

        //Pages

        public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine(HelpFunctions.Hashing("123"));
        }

        private void AutorizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PasswUser.Password.ToString() != "" && NameUser.Text != "")
            {
                var usersData = users.GetData().Rows;

                bool aut_t = false;
                int ind = 0;
                string hash = HelpFunctions.Hashing(PasswUser.Password.ToString());
                Debug.WriteLine(hash);
                for (int i = 0; i < usersData.Count; i++)
                {
                    if ((usersData[i][3].ToString() == hash) && (usersData[i][1].ToString() == NameUser.Text))
                    {
                        aut_t = true;
                        ind = i;
                        break;
                    }
                }

                if (aut_t)
                {
                    int role = Convert.ToInt32(usersData[ind][5]);
                    int id = Convert.ToInt32(usersData[ind][0]);
                    PasswUser.Password = null;
                    NameUser.Text = null;
                    switch (role)
                    {
                        case 1:
                            AllFrame.Content = new Profile_Admin(id);
                            break;
                        case 2:
                            AllFrame.Content = new User_Profile(id);
                            break;

                        case 3:
                            AllFrame.Content = new Seller_Profile(id);
                            break;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
    }
}
