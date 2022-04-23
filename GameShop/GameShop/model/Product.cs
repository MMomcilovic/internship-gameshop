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
        public double tax { get; set; } = 20;
        public double discount { get; set; } = 0;

        public double GetTaxAmount()
        {
            return price * tax / 100;
        }
        public double GetDiscountAmount()
        {
            return price * discount / 100;

        }
        private object GetFullPrice()
        {
            return price + GetTaxAmount() - GetDiscountAmount();
        }
        internal string FullPriceDisplay()
        {
            return $"Iznos poreza = {GetTaxAmount():N2} din ({tax:N2}%); Iznos popusta = {GetDiscountAmount():N2} din ({discount}%)\nOsnova cena {price:N2} din, Cena nakon popusta i poreza {GetFullPrice():N2} din";
        }

    }
}
