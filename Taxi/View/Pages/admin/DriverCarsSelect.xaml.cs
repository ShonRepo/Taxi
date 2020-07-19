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
    /// Interaction logic for DriverCarsSelect.xaml
    /// </summary>
    public partial class DriverCarsSelect : Page
    {
        taxiEntities context = new taxiEntities();

        List<car> AllCarsList;

        List<driverCar> UserCarsList;

        public DriverCarsSelect()
        {
            try
            {
                InitializeComponent();
                Driver.ItemsSource = context.driver.ToList();
                Driver.DropDownClosed += this.ShowUserCars;
                ShowAllCars();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void ShowUserCars(object sender, EventArgs e)
        {
            try
            {

                ShowUserCar();
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void ShowUserCar()
        {
            try
            {
                if (Driver.SelectedItem is driver driver)
                {
                    UserCarsList = driver.driverCar.ToList();
                    CarsDriver.ItemsSource = UserCarsList.Select(i =>
                    new CarName
                    {
                        Car = i.car1,
                        Name =
                        $" {i.car1.number}" +
                    $"({i.car1.model1.brand1.name}" +
                    $" {i.car1.model1.name})"
                    });
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void ShowAllCars()
        {
            try
            {
                AllCarsList = context.car.Where(i => i.driverCar.Count == 0).ToList();
                AllCars.ItemsSource = AllCarsList.
                    Select(i => new CarName
                    {
                        Car = i,
                        Name =
                    $" {i.number}" +
                    $"({i.model1.brand1.name}" +
                    $" {i.model1.name})"
                    }).ToList();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void AddCarDriver(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AllCars.SelectedItem is CarName selectCar &&
                    Driver.SelectedItem is driver selectUser)
                {
                    context.driverCar.Add(
                        new driverCar()
                        {
                            car = selectCar.Car.id,
                            driver = selectUser.id
                        });
                    context.SaveChanges();
                    ShowUserCar();
                    ShowAllCars();
                }

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
                if (CarsDriver.SelectedItem is CarName selectCar &&
                 Driver.SelectedItem is driver selectUser)
                {
                    context.driverCar.Remove(context.driverCar.Where(i => i.car == selectCar.Car.id && i.driver == selectUser.id).FirstOrDefault());
                    context.SaveChanges();
                    ShowUserCar();
                    ShowAllCars();
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }

        }

        private class CarName
        {
            public car Car { get; set; }
            public string Name { get; set; }
        }
    }
}
