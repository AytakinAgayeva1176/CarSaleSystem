using AutoMapper;
using CSSAccess.ViewModels;
using CSSEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSAccess.AutoMapper
{
    public class CommonMappingProfile:Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<Brand, BrandViewModel>();
            CreateMap<Model, ModelViewModel>();
            CreateMap<Transmission, TransmissionViewModel>();

            CreateMap<BrandViewModel, Brand>();
            CreateMap<ModelViewModel, Model>();
            CreateMap<Transmission, Transmission>();
        }
    }
}
