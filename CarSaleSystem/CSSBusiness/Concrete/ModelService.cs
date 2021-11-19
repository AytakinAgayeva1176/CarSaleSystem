using CSSAccess.Abstract;
using CSSAccess.ViewModels;
using CSSBusiness.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSBusiness.Concrete
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository repository;
        public ModelService(IModelRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<ModelViewModel>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<ModelViewModel> GetByID(int id)
        {
            return await repository.GetByID(id);
        }
    }
}
