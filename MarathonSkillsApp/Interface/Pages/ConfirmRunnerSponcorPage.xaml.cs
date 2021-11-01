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

namespace MarathonSkillsApp.Interface
{
    /// <summary>
    /// Логика взаимодействия для ConfirmRunnerSponcorPage.xaml
    /// </summary>
    public partial class ConfirmRunnerSponcorPage : Page
    {
        public ConfirmRunnerSponcorPage(Sponsorship s)
        {
            InitializeComponent();
            grid.DataContext = s;
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.GoBack();
        }
    }
}
