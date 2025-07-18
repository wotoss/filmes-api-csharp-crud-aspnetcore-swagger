using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    //ira fazer o élo entre o ( dominio aplicação e o nosso banco de dados ).
    public class FilmeContext : DbContext
    {
        
        public FilmeContext(DbContextOptions<FilmeContext> options)
            //base -  nós estamos passando esta opções para o nosso construtor DbContext
            : base(options) 
        { }
        //irá nós das as informações dos nossos dados do banco
        public DbSet<Filme> Filmes {  get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Sessao> Sessaos { get; set; }  
    }
}
