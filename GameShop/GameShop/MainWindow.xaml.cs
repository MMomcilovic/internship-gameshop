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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Data data { get; set; }
        public MainWindow()
        {
            data = new Data();
            data.products.Add(new Product() { name= "LEGO blokovi = “Friends Forest House”", price=20.25, UPC=41679, discount=7});
            data.products.Add(new Product() { name= "Ricky Zoom SUPER LOOP", price=1299.00, UPC=200633, discount=32});
            data.products.Add(new Product() { name= "LEGO Classic Basic BRICK SET", price=2899.00, UPC=11002, discount=0});
            data.products.Add(new Product() { name= "LEGO Classic Around The WORLD", price=6999.00, UPC=11015, discount=19});
            InitializeComponent();
            this.DataContext = this;
        }

        private void AddItme_Click(object sender, RoutedEventArgs e)
        {
            AddProductForm apf = new AddProductForm(data);
            apf.DataChangedEvent += ProductListUpdate_DataChanged;
            apf.Show();
        }

        private void ResetItems_Click(object sender, RoutedEventArgs e)
        {
            data.products.Clear();
            ProductsList.Items.Refresh();
        }

        private void ProductListUpdate_DataChanged(object sender, EventArgs e)
        {
            ProductsList.Items.Refresh();
        }

        private void TaxesDialog(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as Product;
            if (item != null)
            {
                DisplayTaxes dt = new DisplayTaxes(item, data);
                dt.Show();
            }
        }
    }
}
