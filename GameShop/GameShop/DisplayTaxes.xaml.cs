using GameShop.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GameShop.data;

namespace GameShop
{
    /// <summary>
    /// Interaction logic for DisplayTaxes.xaml
    /// </summary>
    public partial class DisplayTaxes : Window, INotifyPropertyChanged
    {
        public Product product { get; set; }
        public List<string> taxes { get; set; }

        public Data data { get; set; }
        public DisplayTaxes(Product p, Data d)
        {
            product = p;
            data = d;
            taxes = new List<string>();
            taxes.Add(product.FullPriceDisplay(d.GlobalTax, d.GlobalDiscount));
            InitializeComponent();
            TaxList.ItemsSource = taxes;
        }

        public string TaxText
        {
            get { return data.GlobalTax.ToString(); }
            set { data.GlobalTax = Double.Parse(value); }
        }
        public string PriceText
        {
            get { return product.price.ToString(); }
            set { product.price = Double.Parse(value); }
        }
        public string DiscountText
        {
            get { return data.GlobalDiscount.ToString(); }
            set { data.GlobalDiscount = Double.Parse(value); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void AddTax(object sender, RoutedEventArgs e)
        {
            double price = 0, tax = 0, discount = 0;
            if (Double.TryParse(PriceText, out price) || Double.TryParse(TaxText, out tax) || Double.TryParse(DiscountText, out discount))
            {
                if (price < 0 || tax < 0 || discount < 0)
                {
                    return;
                }
                taxes.Add(product.FullPriceDisplay(data.GlobalTax, data.GlobalDiscount));
                TaxList.Items.Refresh();
            }
        }
    }
}
