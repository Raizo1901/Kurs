using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class WSUniverasl
    {
        public static decimal SalaryTime(decimal Salary_hours, int hours)
        {
            if (hours <= 8)
                return Salary_hours * hours;
            else if (hours > 8 && hours <= 12)
                return Salary_hours * hours + (Salary_hours * hours / 100 * 10);
            else
                return Salary_hours * hours + (Salary_hours * hours / 100 * 25);
        }
    }
}
