// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Net.Http.Headers;

namespace ConsoleUI // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetCarsByBrandId();
            //GetAllCars();
            //AddCar();
            //GetAllBrands();
            //GetBrandById();
            //GetAllColors();
            //GetColor();
            //CarDetails();
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void GetColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(colorManager.GetById(1).ColorName);
        }

        private static void GetAllColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void GetBrandById()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandManager.GetById(1).BrandName);
        }

        private static void GetAllBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void GetCarsByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void GetAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car() { BrandId = 1, CarId = 5, CarName = "A", ColorId = 1, DailyPrice = 5, Description_ = "Deneme", ModelYear = 1998 });
        }
    }
}
