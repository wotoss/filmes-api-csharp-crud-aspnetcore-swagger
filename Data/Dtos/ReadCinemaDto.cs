﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class ReadCinemaDto
    {
        public int Id { get; set; } 
        public string Nome { get; set; } 
        public ReadEnderecoDto Endereco { get; set; }
        public ICollection<ReadSessaoDto> Sessao { get; set; }
    }
}
