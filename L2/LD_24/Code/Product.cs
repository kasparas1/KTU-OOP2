using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_24.Code
{
    /// <summary>
    /// Holds informations about a single product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identification number of product
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Name of product
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Price of product
        /// </summary>
        public decimal Price { get; set; }

        public Product(string iD, string name, decimal price)
        {
            ID = iD;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return String.Format("Product{ID = '{0}'}", ID);
        }
    }
}
