using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.ProfileAutoMapper
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            //Quando estamos "criando - post" mapeamos do dto -> para o endereço
            CreateMap<CreateEnderecoDto, Endereco>();
            //Quando estamos "buscando - get" mapeamos do endereco -> para o dto
            CreateMap<Endereco, ReadEnderecoDto>();
            //Quando estamos "atualizando - put" mapeamos do dto -> para o endereço
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
        
    }
}
