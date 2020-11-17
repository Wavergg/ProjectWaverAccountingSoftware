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

namespace WaverAccountingSoftware.Views.Invoice
{
    /// <summary>
    /// Interaction logic for InvoiceContent.xaml
    /// </summary>
    public partial class InvoiceContent : UserControl
    {
        List<InvoiceTemplate> _invoiceTemplates = new List<InvoiceTemplate>();

        public InvoiceContent()
        {
            InitializeComponent();
            InitListView();
        }

        private void InitListView()
        {
            _invoiceTemplates.Add(new InvoiceTemplate("1", "11 nov 2020","3", "William", "Sanggau", "jln 301 sepakat1 no 5", "08565038111", "5000"));
            _invoiceTemplates.Add(new InvoiceTemplate("2", "13 nov 2020","3", "Kappa", "Pontianak", "jln 301 sepakat1 no 5", "08565038111", "51000"));
            _invoiceTemplates.Add(new InvoiceTemplate("3", "15 nov 2020","3", "Ryan", "Sungai batang", "jln 301 sepakat1 no 5", "08565038111", "2002"));
            _invoiceTemplates.Add(new InvoiceTemplate("4", "11 nov 2020","3", "William", "Sanggau", "jln 301 sepakat1 no 5", "08565038111", "5000"));
            _invoiceTemplates.Add(new InvoiceTemplate("5", "13 nov 2020","3", "Kappa", "Sanggau", "jln 301 sepakat1 no 5", "08565038111", "51000"));
            _invoiceTemplates.Add(new InvoiceTemplate("3", "15 nov 2020","3", "Ryan", "Sanggau", "jln 301 sepakat1 no 5", "08565038111", "2002"));
            _invoiceTemplates.Add(new InvoiceTemplate("7", "11 nov 2020","3", "William", "Sanggau", "jln 301 sepakat1 no 5", "08565038111", "5000"));
            _invoiceTemplates.Add(new InvoiceTemplate("8", "13 nov 2020","3", "Kappa", "Sanggau", "jln 301 sepakat1 no 5", "08565038111", "51000"));
            _invoiceTemplates.Add(new InvoiceTemplate("9", "15 nov 2020","3", "Ryan", "Sanggau", "jln 301 sepakat1 no 5", "08565038111", "2002"));
            _invoiceTemplates.Add(new InvoiceTemplate("10", "11 nov 2020","3", "William", "Sanggau", "jln 301 sepakat1 no 5", "08565038111", "5000"));
            //_invoiceTemplates.Add(new InvoiceTemplate("11", "13 nov 2020", "Kappa", "51000"));
            //_invoiceTemplates.Add(new InvoiceTemplate("12", "15 nov 2020", "Ryan", "2002"));
            //_invoiceTemplates.Add(new InvoiceTemplate("13", "11 nov 2020", "William", "5000"));
            //_invoiceTemplates.Add(new InvoiceTemplate("14", "13 nov 2020", "Kappa", "51000"));
            //_invoiceTemplates.Add(new InvoiceTemplate("15", "15 nov 2020", "Ryan", "2002"));
            _ListViewInvoice.ItemsSource = _invoiceTemplates;
        }

        private void _ListViewInvoice_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var workingWidth = _ListViewInvoice.ActualWidth -50;
            var idCol = 0.1;
            var dateCol = 0.15;
            var nameCol = 0.175;
            var cityCol = 0.15;
            var addCol = 0.2;
            var phCol = 0.1;
            var totCol = 0.1;

            _GridViewInvoice.Columns[0].Width = workingWidth * idCol;
            _GridViewInvoice.Columns[1].Width = workingWidth * dateCol;
            _GridViewInvoice.Columns[2].Width = workingWidth * nameCol;
            _GridViewInvoice.Columns[3].Width = workingWidth * cityCol;
            _GridViewInvoice.Columns[4].Width = workingWidth * addCol;
            _GridViewInvoice.Columns[5].Width = workingWidth * phCol;
            _GridViewInvoice.Columns[6].Width = workingWidth * totCol;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem selectedViewItem = sender as ListViewItem;
            InvoiceTemplate invoice = selectedViewItem.DataContext as InvoiceTemplate;
            //MessageBox.Show(temp.CustomerName);

            InvoiceDetailsWindow invoiceDetailsWindow = new InvoiceDetailsWindow(invoice);
            invoiceDetailsWindow.Show();
        }
    }

    public class InvoiceTemplate
    {
        public string InvoiceID { get; set; }

        public string InvoiceDate { get; set; }

        public string CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerCity { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhone { get; set; }

        public string InvoiceTotal { get; set; }

        public InvoiceTemplate(string invoiceID, string invoiceDate,string customerID, string customerName, string customerCity, string customerAddress, string customerPhone , string invoiceTotal)
        {
            this.InvoiceID = invoiceID;
            this.InvoiceDate = invoiceDate;
            this.CustomerID = customerID;
            this.CustomerName = customerName;
            this.CustomerCity = customerCity;
            this.CustomerAddress = customerAddress;
            this.CustomerPhone = customerPhone;
            this.InvoiceTotal = invoiceTotal;
        }
    }
}
