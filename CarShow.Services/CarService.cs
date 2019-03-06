using CarShow.Data;
using CarShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShow.Services
{
    public class CarService
    {
        private readonly Guid _userId;

        public CarService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCar(CarCreate model)
        {
            var entity =
                new Car()
                {
                    OwnerId = _userId,
                    Make = model.Make,
                    Model = model.Model,
                    Year = model.Year,
                    Color = model.Color,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.car.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<CarListItem> GetCar()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                 ctx
                     .Cars
                     .Where(e => e.OwnerId == _userId)
                     .Select(
                         e =>
                             new CarListItem
                             {
                                 CarId = e.CarId,
                                 Make = e.Make,
                                 Model = e.Model,
                                 Year = e.Year,
                                 Color = e.Color,
                                 CreatedUtc = DateTimeOffset.Now
                             }
                    );

                return query.ToArry();
            }
        }
    }
}



