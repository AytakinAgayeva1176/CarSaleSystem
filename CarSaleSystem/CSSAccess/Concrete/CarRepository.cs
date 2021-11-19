using AutoMapper;
using CSSAccess.Abstract;
using CSSAccess.Concrete.EF;
using CSSAccess.ViewModels;
using CSSEntity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSAccess.Concrete
{
    public class CarRepository : ICarRepository
    {
        #region fields
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        #endregion

        #region ctor
        public CarRepository(AppDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        public async Task<CarResultModel> Create(CarCreateModel model)
        {
            var car = mapper.Map<Car>(model);
            context.Cars.Add(car);
            var result = await context.SaveChangesAsync() > 0;
            if (!result)
            {
                throw new Exception("Car couldn't create");
            }

            CarResultModel resultModel = new CarResultModel()
            {
                Id = car.Id,
                Model = context.Models.Find(car.ModelId).Name
            };
            return resultModel;
        }


        public async Task<List<CarViewModel>> GetAll(CarSearchModel model)
        {
            var query = CreateFilteredQuery(model);

            if (query != null)
            {
                return mapper.Map<List<CarViewModel>>(await query.ToListAsync());
            }

             throw new Exception("Something went wrong");
        }


        private IQueryable<Car> CreateFilteredQuery(CarSearchModel model)
        {
            var getAllQuery = context.Cars.Include(c => c.Model)
                .Include(c => c.Brand)
                .Include(c => c.Transmission)
                .OrderByDescending(e => e.Price).AsQueryable();

            if (model.BrandId.HasValue)
            {
                getAllQuery = getAllQuery.Where(c => c.BrandId == model.BrandId);
            }

            if (model.ModelId.HasValue)
            {
                getAllQuery = getAllQuery.Where(c => c.ModelId == model.ModelId);
            }

            if (model.lowPrice.HasValue)
            {
                getAllQuery = getAllQuery.Where(c => c.Price >= model.lowPrice);
            }
            if (model.highPrice.HasValue)
            {
                getAllQuery = getAllQuery.Where(c => c.Price <= model.highPrice);
            }
            if (!string.IsNullOrEmpty(model.Color))
            {
                getAllQuery = getAllQuery.Where(c => Microsoft.EntityFrameworkCore.EF.Functions.Like(c.Color, $"%{model.Color}%"));
            }

            return getAllQuery;
        }


        public async Task<CarViewModel> GetById(int id)
        {
            var car = await context.Cars.FindAsync(id);
            if (car == null)
            {
                throw new Exception("Car doesnt exist");
            }

            return mapper.Map<CarViewModel>(car);
        }


        public async Task<bool> Remove(int id)
        {
            var car = await context.Cars.FindAsync(id);
            if (car == null)
            {
                throw new Exception("Car doesn't exist");
            }

            context.Cars.Remove(car);
            var result = await context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<CarResultModel> Update(CarViewModel model)
        {
            var car = mapper.Map<Car>(model);
            context.Cars.Update(car);
            var savedItemCount = await context.SaveChangesAsync() > 0;
            if (savedItemCount)
            {
                CarResultModel resultModel = new CarResultModel()
                {
                    Id = car.Id,
                    Model = context.Models.Find(car.ModelId).Name
                };
                return resultModel;
            }
            throw new Exception("Car doesn't exist");
        }

      

    }
}
