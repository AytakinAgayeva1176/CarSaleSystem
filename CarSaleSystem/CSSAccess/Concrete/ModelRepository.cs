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
    public class ModelRepository : IModelRepository
    {
        #region fields
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        #endregion

        #region ctor
        public ModelRepository(AppDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion
        public async Task<List<ModelViewModel>> GetAll()
        {
            var models = await context.Models.ToListAsync();
            var listModels = mapper.Map<List<ModelViewModel>>(models);
            if (listModels != null)
            {
                return listModels;
            }

            throw new Exception("Something went wrong");
        }

        public async Task<ModelViewModel> GetByID(int id)
        {
            var model = await context.Models.FindAsync(id);
            if (model == null)
            {
                throw new Exception("Model doesnt exist");
            }

            return mapper.Map<ModelViewModel>(model);
        }
    }
}
