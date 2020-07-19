using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Taxi.View.Pages.Shared
{
    /// <summary>
    /// Interaction logic for SettingsPassword.xaml
    /// </summary>
    public partial class SettingsPassword : Page
    {
        Model.taxiEntities context = new taxiEntities();

        private user user;
        public SettingsPassword(user user)
        {
            InitializeComponent();
            this.user = user;
        }

        public bool SavePassword()
        {
            try
            {
                if (user.password == oldPass.Text)
                {
                    if (newPass.Text == ReplayPass.Text)
                    {
                        var usera = context.user.Find(user.id);
                        usera.password = newPass.Text;
                        context.SaveChanges();
                        MainWindow.User = usera;
                        return true;
                    }
                    else
                    {
                        instruments.MsgBox.Warning("Пароли не совпадают");

                    }
                }
                else
                {
                    instruments.MsgBox.Warning("Введите верный старный пароль");
                }
                return false;

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
                return false;
            }
        }
    }
}
