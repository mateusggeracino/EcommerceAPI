using AutoMapper;
using Ecommerce.Application.AutoMapper.Profiles;

namespace Ecommerce.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x =>
            {
                x.AddProfile(new DomainToViewModel());
                x.AddProfile(new ViewModelToDomain());
            });
        }
    }
}
