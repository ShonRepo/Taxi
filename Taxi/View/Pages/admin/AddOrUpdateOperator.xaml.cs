using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for AddOrUpdateOperator.xaml
    /// </summary>
    public partial class AddOrUpdateOperator : Page
    {
        taxiEntities context = new taxiEntities();

        private user user;

        public event CanLoad CanLoad;

        public AddOrUpdateOperator()
        {
            try
            {
                InitializeComponent();
                user = new user();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        public AddOrUpdateOperator(user user)
        {
            try
            {
                InitializeComponent();
                this.user = user;
                Last.Text = user.lastName;
                First.Text = user.firstName;
                Email.Text = user.email;
                Password.Text = user.password;

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.GoBack();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Last.Text != string.Empty &&
                    First.Text != string.Empty &&
                    Email.Text != string.Empty &&
                    Password.Text != string.Empty)
                {
                    user.lastName = Last.Text;
                    user.firstName = First.Text;
                    user.email = Email.Text;
                    user.password = Password.Text;
                    user.role = 1;
                    context.user.AddOrUpdate(user);
                    context.SaveChanges();
                    CanLoad();
                    NavigationService.GoBack();
                }
                else
                {
                    MsgBox.Warning("Проверьте правильность введенных данных");
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }
    }
}
