using CSSAccess.Abstract;
using CSSAccess.ViewModels;
using CSSBusiness.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSBusiness.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public async Task<List<BrandViewModel>> GetAll()
        {
            return await brandRepository.GetAll();
        }

        public async Task<BrandViewModel> GetByID(int id)
        {
            return await brandRepository.GetByID(id);
        }
    }
}
