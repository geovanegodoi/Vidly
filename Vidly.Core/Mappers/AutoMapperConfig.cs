using AutoMapper;

namespace Vidly.Core.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                DomainToModelMapping.ApplyMapping(cfg);
                ModelToCriteriaMapping.ApplyMapping(cfg);
                ModelToDomainMapping.ApplyMapping(cfg);
                ViewModelToModelMapping.ApplyMapping(cfg);
            });
        }
    }
}
