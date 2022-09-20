using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId= 1, BrandId = 1, ColorId = 1, ModelYear = 1998, DailyPrice = 50000, Description_ = "Car1"},
                new Car {CarId= 2, BrandId = 2, ColorId = 2, ModelYear = 2001, DailyPrice = 75000, Description_ = "Car2"},
                new Car {CarId= 3, BrandId = 2, ColorId = 1, ModelYear = 2010, DailyPrice = 170000, Description_ = "Car3"},
                new Car {CarId= 4, BrandId = 3, ColorId = 3, ModelYear = 2007, DailyPrice = 120000, Description_ = "Car4"},
                new Car {CarId= 5, BrandId = 4, ColorId = 5, ModelYear = 2015, DailyPrice = 250000, Description_ = "Car5"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>>? filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description_ = car.Description_;

        }
    }
}
