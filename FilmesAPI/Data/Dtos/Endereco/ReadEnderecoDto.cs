using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Endereco
{
    public class ReadEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Logradouro { get; set; }
        public int Bairro { get; set; }
        public int Numero { get; set; }
    }
}
