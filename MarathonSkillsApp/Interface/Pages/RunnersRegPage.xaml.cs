using MarathonSkillsApp.Clases;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для RunnersRegPage.xaml
    /// </summary>
    public partial class RunnersRegPage : Page
    {
        private byte[] Photo;
        public RunnersRegPage()
        {
            InitializeComponent();
            CbGender.ItemsSource = MarathonEntities.GetContext().Gender.ToList();
            CbCountry.ItemsSource = MarathonEntities.GetContext().Country.OrderBy(p=>p.CountryName).ToList();
        }

        private void BtOpenPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.ShowDialog();
            PhotoRunner.Source = new BitmapImage(new Uri(FD.FileName));
            Photo = File.ReadAllBytes(FD.FileName);
            TbImagePath.Text = FD.FileName;
        }

        private void BtReg_Click(object sender, RoutedEventArgs e)
        {
            string pattern = "[a-z]+[0-9]+[!, @, #, $, %, ^]+";
            if (TbEmail.Text == "" || TbFirstName.Text =="" || TbName.Text == "" || TbPassword.Text=="" || TbConfirmPassword.Text=="" || Photo==null || CbCountry.SelectedItem==null||CbGender.SelectedItem==null||DpBirth.SelectedDate==null)
            {
                MessageBox.Show("Введите все данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(!(new EmailAddressAttribute().IsValid(TbEmail.Text)))
            {
                MessageBox.Show("Неверный Email", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(TbPassword.Text.Length<6 || !Regex.IsMatch(TbPassword.Text, pattern))
            {
                MessageBox.Show("Требования для пароля- \nМинимум 6 символов\nМинимум 1 прописная буква\nМинимум 1 цифра\nПо крайней мере один из следующих символов: ! @ # $ % ^");
            }
            else if(TbPassword.Text  != TbConfirmPassword.Text)
            {
                MessageBox.Show("Пароли отличаются", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(DpBirth.SelectedDate.Value > new DateTime(DateTime.Now.Year-10, DateTime.Now.Month, DateTime.Now.Day))
            {
                MessageBox.Show("На момент регистрации вам должно быть более 10 лет", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                User u = new User
                {
                    Email = TbEmail.Text,
                    FirstName = TbFirstName.Text,
                    LastName = TbName.Text,
                    Password = TbPassword.Text,
                    Role = MarathonEntities.GetContext().Role.Where(p => p.RoleName == "Runner").FirstOrDefault(),
                    RoleId = MarathonEntities.GetContext().Role.Where(p => p.RoleName == "Runner").FirstOrDefault().RoleId
                };
                Runner r = new Runner
                {
                    Country = CbCountry.SelectedItem as Country,
                    CountryCode = (CbCountry.SelectedItem as Country).CountryCode,
                    DateOfBirth = DpBirth.SelectedDate,
                    Email = u.Email,
                    Gender = (CbGender.SelectedItem as Gender).Gender1,
                    Gender1 = CbGender.SelectedItem as Gender,
                    Photo = Photo,
                    User = u
                };
                u.Runner.Add(r);

                MarathonEntities.GetContext().Runner.Add(r);
                MarathonEntities.GetContext().User.Add(u);
                MarathonEntities.GetContext().SaveChanges();
                Manager.LogicFrame.Navigate(new RunnerPage());
                LogicWindow.CurrentUser = MarathonEntities.GetContext().User.Where(p => p.Email == u.Email && p.Password == u.Password).FirstOrDefault();
            }
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.GoBack();
        }
    }
}
