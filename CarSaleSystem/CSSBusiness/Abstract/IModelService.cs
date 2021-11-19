using CSSAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSBusiness.Abstract
{
    public interface IModelService
    {
        Task<List<ModelViewModel>> GetAll();
        Task<ModelViewModel> GetByID(int id);
    }
}
