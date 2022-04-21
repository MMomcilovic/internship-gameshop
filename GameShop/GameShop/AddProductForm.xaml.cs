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
        public AddProductForm(Data d)
        {
            data = d;
            pr = new Product();
            InitializeComponent();
        }
        public string UPCText
        {
            get { return pr.UPC.ToString(); }
            set { pr.UPC = Int32.Parse(value); }
        }
        public string PriceText
        {
            get { return pr.price.ToString(); }
            set { pr.price = Double.Parse(value); }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (pr.price < 0 || pr.UPC < 0 || Name_Text.Text.Length < 3)
            {
                return;
            }
            Product x = new Product();
            x.price = pr.price;
            x.name = Name_Text.Text;
            x.UPC = pr.UPC;
            if (data.ProductWithUPC(x.UPC) != null)
            {
                MessageBox.Show("Product with this UPC exists!");
            }
            else
            {
                data.products.Add(x);
                DataChangedEventHandler handler = DataChangedEvent;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
        }

        private void UPC_Text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(UPC_Text.Text, out double x) || !Double.TryParse(Price_Text.Text, out double y))
            {
                Submit_btn.IsEnabled = false;
                return;
            }
            Submit_btn.IsEnabled = true;
        }

        private void Price_Text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(UPC_Text.Text, out double x) || !Double.TryParse(Price_Text.Text, out double y))
            {
                Submit_btn.IsEnabled = false;
                return;
            }
            Submit_btn.IsEnabled = true;
        }
    }
}
