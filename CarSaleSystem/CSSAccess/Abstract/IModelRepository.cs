using CSSAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSAccess.Abstract
{
    public interface IModelRepository : IGenericRepository<ModelViewModel, int>
    {
    }
}
