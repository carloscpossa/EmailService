using EmailService.Interfaces;
using System;
using System.Collections.Generic;

namespace EmailService
{
    public class DestinatarioFactory : IDestinatarioFactory
    {
        private readonly IValidadorEmail _validadorEmail;

        public DestinatarioFactory(IValidadorEmail validadorEmail)
        {
            _validadorEmail = validadorEmail;
        }

        public List<Destinatario> criarDestinatarios(string[] enderecoEmailDestinatarios)
        {
            if (enderecoEmailDestinatarios == null)
            {
                throw new ArgumentException("Favor informar endereços de destinatário válidos para criação de lista de destinatário.");
            }

            List<Destinatario> listaDestinatario = new List<Destinatario>();

            foreach (string item in enderecoEmailDestinatarios)
            {
                if (item != null && !string.IsNullOrEmpty(item.Trim()))
                {
                    EnderecoEmail endereco = new EnderecoEmail(item, _validadorEmail);
                    Destinatario dest = new Destinatario(endereco);
                    listaDestinatario.Add(dest);
                }
            }

            return listaDestinatario;
        }
    }
}
