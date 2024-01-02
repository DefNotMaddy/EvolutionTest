using AutoMapper;
using EvolutionStuff.ServiceModel.Models.DbModel;
using EvolutionStuff.ServiceModel.Models.Dto;

namespace EvolutionStuff.ServiceInterface.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, UserDb>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website))

                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new AddressDb
                {
                    Street = src.Address.Street,
                    Suite = src.Address.Suite,
                    City = src.Address.City,
                    Zipcode = src.Address.Zipcode,

                    Geo = new GeoDb
                    {
                        Lat = src.Address.Geo.Lat,
                        Lng = src.Address.Geo.Lng
                    }
                }))

                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => new CompanyDb
                {
                    Name = src.Company.Name,
                    CatchPhrase = src.Company.CatchPhrase,
                    Bs = src.Company.Bs
                }));
            CreateMap<UserDb, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website))

                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new AddressDto
                {
                    Street = src.Address.Street,
                    Suite = src.Address.Suite,
                    City = src.Address.City,
                    Zipcode = src.Address.Zipcode,

                    Geo = new GeoDto
                    {
                        Lat = src.Address.Geo.Lat,
                        Lng = src.Address.Geo.Lng
                    }
                }))

                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => new CompanyDto
                {
                    Name = src.Company.Name,
                    CatchPhrase = src.Company.CatchPhrase,
                    Bs = src.Company.Bs
                }));


        }
    }
}
