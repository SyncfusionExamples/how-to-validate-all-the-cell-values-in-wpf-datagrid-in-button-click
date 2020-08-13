using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace SfDataGridDemo
{
    public class ViewModel
    {
        private ObservableCollection<OrderInfo> _orders;
        public ObservableCollection<OrderInfo> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public ViewModel()
        {
            _orders = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
            rowDataCommand = new RelayCommand(ChangeCanExecute);
        }

        private ICommand rowDataCommand { get; set; }
        public ICommand RowDataCommand
        {
            get
            {
                return rowDataCommand;
            }
            set
            {
                rowDataCommand = value;
            }
        }

        public void ChangeCanExecute(object obj)
        {
            var datagrid = (obj as SfDataGrid);
            //Here customize condition based cell validation 
            foreach (var record in datagrid.View.Records)
            {
                if ((record.Data as OrderInfo).UnitPrice == 0)
                {
                    MessageBox.Show("Invalid value in OrderID: " + (record.Data as OrderInfo).OrderID);

                    Setter setter = new Setter();
                    setter.Property = GridCell.BackgroundProperty;
                    setter.Value = Brushes.Red;
                    var style = new Style(typeof(GridCell));

                    DataTrigger dataTrigger = new DataTrigger();
                    dataTrigger.Binding = new Binding("UnitPrice");
                    dataTrigger.Value = (double?)000;
                    dataTrigger.Setters.Add(setter);

                    style.Triggers.Add(dataTrigger);
                    datagrid.Columns["UnitPrice"].CellStyle = style;
                }
            }
        }

        private void GenerateOrders()
        {
            _orders.Add(new OrderInfo() { OrderID = 1001, CustomerName = "Maria Anders", Country="Germany", CustomerID = "ALFKI", UnitPrice = 000 });
            _orders.Add(new OrderInfo() { OrderID = 1002, CustomerName = "Ana Trujilo", Country = "Mexico", CustomerID = "ANATR", UnitPrice = 36000 });
            _orders.Add(new OrderInfo() { OrderID = 1003, CustomerName = "Antonio Moreno", Country = "Mexico", CustomerID = "ANTON", UnitPrice = 40040 });
            _orders.Add(new OrderInfo() { OrderID = 1004, CustomerName = "Thomas Hardy", Country = "UK", CustomerID = "AROUT", UnitPrice=10700});
            _orders.Add(new OrderInfo() { OrderID = 1005, CustomerName="Christina Berglund", Country = "Sweden", CustomerID = "BERGS", UnitPrice=20300 });
            _orders.Add(new OrderInfo() { OrderID = 1006, CustomerName = "Hanna Moos", Country = "Germany", CustomerID = "BLAUS", UnitPrice = 000 });
            _orders.Add(new OrderInfo() { OrderID = 1007, CustomerName = "Frederique Citeaux", Country = "France", CustomerID = "BLONP", UnitPrice = 10700 });
            _orders.Add(new OrderInfo() { OrderID = 1008, CustomerName = "Martin Sommer", Country = "Spain", CustomerID = "BOLID", UnitPrice = 000 });
            _orders.Add(new OrderInfo() { OrderID = 1009, CustomerName = "Laurence Lebihan", Country = "France", CustomerID = "BONAP", UnitPrice = 20030 });
            _orders.Add(new OrderInfo() { OrderID = 1010, CustomerName = "Elizabeth Lincoln", Country = "Canada", CustomerID = "BOTTM", UnitPrice = 54000 });

        }
    }
}
            
        
     

