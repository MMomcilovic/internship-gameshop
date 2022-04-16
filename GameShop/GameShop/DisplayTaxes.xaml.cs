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
        public double tax { get; set; } = 20;
        public List<string> taxes { get; set; }
        public DisplayTaxes(Product p)
        {
            product = p;
            taxes = new List<string>();
            taxes.Add(product.TaxDispaly(tax));
            InitializeComponent();
            TaxList.ItemsSource = taxes;
        }

        public string Text
        {
            get { return tax.ToString(); }
            set { tax = Double.Parse(value); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void AddTax(object sender, RoutedEventArgs e)
        {
            taxes.Add(product.TaxDispaly(Double.Parse(Text)));
            TaxList.Items.Refresh();
        }
    }
}
