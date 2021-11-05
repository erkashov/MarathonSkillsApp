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
    /// Логика взаимодействия для DeliveryInvPage.xaml
    /// </summary>
    public partial class DeliveryInvPage : Page
    {
        public DeliveryInvPage()
        {
            InitializeComponent();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MarathonEntities.GetContext().StockInventar.Where(p => p.InvName == "Number").OrderByDescending(p => p.Id).First().Stock += int.Parse(TbNum.Text);
                MarathonEntities.GetContext().StockInventar.Where(p => p.InvName == "RFID").OrderByDescending(p => p.Id).First().Stock += int.Parse(TbId.Text);
                MarathonEntities.GetContext().StockInventar.Where(p => p.InvName == "BaseboolCap").OrderByDescending(p => p.Id).First().Stock += int.Parse(TbBaseb.Text);
                MarathonEntities.GetContext().StockInventar.Where(p => p.InvName == "Water").OrderByDescending(p => p.Id).First().Stock += int.Parse(TbWater.Text);
                MarathonEntities.GetContext().StockInventar.Where(p => p.InvName == "TShirt").OrderByDescending(p => p.Id).First().Stock += int.Parse(TbT.Text);
                MarathonEntities.GetContext().StockInventar.Where(p => p.InvName == "Buklet").OrderByDescending(p => p.Id).First().Stock += int.Parse(TbBuklet.Text);
                MarathonEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные внесены");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Введите корректные данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
