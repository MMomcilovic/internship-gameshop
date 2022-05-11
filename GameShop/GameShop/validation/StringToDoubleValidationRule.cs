using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameShop.validation
{
    public class StringToDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var s = value as string;
            double r;
            if(double.TryParse(s, out r))
            {
                if (r < 0)
                {
                    return new ValidationResult(false, "Vrednost mora biti veca od 0!");
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Molim Vas unesite brojnu vrednost.");
        }
    }

    public class MinMaxValidationRule : ValidationRule
    {
        public double Min { get; set; } 
        public double Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var s = value as string;
            double d;
            if (double.TryParse(s, out d))
            {
                if (d < Min) return new ValidationResult(false, $"Broj mora biti veci od {Min}.");
                if (d > Max) return new ValidationResult(false, $"Broj mora biti manji od {Max}.");
                return new ValidationResult(true, null);
            } 
            else
            {
                return new ValidationResult(false,"Molim Vas unesite brojnu vrednost!");
            }
        }
    }
}