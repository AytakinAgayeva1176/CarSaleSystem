using AutoMapper;
using CSSAccess.ViewModels;
using CSSEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSAccess.AutoMapper
{
    public class CarMapperProfile :Profile
    {
        public CarMapperProfile()
        {
            CreateMap<CarCreateModel, Car>();
            CreateMap<Car, CarCreateModel>();
            CreateMap<CarViewModel, Car>();
            CreateMap<Car, CarViewModel>();
        }
    }
}
