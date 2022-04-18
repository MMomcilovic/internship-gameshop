using GameShop.data;
using GameShop.model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddProductForm.xaml
    /// </summary>
    public partial class AddProductForm : Window
    {
        public Data data { get; set; }
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChangedEvent;
        public Product pr;
        public string upc { get; set; } = "";
        public string price { get; set; } = "";
        public AddProductForm(Data d)
        {
            data = d;
            pr = new Product();
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Product pr = new Product();
            pr.name = Name_Text.Text;
            pr.price = Double.Parse(price);
            pr.UPC = Int32.Parse(upc);
            data.products.Add(pr);
            this.Close();
            DataChangedEventHandler handler = DataChangedEvent;
            if (handler!= null)
            {
                handler(this, new EventArgs());
            }
        }

        private void UPC_Text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(upc, out double x) || !Double.TryParse(price, out double y))
            {
                Submit_btn.IsEnabled = false;
                return;
            }
            Submit_btn.IsEnabled = true;
        }

        private void Price_Text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(price, out double x) || !Double.TryParse(upc, out double y))
            {
                Submit_btn.IsEnabled = false;
                return;
            }
            Submit_btn.IsEnabled = true;
        }
    }
}
