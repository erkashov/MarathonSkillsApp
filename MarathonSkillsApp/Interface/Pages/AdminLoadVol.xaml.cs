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
    /// Логика взаимодействия для AdminLoadVol.xaml
    /// </summary>
    public partial class AdminLoadVol : Page
    {
        string path = "";
        public AdminLoadVol()
        {
            InitializeComponent();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            int Loaded = 0, Editet = 0;
            if (path == "") return;
            var volonters = File.ReadAllLines(path);
            List<Volunteer> toAdd = new List<Volunteer>();
            foreach(var vol in volonters)
            {
                var data = vol.Split(',');
                try
                {
                    if (data.Length != 5) throw new ArgumentException("Неверные данные");
                    if (data[0] == "VolunteerId") continue;
                    Volunteer v = new Volunteer
                    {
                        VolunteerId = int.Parse(data[0]),
                        FirstName = data[1],
                        LastName = data[2]
                    };
                    var country = MarathonEntities.GetContext().Country.Find(data[3]);
                    if (country == null) throw new Exception("Неверный код страны");
                    else v.Country = country;
                    v.CountryCode = country.CountryCode;
                    if (data[4] == "F")
                    {
                        v.Gender1 = MarathonEntities.GetContext().Gender.Find("Female");
                        v.Gender = v.Gender1.Gender1;
                    }
                    else if (data[4] == "M")
                    {
                        v.Gender1 = MarathonEntities.GetContext().Gender.Find("Male");
                        v.Gender = v.Gender1.Gender1;
                    }
                    else throw new Exception("Некорректный пол");
                    if (MarathonEntities.GetContext().Volunteer.Find(v.VolunteerId) != null)
                    {
                        MarathonEntities.GetContext().Volunteer.Remove(MarathonEntities.GetContext().Volunteer.Find(v.VolunteerId));
                        Loaded--;
                        Editet++;
                    }
                    toAdd.Add(v);
                    Loaded++;
                }
                catch(ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    TbStatus.Text = "CSV файл должен содержать сделующие поля:";
                    TbPolya.Visibility = Visibility.Visible;
                    return;
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении {data[0]} - {ex.Message}");
                    return;
                }
            }
            MarathonEntities.GetContext().SaveChanges();
            MarathonEntities.GetContext().Volunteer.AddRange(toAdd); 
            MarathonEntities.GetContext().SaveChanges();
            TbStatus.Text = $"Загрузка успешна. Загружено - {Loaded}, изменено - {Editet}";
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            Clases.Manager.LogicFrame.GoBack();
        }

        private void BtCSV_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "CVS files| *.csv";
            o.ShowDialog();
            path = o.FileName;
            TbPath.Text = o.SafeFileName;
        }
    }
}
