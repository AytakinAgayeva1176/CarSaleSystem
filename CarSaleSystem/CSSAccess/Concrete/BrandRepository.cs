using AutoMapper;
using CSSAccess.Abstract;
using CSSAccess.Concrete.EF;
using CSSAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSAccess.Concrete
{
    public class BrandRepository : IBrandRepository
    {
        #region fields
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        #endregion

        #region ctor
        public BrandRepository(AppDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion
        public async Task<List<BrandViewModel>> GetAll()
        {
            var brands = await context.Brands.ToListAsync();
            var listBrands = mapper.Map<List<BrandViewModel>>(brands);
            if (listBrands != null)
            {
                return listBrands;
            }

            throw new Exception("Something went wrong");
        }

        public async Task<BrandViewModel> GetByID(int id)
        {
            var brand = await context.Brands.FindAsync(id);
            if (brand == null)
            {
                throw new Exception("Brand doesnt exist");
            }

            return mapper.Map<BrandViewModel>(brand);
        }
    }
}
