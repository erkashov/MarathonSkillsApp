using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MarathonSkillsApp.Clases
{
    public static class Manager
    {
        public static Frame LogicFrame;
        /// <summary>
        /// Функция для определения контента таймера до начала марафона
        /// </summary>
        /// <returns></returns>
        public static string TimeTo()
        {
            TimeSpan time = (DateTime.Parse("24.11.2021 06:00") - DateTime.Now);
            string days, hours, minutes;
            int[] mas = new int[] { 2, 3, 4 };
            int[] unmas = new int[] { 12, 13, 14 };

            if (time.Days % 10 == 1) days = "день";
            else if (mas.Contains(time.Days % 10) && !unmas.Contains(time.Days)) days = "дня";
            else days = "дней";

            if (time.Hours % 10 == 1) hours = "час";
            else if (mas.Contains(time.Hours % 10) && !unmas.Contains(time.Hours)) hours = "часа";
            else hours = "часов";

            if (time.Minutes % 10 == 1) minutes = "минута";
            else if (mas.Contains(time.Minutes % 10) && !unmas.Contains(time.Minutes)) minutes = "минуты";
            else minutes = "минут";

            return $"{time.Days} {days} {time.Hours} {hours} и {time.Minutes} {minutes} до старта марафона!";
        }
    }
}
