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
    /// Логика взаимодействия для Marathon2016Info.xaml
    /// </summary>
    public partial class Marathon2016Info : Page
    {
        public Marathon2016Info()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.LogicFrame.Navigate(new InretactiveMap());
        }
    }
}
