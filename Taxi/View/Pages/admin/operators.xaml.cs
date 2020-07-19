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
using Taxi.instruments;
using Taxi.Model;

namespace Taxi.View.Pages.admin
{
    /// <summary>
    /// Interaction logic for operators.xaml
    /// </summary>
    public partial class Operators : Page
    {
        taxiEntities context = new taxiEntities();

        public Operators()
        {
            try
            {
                InitializeComponent();
                OperatorList.ItemsSource = context.user.Where(i => i.role == 1).ToList();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void DeleteOperator(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MsgBox.Question("Вы хотите удалить оператора?") == MessageBoxResult.Yes)
                {
                    if (OperatorList.SelectedItem is user user)
                    {
                        context.user.Remove(context.user.Find(user.id));
                        context.SaveChanges();
                        OperatorList.ItemsSource = context.user.ToList();
                    }
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void UpdateOperator(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OperatorList.SelectedItem is user user)
                {
                    var userPage = new AddOrUpdateOperator(user);
                    userPage.CanLoad += this.LoadUser;
                    NavigationService.Navigate(userPage);
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void LoadUser()
        {
            try
            {
                OperatorList.ItemsSource = context.user.ToList();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void AddOperator(object sender, RoutedEventArgs e)
        {
            try
            {
                var userPage = new AddOrUpdateOperator();
                userPage.CanLoad += this.LoadUser;
                NavigationService.Navigate(userPage);

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }
    }
}
