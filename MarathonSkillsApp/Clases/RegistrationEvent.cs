using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkillsApp
{
    public partial class RegistrationEvent
    {
        /// <summary>
        /// Определяет возратсную категорию бегуна
        /// </summary>
        /// <param name="DateOfBirth">дата рождения</param>
        /// <param name="CalcTime">дата, относительно которой надо вычитать категорию</param>
        /// <returns></returns>
        public string GetCategory
        {
            get
            {
                DateTime DateBirth = (DateTime)Registration.Runner.DateOfBirth;
                DateTime CalcDate = (DateTime)Event.StartDateTime;
                TimeSpan delta = CalcDate - DateBirth;
                if (delta < (CalcDate - new DateTime(CalcDate.Year - 18, CalcDate.Month, CalcDate.Day))) return "до 18";
                if (delta < (CalcDate - new DateTime(CalcDate.Year - 30, CalcDate.Month, CalcDate.Day))) return "18-29";
                if (delta < (CalcDate - new DateTime(CalcDate.Year - 40, CalcDate.Month, CalcDate.Day))) return "30-39";
                if (delta < (CalcDate - new DateTime(CalcDate.Year - 56, CalcDate.Month, CalcDate.Day))) return "40-55";
                if (delta < (CalcDate - new DateTime(CalcDate.Year - 70, CalcDate.Month, CalcDate.Day))) return "56-70";
                else return "более 70";
            }
        }
    }
}
