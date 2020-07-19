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

    public delegate void CanLoad();
    /// <summary>
    /// Interaction logic for AddOrUpdateDriver.xaml
    /// </summary>
    public partial class AddOrUpdateDriver : Page
    {
        taxiEntities context = new taxiEntities();
        public event CanLoad CanLoad;

        private driver driver;

        public AddOrUpdateDriver()
        {

            try
            {

                InitializeComponent();
                this.driver = new driver();
                LoadGender();
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        public AddOrUpdateDriver(driver driver)
        {
            try
            {
                InitializeComponent();
                this.driver = driver;
                LoadGender();
                Last.Text = driver.lastName;
                First.Text = driver.firstName;
                Email.Text = driver.email;
                Phone.Text = driver.phone;
                Date.SelectedDate = driver.dateOfBirth;
                Gender.SelectedItem = context.driver.Find(driver.id).gender1;

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void LoadGender()
        {
            try
            {
                Gender.ItemsSource = context.gender.ToList();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void ExitThis()
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
                    Phone.Text != string.Empty &&
                    Gender.SelectedItem is gender gender &&
                    Date.SelectedDate != null)
                {
                    driver.lastName = Last.Text;
                    driver.firstName = First.Text;
                    driver.email = Email.Text;
                    driver.phone = Phone.Text;
                    driver.gender = gender.id;
                    driver.dateOfBirth = Date.SelectedDate.Value;
                    context.driver.AddOrUpdate(driver);
                    context.SaveChanges();
                    CanLoad();
                    ExitThis();
                }
                else
                {
                    MessageBox.Show("Проверьте правильность введенных данных");
                }

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
                ExitThis();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }
    }
}
