using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.AutoMapper.Profiles
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain( )
        {
            CreateMap<StockViewModel, Stock>( );
            CreateMap<PaymentMethodViewModel, PaymentMethod>( );
            CreateMap<ClientViewModel, Client>( );
            CreateMap<ProductViewModel, Product>( );
        }
    }
}