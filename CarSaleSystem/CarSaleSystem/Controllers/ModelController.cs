﻿using CSSAccess.ViewModels;
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
    public class ModelController : ControllerBase
    {
        private readonly IModelService service;
        public ModelController(IModelService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get Model by Id
        /// </summary>
        /// <param name="id">Model Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelViewModel>> GetById(int id)
        {
            var model =await service.GetByID(id);
            if (model != null)
            {
                return Ok(model);
            }
            return BadRequest();
        }



        /// <summary>
        /// Get All Models
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CarViewModel>> GetAllModels()
        {
            var models =await service.GetAll();
            if (models != null)
            {
                return Ok(models);
            }
            return BadRequest();
        }
    }
}
