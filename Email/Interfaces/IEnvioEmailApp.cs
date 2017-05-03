namespace EmailService.Interfaces
{
    public interface IEnvioEmailApp
    {
        void EnviarEmail(string enderecoEmailRemetente, string smtpRemetente, string senhaRemente, int portaSmtp, bool habilitaSSL, string[] destinatarios,
                         string[] comCopia, string[] comCopiaOculta, string[] anexos, string assunto, string textoEmail);
    }
}
