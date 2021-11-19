using CSSAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSBusiness.Abstract
{
    public interface ITransmissionService
    {
        Task<List<TransmissionViewModel>> GetAll();
        Task<TransmissionViewModel> GetByID(int id);
    }
}
