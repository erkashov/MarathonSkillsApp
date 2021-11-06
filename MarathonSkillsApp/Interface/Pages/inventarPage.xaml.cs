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
    /// Логика взаимодействия для inventarPage.xaml
    /// </summary>
    public partial class inventarPage : Page
    {
        public inventarPage()
        {
            InitializeComponent();
            int A = MarathonEntities.GetContext().RegistrationEvent.Where(p => p.Event.Marathon.MarathonName == "Marathon Skills 2015" && p.Registration.RaceKitOptionId == "A").Count();
            int B = MarathonEntities.GetContext().RegistrationEvent.Where(p => p.Event.Marathon.MarathonName == "Marathon Skills 2015" && p.Registration.RaceKitOptionId == "B").Count();
            int C = MarathonEntities.GetContext().RegistrationEvent.Where(p => p.Event.Marathon.MarathonName == "Marathon Skills 2015" && p.Registration.RaceKitOptionId == "C").Count();
            var Stock = MarathonEntities.GetContext().StockInventar.OrderByDescending(p => p.Id).ToList();

            var source = new
            {
                TotalRunners = MarathonEntities.GetContext().RegistrationEvent.Where(p => p.Event.Marathon.MarathonName == "Marathon Skills 2015").Count(),
                TypeA = A,
                TypeB = B,
                TypeC = C,
                Need = A + B + C,
                Stock = 165,
                NeedNum = A,
                NeedId = A,
                NeedBaseb = A + B,
                NeedWater = A + B,
                NeedT = A + B + C,
                NeedBuklet = A + B + C,
                StockNum = Stock.Where(p => p.InvName == "Number").First().Stock,
                StockId = Stock.Where(p => p.InvName == "RFID").First().Stock,
                StockBaseb = Stock.Where(p => p.InvName == "BaseboolCap").First().Stock,
                StockWater = Stock.Where(p => p.InvName == "Water").First().Stock,
                StockT = Stock.Where(p => p.InvName == "TShirt").First().Stock,
                StockBuklet = Stock.Where(p => p.InvName == "Buklet").First().Stock,
                TotalStock = Stock.Where(p => p.InvName == "Number").First().Stock,
                OrderNum = A - Stock.Where(p => p.InvName == "Number").First().Stock,
                OrderId = A - Stock.Where(p => p.InvName == "RFID").First().Stock,
                OrderBaseb = A + B + Stock.Where(p => p.InvName == "BaseboolCap").First().Stock,
                OrderWater = A + B + Stock.Where(p => p.InvName == "Water").First().Stock,
                OrderT = A + B + C + Stock.Where(p => p.InvName == "TShirt").First().Stock,
                OrderBuklet = A + B + C + Stock.Where(p => p.InvName == "Buklet").First().Stock,
            };
            grid.DataContext = source;
        }

        private void BtDel_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.Navigate(new DeliveryInvPage());
        }

        private void BtReport_Click(object sender, RoutedEventArgs e)
        {
            PopupPrint.IsOpen = true;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PopupPrint.IsOpen = false;
        }
    }
}
