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

namespace GameShop
{
    /// <summary>
    /// Interaction logic for DisplayTaxes.xaml
    /// </summary>
    public partial class DisplayTaxes : Window, INotifyPropertyChanged
    {
        public Product product { get; set; }
        public List<string> taxes { get; set; }
        public DisplayTaxes(Product p)
        {
            product = p;
            taxes = new List<string>();
            taxes.Add(product.FullPriceDisplay());
            InitializeComponent();
            TaxList.ItemsSource = taxes;
        }

        public string TaxText
        {
            get { return product.tax.ToString(); }
            set { product.tax = Double.Parse(value); }
        }
        public string PriceText
        {
            get { return product.price.ToString(); }
            set { product.price = Double.Parse(value); }
        }
        public string SaleText
        {
            get { return product.sale.ToString(); }
            set { product.sale = Double.Parse(value); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void AddTax(object sender, RoutedEventArgs e)
        {
            double price = 0, tax = 0, sale = 0;
            if (Double.TryParse(PriceText, out price) || Double.TryParse(TaxText, out tax) || Double.TryParse(SaleText, out sale))
            {
                if (price < 0 || tax < 0 || sale < 0)
                {
                    return;
                }
                taxes.Add(product.FullPriceDisplay());
                TaxList.Items.Refresh();
            }
        }
    }
}
