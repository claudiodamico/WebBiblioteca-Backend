using AutoMapper;
using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Alquiler, AlquilerDto>().ReverseMap();
            CreateMap<Libro, LibroDto>().ReverseMap();
        }
    }
}
