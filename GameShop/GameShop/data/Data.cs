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
        public List<Product> products { get; set; }

        public Data()
        {
            products = new List<Product>(); 
        }
    }
}
