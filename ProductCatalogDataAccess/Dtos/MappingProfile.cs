using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalogDataAccess.Models;

namespace ProductCatalogDataAccess.Dtos
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
            });
        }
    }

    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<Supplier, SupplierDto>();
            Mapper.CreateMap<SupplierDto, Supplier>();


        }
    }
}
