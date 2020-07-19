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
using Taxi.View.Windows;

namespace Taxi.View.Pages.operatorv
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {

        Shared.SettingsPassword Password = new Shared.SettingsPassword(MainWindow.User);
        public Settings()
        {
            try
            {
                InitializeComponent();
                FrameSettings.Navigate(Password);

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void Confim(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Password.SavePassword())
                {
                    MessageBox.Show("Данные изменены");
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }
    }
}
