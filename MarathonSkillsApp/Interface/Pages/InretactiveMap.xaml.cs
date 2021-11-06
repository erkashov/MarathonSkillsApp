using MarathonSkillsApp.Clases;
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

namespace MarathonSkillsApp.Interface.Pages
{
    /// <summary>
    /// Логика взаимодействия для InretactiveMap.xaml
    /// </summary>
    public partial class InretactiveMap : Page
    {
        public InretactiveMap()
        {
            InitializeComponent();
        }


        private void Ellipse_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Ellipse_MouseDown_2(object sender, MouseButtonEventArgs e)
        {

        }

        private void Ellipse_MouseDown_3(object sender, MouseButtonEventArgs e)
        {

        }

        private void Ellipse_MouseDown_4(object sender, MouseButtonEventArgs e)
        {

        }

        private void Ellipse_MouseDown_5(object sender, MouseButtonEventArgs e)
        {

        }

        private void Ellipse_MouseDown_6(object sender, MouseButtonEventArgs e)
        {

        }

        private void Ellipse_MouseDown_7(object sender, MouseButtonEventArgs e)
        {

        }

        private void Ellipse_MouseDown_8(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PInfo.IsOpen = true;
            PInfo.DataContext = new
            {
                Title = "Старт",
                Descr = "Полный марафон"
            };
        }

        private void Ellipse_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            PInfo.IsOpen = true;
            PInfo.DataContext = new
            {
                Title = "Точка 1",
                Descr = "Особенности"
            };
            LwPopup.ItemsSource = new List<Icons>()
            {
                new Icons()
                {
                    Icon = new BitmapImage(new Uri("/Resources/map-icon-drinks.png", UriKind.Relative)),
                    IconName = "Напитки"
                },
                new Icons()
                {
                    Icon = new BitmapImage(new Uri("/Resources/map-icon-energy-bars.png", UriKind.Relative)),
                    IconName = "Энергетические батончики"
                },
            };
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PInfo.IsOpen = false;
        }

        private void Image_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            PInfo.IsOpen = true;
            PInfo.DataContext = new
            {
                Title = "Старт",
                Descr = "Полумарафон"
            };
        }

        private void Image_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            PInfo.IsOpen = true;
            PInfo.DataContext = new
            {
                Title = "Старт",
                Descr = "5км марафон"
            };
        }
    }
}
