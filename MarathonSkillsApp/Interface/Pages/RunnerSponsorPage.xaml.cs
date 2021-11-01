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
    /// Логика взаимодействия для RunnerSponsorPage.xaml
    /// </summary>
    public partial class RunnerSponsorPage : Page
    {
        public RunnerSponsorPage()
        {
            InitializeComponent();
            CbRunners.ItemsSource = MarathonEntities.GetContext().Registration.Select(p => p.Runner).ToList();
        }

        private void BtMinus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TbSumma.Text = (int.Parse(TbSumma.Text) - 10).ToString();
            }
            catch { }
        }

        private void BtPlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TbSumma.Text = (int.Parse(TbSumma.Text) + 10).ToString();
            }
            catch { }
        }

        private void BtPay_Click(object sender, RoutedEventArgs e)
        {
            string errors = "";
            if (TbName.Text == "") errors += "Введите ваше имя\n";
            if (CbRunners.SelectedItem == null) errors += "Выберите бегуна\n";
            if (TbCard.Text == "") errors += "Введите имя держателя карты\n";
            int check = 0;
            if (TbNumberCard.Text.Length < 16) errors += "В номере карты должно быть 16 цифр\n";
            else
            {
                try
                {
                    Int64.Parse(TbNumberCard.Text);
                }
                catch(Exception ex)
                {
                    errors += "Неверный номер карты\n";
                }
            }

            if (TbAviableMonth.Text.Length == 0) errors += "Неверный срок действия\n";
            else if(!int.TryParse(TbAviableMonth.Text, out check) || check<1 || check > 12) errors += "Неверный срок действия\n";

            else if (TbAviableYear.Text.Length == 0) errors += "Неверный срок действия\n";
            else if (!int.TryParse(TbAviableYear.Text, out check) || check < 2021 ) errors += "Неверный срок действия\n";

            if (TbCVC.Text.Length < 3) errors += "В CVC-коде должно быть 3 цифры\n";
            else if (!int.TryParse(TbCVC.Text, out check)) errors += "Неверный CVC\n";

            if (!int.TryParse(TbSumma.Text, out check)) errors += "Неверная сумма\n";
            else if (check < 1) errors += "Неверная сумма\n";

            if(errors != "")
            {
                MessageBox.Show(errors, "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Sponsorship s = new Sponsorship();
                s.Amount = decimal.Parse(TbSumma.Text);
                s.SponsorName = TbName.Text;
                int id = (CbRunners.SelectedItem as Runner).Registration.LastOrDefault().RegistrationId;
                s.Registration = MarathonEntities.GetContext().Registration.Find(id);
                s.RegistrationId = s.Registration.RegistrationId;
                MarathonEntities.GetContext().Sponsorship.Add(s);
                MarathonEntities.GetContext().SaveChanges();
                Manager.LogicFrame.Navigate(new ConfirmRunnerSponcorPage(s));
            }
        }

        private void TbName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
