namespace UsuariosApi.Models
{
    public class Token
    {
        public Token(string value)
        {
            this.value = value;
        }

        public string value { get; }
    }
}
