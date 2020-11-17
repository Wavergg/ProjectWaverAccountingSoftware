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

namespace WaverAccountingSoftware.Views.Invoice
{
    /// <summary>
    /// Interaction logic for InvoiceDetailsWindow.xaml
    /// </summary>
    public partial class InvoiceDetailsWindow : Window
    {
        List<ItemDetailsTemplate> _itemDetailsTemplates = new List<ItemDetailsTemplate>();

        int _windowStateSwitch = 0;

        public InvoiceDetailsWindow(InvoiceTemplate invoice)
        {
            InitializeComponent();

            this.DataContext = invoice;

            InitItemDetails(invoice.InvoiceID);
        }

        private void InitItemDetailsGridWidth()
        {
            
        }

        private void InitItemDetails(string invoiceID)
        {
            _itemDetailsTemplates.Clear();
            //CallDatabase based on invoice ID return InvoiceDetails

            //Get Item from InvoiceDetails.ItemID

            //Construct item Template
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("1","Kappa Lace","50 Cole x50 Lsn","50000","50","2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("2", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("3", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("4", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("1", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("2", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("3", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("4", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("1", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("2", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("3", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("4", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("1", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("2", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("3", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));
            _itemDetailsTemplates.Add(new ItemDetailsTemplate("4", "Kappa Lace", "50 Cole x50 Lsn", "50000", "50", "2500000"));

            //Assign To List View
            _ListViewItemDetails.ItemsSource = _itemDetailsTemplates;
        }


        private void _ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem selectedViewItem = sender as ListViewItem;
            ItemDetailsTemplate itemDetails = selectedViewItem.DataContext as ItemDetailsTemplate;
            MessageBox.Show(itemDetails.ItemName);
        }

        private void _LabelCustomerName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            InvoiceTemplate invoice = label.DataContext as InvoiceTemplate;
            MessageBox.Show($"{invoice.CustomerName}: {invoice.CustomerID}");
        }

        private void _ListViewItemDetails_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var workingWidth = _ListViewItemDetails.ActualWidth - 60;
            var itemCodeCol = 0.16;
            var itemNameCol = 0.18;
            var itemDescCol = 0.2;
            var unitPriceCol = 0.16;
            var quantityCol = 0.15;
            var lineTotalCol = 0.15;

            _GridViewItemDetails.Columns[0].Width = workingWidth * itemCodeCol;
            _GridViewItemDetails.Columns[1].Width = workingWidth * itemNameCol;
            _GridViewItemDetails.Columns[2].Width = workingWidth * itemDescCol;
            _GridViewItemDetails.Columns[3].Width = workingWidth * unitPriceCol;
            _GridViewItemDetails.Columns[4].Width = workingWidth * quantityCol;
            _GridViewItemDetails.Columns[5].Width = workingWidth * lineTotalCol;
        }

        private void _ButtonRestore_Click(object sender, RoutedEventArgs e)
        {
            _windowStateSwitch++;

            switch (_windowStateSwitch % 2)
            {
                case 0:
                    this.WindowState = WindowState.Normal;
                    break;
                case 1:
                    this.WindowState = WindowState.Maximized;
                    break;
            }
        }
    }

    public class ItemDetailsTemplate
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string InvoiceLineDescription { get; set; }
        public string ItemPrice { get; set; }
        public string ItemQuantity { get; set; }
        public string Total { get; set; }

        public ItemDetailsTemplate(string itemID, string itemName, string invoiceLineDescription, string itemPrice, string itemQuantity, string total)
        {
            this.ItemID = itemID;
            this.ItemName = itemName;
            this.InvoiceLineDescription = invoiceLineDescription;
            this.ItemPrice = itemPrice;
            this.ItemQuantity = itemQuantity;
            this.Total = total;
        }
    }
}
