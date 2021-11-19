using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSAccess.Abstract
{
    public interface IGenericRepository<TModel,IdType> 
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetByID(IdType id);
    }
}
