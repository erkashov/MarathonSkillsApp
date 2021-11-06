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
    /// Логика взаимодействия для AdminVolont.xaml
    /// </summary>
    public partial class AdminVolont : Page
    {
        public AdminVolont()
        {
            InitializeComponent();
            TbTotalCount.Text = MarathonEntities.GetContext().Volunteer.Count().ToString();
            DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.FirstName).ToList();
            CbSort.SelectedIndex = 0;
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (CbSort.SelectedIndex)
            {
                case 0:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.FirstName).ToList();
                        break;
                    }
                case 1:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.LastName).ToList();
                        break;
                    }
                case 2:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.Country.CountryName).ToList();
                        break;
                    }
                case 3:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.Gender).ToList();
                        break;
                    }
            }
        }

        private void BtLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbSort.SelectedIndex)
            {
                case 0:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.FirstName).ToList();
                        break;
                    }
                case 1:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.LastName).ToList();
                        break;
                    }
                case 2:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.Country.CountryName).ToList();
                        break;
                    }
                case 3:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.Gender).ToList();
                        break;
                    }
            }
        }

        private void Update()
        {
            switch (CbSort.SelectedIndex)
            {
                case 0:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.FirstName).ToList();
                        break;
                    }
                case 1:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.LastName).ToList();
                        break;
                    }
                case 2:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.Country.CountryName).ToList();
                        break;
                    }
                case 3:
                    {
                        DgVol.DataContext = MarathonEntities.GetContext().Volunteer.OrderBy(p => p.Gender).ToList();
                        break;
                    }
            }
        }
    }
}
