using AutoMapper;
using Ultimus.Application.Features.Customer.Queries.GetCustomersList;
using Ultimus.Application.Features.CustomerAddress.Queries.GetCustomerAddressesList;
using Ultimus.Application.Features.Product.Queries.GetProductsList;
using Ultimus.Application.Features.ProductCategory.Queries.GetProductCategoryList;
using Ultimus.Domain.Entities;

namespace Ultimus.Application.Common.Profiiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Customer
            CreateMap<Customer, CustomersListOutputVM>().ReverseMap();            
            CreateMap<Product, ProductsListOutputVM>().ReverseMap();
            CreateMap<ProductCategory,ProductCategoryVM>().ReverseMap();
            CreateMap<CustomerAddress,CustomerAddressVM>().ForMember(dest => dest.Rowguid, opt => opt.Ignore()).ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressesListOutputVM>().ReverseMap();
            CreateMap<ProductCategory,ProductCategoryListOutputVM>().ReverseMap();            
            //CreateMap<Customer, UpdateTestDto>().ReverseMap();
            #endregion            
        }
    }
}
