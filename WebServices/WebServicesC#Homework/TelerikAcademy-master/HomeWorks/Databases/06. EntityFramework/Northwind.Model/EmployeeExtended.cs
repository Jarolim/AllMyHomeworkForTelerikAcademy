using System;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Northwind.Model
{
    public partial class Employee
    {
        private EntitySet<Territory> territoriesSet = new EntitySet<Territory>();

        public EntitySet<Territory> TerritoriesSet
        {
            get
            {
                this.territoriesSet.AddRange(this.Territories);

                return this.territoriesSet;
            }
        }
    }
}
