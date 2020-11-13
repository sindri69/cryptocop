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
            CreateMap<Order, OrderDto>()
                .ForMember(src => src.CreditCard, opt => opt.MapFrom(src => src.MaskedCreditCard));
            CreateMap<ShoppingCart, ShoppingCartItemDto>();

        }
    }
}