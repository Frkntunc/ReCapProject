using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage) //Resim ekleme yapıyor ama hiçbir resim olmadığında default resim ekleme yapmıyor.
        {
            IResult result = BusinessRules.Run(CheckIfCarImageExist(carImage.CarId)
                ,CheckIfCarImageLimitMax(carImage.CarId));

            var carImageResult = FileHelperManager.Upload(formFile);
            if (!carImageResult.Success)
            {
                return new ErrorResult(carImageResult.Message);
            }

            carImage.ImagePath = carImageResult.Message;
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult();

        }

        public IResult Delete(CarImage carImage)//Delete ve Update işlemlerini yapmıyor. Daha doğrusu single or default'a takılıyor EfEntityRepositoryBase'deki.
        {
            var result = _carImageDal.Get(c => c.Id == carImage.Id);
            if (result==null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }
            FileHelperManager.Delete(result.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<CarImage> GetByCarId(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == Id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }
            var result = FileHelperManager.Update(formFile, carImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            carImage.ImagePath = result.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageExist(int carId)
        {
            try
            {
                string path = @"\Images\default.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    using (EntityDatabaseContext context = new EntityDatabaseContext())
                    {
                        var carImage = from c in context.Cars
                                       join i in context.CarImages
                                       on c.Id equals i.CarId
                                       select new CarImage { CarId = c.Id, ImagePath = path, Date = DateTime.Now };
                        //List<CarImage> carImage = new List<CarImage>();
                        //carImage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                        
                    }
                    return new SuccessResult();
                }

            }
            catch (Exception exception)
            {
                
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId).ToList());
        }

        private IResult CheckIfCarImageLimitMax(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>5)
            {
                return new ErrorResult(Messages.CarImageOutOfLimit);
            }
            return new SuccessResult();
        }
    }
}
