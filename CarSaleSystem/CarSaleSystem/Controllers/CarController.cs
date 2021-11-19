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
    public class CarController : ControllerBase
    {
        private readonly ICarService service;
        public CarController(ICarService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get Car by Id
        /// </summary>
        /// <param name="id">Car Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async  Task<ActionResult<CarViewModel>> GetById(int id)
        {
            var car =await service.GetById(id);
            if (car != null)
            {
                return Ok(car);
            }
            return BadRequest();
        }



        /// <summary>
        /// Get All Cars
        /// </summary>
        ///<param name="model">Car Search Model</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CarViewModel>> GetAllCars(CarSearchModel model)
        {
            var cars = await service.GetAll(model);
            if (cars != null)
            {
                return Ok(cars);
            }
            return BadRequest();
        }





        /// <summary>
        /// Add New Car
        /// </summary>
        /// <param name="model">Car object</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CarResultModel>> Create(CarCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var carModel = await service.Create(model);
                if (carModel == null)
                {
                    return BadRequest();
                }

                return Ok(carModel);
            }

            return BadRequest();
        }



        /// <summary>
        /// Update Car 
        /// </summary>
        /// <param name="model">Car object</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<CarResultModel>> Update(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                var car = await service.Update(model);
                if (car == null)
                {
                    return BadRequest();
                }

                return Ok(car);
            }

            return BadRequest();
        }




        /// <summary>
        /// Delete Car 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                await service.Remove(id);
                return Ok("Car Removed");
            }

            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }




    }
}
