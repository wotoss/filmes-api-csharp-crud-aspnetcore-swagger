using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Sessao
    {
        public int? FilmeId { get; set; }

        public virtual Filme Filme { get; set; }  
        
        
        public int? CinemaId { get; set; }

        // (n) sessões pode ter 1 cinema
        public virtual Cinema Cinema { get; set; }
    }
}
