using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; } 
        //iremos avisar ao entity que vamos criar uma propriedade
        //que vai conter o Id do endereço EnderecoId
        public int EnderecoId { get; set; }
        //preciso mostrar ao entity que o relacionamento é de (1:1)
        public virtual Endereco Endereco { get; set; }  
    }
}
