using CSSAccess.ViewModels;
using CSSBusiness.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSaleSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionController : ControllerBase
    {
        private readonly ITransmissionService service;
        public TransmissionController(ITransmissionService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get Transmission by Id
        /// </summary>
        /// <param name="id">Transmission Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TransmissionViewModel>> GetById(int id)
        {
            var model =await service.GetByID(id);
            if (model != null)
            {
                return Ok(model);
            }
            return BadRequest();
        }



        /// <summary>
        /// Get All Transmission types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<TransmissionViewModel>> GetAllTransmissionTypes()
        {
            var models = await service.GetAll();
            if (models != null)
            {
                return Ok(models);
            }
            return BadRequest();
        }
    }
}
