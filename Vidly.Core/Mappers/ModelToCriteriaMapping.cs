using AutoMapper;

namespace Vidly.Core.Mappers
{
    public static class ModelToCriteriaMapping
    {
        public static void ApplyMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TO.CustomerTO, TO.CustomerCriteriaTO>();

            cfg.CreateMap<TO.GenderTO, TO.GenderCriteriaTO>();

            cfg.CreateMap<TO.MembershipTypeTO, TO.MembershipTypeCriteriaTO>();

            cfg.CreateMap<TO.MovieTO, TO.MovieCriteriaTO>();

        }
    }
}