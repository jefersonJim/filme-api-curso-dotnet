using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Request
{
    public class AtivaContaRequest
    {
        [Required]
        public int UsuarioID { get; set; }
        [Required]
        public string CodigoDeAtivavao { get; set; }
    }
}
