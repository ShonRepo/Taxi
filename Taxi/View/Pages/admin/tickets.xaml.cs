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
using Taxi.View.Windows.Modal;

namespace Taxi.View.Pages.admin
{
    /// <summary>
    /// Interaction logic for tickets.xaml
    /// </summary>
    public partial class Tickets : Page
    {
        taxiEntities context = new taxiEntities();

        public Tickets()
        {
            try
            {
                InitializeComponent();
                ticketList.ItemsSource = context.ticket.ToList();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {


            try
            {
                if (MsgBox.Question("Вы хотите удалить заказ?") == MessageBoxResult.Yes)
                {
                    if (ticketList.SelectedItem is ticket ticket1)
                    {
                        context.ticket.Remove(context.ticket.Find(ticket1.id));
                        context.SaveChanges();
                        ticketList.ItemsSource = context.ticket.ToList();
                    }
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void Show(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ticketList.SelectedItem is ticket ticket1)
                {
                    ShowTicket ticket = new ShowTicket(ticket1);
                    if (ticket.ShowDialog().Value)
                    {
                        context = new taxiEntities();
                        ticketList.ItemsSource = context.ticket.ToList();
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
