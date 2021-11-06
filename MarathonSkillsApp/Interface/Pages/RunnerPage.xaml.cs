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
    /// Логика взаимодействия для RunnerPage.xaml
    /// </summary>
    public partial class RunnerPage : Page
    {
        public RunnerPage()
        {
            InitializeComponent();
        }

        private void BtContacts_Click(object sender, RoutedEventArgs e)
        {
            PopupContacts.IsOpen = true;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PopupContacts.IsOpen = false;
        }

        private void BtReg_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.Navigate(new RunnersRegOnMarPage());

        }

        private void BtEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.Navigate(new EdirRunnerProfilePage());

        }

        private void BtResults_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.Navigate(new RunnersRezPage());

        }

        private void BtSponcor_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.Navigate(new RunnersSponsors());

        }
    }
}
