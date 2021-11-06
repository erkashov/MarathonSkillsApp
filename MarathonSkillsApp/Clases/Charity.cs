using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MarathonSkillsApp
{
    public partial class Charity
    {
        public BitmapImage ImageSource
        {
            get
            {
                try
                {
                    return new BitmapImage(new Uri($"pack://application:,,,/Resources/{CharityLogo}", UriKind.Absolute));
                }
                catch
                {
                    return new BitmapImage();
                }

            }
        }
    }
}
