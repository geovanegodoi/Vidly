using AutoMapper;

namespace Vidly.Core.Mappers
{
    public static class ModelToDomainMapping
    {
        public static void ApplyMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TO.CustomerTO, Domain.Customer>();

            cfg.CreateMap<TO.GenderTO, Domain.Gender>();

            cfg.CreateMap<TO.MembershipTypeTO, Domain.MembershipType>();

            cfg.CreateMap<TO.MovieTO, Domain.Movie>();
        }
    }
}