using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetByColorId(int ColorId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.ColorId == ColorId));

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [SecuredOperation("car.insert,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Insert(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car);

            IResult result = BusinessRules.Run(CheckIfBrandLimitExceded()
                ,CheckIfCarCountOfBrandCorrect(car.BrandId));

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result>=10)
            {
                return new ErrorResult(Messages.BrandLimit);
            }
            return new SuccessResult();
        }

        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.data.Count>12)
            {
                return new ErrorResult(Messages.BrandLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
