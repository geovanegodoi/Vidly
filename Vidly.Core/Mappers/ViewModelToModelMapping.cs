using AutoMapper;

namespace Vidly.Core.Mappers
{
    public static class ViewModelToModelMapping
    {
        public static void ApplyMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ViewModel.CustomerViewModel, TO.CustomerTO>()
               .ForMember(dst => dst.Id                       , opt => opt.MapFrom(src => src.Customer.Id))
               .ForMember(dst => dst.Name                     , opt => opt.MapFrom(src => src.Customer.Name))
               .ForMember(dst => dst.IsSubscribedToNewsletter , opt => opt.MapFrom(src => src.Customer.IsSubscribedToNewsletter))
               .ForMember(dst => dst.MembershipTypeId         , opt => opt.MapFrom(src => src.Customer.MembershipTypeId))
               .ForMember(dst => dst.Birthdate                , opt => opt.MapFrom(src => src.Customer.Birthdate));
        }
    }
}