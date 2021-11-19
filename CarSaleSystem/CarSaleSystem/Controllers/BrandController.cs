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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService service;
        public BrandController(IBrandService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get Brand by Id
        /// </summary>
        /// <param name="id">Brand Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandViewModel>> GetById(int id)
        {
            var brand =await service.GetByID(id);
            if (brand != null)
            {
                return Ok(brand);
            }
            return BadRequest();
        }



        /// <summary>
        /// Get All Brands
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CarViewModel>> GetAllBrands()
        {
            var brands = await service.GetAll();
            if (brands != null)
            {
                return Ok(brands);
            }
            return BadRequest();
        }

    }
}
