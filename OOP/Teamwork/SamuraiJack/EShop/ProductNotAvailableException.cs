using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop
{
    public class ProductNotAvailableException : ApplicationException
    {
        private Product product;

        public Product Product
        {
            get { return this.product; }
            set { this.product = value; }
        }

        public ProductNotAvailableException(string msg, Product product, Exception innerEx)
            : base(msg, innerEx)
        {
            this.Product = product;
        }

        public ProductNotAvailableException(string msg, Product product)
            : this(msg, product, null)
        {
        }

        public override string Message
        {
            get
            {
                return string.Format("Message: {0} (Product:{1}, Quantity:{2})",
                    base.Message, this.Product.Name, this.Product.Quantity);
            }
        }
    }
}