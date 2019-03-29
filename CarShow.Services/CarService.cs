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
                ctx.Cars.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<CarListItem> GetCars()

        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                 ctx
                     .Cars
                     //.Where(e => e.OwnerId == _userId)
                     .Select(
                     e =>
                     new CarListItem
                     {
                         CarId = e.CarId,
                         Make = e.Make,
                         Model = e.Model,
                         Year = e.Year,
                         Color = e.Color,
                         CreatedUtc = DateTimeOffset.Now,
                     }
                    );

                return query.ToArray();
            }
        }
        public CarDetail GetCarById(int carId)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =


                        ctx.Cars.Single(e => e.CarId == carId);
                return
                    new CarDetail
                    {
                        CarId = entity.CarId,
                        Make = entity.Make,
                        Model = entity.Model,
                        Year = entity.Year,
                        Color = entity.Color,
                        CreatedUtc = DateTimeOffset.Now
                    };
            }
        }
        public bool UpdateCar(CarEdit model)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cars
                    .Single(e => e.OwnerId == _userId);

                entity.CarId = model.CarId;
                entity.Make = model.Make;
                entity.Model = model.Model;
                entity.Year = model.Year;
                entity.Color = model.Color;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCar(int carId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cars
                        .Single(e => e.CarId == carId);

                ctx.Cars.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}






