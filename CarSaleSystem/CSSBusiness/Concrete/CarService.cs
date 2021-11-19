
using CSSAccess.Abstract;
using CSSAccess.ViewModels;
using CSSBusiness.Abstract;
using CSSEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSBusiness.Concrete
{
    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;
        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        
        public async Task<CarResultModel> Create(CarCreateModel model)
        {
            return await carRepository.Create(model);
        }

        public async Task<List<CarViewModel>> GetAll(CarSearchModel model)
        {
            return await carRepository.GetAll(model);
        }

        public async Task<CarViewModel> GetById(int id)
        {
            return await carRepository.GetById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await carRepository.Remove(id);
        }



        public async Task<CarResultModel> Update(CarViewModel model)
        {
            return await carRepository.Update(model);
        }
    }
}
