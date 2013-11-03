namespace CarServices.Data
{
    using CarServices.Model;
    using System.Data.Entity;

    public class CarEntities : DbContext
    {
        public CarEntities()
            : base("CarsDb")
        {
        }

        public DbSet<Car> Cars { get; set; } 
    }
}
