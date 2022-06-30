using MailKit.Net.Smtp;
using MimeKit;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class EmailService
    {
        private IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void EnviarEmail(string[] destinatario,string assunto, 
            int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario,
                assunto, usuarioId, code);

            var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using (var cliente = new SmtpClient())
            {
                try
                {
                    cliente.Connect(
                        _config.GetValue<string>("EmailSettings:SmtpServer"),
                        _config.GetValue<int>("EmailSettings:Port"), false
                    );
                    cliente.AuthenticationMechanisms.Remove("XOUATH2");
                    cliente.Authenticate(
                        _config.GetValue<string>("EmailSettings:From"),
                        _config.GetValue<string>("EmailSettings:Password")
                    );
                    cliente.Send(mensagemDeEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    cliente.Disconnect(true);
                }
            } 
            
        }

        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress("Filmes App", _config.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return mensagemDeEmail;
        }
    }
}
