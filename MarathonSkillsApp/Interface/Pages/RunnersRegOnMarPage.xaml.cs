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
    /// Логика взаимодействия для RunnersRegOnMarPage.xaml
    /// </summary>
    public partial class RunnersRegOnMarPage : Page
    {
        int vznos = 0;
        int summa = 0;
        int MarathonId;
        public RunnersRegOnMarPage()
        {
            InitializeComponent();
            CbFond.ItemsSource = MarathonEntities.GetContext().Charity.ToList();
            RbVarA.IsChecked = true;
        }

        private void Cb_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)RbVarA.IsChecked) vznos = 0;
                if ((bool)RbVarB.IsChecked) vznos = 20;
                if ((bool)RbVarC.IsChecked) vznos = 25;
                if ((bool)CbType42.IsChecked) vznos += 145;
                if ((bool)CbType21.IsChecked) vznos += 75;
                if ((bool)CbType5.IsChecked) vznos += 20;
                vznos += summa;
                TbRegVznos.Text = $"${vznos}";
            }
            catch { }
        }


        private void TbSumma_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtReg_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)!CbType21.IsChecked && (bool)!CbType42.IsChecked && (bool)!CbType5.IsChecked)
            {
                MessageBox.Show("Выберите марафон", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (CbFond.SelectedItem==null)
            {
                MessageBox.Show("Выберите фонд", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string s;
            if (TbSumma.Text.Contains("$")) s = TbSumma.Text.Substring(1);
            else s = TbSumma.Text;
            if (!int.TryParse(s, out summa))
            {
                MessageBox.Show("Некорректное число", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if ((bool)CbType42.IsChecked)
            {
                Reg("16_6FM");
            }
            if ((bool)CbType5.IsChecked)
            {
                Reg("16_6FR");
            }
            if ((bool)CbType21.IsChecked)
            {
                Reg("16_6HM");
            }
            Manager.LogicFrame.Navigate(new ConfirmRegOnMarPage());
        }

        private void Reg(string TypeMarathon)
        {
            Registration r = new Registration
            {
                Runner = LogicWindow.CurrentUser.Runner.Last(),
                RunnerId = LogicWindow.CurrentUser.Runner.Last().RunnerId
            };
            r.Charity = CbFond.SelectedItem as Charity;
            r.CharityId = (CbFond.SelectedItem as Charity).CharityId;
            r.SponsorshipTarget = summa;
            if ((bool)RbVarA.IsChecked) r.RaceKitOption = MarathonEntities.GetContext().RaceKitOption.Find("A");
            if ((bool)RbVarB.IsChecked) r.RaceKitOption = MarathonEntities.GetContext().RaceKitOption.Find("B");
            if ((bool)RbVarC.IsChecked) r.RaceKitOption = MarathonEntities.GetContext().RaceKitOption.Find("C");
            r.RaceKitOptionId = r.RaceKitOption.RaceKitOptionId;
            r.RegistrationDateTime = DateTime.Now;
            r.RegistrationStatus = MarathonEntities.GetContext().RegistrationStatus.Find(1);
            r.Cost = vznos - summa;


            RegistrationEvent re = new RegistrationEvent
            {
                Registration = r,
                RegistrationId = r.RegistrationId
            };
            re.Event = MarathonEntities.GetContext().Event.Find(TypeMarathon);
            re.EventId = re.Event.EventId;
            var LastBibNum = MarathonEntities.GetContext().RegistrationEvent.Where(p => p.Event.EventId == re.EventId).OrderByDescending(p => p.BibNumber).FirstOrDefault();
            short maxBibNum;
            if (LastBibNum == null) maxBibNum = 0;
            else maxBibNum = (short) LastBibNum.BibNumber;
            re.BibNumber = ++maxBibNum;

            r.RegistrationEvent.Add(re);

            Sponsorship ss = new Sponsorship
            {
                Registration = r,
                RegistrationId = r.RegistrationId,
                Amount = summa,
                SponsorName = LogicWindow.CurrentUser.FirstName + " " + LogicWindow.CurrentUser.LastName
            };

            r.Sponsorship.Add(ss);

            r.SponsorshipTarget = decimal.Parse(summa.ToString());
            MarathonEntities.GetContext().Sponsorship.Add(ss);
            MarathonEntities.GetContext().Registration.Add(r);
            MarathonEntities.GetContext().SaveChanges();

            re.RegistrationId = MarathonEntities.GetContext().Registration.Where(p => p.RunnerId == r.RunnerId && p.RegistrationDateTime == r.RegistrationDateTime).FirstOrDefault().RegistrationId;
            //MarathonEntities.GetContext().RegistrationEvent.Add(re);
            MarathonEntities.GetContext().SaveChanges();
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.GoBack();
        }

        private void TbSumma_LostFocus(object sender, RoutedEventArgs e)
        {
            string s;
            if (TbSumma.Text.Contains("$")) s = TbSumma.Text.Substring(1);
            else s = TbSumma.Text;
            if (!int.TryParse(s, out summa)) MessageBox.Show("Некорректное число", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            else Cb_Checked(sender, e);
        }
    }
}
