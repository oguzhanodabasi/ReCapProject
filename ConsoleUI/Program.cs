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
            RentalManager rentalsManager = new RentalManager(new EfRentalDal());
            //RentalAdd(rentalsManager);
            //RentalUpdate(rentalsManager);
            //RentalDelete(rentalsManager);
            RentalGetAll(rentalsManager);

            Line();

            CustomerManager customersManager = new CustomerManager(new EfCustomerDal());
            /*CustomerAdd(customersManager);
            CustomerUpdate(customersManager);
            CustomerDelete(customersManager);
            CustomerGetAll(customersManager);*/

            Line();

            UserManager usersManager = new UserManager(new EfUserDal());
            /*UserAdd(usersManager);
            UserUpdate(usersManager);
            UserDelete(usersManager);
            UserGetAll(usersManager);*/

            Line();


            CarManager carsManager = new CarManager(new EfCarDal());
            /*CarAdd(carsManager);
            CarUpdate(carsManager);
            CarDelete(carsManager);
            CarDtoList(carsManager);*/

            Line();

            BrandManager brandsManager = new BrandManager(new EfBrandDal());
            /*BrandAdd(brandsManager);
            BrandUpdate(brandsManager);
            BrandDelete(brandsManager);
            BrandGetAll(brandsManager);*/

            Line();

            ColorManager colorsManager = new ColorManager(new EfColorDal());
            /*ColorAdd(colorsManager);
            ColorUpdate(colorsManager);
            ColorDelete(colorsManager);
            ColorGetAll(colorsManager);*/


        }
        #region Rentals

        private static void RentalDelete(RentalManager rentalsManager)
        {
            rentalsManager.Delete(new Rental { RentalId = 3 });
        }

        private static void RentalUpdate(RentalManager rentalsManager)
        {
            rentalsManager.Update(new Rental
            {
                RentalId = 2,
                CarId = 2,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now
            });
        }

        private static void RentalAdd(RentalManager rentalsManager)
        {
            rentalsManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now
            });
        }

        private static void RentalGetAll(RentalManager rentalsManager)
        {
            var result = rentalsManager.GetAll();

            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("{0} {1} {2} {3}", rental.CustomerId, rental.CarId, rental.RentDate, rental.ReturnDate);
                }
            }

            Console.WriteLine(result.Message);
        }
        #endregion
        #region Customers
        private static void CustomerGetAll(CustomerManager customersManager)
        {
            var result = customersManager.GetAll();

            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("{0} {1} {2}", customer.CustomerId, customer.UserId, customer.CompanyName);
                }
            }

            Console.WriteLine(result.Message);
        }

        private static void CustomerDelete(CustomerManager customersManager)
        {
            customersManager.Delete(new Customer { CustomerId = 3 });
        }

        private static void CustomerUpdate(CustomerManager customersManager)
        {
            customersManager.Update(new Customer
            {
                CustomerId = 2,
                UserId = 2,
                CompanyName = "Kod Elektronik"
            });
        }

        private static void CustomerAdd(CustomerManager customersManager)
        {
            customersManager.Add(new Customer
            {
                UserId = 3,
                CompanyName = "Ukaz Yangın",
            });
        }
        #endregion
        #region Users
        private static void UserGetAll(UserManager usersManager)
        {
            var result = usersManager.GetAll();

            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", user.UserId, user.FirstName, user.LastName, user.Email, user.Password);
                }
            }

            Console.WriteLine(result.Message);
        }

        private static void UserDelete(UserManager usersManager)
        {
            usersManager.Delete(new User
            {
                UserId = 3
            });
        }

        private static void UserUpdate(UserManager usersManager)
        {
            usersManager.Update(new User
            {
                UserId = 1,
                FirstName = "Hakan",
                LastName = "Sönmez",
                Email = "hakansonmez2326@gmail.com",
                Password = "Password"
            });
        }

        private static void UserAdd(UserManager usersManager)
        {
            usersManager.Add(new User
            {
                FirstName = "Veli",
                LastName = "Öztürk",
                Email = "veliozturk@gmail.com",
                Password = "12345678"
            });
        }
        #endregion
        #region Colors
        private static void ColorGetAll(ColorManager colorsManager)
        {
            var result = colorsManager.GetAll();

            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
                }
            }

            Console.WriteLine(result.Message);
        }

        private static void ColorDelete(ColorManager colorsManager)
        {
            colorsManager.Delete(new Color
            {
                ColorId = 2
            });
        }

        private static void ColorUpdate(ColorManager colorsManager)
        {
            colorsManager.Update(new Color
            {
                ColorId = 1,
                ColorName = "Black Matte"
            });
        }

        private static void ColorAdd(ColorManager colorsManager)
        {
            colorsManager.Add(new Color
            {
                ColorName = "Red"
            });
        }
        #endregion
        #region Brands
        private static void BrandGetAll(BrandManager brandsManager)
        {
            var result = brandsManager.GetAll();

            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
                }
            }

            Console.WriteLine(result.Message);
        }
        private static void BrandDelete(BrandManager brandsManager)
        {
            brandsManager.Delete(new Brand
            {
                BrandId = 2
            });
        }

        private static void BrandUpdate(BrandManager brandsManager)
        {
            brandsManager.Update(new Brand
            {
                BrandId = 1,
                BrandName = "Range Over Sports"
            });
        }

        private static void BrandAdd(BrandManager brandsManager)
        {
            brandsManager.Add(new Brand
            {
                BrandName = "Jaguar"
            });
        }
        #endregion
        #region Cars
        private static void CarDtoList(CarManager carsManager)
        {
            var result = carsManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var carDto in result.Data)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", carDto.BrandName, carDto.ColorName, carDto.DailyPrice);
                }
            }

            Console.WriteLine(result.Message);

        }
        private static void CarDelete(CarManager carsManager)
        {
            carsManager.Delete(new Car
            {
                CarId = 2,
            });
        }

        private static void CarUpdate(CarManager carsManager)
        {
            carsManager.Update(new Car
            {
                CarId = 10,
                BrandId = 2,
                ColorId = 2,
                ModelYear = 2010,
                DailyPrice = 75,
                Description_ = "TestingUpdate"

            });
        }

        private static void CarAdd(CarManager carsManager)
        {
            carsManager.Add(new Car
            {
                BrandId = 3,
                ColorId = 1,
                ModelYear = 2023,
                DailyPrice = 400,
                Description_ = "a"
            });

        }
        #endregion

        private static void Line()
        {
            Console.WriteLine("-------------------------------");
        }
    }
}
