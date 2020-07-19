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
using Taxi.Model;

namespace Taxi.View.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static user User { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ShowTitle(object sender, NavigationEventArgs e)
        {
            if (e.Content is Page page)
            {
                this.Title = page.Title;
            }

        }
    }
}
