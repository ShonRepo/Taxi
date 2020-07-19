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

namespace Taxi.View.Pages.admin
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ShowTitle(object sender, NavigationEventArgs e)
        {
            if (e.Content is Page page)
            {
                this.Title += page.Title;
            }
        }

        private void GoToSettings(object sender, RoutedEventArgs e)
        {
            FrameOperator.Navigate(new operatorv.Settings());
        }

        private void GoToTickets(object sender, RoutedEventArgs e)
        {
            FrameOperator.Navigate(new Tickets());
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            if (instruments.MsgBox.Question("Вы действительно хотите выйти?") == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new Authorization.Auth());
            }
        }

        private void GoToUserList(object sender, RoutedEventArgs e)
        {
            FrameOperator.Navigate(new Operators());
        }

        private void GoToDrivers(object sender, RoutedEventArgs e)
        {
            FrameOperator.Navigate(new Drivers());
        }

        private void GoToCars(object sender, RoutedEventArgs e)
        {
            FrameOperator.Navigate(new Cars());
        }

        private void GoToCarsDriver(object sender, RoutedEventArgs e)
        {
            FrameOperator.Navigate(new DriverCarsSelect());
        }
    }
}
