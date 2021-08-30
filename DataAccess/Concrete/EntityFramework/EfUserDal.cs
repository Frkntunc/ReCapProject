using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, EntityDatabaseContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (EntityDatabaseContext context = new EntityDatabaseContext())
            {
                var result = from u in context.UserOperationClaims
                             join o in context.OperationClaims
                             on u.OperationClaimId equals o.Id
                             where u.UserId == user.Id
                             select new OperationClaim { Id = o.Id, Name = o.Name };
                return result.ToList();
            }
        }
    }
}
