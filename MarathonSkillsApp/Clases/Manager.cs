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
        /// <summary>
        /// Определяет возратсную категорию бегуна
        /// </summary>
        /// <param name="DateOfBirth">дата рождения</param>
        /// <param name="CalcTime">дата, относительно которой надо вычитать категорию</param>
        /// <returns></returns>
        public static string GetCategory(DateTime DateOfBirth, DateTime CalcTime)
        {
            TimeSpan delta = CalcTime - DateOfBirth;
            if (delta < (CalcTime - new DateTime(CalcTime.Year - 18, CalcTime.Month, CalcTime.Day))) return "до 18";
            if (delta < (CalcTime - new DateTime(CalcTime.Year - 30, CalcTime.Month, CalcTime.Day))) return "18-29";
            if (delta < (CalcTime - new DateTime(CalcTime.Year - 40, CalcTime.Month, CalcTime.Day))) return "30-39";
            if (delta < (CalcTime - new DateTime(CalcTime.Year - 56, CalcTime.Month, CalcTime.Day))) return "40-55";
            if (delta < (CalcTime - new DateTime(CalcTime.Year - 70, CalcTime.Month, CalcTime.Day))) return "56-70";
            else return "более 70";
        }
    }
}
