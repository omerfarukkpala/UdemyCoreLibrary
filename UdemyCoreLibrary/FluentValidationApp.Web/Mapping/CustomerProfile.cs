using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreditCard, CustomerDto>();

            CreateMap<Customer, CustomerDto>().IncludeMembers(x => x.CreditCard) // CreditCard daki propertyleri CustomerDto daki isimleri birebir aynı olanlarla eşler.
                .ForMember(dest => dest.Isim, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age));
            //.ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.FullName2()));
            // Farklı propertyleri eşleme


            //CreateMap<Customer, CustomerDto>().ReverseMap(); // 2 satırı tek satıra dönüştürüyor.
            //CreateMap<CustomerDto, Customer>();
        }
    }
}
