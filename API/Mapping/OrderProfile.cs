using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;

namespace API.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.FlightRate.Price.Value))
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.FlightRate.Price.GetCurrencyCode()));
        }
    }
}
