using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
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

namespace Taxi.View.Pages.admin
{
    /// <summary>
    /// Interaction logic for AddOrUpdateCar.xaml
    /// </summary>
    public partial class AddOrUpdateCar : Page
    {
        taxiEntities context = new taxiEntities();

        private car car;

        private byte[] Image;

        public event CanLoad CanLoad;

        public AddOrUpdateCar()
        {
            try
            {
                InitializeComponent();
                car = new car();
                LoadBrand();

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        public AddOrUpdateCar(car car)
        {
            try
            {

                InitializeComponent();
                LoadBrand();
                this.car = car;
                number.Text = car.number;
                VIN.Text = car.vin;
                Image = car.photo;
                Brand.SelectedItem = context.brand.Find(car.model1.brand1.id);
                LoadModel(car.model1.brand1);
                Model.SelectedItem = context.model.Find(car.model1.id);
                CarImage.Source = instruments.Converter.ByteToImage(Image);
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void LoadBrand()
        {
            try
            {

                Brand.ItemsSource = context.brand.ToList();
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void LoadModel(brand brand)
        {
            try
            {
                Model.ItemsSource = context.model.Where(i => i.brand == brand.id).ToList();

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

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Image != null &&
                    Model.SelectedItem is model model &&
                    Brand.SelectedItem is brand brand &&
                    number.Text != string.Empty &&
                    VIN.Text != string.Empty)
                {
                    car.photo = Image;
                    car.number = number.Text;
                    car.vin = VIN.Text;
                    car.model = model.id;
                    context.car.AddOrUpdate(car);
                    context.SaveChanges();
                    CanLoad();
                    ExitThis();

                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                if (openFileDialog.ShowDialog().Value)
                {
                    Image = File.ReadAllBytes(openFileDialog.FileName);
                    CarImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                }
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }

        private void SelectBrand(object sender, EventArgs e)
        {
            try
            {
                if (Brand.SelectedItem is brand brand)
                {
                    LoadModel(brand);
                }

            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
            }
        }
    }
}
