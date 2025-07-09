using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        //fazendo as validações com (data annotations)
        [Required(ErrorMessage = "O titulo do filme é obrigátorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O genêro do filme é obrigátorio")]
        [MaxLength(50, ErrorMessage = "O tamanho do filme não pode exceder que 50 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "A duração do filme é obrigátorio")]
        //70 a 600 para que ele possa ser considerado um filme
        [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
