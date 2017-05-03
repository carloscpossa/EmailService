using EmailService.Interfaces;
using System;

namespace EmailService
{
    public class EnderecoEmail
    {
        private readonly IValidadorEmail _validador;

        private string _enderecoEmail;

        public string enderecoEmail
        {
            get
            {
                return _enderecoEmail;
            }
        }

        public EnderecoEmail(string endereco, IValidadorEmail validador)
        {            
            if (validador == null)
            {
                throw new Exception("Favor informar um validador de e-mail.");
            }

            _validador = validador;

            if (!_validador.EmailValido(endereco))
            {
                throw new Exception("Email inválido");
            }

            this._enderecoEmail = endereco;
        }
    }
}