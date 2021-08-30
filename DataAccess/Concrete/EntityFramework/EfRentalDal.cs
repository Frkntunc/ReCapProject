using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, EntityDatabaseContext>, IRentalDal
    {
        public List<RentalDetail> GetRentals()
        {
            using (EntityDatabaseContext context = new EntityDatabaseContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cs in context.Customers
                             on r.CustomerId equals cs.Id
                             select new RentalDetail { Id = r.Id, CarId = c.Id, CustomerId = cs.Id, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

                return result.ToList();
            }
        }
    }
}
