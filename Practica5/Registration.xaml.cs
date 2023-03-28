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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        usersTableAdapter users = new usersTableAdapter();
        rolesTableAdapter roles = new rolesTableAdapter();
        workersTableAdapter workers = new workersTableAdapter();
        int id;
        public Registration(int id)
        {
            InitializeComponent();
            this.id = id;
            RolesBox.ItemsSource = roles.GetData();
            RolesBox.DisplayMemberPath = "roleName";
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EmailBox.Text != null && AgeBox.Text != null && NameBox.Text != null && PasswBox.Password.ToString() != null && RolesBox.SelectedIndex != -1)
                {
                    int ct = 0;
                    for (int i = 0; i < AgeBox.Text.Length; i++)
                    {
                        if (char.IsDigit(Convert.ToChar(AgeBox.Text[i])))
                        {
                            ct++;
                        }
                    }
                    if (ct == AgeBox.Text.Length)
                    {
                        string mdPassw = HelpFunctions.Hashing(PasswBox.Password.ToString());
                        int age = Convert.ToInt32(AgeBox.Text);
                        int role = roles.GetData()[RolesBox.SelectedIndex].id;

                        users.InsertQuery(NameBox.Text, EmailBox.Text, mdPassw, age, role);
                        if (role == 3)
                        {
                            int lastID = roles.GetData()[roles.GetData().Count - 1].id;
                            workers.InsertQuery(lastID);
                        }

                        ((Application.Current.MainWindow as MainWindow).AllFrame.Content as Profile_Admin).AdminFrame.Content = null;
                    }
                    else
                    {
                        MessageBox.Show("Неверно введён возраст");
                    }
                }
                else
                {
                    MessageBox.Show("Одно из полей не заполнено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).AllFrame.Content as Profile_Admin).AdminFrame.Content = null;
        }
    }
}
