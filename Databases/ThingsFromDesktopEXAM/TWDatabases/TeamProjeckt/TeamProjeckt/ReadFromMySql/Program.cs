using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;

namespace ReadFromMySql
{
    class Program
    {
        static void Main()
        {
            SupermarketEntitiesModel super = new SupermarketEntitiesModel();

            foreach (var item in super.Products)
            {
                Console.WriteLine(item.Product_Name);
            }
        }
    }
}
