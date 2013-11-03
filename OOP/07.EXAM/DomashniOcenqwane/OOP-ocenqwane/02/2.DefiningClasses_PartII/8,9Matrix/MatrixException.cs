using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixException:ArgumentException

    {
        public MatrixException()
            :base()
        {
        }

        public MatrixException(string message)
            : base(message)
        {            
        }

        public MatrixException(string message,Exception innerException)
            :base(message,innerException)
        {

        }

        
    }
}
