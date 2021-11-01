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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MarathonSkillsApp.Interface
{
    /// <summary>
    /// Логика взаимодействия для LogicWindow.xaml
    /// </summary>
    public partial class LogicWindow : Window
    {
        public static LogicWindow CurrentWindow;
        public static Button ButtonLogout;
        public static User CurrentUser;
        public DispatcherTimer dispatcherTimer;

        public LogicWindow()
        {
            InitializeComponent();
            
            CurrentWindow = this;
            ButtonLogout = BtLogout;
            Manager.LogicFrame = LogicFrame;
            LogicFrame.Navigate(new RunnerSponsorPage());

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
            DispatcherTimer_Tick(new object(), new EventArgs());
        }
        /// <summary>
        /// Обработчик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            timer.Text = Manager.TimeTo();
        }

        private void BtLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if(LogicFrame.CanGoBack) LogicFrame.GoBack();
            else
            {
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
            }
        }
    }
}
