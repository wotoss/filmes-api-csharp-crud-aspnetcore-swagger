using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.ProfileAutoMapper
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
            CreateMap<Filme, ReadFilmeDto>()
                //vamos mapear m (filme ) apartir das (sessões) dele
                .ForMember(filmeDto => filmeDto.Sessao,
                options => options.MapFrom(filme =>
                filme.Sessao));
        }
        
    }
}
