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
    /// Логика взаимодействия для ConfirmRegOnMarPage.xaml
    /// </summary>
    public partial class ConfirmRegOnMarPage : Page
    {
        public ConfirmRegOnMarPage()
        {
            InitializeComponent();
        }

        private void BtOk_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.Navigate(new RunnerPage());
        }
    }
}
