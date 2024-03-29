﻿using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.AutoMapper.Profiles
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel( )
        {
            CreateMap<Stock, StockViewModel>( );
            CreateMap<PaymentMethod, PaymentMethodViewModel>( );
            CreateMap<Client, ClientViewModel>( );
            CreateMap<ShoppingCarts, ShoppingCartsViewModel>( );
            CreateMap<Product, ProductViewModel>( );
            CreateMap<Price, PriceViewModel>( );
        }
    }
}