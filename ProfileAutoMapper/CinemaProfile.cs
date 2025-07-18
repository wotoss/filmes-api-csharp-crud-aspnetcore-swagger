using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.ProfileAutoMapper
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            //quando eu crio eu passo dto para o classe concreta
            CreateMap<CreateCinemaDto, Cinema>();
            //quando eu "busco no banco" busco para classe concreta e transfiro ao dto
            CreateMap<Cinema, ReadCinemaDto>()
                //estou dizendo que o meu campo de "cinema.Endereco" será mapeado para "cinemaDto.Endereco"
                .ForMember(cinemaDto => cinemaDto.Endereco,
                options => options.MapFrom(cinema => cinema.Endereco));
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
