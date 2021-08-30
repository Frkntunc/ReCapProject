using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetByCustomerId(int customerId);
        IResult Insert(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        
    }
}
