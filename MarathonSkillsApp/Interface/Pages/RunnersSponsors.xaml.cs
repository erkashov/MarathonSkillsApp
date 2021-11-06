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
    /// Логика взаимодействия для RunnersSponsors.xaml
    /// </summary>
    public partial class RunnersSponsors : Page
    {
        public RunnersSponsors()
        {
            InitializeComponent();
            var reg = LogicWindow.CurrentUser.Runner.Last().Registration.Where(p => p.RegistrationEvent.ToList().Last().Event.Marathon.MarathonId == 5).ToList().Last();
            if(reg!=null)
            {
                grid.DataContext = reg.Charity;
                DgSponsors.ItemsSource = MarathonEntities.GetContext().Sponsorship.Where(p => p.RegistrationId == reg.RegistrationId).ToList();
                stack.DataContext = new
                {
                    Itog = MarathonEntities.GetContext().Sponsorship.Where(p => p.RegistrationId == reg.RegistrationId).Sum(p => p.Amount)
                };

            }
        }
    }
}
