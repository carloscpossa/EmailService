using System;

namespace EmailService
{
    public class Remetente
    {

        private EnderecoEmail _endereco;
        private SMTP _SMTP;
        private string _senhaEmail;

        public EnderecoEmail EnderecoEmail
        {
            get
            {
                return this._endereco;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Favor informar o endereço de email do remetente.");
                }

                this._endereco = value;
            }
        }        

        public SMTP SMTP
        {
            get
            {
                return _SMTP;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Favor informar o servidor SMTP de email do remetente.");
                }

                this._SMTP = value;
            }
        }

        public string SenhaEmail
        {
            get
            {
                return _senhaEmail;
            }
            private set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Favor informar a senha de email do remetente.");
                }

                this._senhaEmail = value;
            }
        }                        

        public Remetente(EnderecoEmail _enderecoEmail, SMTP smtp, string senhaEmail)
        {
            this.EnderecoEmail = _enderecoEmail;
            this.SMTP = smtp;
            this.SenhaEmail = senhaEmail;                       
        }
    }
}