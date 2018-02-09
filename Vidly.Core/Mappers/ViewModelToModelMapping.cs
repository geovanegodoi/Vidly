using AutoMapper;

namespace Vidly.Core.Mappers
{
    public static class ViewModelToModelMapping
    {
        public static void ApplyMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ViewModel.CustomerViewModel, TO.CustomerTO>()
<<<<<<< HEAD
               .ForMember(dst => dst.Id                       , opt => opt.MapFrom(src => src.Customer.Id))
               .ForMember(dst => dst.Name                     , opt => opt.MapFrom(src => src.Customer.Name))
               .ForMember(dst => dst.IsSubscribedToNewsletter , opt => opt.MapFrom(src => src.Customer.IsSubscribedToNewsletter))
               .ForMember(dst => dst.MembershipTypeId         , opt => opt.MapFrom(src => src.Customer.MembershipTypeId))
               .ForMember(dst => dst.Birthdate                , opt => opt.MapFrom(src => src.Customer.Birthdate));
=======
               .ForMember(dst => dst.Id                       , opt => opt.MapFrom(src => src.Customer.Id                      ))
               .ForMember(dst => dst.Name                     , opt => opt.MapFrom(src => src.Customer.Name                    ))
               .ForMember(dst => dst.IsSubscribedToNewsletter , opt => opt.MapFrom(src => src.Customer.IsSubscribedToNewsletter))
               .ForMember(dst => dst.MembershipTypeId         , opt => opt.MapFrom(src => src.Customer.MembershipTypeId        ))
               .ForMember(dst => dst.Birthdate                , opt => opt.MapFrom(src => src.Customer.Birthdate               ));

            cfg.CreateMap<ViewModel.MovieViewModel, TO.MovieTO>()
                .ForMember(dst => dst.Id          , opt => opt.MapFrom(src => src.Movie.Id         ))
                .ForMember(dst => dst.Name        , opt => opt.MapFrom(src => src.Movie.Name       ))
                .ForMember(dst => dst.GenderId    , opt => opt.MapFrom(src => src.Movie.GenderId   ))
                .ForMember(dst => dst.ReleaseDate , opt => opt.MapFrom(src => src.Movie.ReleaseDate))
                .ForMember(dst => dst.Added       , opt => opt.MapFrom(src => src.Movie.Added      ))
                .ForMember(dst => dst.Stock       , opt => opt.MapFrom(src => src.Movie.Stock      ));
>>>>>>> dev
        }
    }
}