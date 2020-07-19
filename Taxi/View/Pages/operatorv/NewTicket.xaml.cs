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
using Taxi.View.Windows;

namespace Taxi.View.Pages.operatorv
{
    /// <summary>
    /// Interaction logic for NewTicket.xaml
    /// </summary>
    public partial class NewTicket : Page
    {
        taxiEntities context = new taxiEntities();

        public NewTicket()
        {
            try
            {
                InitializeComponent();
                DriversList.ItemsSource = context.driver.ToList().Where(i => i.driverCar.Count > 0).Select(i =>
                 new DriverCar
                 {
                     Driver = i,
                     Name = $"{i.firstName} {i.lastName}| " +
                     $" {i.driverCar.FirstOrDefault().car1.number}" +
                     $"({i.driverCar.FirstOrDefault().car1.model1.brand1.name}" +
                     $" {i.driverCar.FirstOrDefault().car1.model1.name})"
                 }).ToList();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }


        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DriversList.SelectedItem is DriverCar driverCar &&
                    Decimal.TryParse(Price.Text, out decimal price) &&
                    StartStreet.Text != string.Empty &&
                    Starthouse.Text != string.Empty &&
                    EndStreet.Text != string.Empty &&
                    Endhouse.Text != string.Empty)
                {
                    ticket ticket = new ticket();
                    ticket.date = DateTime.Now;
                    ticket.driver = driverCar.Driver.id;
                    ticket.price = price;
                    ticket.status = 1;
                    ticket.startStreet = StartStreet.Text;
                    ticket.startHouse = Starthouse.Text;
                    ticket.endStreet = EndStreet.Text;
                    ticket.endHouse = Endhouse.Text;
                    ticket.user = MainWindow.User.id;
                    context.ticket.Add(ticket);
                    context.SaveChanges();
                    MsgBox.Info("Заявка создана");
                    NavigationService.Navigate(new NewTicket());
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private class DriverCar
        {
            public driver Driver { get; set; }

            public string Name { get; set; }
        }
    }
}
