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
using System.Windows.Shapes;
using Taxi.instruments;
using Taxi.Model;

namespace Taxi.View.Windows.Modal
{
    /// <summary>
    /// Interaction logic for ShowTicket.xaml
    /// </summary>
    public partial class ShowTicket : Window
    {
        taxiEntities context = new taxiEntities();
        ticket ticket;

        public ShowTicket(ticket ticket)
        {


            try
            {
                this.ticket = ticket;
                InitializeComponent();
                Status.ItemsSource = context.status.ToList();
                Status.SelectedItem = context.status.Find(ticket.status);

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            var ticket = context.ticket.Find(this.ticket.id);
            ticket.status = (Status.SelectedItem as status).id;
            context.SaveChanges();
            DialogResult = true;
        }
    }
}
