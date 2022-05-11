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
        public double discount { get; set; } = 0;
        public bool CalculateBeforeTax { get; set; } = false;
        public double CalculatedPrice { get; set; }
        public double FullDiscont { get; set; } = 0;
        public double GetTaxAmount(double GlobalT)
        {
            double globalT = CalculatedPrice * GlobalT / 100;
            return globalT;
        }
        public double GetSelectiveDiscountAmount()
        {
            return CalculatedPrice * discount / 100;
        }
        public double GetGlobalDiscountAmount(double GlobalD)
        {
            return CalculatedPrice * GlobalD / 100;
        }
        private double GetFullPrice(double GlobalD, double GlobalT, bool GlobalCBT)
        {
            CalculatedPrice = price;
            FullDiscont = 0;
            double tax;
            double disc= 0;
            double fullPrice;
            if (CalculateBeforeTax || GlobalCBT)
            {
                if (CalculateBeforeTax)
                {
                    disc += GetSelectiveDiscountAmount();
                    CalculatedPrice -= disc;
                    FullDiscont += disc;
                }
                if (GlobalCBT)
                {
                    disc = GetGlobalDiscountAmount(GlobalD);
                    CalculatedPrice -= disc;
                    FullDiscont += disc;
                }
                tax = GetTaxAmount(GlobalT);
                if (!CalculateBeforeTax)
                {
                    FullDiscont += GetSelectiveDiscountAmount();
                }
                if (!GlobalCBT)
                {
                    FullDiscont += GetGlobalDiscountAmount(GlobalD);
                }
                fullPrice = price - FullDiscont + tax;
            } else
            {
                FullDiscont = GetSelectiveDiscountAmount() + GetGlobalDiscountAmount(GlobalD);
                fullPrice = price - FullDiscont + GetTaxAmount(GlobalT);
            }
            if (fullPrice < 0)
            {
                return 0;
            }
            return fullPrice;
        }
        internal string FullPriceDisplay(double GlobalTax, double GlobalDisocunt, bool GlobalCalculateBeforeTax)
        {
            string s = $"Iznos poreza = {GlobalTax:N2}%;\n";
            if ((discount + GlobalDisocunt) > 0)
            {
                if (discount > 0)
                {
                    s += $"Selektvni popust";
                    s += CalculateBeforeTax ? "(pre poreza)" : "(posle poreza)";
                    s += $" = { discount}%; ";
                }
                if (GlobalDisocunt > 0)
                {
                    s += $"Globalni popust";
                    s += GlobalCalculateBeforeTax ? "(pre poreza)" : "(posle poreza)";
                    s += $" = { GlobalDisocunt}%";
                }
            } else
            {
                s += "Nema popusta.";
            }
            s += $"\nOsnovna cena {price:N2} din, Cena nakon popusta i poreza {GetFullPrice(GlobalDisocunt, GlobalTax, GlobalCalculateBeforeTax):N2} din\nOdbijeno {FullDiscont:N2} din";
            return s;
        }

    }
}
