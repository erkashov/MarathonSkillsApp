using MarathonSkillsApp.Clases;
using MarathonSkillsApp.Interface.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MarathonSkillsApp.Interface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer_Tick(new object(), new EventArgs());
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();            
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            timer.Text = Manager.TimeTo();
            // Forcing the CommandManager to raise the RequerySuggested event
            //CommandManager.InvalidateRequerySuggested();
        }

        private void BtSponsor_Click(object sender, RoutedEventArgs e)
        {
            LogicWindow l = new LogicWindow();
            l.LogicFrame.Navigate(new RunnerSponsorPage());
            l.Show();
            this.Close();
        }

        private void BtDetail_Click(object sender, RoutedEventArgs e)
        {
            LogicWindow l = new LogicWindow();
            l.LogicFrame.Navigate(new DetailInfoPage());
            l.Show();
            this.Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            LogicWindow l = new LogicWindow();
            l.LogicFrame.Navigate(new LoginPage());
            l.Show();
            this.Close();
        }

        private void BtRunner_Click(object sender, RoutedEventArgs e)
        {
            LogicWindow l = new LogicWindow();
            l.LogicFrame.Navigate(new CheckRunners());
            l.Show();
            this.Close();
        }
    }
}
