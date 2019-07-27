using AutoMapper;
using Ecommerce.Application.AutoMapper.Profiles;

namespace Ecommerce.Application.AutoMapper
{
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
