using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LD_24.Code;

namespace LD_24
{
    public partial class Forma1 : System.Web.UI.Page
    {
        /// <summary>
        /// Show a list in a table
        /// </summary>
        /// <param name="table">Target table</param>
        /// <param name="list">Target list</param>
        /// <param name="columns">Columns names</param>
        /// <returns></returns>
        private IEnumerable<Tuple<object, TableRow>> ShowTable(Table table, IEnumerable list, params string[] columns)
        {
            TableRow header = new TableRow();
            foreach (string column in columns)
            {
                header.Cells.Add(new TableCell { Text = column });
            }
            table.Rows.Add(header);

            int n = 0;
            foreach (object item in list)
            {
                TableRow row = new TableRow();
                yield return Tuple.Create(item, row);
                table.Rows.Add(row);
                n++;
            }

            if (n == 0)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = "Nėra", ColumnSpan = columns.Length });
                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Show a list of products in a table
        /// </summary>
        /// <param name="table">Target table</param>
        /// <param name="products">Target products</param>
        public void ShowProducts(Table table, ProductList products)
        {
            foreach (var tuple in ShowTable(table, products, "ID", "Vardas", "Kaina, eur."))
            {
                Product product = (Product)tuple.Item1;
                TableRow row = tuple.Item2;
                row.Cells.Add(new TableCell { Text = product.ID });
                row.Cells.Add(new TableCell { Text = product.Name });
                row.Cells.Add(new TableCell { Text = product.Price.ToString() });
            }
        }

        /// <summary>
        /// Show a list of orders in a table
        /// </summary>
        /// <param name="table">Target table</param>
        /// <param name="orders">Target orders</param>
        public void ShowOrders(Table table, OrderList orders)
        {
            foreach (var tuple in ShowTable(table, orders, "Pavardė", "Vardas", "Įtaisas", "Įtaisų kiekis, vnt."))
            {
                Order order = (Order)tuple.Item1;
                TableRow row = tuple.Item2;
                row.Cells.Add(new TableCell { Text = order.CustomerSurname });
                row.Cells.Add(new TableCell { Text = order.CustomerName });
                row.Cells.Add(new TableCell { Text = order.ProductID.ToString() });
                row.Cells.Add(new TableCell { Text = order.ProductAmount.ToString() });
            }
        }

        /// <summary>
        /// Show the most popular products in a table
        /// </summary>
        /// <param name="table">Target table</param>
        /// <param name="orders">Target orders</param>
        /// <param name="popularProducts">List of most popular products</param>
        public void ShowMostPopularProducts(Table table, OrderList orders, ProductList popularProducts)
        {
            foreach (var tuple in ShowTable(table, popularProducts, "ID", "Vardas", "Įtaisų kiekis, vnt.", "Įtaisų kaina, eur."))
            {
                Product product = (Product)tuple.Item1;
                TableRow row = tuple.Item2;
                int sales = TaskUtils.CountProductSales(orders, product.ID);
                row.Cells.Add(new TableCell { Text = product.ID });
                row.Cells.Add(new TableCell { Text = product.Name });
                row.Cells.Add(new TableCell { Text = sales.ToString() });
                row.Cells.Add(new TableCell { Text = String.Format("{0:f2}", sales * product.Price) });
            }
        }

        /// <summary>
        /// Show a list of orders with their prices in a table
        /// </summary>
        /// <param name="table">Target table</param>
        /// <param name="orders">Target orders</param>
        /// <param name="products">List of products</param>
        public void ShowOrdersWithPrices(Table table, OrderList orders, ProductList products)
        {
            foreach (var tuple in ShowTable(table, orders, "Pavardė", "Vardas", "Įtaisų kiekis, vnt.", "Sumokėta, eur."))
            {
                Order order = (Order)tuple.Item1;
                TableRow row = tuple.Item2;
                Product product = TaskUtils.FindByID(products, order.ProductID);

                row.Cells.Add(new TableCell { Text = order.CustomerSurname });
                row.Cells.Add(new TableCell { Text = order.CustomerName });
                row.Cells.Add(new TableCell { Text = order.ProductAmount.ToString() });
                row.Cells.Add(new TableCell { Text = String.Format("{0:f2}", order.ProductAmount * product.Price, 2) });
            }
        }
    }
}