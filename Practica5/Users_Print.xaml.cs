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
    /// Логика взаимодействия для Users_Print.xaml
    /// </summary>
    public partial class Users_Print : Page
    {
        usersTableAdapter users = new usersTableAdapter();
        rolesTableAdapter roles = new rolesTableAdapter();
        int id;
        public Users_Print(int id)
        {
            InitializeComponent();
            //Inert into datagrid data from db
            UsersGrid.ItemsSource = users.GetData();
            this.id = id;

            DelBox.ItemsSource = users.GetData();
            DelBox.DisplayMemberPath = "nameUser";

            RolesBox.ItemsSource = roles.GetData();
            RolesBox.DisplayMemberPath = "roleName";
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).AllFrame.Content as Profile_Admin).AdminFrame.Content = null;

        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DelBox.SelectedIndex != -1)
                {
                    users.DeleteQuery(Convert.ToInt32(users.GetData()[DelBox.SelectedIndex].id));
                    DelBox.ItemsSource = users.GetData();
                    UsersGrid.ItemsSource = users.GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameBox.Text != null && MailBox.Text != null 
                    && PasswBox.Text != null && AgeBox.Text != null && RolesBox.SelectedIndex != -1)
                {
                    string passwHash = HelpFunctions.Hashing(PasswBox.Text);
                    int role = roles.GetData()[RolesBox.SelectedIndex].id;
                    int id = Convert.ToInt32((UsersGrid.SelectedItem as DataRowView).Row[0]);
                    users.UpdateQuery(NameBox.Text, MailBox.Text, passwHash, Convert.ToInt32(AgeBox.Text), role, id);
                    UsersGrid.ItemsSource = users.GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void UsersGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if ((UsersGrid.SelectedItem as DataRowView) != null)
                {
                    NameBox.Text = (UsersGrid.SelectedItem as DataRowView).Row[1].ToString();
                    MailBox.Text = (UsersGrid.SelectedItem as DataRowView).Row[2].ToString();
                    PasswBox.Text = (UsersGrid.SelectedItem as DataRowView).Row[3].ToString();
                    AgeBox.Text = (UsersGrid.SelectedItem as DataRowView).Row[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
