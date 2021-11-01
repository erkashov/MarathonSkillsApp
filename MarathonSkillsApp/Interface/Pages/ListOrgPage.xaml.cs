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
    /// Логика взаимодействия для ListOrgPage.xaml
    /// </summary>
    public partial class ListOrgPage : Page
    {
        public ListOrgPage()
        {
            InitializeComponent();
            LvList.ItemsSource = MarathonEntities.GetContext().Charity.ToList();

        }
    }
}
