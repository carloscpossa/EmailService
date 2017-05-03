using System;

namespace EmailService
{
    public class Destinatario
    {
        private EnderecoEmail _enderecoEmail;

        public Destinatario(EnderecoEmail enderecoEmail)
        {
            if (enderecoEmail == null)
            {
                throw new ArgumentException("Favor informar um endereço de e-mail não nulo.");
            }

            _enderecoEmail = enderecoEmail;
        }

        public EnderecoEmail EnderecoEmail
        {
            get
            {
                return this._enderecoEmail;
            }
        }
    }
}