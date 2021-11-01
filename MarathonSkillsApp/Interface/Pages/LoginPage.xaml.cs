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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            LogicWindow.CurrentWindow.Close();
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            if(TbEmail.Text=="" || TbPassword.Text == "")
            {
                MessageBox.Show("Введите все данные");
                return;
            }
            User u = MarathonEntities.GetContext().User.Where(p => p.Email == TbEmail.Text && p.Password == TbPassword.Text).FirstOrDefault();
            if (u == null)
            {
                MessageBox.Show("Неправильные данные");
                return;
            }
            LogicWindow.ButtonLogout.Visibility = Visibility.Visible;
            LogicWindow.CurrentUser = u;
            switch (u.Role.RoleName)
            {
                case "Runner":
                    {
                        Manager.LogicFrame.Navigate(new RunnerPage());
                        break;
                    }
                case "Coordinator":
                    {
                        Manager.LogicFrame.Navigate(new CoordinatorPage());
                        break;
                    }
                case "Administrator":
                    {
                        Manager.LogicFrame.Navigate(new AdminPage());
                        break;
                    }
            }
        }
    }
}
