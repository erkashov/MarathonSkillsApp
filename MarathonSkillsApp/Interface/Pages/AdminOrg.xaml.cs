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
    /// Логика взаимодействия для AdminOrg.xaml
    /// </summary>
    public partial class AdminOrg : Page
    {
        public AdminOrg()
        {
            InitializeComponent();
            DgOrgs.ItemsSource = MarathonEntities.GetContext().Charity.ToList();
        }

        private void BtEditOrg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
