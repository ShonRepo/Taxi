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
    /// Interaction logic for Cars.xaml
    /// </summary>
    public partial class Cars : Page
    {
        taxiEntities context = new taxiEntities();

        public Cars()
        {
            try
            {
                InitializeComponent();
                CarList.ItemsSource = context.car.ToList();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void DeleteCar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MsgBox.Question("Вы хотите удалить авто?") == MessageBoxResult.Yes)
                {
                    if (CarList.SelectedItem is car car)
                    {
                        context.car.Remove(context.car.Find(car.id));
                        context.SaveChanges();
                        CarList.ItemsSource = context.car.ToList();
                    }
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void UpdateCar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CarList.SelectedItem is car car)
                {
                    AddOrUpdateCar carPage = new AddOrUpdateCar(car);
                    carPage.CanLoad += this.LoadCar;
                    NavigationService.Navigate(carPage);
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void LoadCar()
        {
            try
            {
                CarList.ItemsSource = context.car.ToList();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }


        private void AddCar(object sender, RoutedEventArgs e)
        {
            try
            {

                AddOrUpdateCar carPage = new AddOrUpdateCar();
                carPage.CanLoad += this.LoadCar;
                NavigationService.Navigate(carPage);
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }
    }
}
