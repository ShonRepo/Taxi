using System;
using System.Collections.Generic;
using System.IO;
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
using Taxi.View.Windows.Modal;

namespace Taxi.View.Pages.operatorv
{
    /// <summary>
    /// Interaction logic for tickets.xaml
    /// </summary>
    public partial class Tickets : Page
    {
        Model.taxiEntities context = new taxiEntities();

        List<TictetCar> tictetCars;

        public Tickets()
        {
            try
            {
                InitializeComponent();
                tictetCars = context.ticket.ToList().Select(i => new TictetCar { Ticket = i, Car = i.driver1.driverCar.FirstOrDefault().car1 }).ToList();
                sort.ItemsSource = context.status.ToList().Select(i => new CheckStatus { Status = i, Check = false }).ToList();
                ticketList.ItemsSource = tictetCars.Where(i => i.Ticket.status == 1);

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowResult();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void ShowResult()
        {
            try
            {
                tictetCars = context.ticket.ToList().Select(i => new TictetCar { Ticket = i, Car = i.driver1.driverCar.FirstOrDefault().car1 }).ToList();
                var status = sort.ItemsSource as List<CheckStatus>;
                ticketList.ItemsSource = tictetCars.Where(i =>
                status.Where(q => q.Check).Select(q => q.Status).Contains(i.Ticket.status1)
                ).ToList();
                if (status.Where(q => q.Check).Count() == 0)
                {
                    ticketList.ItemsSource = tictetCars;
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private class CheckStatus
        {
            public status Status { get; set; }

            public bool Check { get; set; }
        }

        private class TictetCar
        {
            public ticket Ticket { get; set; }

            public car Car { get; set; }
        }

        private void SelectTicket(object sender, SelectionChangedEventArgs e)
        {
            if (ticketList.SelectedItem is TictetCar tictetCar)
            {
                ShowTicket ticket = new ShowTicket(tictetCar.Ticket);
                if (ticket.ShowDialog().Value)
                {
                    context = new taxiEntities();
                    ShowResult();
                }
            }
        }
    }
}
