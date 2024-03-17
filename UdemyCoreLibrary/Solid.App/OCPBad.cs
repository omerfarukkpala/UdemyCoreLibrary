using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.OCP.Bad
{
    public class SalaryCalculator // Yeni tipler gelince yeni caseler yazılmak zorunda kalacağı için Open-Close prensibine aykırı oluyor.
    {
        public decimal Calculate(decimal salary, SalaryType salaryType)
        {
            decimal newSalary = 0;

            switch (salaryType)
            {
                case SalaryType.Low:
                    newSalary = salary * 2;
                    break;

                case SalaryType.Medium:
                    newSalary = salary * 4;
                    break;

                case SalaryType.High:
                    newSalary = salary * 6;
                    break;

                default:
                    break;
            }

            return newSalary;

        }
    }

    public enum SalaryType
    {
        Low,
        Medium,
        High,
        Super // Sıkıntı burda
    }
}
