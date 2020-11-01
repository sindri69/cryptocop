using System;
using AutoMapper;


namespace Cryptocop.Software.API.Mappings;
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewsItem, NewsItemDto>();
            CreateMap<NewsItem, NewsItemDetailDto>();
            CreateMap<NewsItemInputModel, NewsItem>()
                .ForMember(src => src.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "TechnicalRadiationAdmin"));

            CreateMap<Category, CategoryDto>()
                .ForMember(src => src.Slug, opt => opt.MapFrom<SlugResolver>());

            CreateMap<Category, CategoryDetailDto>()
                .ForMember(src => src.Slug, opt => opt.MapFrom<DetailSlugResolver>());

            CreateMap<CategoryInputModel, Category>()
                .ForMember(src => src.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "TechnicalRadiationAdmin"));
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorDetailDto>();
            CreateMap<AuthorInputModel, Author>()
                .ForMember(src => src.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.CreatedDate, opt => opt.MapFrom(src => DateTime.Now ))
                .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "TechnicalRadiationAdmin"));
        }
    }
}