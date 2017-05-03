using System.Collections.Generic;

namespace EmailService.Interfaces
{
    public interface IDestinatarioFactory
    {
        List<Destinatario> criarDestinatarios(string[] enderecoEmailDestinatarios);
    }
}
