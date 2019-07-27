using AutoMapper;
using Ecommerce.Application.AutoMapper.Profiles;
using System.Diagnostics.CodeAnalysis;

namespace Ecommerce.Application.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings( )
        {
            return new MapperConfiguration( ps =>
             {
                 ps.AddProfile( new DomainToViewModel( ) );
                 ps.AddProfile( new ViewModelToDomain( ) );
             } );
        }
    }
}
