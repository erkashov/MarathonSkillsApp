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
    /// Логика взаимодействия для CoordinatorPage.xaml
    /// </summary>
    public partial class CoordinatorPage : Page
    {
        public CoordinatorPage()
        {
            InitializeComponent();
        }

        private void BtRunners_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");

        }

        private void BtSponcors_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");

        }
    }
}
