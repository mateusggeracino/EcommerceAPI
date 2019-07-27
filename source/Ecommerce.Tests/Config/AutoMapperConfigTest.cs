using AutoMapper;
using Ecommerce.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Tests.Config
{
    public class AutoMapperConfigTest
    {
        public static IMapper GetInstance( )
        {
            var mapperConfig = AutoMapperConfig.RegisterMappings( );
            return mapperConfig.CreateMapper( );
        }
    }
}
