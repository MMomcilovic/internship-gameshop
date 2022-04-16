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

        public double GetPriceWithTax(double tax = 20)
        {
            if (tax < 0 || tax > 100)
            {
                return price * 1.2;
            }
            return price * (1+tax/100);
        }

        internal string TaxDispaly(double tax)
        {
            return $"Cena {price:N2} din pre poreza i {GetPriceWithTax(tax):N2} din nakon {tax}% poreza.";
        }
    }
}
