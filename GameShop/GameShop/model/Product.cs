using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.model
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string name { get; set; }
        public int UPC { get; set; }
        public double price { get; set; }
        public double tax { get; set; }
        public double discount { get; set; } = 0;

        public double GetTaxAmount(double GlobalT)
        {
            double localT = price * tax / 100;
            double globalT = price * GlobalT / 100;
            return localT + globalT;
        }
        public double GetDiscountAmount(double GlobalDiscount)
        {
            double disc = GlobalDiscount + discount;
            if (disc > 100) disc = 100;
            return price * disc / 100;

        }
        private object GetFullPrice(double globalD, double GlobalT)
        {
            return price + GetTaxAmount(GlobalT) - GetDiscountAmount(globalD);
        }
        internal string FullPriceDisplay(double GlobalTax, double GlobalDisocunt)
        {
            string s = $"Iznos poreza = {(price * GlobalTax / 100):N2} din ({GlobalTax:N2}%); Ukupan popust = {GetDiscountAmount(GlobalDisocunt):N2} din ({GlobalDisocunt+discount}%)\n";
            if (discount > 0)
            {
                s += $"Proizvod sadrzi selektivni popust ({discount}%)\n";
            }
            s += $"Osnovna cena {price:N2} din, Cena nakon popusta i poreza {GetFullPrice(GlobalDisocunt, GlobalTax):N2} din";
            return s;
        }

    }
}
