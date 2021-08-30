using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManagerMethod();

            //ColorMenagerMethod();

            //BrandManagerMethod();

            //CustomerMenager();

        }

        private static void CustomerMenager()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer = new Customer();
            //customer.Id = 2;
            customer.CompanyName = "B Firması";

            customerManager.Insert(customer);

            var result = customerManager.GetAll();
            if (result.Success == true)
            {
                foreach (var item in result.data)
                {
                    Console.WriteLine(item.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandManagerMethod()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand brand1 = new Brand();
            brand1.Id = 6;
            brand1.BrandName = "Kia";

            //brandManager.Insert(brand1);
            //brandManager.Update(brand1);
            //brandManager.Delete(brand1);

            var result = brandManager.GetAll();

            if (result.Success==true)
            {
                foreach (var item in result.data)
                {
                    Console.WriteLine(item.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorMenagerMethod()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color color1 = new Color();
            color1.Id = 1002;
            color1.ColorName = "Sarı";

            //colorManager.Insert(color1);
            //colorManager.Update(color1);
            //colorManager.Delete(color1);

            var result = colorManager.GetAll();

            if (result.Success==true)
            {
                foreach (var item in result.data)
                {
                    Console.WriteLine(item.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarManagerMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal(),new BrandManager(new EfBrandDal()));

            Car car1 = new Car();
            car1.BrandId = 3;
            car1.ColorId = 1002;
            car1.Id = 3002;  //Yeni araba eklemek için Id yazma Ama olan bir arabayı silmek için Id yaz
            car1.ModelYear = 2021;
            car1.Description = "Yeni Audi Araba";
            car1.DailyPrice = 300;

            carManager.Update(car1);
            //carManager.Insert(car1);
            //carManager.Delete(car1);

            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.data)
                {
                    Console.WriteLine("Günlük Araba Fiyatlarımız: " + car.CarName + " : " + car.BrandName + " : " + car.ColorName + " : " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
