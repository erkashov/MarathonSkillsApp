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
    /// Логика взаимодействия для DetailInfoPage.xaml
    /// </summary>
    public partial class DetailInfoPage : Page
    {
        public DetailInfoPage()
        {
            InitializeComponent();
        }

        private void ListOrg_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.Navigate(new ListOrgPage());
        }

        private void MarathonSkills2016_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");

        }

        private void LastResults_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");

        }

        private void BMICalc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");

        }

        private void HowLong_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");

        }

        private void ListOrg_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");

        }

        private void BMRCalc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");

        }
    }
}
