using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using Taxi.View.Windows;

namespace Taxi.View.Pages.Authorization
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        Taxi.Helpers.Auth.Authhelper Authhelper = new Helpers.Auth.Authhelper();

        public Auth()
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void LogIn(user user)
        {
            try
            {
                if (user != null)
                {

                    MainWindow.User = user;
                    switch (user.role)
                    {
                        case 1:
                            NavigationService.Navigate(new Pages.operatorv.Main());
                            break;
                        case 2:
                            NavigationService.Navigate(new admin.Main());
                            break;
                        default:
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void LogInSystem(object sender, RoutedEventArgs e)
        {

            try
            {

                try
                {
                    var user = Authhelper.Auth(Login.Text, Pass.Text);
                    if (user is null)
                    {
                        instruments.MsgBox.Error("Такого пользователя не существует");
                    }
                    LogIn(user);
                }
                catch (Exception ex)
                {
                    MsgBox.Error(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }

        }
    }
}
