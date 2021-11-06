using MarathonSkillsApp.Clases;
using MarathonSkillsApp.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddOrg.xaml
    /// </summary>
    public partial class AddOrg : Page
    {
        private Charity CurrentCharity { get; set; }
        OpenFileDialog o = new OpenFileDialog();
        byte[] image = new byte[] { };


        public AddOrg()
        {
            InitializeComponent();
        }
        public AddOrg(Charity c)
        {
            InitializeComponent();
            CurrentCharity = c;
            grid.DataContext = c;
            Title.Text = "Редактирование благотворительной организации";
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbName.Text == "") MessageBox.Show("Введите наименование", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (CurrentCharity == null)
            {
                CurrentCharity = new Charity() { CharityName = TbName.Text, CharityDescription = TbDescr.Text };
                if (TbPath.Text != "")
                {
                    CurrentCharity.CharityLogo = TbPath.Text;
                    //добавление в ресурсы
                    /*System.Resources.ResourceWriter RW = new System.Resources.ResourceWriter("MarathonSkillsApp.Properties.Resources");
                    RW.AddResource(o.SafeFileName, image);                    
                    RW.Close();*/
                    MarathonEntities.GetContext().Charity.Add(CurrentCharity);
                    MarathonEntities.GetContext().SaveChanges();
                }
                MessageBox.Show("Организация сохранена");
                Manager.LogicFrame.Navigate(new AdminOrg());
            }
            else
            {
                CurrentCharity = MarathonEntities.GetContext().Charity.Find(CurrentCharity.CharityId);
                if (TbName.Text != CurrentCharity.CharityName) CurrentCharity.CharityName = TbName.Text;
                if (TbDescr.Text != CurrentCharity.CharityDescription) CurrentCharity.CharityDescription = TbDescr.Text;
                if (TbPath.Text != CurrentCharity.CharityLogo) CurrentCharity.CharityLogo = TbPath.Text;
                MarathonEntities.GetContext().SaveChanges();
                MessageBox.Show("Организация изменена");
                Manager.LogicFrame.Navigate(new AdminOrg());
            }
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.LogicFrame.GoBack();
        }

        private void BtPhoto_Click(object sender, RoutedEventArgs e)
        {
            o.Filter = "Image Files| *.jpg; *.jpeg; *.png";
            o.ShowDialog();
            TbPath.Text = o.SafeFileName;
            image = File.ReadAllBytes(o.FileName);
            grid.DataContext = new
            {
                ImageSource = image
            };
        }
    }
}
