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
    public class TransmissionRepository : ITransmissionRepository
    {
        #region fields
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        #endregion

        #region ctor
        public TransmissionRepository(AppDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion
        public async Task<List<TransmissionViewModel>> GetAll()
        {

            var transmissions = await context.Transmissions.ToListAsync();
            var listTransmissions = mapper.Map<List<TransmissionViewModel>>(transmissions);
            if (listTransmissions != null)
            {
                return listTransmissions;
            }

            throw new Exception("Something went wrong");
        }

        public async Task<TransmissionViewModel> GetByID(int id)
        {
            var transmission = await context.Transmissions.FindAsync(id);
            if (transmission == null)
            {
                throw new Exception("Transmission doesnt exist");
            }

            return mapper.Map<TransmissionViewModel>(transmission);
        }
    }
}
