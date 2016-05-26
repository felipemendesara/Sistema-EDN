using Microsoft.Extensions.PlatformAbstractions;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EDNEVENTOS.Services
{
    public class ServicoEmail
    {
        public static Task EnviarEmail(string email,string assunto,string mensagem, IApplicationEnvironment appEnvironment,string usuario,string senha)
        {
            var caminhoTemplate = "/Templates/ServicosEmail.cshtml";
            var conteudoTemplate = System.IO.File.ReadAllText(appEnvironment.ApplicationBasePath + caminhoTemplate);
            conteudoTemplate = conteudoTemplate.Replace("#url", mensagem).Replace("#Usuario", usuario).Replace("#Senha", senha);


            try
            {
                var minhaMensagem = new SendGridMessage();
                minhaMensagem.AddTo(email);
                minhaMensagem.From = new System.Net.Mail.MailAddress("email@gmail.com", "EDN EVENTOS");
                minhaMensagem.Subject = assunto;
                minhaMensagem.Html = conteudoTemplate;

                var credenciais = new NetworkCredential("userSendGrid", "passSend");
                var transporteWeb = new Web(credenciais);
                return transporteWeb.DeliverAsync(minhaMensagem);
            }
            catch (Exception)
            {
                return Task.FromResult(0);
            }
        }
    }
}
