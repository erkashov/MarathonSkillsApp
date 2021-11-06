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
    /// Логика взаимодействия для RunnersRezPage.xaml
    /// </summary>
    public partial class RunnersRezPage : Page
    {
        public RunnersRezPage()
        {
            InitializeComponent();
            List<MarathonRes> results = new List<MarathonRes>();
            var email = LogicWindow.CurrentUser.Runner.First().Email;
            var regs = MarathonEntities.GetContext().Registration.Where(p => p.Runner.Email == email).ToList();
            TbAgeCat.Text = Manager.GetCategory((DateTime)LogicWindow.CurrentUser.Runner.First().DateOfBirth, DateTime.Now);
            foreach(var reg in regs)
            {
               var regevents = reg.RegistrationEvent.ToList();
                foreach (var regevent in regevents)
                {
                    MarathonRes res = new MarathonRes();
                    res.Marathon = regevent.Event.Marathon.YearHeld + " " + regevent.Event.Marathon.Country.CountryName;
                    res.Dist = regevent.Event.EventType.EventTypeName;
                    int hours, min, sec;
                    int time = (int)regevent.RaceTime;
                    sec = time % 60;
                    time /= 60;
                    min = time % 60;
                    time /= 60;
                    hours = time;
                    res.Time = $"{hours}h {min}m {sec}s";
                    res.TotalPos = "#" + (MarathonEntities.GetContext().RegistrationEvent.Where(p => p.EventId == regevent.EventId).OrderBy(p => p.RaceTime).ToList().IndexOf(regevent) + 1);

                    //res.CatPos = "#" + (MarathonEntities.GetContext().RegistrationEvent.Where(p => p.EventId == regevent.EventId && p.GetCategory == regevent.GetCategory).OrderBy(p => p.RaceTime).ToList().IndexOf(regevent) + 1);
                                                  
                    results.Add(res);
                }
            }
            DGRes.ItemsSource = results;
        }

        private void BtAllRez_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
