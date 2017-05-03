using System.Runtime.InteropServices;

namespace EmailService.Interfaces
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual),
    Guid("94CCF2BB-8D87-40C4-9E59-84007BFE1B85"),
    ComVisible(true)]    
    public interface IServicoEmail
    {
        void EnviarEmail(string enderecoEmailRemetente, string smtpRemetente, string senhaRemente, int portaSmtp, bool habilitaSSL, string destinatarios,
                         string comCopia, string comCopiaOculta, string anexos, string assunto, string textoEmail);
    }
}
