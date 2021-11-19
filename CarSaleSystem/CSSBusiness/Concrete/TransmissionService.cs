using CSSAccess.Abstract;
using CSSAccess.ViewModels;
using CSSBusiness.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSBusiness.Concrete
{
    public class TransmissionService : ITransmissionService
    {
        private readonly ITransmissionRepository repository;
        public TransmissionService(ITransmissionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<TransmissionViewModel>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<TransmissionViewModel> GetByID(int id)
        {
            return await repository.GetByID(id);
        }
    }
}
