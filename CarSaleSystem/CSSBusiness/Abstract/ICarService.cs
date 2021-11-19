using CSSAccess.ViewModels;
using CSSEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSBusiness.Abstract
{
    public interface ICarService
    {
        Task<List<CarViewModel>> GetAll(CarSearchModel model);
        Task<CarResultModel> Create(CarCreateModel model);
        Task<CarResultModel> Update(CarViewModel model);
        Task<bool> Remove(int id);
        Task<CarViewModel> GetById(int id);
    }
}
