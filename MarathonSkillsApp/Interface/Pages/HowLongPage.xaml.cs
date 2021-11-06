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
    /// Логика взаимодействия для HowLongPage.xaml
    /// </summary>
    public partial class HowLongPage : Page
    {
        public HowLongPage()
        {
            InitializeComponent();
            List<LongData> LDS = new List<LongData>()
            {
                new LongData(){ Name = "F1 Car", ImageSource= new BitmapImage(new Uri("/Resources/f1-car.jpg", UriKind.Relative)), Speed =345, Descr=$"An F1 car travels at 345 km/h so would complete the marathon in 7 minutes 20 seconds." },
                new LongData(){ Name = "Slug", ImageSource=new BitmapImage(new Uri("/Resources/slug.jpg", UriKind.Relative)), Speed=0.01, Descr=$"An slug travels at 0.01 km/h so would complete the marathon in 4200 hours." },
                new LongData(){ Name = "Horse", ImageSource=new BitmapImage(new Uri("/Resources/horse.png", UriKind.Relative)), Speed=15, Descr=$"An horse travels at 15 km/h so would complete the marathon in 2 hours 48 minutes." },
                new LongData(){ Name = "Sloth", ImageSource=new BitmapImage(new Uri("/Resources/sloth.jpg", UriKind.Relative)), Speed=0.12, Descr=$"An sloth travels at 0.12 km/h so would complete the marathon in 350 hours." },
                new LongData(){ Name = "Capybara", ImageSource=new BitmapImage(new Uri("/Resources/capybara.jpg", UriKind.Relative)), Speed=35, Descr=$"An sloth travels at 0.12 km/h so would complete the marathon in 1 hour 12 minutes." },
                new LongData(){ Name = "Jaguar", ImageSource=new BitmapImage(new Uri("/Resources/jaguar.jpg", UriKind.Relative)), Speed=80, Descr=$"An sloth travels at 0.12 km/h so would complete the marathon in 31 minutes 30 seconds." },
                new LongData(){ Name = "Worn", ImageSource=new BitmapImage(new Uri("/Resources/worm.jpg", UriKind.Relative)), Speed=0.03, Descr=$"An sloth travels at 0.12 km/h so would complete the marathon in 1400 hours." },
            };
            List<LongData> LDD = new List<LongData>()
            {
                new LongData(){ Name = "Bus", ImageSource= new BitmapImage(new Uri("/Resources/bus.jpg", UriKind.Relative)), Speed =10, Descr=$"A bus is 10 m in lenght so 4200 would fit into the marathon lenght" },
                new LongData(){ Name = "Pair of Havaianas", ImageSource=new BitmapImage(new Uri("/Resources/pair-of-havaianas.jpg", UriKind.Relative)), Speed=0.245, Descr=$"An avaianas is 0.245 m in lenght so 171 428,57 would fit into the marathon lenght" },
                new LongData(){ Name = "Airbus A380", ImageSource=new BitmapImage(new Uri("/Resources/airbus-a380.jpg", UriKind.Relative)), Speed=73, Descr=$"A Airbus A380 is 73 m in lenght so 575,34 would fit into the marathon lenght" },
                new LongData(){ Name = "Football Field", ImageSource=new BitmapImage(new Uri("/Resources/football-field.jpg", UriKind.Relative)), Speed=105, Descr=$"A football field is 105 m in lenght so 400 would fit into the marathon lenght" },
                new LongData(){ Name = "Ronaldinho", ImageSource=new BitmapImage(new Uri("/Resources/ronaldinho.jpg", UriKind.Relative)), Speed=1.81, Descr=$"A Ronaldinho is 1.81 m in lenght so 23 204,41 would fit into the marathon lenght" },
                };
            LwSpeed.ItemsSource = LDS;
            LwDist.ItemsSource = LDD;
            LwSpeed.SelectedIndex = 0;
        }


        private void LwSpeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grid.DataContext = LwSpeed.SelectedItem;
        }

        private void LwDist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grid.DataContext = LwDist.SelectedItem;
        }
    }
}
