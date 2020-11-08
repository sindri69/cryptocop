using System;
using AutoMapper;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Repositories.Helpers;

namespace Cryptocop.Software.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Address, AddressDto>();
            CreateMap<PaymentCard, PaymentCardDto>()
                .ForMember(src => src.CardNumber, opt => opt.MapFrom(src => PaymentCardHelper.MaskPaymentCard(src.CardNumber)));
            CreateMap<Order, OrderDto>();
            CreateMap<ShoppingCart, ShoppingCartItemDto>();
            //     .ForMember(src => src.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
            //     .ForMember(src => src.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
            //     .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "TechnicalRadiationAdmin"));

            // CreateMap<Category, CategoryDto>()
            //     .ForMember(src => src.Slug, opt => opt.MapFrom<SlugResolver>());

            // CreateMap<Category, CategoryDetailDto>()
            //     .ForMember(src => src.Slug, opt => opt.MapFrom<DetailSlugResolver>());

            // CreateMap<CategoryInputModel, Category>()
            //     .ForMember(src => src.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
            //     .ForMember(src => src.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
            //     .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "TechnicalRadiationAdmin"));
            // CreateMap<Author, AuthorDto>();
            // CreateMap<Author, AuthorDetailDto>();
            // CreateMap<AuthorInputModel, Author>()
            //     .ForMember(src => src.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
            //     .ForMember(src => src.CreatedDate, opt => opt.MapFrom(src => DateTime.Now ))
            //     .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "TechnicalRadiationAdmin"));
        }
    }
}