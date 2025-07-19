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
        //override no método pois vamos sobescrever um método que já vem no (DbContext)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
                    //A entidade (Sessao) terá como chave/key
                    //a (sessao.FilmeId a chave do cinema sessao.CinemaId)
            modelBuilder.Entity<Sessao>()
                
                 .HasKey(sessao => new
                 {
                     sessao.FilmeId,
                     sessao.CinemaId
                 });

            modelBuilder.Entity<Sessao>()
                //HasOne - uma sessão tera um cinema
                .HasOne(sessao => sessao.Cinema)
                //WithMany - cinema tera (1:n) uma ou mais sessões
                .WithMany(Cinema => Cinema.Sessao)
                //HasForeignKey - chave estrangeira ou fk terá o id do cinema - CinemaId 
                .HasForeignKey(sessao => sessao.CinemaId);

            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessao)
                .HasForeignKey(sessao => sessao.FilmeId);

            //evitar que a deleção aconteça em cascata
            //não que a deleção seja em cascata.
            //quero que seja restrita - DeleteBehavior.Restrict
            modelBuilder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .OnDelete(DeleteBehavior.Restrict);
        }



        //irá nós das as informações dos nossos dados do banco
        public DbSet<Filme> Filmes {  get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Sessao> Sessaos { get; set; }  
    }
}
