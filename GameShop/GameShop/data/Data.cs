using GameShop.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.data
{
    public class Data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Product> products { get; set; } = new List<Product>();
        public double GlobalTax { get; set; } = 20;
        public double GlobalDiscount { get; set; } = 0;
        internal Product ProductWithUPC(int UPC)
        {
            foreach(Product p in products)
            {
                if (p.UPC == UPC)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
