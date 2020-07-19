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
    /// Interaction logic for Drivers.xaml
    /// </summary>
    public partial class Drivers : Page
    {
        taxiEntities context = new taxiEntities();

        public Drivers()
        {
            try
            {
                InitializeComponent();
                DriverList.ItemsSource = context.driver.ToList();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }

        }


        private void Load()
        {
            try
            {
                DriverList.ItemsSource = context.driver.ToList();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }


        private void AddDriver(object sender, RoutedEventArgs e)
        {
            try
            {
                var driverPage = new AddOrUpdateDriver();
                driverPage.CanLoad += Load;
                NavigationService.Navigate(driverPage);

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void UpdateDriver(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DriverList.SelectedItem is driver driver)
                {
                    var driverPage = new AddOrUpdateDriver(driver);
                    driverPage.CanLoad += Load;
                    NavigationService.Navigate(driverPage);

                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void DeleteDriver(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MsgBox.Question("Вы хотите удалить водителя?") == MessageBoxResult.Yes)
                {
                    if (DriverList.SelectedItem is driver driver)
                    {
                        context.driver.Remove(context.driver.Find(driver.id));
                        context.SaveChanges();
                        DriverList.ItemsSource = context.driver.ToList();
                    }
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }
    }
}
