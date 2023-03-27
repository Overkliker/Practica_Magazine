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
    /// Логика взаимодействия для Roles_Print.xaml
    /// </summary>
    public partial class Roles_Print : Page
    {
        rolesTableAdapter roles = new rolesTableAdapter();
        public Roles_Print()
        {
            InitializeComponent();
            RolesGrid.ItemsSource = roles.GetData();
            RoleDelBox.ItemsSource = roles.GetData();
            RoleDelBox.DisplayMemberPath = "id";
        }

        private void RolesGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if ((RolesGrid.SelectedItem as DataRowView) != null)
            {
                RoleUpBox.Text = (RolesGrid.SelectedItem as DataRowView).Row[1].ToString();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).AllFrame.Content as Profile_Admin).AdminFrame.Content = null;
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RolesInBox.Text != null)
            {
                roles.InsertQuery(RolesInBox.Text);
                RolesGrid.ItemsSource = roles.GetData();
                RoleDelBox.ItemsSource = roles.GetData();
            }
        }

        private void DelRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoleDelBox.SelectedIndex != -1)
            {
                roles.DeleteQuery(roles.GetData()[RoleDelBox.SelectedIndex].id);
                RolesGrid.ItemsSource = roles.GetData();
                RoleDelBox.ItemsSource = roles.GetData();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoleUpBox.Text != null)
            {
                roles.UpdateQuery(RoleUpBox.Text, Convert.ToInt32((RolesGrid.SelectedItem as DataRowView).Row[0]));
                RolesGrid.ItemsSource = roles.GetData();
                RoleDelBox.ItemsSource = roles.GetData();
            }
        }
    }
}
