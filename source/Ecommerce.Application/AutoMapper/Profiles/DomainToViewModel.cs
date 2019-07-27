using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.AutoMapper.Profiles
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel( )
        {
            CreateMap<Stock, StockViewModel>( );
            CreateMap<PaymentMethodViewModel, PaymentMethod>( );
        }
    }
}