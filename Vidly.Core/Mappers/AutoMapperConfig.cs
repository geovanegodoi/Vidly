using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Core.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void RegisterMappings()
        {
            AutoMapperConfig.Mapper = (IMapper)new MapperConfiguration((mapper) =>
            {
                mapper.AddProfile<DomainToModelMapping>();
                mapper.AddProfile<ModelToDomainMapping>();
            });
        }
    }
}
