using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozon.Entities
{
    public partial class Sotrydnik
    {
        public string DoljnostText
        {
            get
            {

                return $"Должность: {Doljnost.Name}";

            }
        }
        public string SalaryText
        {
            get
            {
                return $"Зарплата в час: {Salary_per_hour:N2} рублей";
            }
        }
        public string SotrText
        {
            get
            {
                return $"ФИО: {Familia} {Ima} {Otchestvo}";
            }
        }
    }
}
