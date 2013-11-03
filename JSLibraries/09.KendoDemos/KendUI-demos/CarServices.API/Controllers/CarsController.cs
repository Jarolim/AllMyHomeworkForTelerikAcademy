using System;
using System.Collections.Generic;
using System.Linq;
using CarServices.Data;
using CarServices.Model;
using System.Web.Http;

namespace CarServices.API.Controllers
{
    public class CarsController : ApiController
    {
        private CarEntities context;

        public CarsController()
        {
            context = new CarEntities();
        }

        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return this.context.Cars;
        }

        [HttpPost]
        public IEnumerable<Car> Add(Car car)
        {
            this.context.Cars.Add(car);
            this.context.SaveChanges();
            return this.context.Cars;
        }
    }
}