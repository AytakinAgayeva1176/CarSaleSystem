
using CSSAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSAccess.Abstract
{
    public interface ICarRepository 
    {
        Task<List<CarViewModel>> GetAll(CarSearchModel model);
        Task<CarResultModel> Create(CarCreateModel model);
        Task<CarResultModel> Update(CarViewModel model);
        Task<bool> Remove(int id);
        Task<CarViewModel> GetById(int id);

    }
}
