using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailService
{
    public class Email
    {
        private Remetente _remetente;
        private IEnumerable<Destinatario> _destinatarios;
        private string _assunto;
        private string _texto;
        private IEnumerable<Anexo> _anexos;
        private IEnumerable<Destinatario> _comCopia;
        private IEnumerable<Destinatario> _comCopiaOculta;

        public Remetente Remetente
        {
            get
            {
                return _remetente;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Favor informar um remetente válido.");
                }

                this._remetente = value;
            }
        }

        public IEnumerable<Destinatario> Destinatarios
        {
            get
            {
                return this._destinatarios;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Favor informar uma lista de destinatários não nula.");
                }

                if (value.Count() == 0)
                {
                    throw new ArgumentException("Favor informar pelo menos um destinatário.");
                }

                this._destinatarios = value;
            }
        }

        public string Assunto
        {
            get
            {
                return this._assunto;
            }
            private set
            {
                this._assunto = value;
            }
        }

        public string Texto
        {
            get
            {
                return this._texto;
            }
            private set
            {
                this._texto = value;
            }
        }

        public IEnumerable<Anexo> Anexos
        {
            get
            {
                return _anexos;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Favor informar uma lista de anexos não nula.");
                }
                this._anexos = value;
            }
        }

        public IEnumerable<Destinatario> ComCopia
        {
            get
            {
                return this._comCopia;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Favor informar uma lista de destinatários não nula.");
                }                

                this._comCopia = value;
            }
        }

        public IEnumerable<Destinatario> ComCopiaOculta
        {
            get
            {
                return this._comCopiaOculta;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Favor informar uma lista de cópias ocultas não nula.");
                }

                this._comCopiaOculta = value;
            }
        }

        public Email(Remetente remetente, IEnumerable<Destinatario> destinatarios, string assunto, string texto, IEnumerable<Anexo> anexos, IEnumerable<Destinatario> comCopia, IEnumerable<Destinatario> comCopiaOculta)
        {
            this.Remetente = remetente;
            this.Destinatarios = destinatarios;
            this.Assunto = assunto;
            this.Texto = texto;
            this.Anexos = anexos;
            this.ComCopia = comCopia;
            this.ComCopiaOculta = comCopiaOculta;
        }
    }
}
