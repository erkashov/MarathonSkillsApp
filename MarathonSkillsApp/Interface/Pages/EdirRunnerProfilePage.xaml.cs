using MarathonSkillsApp.Clases;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EdirRunnerProfilePage.xaml
    /// </summary>
    public partial class EdirRunnerProfilePage : Page
    {
        private byte[] Photo;
        public EdirRunnerProfilePage()
        {
            InitializeComponent();
            CbGender.ItemsSource = MarathonEntities.GetContext().Gender.ToList();
            CbCountry.ItemsSource = MarathonEntities.GetContext().Country.OrderBy(p => p.CountryName).ToList();
            grid.DataContext = LogicWindow.CurrentUser.Runner.LastOrDefault();
            CbCountry.SelectedValue = LogicWindow.CurrentUser.Runner.First().Country.CountryName;
            CbGender.SelectedItem = LogicWindow.CurrentUser.Runner.First().Gender1;
            Photo = LogicWindow.CurrentUser.Runner.LastOrDefault().Photo;
        }

        private void BtReg_Click(object sender, RoutedEventArgs e)
        {
            string pattern = "[a-z]+[0-9]+[!, @, #, $, %, ^]+";
            if (TbFirstName.Text == "" || TbName.Text == "" || Photo == null || CbCountry.SelectedItem == null || CbGender.SelectedItem == null || DpBirth.SelectedDate == null)
            {
                MessageBox.Show("Введите все данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TbPassword.Text != "" && (TbPassword.Text.Length < 6 || !Regex.IsMatch(TbPassword.Text, pattern)))
            {
                MessageBox.Show("Требования для пароля- \nМинимум 6 символов\nМинимум 1 прописная буква\nМинимум 1 цифра\nПо крайней мере один из следующих символов: ! @ # $ % ^");
            }
            else if (TbPassword.Text != TbConfirmPassword.Text)
            {
                MessageBox.Show("Пароли отличаются", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (DpBirth.SelectedDate.Value > new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day))
            {
                MessageBox.Show("На момент регистрации вам должно быть более 10 лет", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                User CurrUser = MarathonEntities.GetContext().User.Find(LogicWindow.CurrentUser.Email);
                if (TbFirstName.Text != CurrUser.FirstName) CurrUser.FirstName = TbFirstName.Text;
                if (TbName.Text != CurrUser.LastName) CurrUser.LastName = TbName.Text;
                if (CbGender.SelectedItem as Gender != CurrUser.Runner.Last().Gender1)
                {
                    CurrUser.Runner.Last().Gender1 = CbGender.SelectedItem as Gender;
                    CurrUser.Runner.Last().Gender = (CbGender.SelectedItem as Gender).Gender1;
                }
                if (CbCountry.SelectedItem as Country != CurrUser.Runner.Last().Country)
                {
                    CurrUser.Runner.Last().Country = CbCountry.SelectedItem as Country;
                    CurrUser.Runner.Last().CountryCode = (CbCountry.SelectedItem as Country).CountryCode;
                }
                if (DpBirth.SelectedDate != CurrUser.Runner.Last().DateOfBirth) CurrUser.Runner.Last().DateOfBirth = DpBirth.SelectedDate;
                if (TbPassword.Text != "") CurrUser.Password = TbPassword.Text;
                if (Photo != CurrUser.Runner.Last().Photo) CurrUser.Runner.Last().Photo = Photo;
                MarathonEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные изменены");
                Manager.LogicFrame.Navigate(new RunnerPage());
                LogicWindow.CurrentUser = CurrUser;
            }
        }
        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.GoBack();
        }

        private void BtOpenPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.ShowDialog();
            PhotoRunner.Source = new BitmapImage(new Uri(FD.FileName));
            Photo = File.ReadAllBytes(FD.FileName);
            TbImagePath.Text = FD.FileName;
        }
    }
}
