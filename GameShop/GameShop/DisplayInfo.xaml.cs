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
        public bool _textChanged = false;
        public DisplayTaxes(Product p, Data d)
        {
            product = p;
            data = d;
            taxes = new List<string>();
            taxes.Add(product.FullPriceDisplay(d.GlobalTax, d.GlobalDiscount, d.GlobalCalculateBeforeTax));
            InitializeComponent();
            TaxList.ItemsSource = taxes;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void CBT_Toggle(object sender, RoutedEventArgs e)
        {
            taxes.Add(product.FullPriceDisplay(data.GlobalTax, data.GlobalDiscount, data.GlobalCalculateBeforeTax));
            TaxList.Items.Refresh();
        }

        private void Fetch(object sender, RoutedEventArgs e)
        {
            taxes.Add(product.FullPriceDisplay(data.GlobalTax, data.GlobalDiscount, data.GlobalCalculateBeforeTax));
            TaxList.Items.Refresh();
        }

        private void discountText_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            double p;
            if (!Double.TryParse(tb.Text, out p))
            {
                tb.Text = data.GlobalDiscount.ToString();
            } else
            {
                if (p < 0)
                {
                    data.GlobalDiscount = 0;
                }
                else if (p > 100)
                {
                    data.GlobalDiscount = 100;
                }
            }
            
        }

        private void priceText_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!Double.TryParse(tb.Text, out double p))
            {
                tb.Text = data.GlobalTax.ToString();
            }
        }
    }
}
