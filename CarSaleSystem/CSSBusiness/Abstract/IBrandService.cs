using CSSAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSBusiness.Abstract
{
    public interface IBrandService
    {
        Task<List<BrandViewModel>> GetAll();
        Task<BrandViewModel> GetByID(int id);
    }
}
