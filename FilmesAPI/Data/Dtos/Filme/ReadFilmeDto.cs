using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { set; get; }
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string Genero { set; get; }
        [Range(1, 600, ErrorMessage = "A duração deve estar entre 1 e 600")]
        public int Duracao { set; get; }
        [Required]
        public int ClassificacaoEtaria { set; get; }
        public DateTime HoraDaConsulta { set; get; }
    }
}
