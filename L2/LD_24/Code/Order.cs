using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_24.Code
{
    /// <summary>
    /// Class used for storing a single order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Surname of customer who ordered
        /// </summary>
        public string CustomerSurname { get; set; }
        /// <summary>
        /// Name of customer who ordered
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// ID of ordered product
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// Amount of ordered products
        /// </summary>
        public int ProductAmount { get; set; }

        public Order(string customerSurname, string customerName, string productID, int productAmount)
        {
            CustomerSurname = customerSurname;
            CustomerName = customerName;
            ProductID = productID;
            ProductAmount = productAmount;
        }

        public override string ToString()
        {
            return String.Format("Order{Name = '{0}'}", CustomerName);
        }

        public static bool operator <(Order a, Order b)
        {
            if (a.ProductAmount > b.ProductAmount)
            {
                return true;
            }
            else if (a.ProductAmount == b.ProductAmount)
            {
                int surnameCompare = a.CustomerSurname.CompareTo(b.CustomerSurname);
                if (surnameCompare < 0)
                {
                    return true;
                }
                else if (surnameCompare == 0)
                {
                    return a.CustomerName.CompareTo(b.CustomerName) < 0;
                }
            }

            return false;
        }
        public static bool operator >(Order a, Order b)
        {
            return !(a < b && a == b);
        }
        public static bool operator ==(Order a, Order b)
        {
            return a.ProductAmount == b.ProductAmount && a.CustomerName == b.CustomerName && a.CustomerSurname == b.CustomerSurname;
        }
        public static bool operator !=(Order a, Order b)
        {
            return !(a == b);
        }
    }
}