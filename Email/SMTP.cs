using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class SMTP
    {
        private string _smtp;
        private int _porta;
        private bool _habilitarSSL;

        public string servidorSMTP
        {
            get
            {
                return this._smtp;
            }
            private set
            {
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Favor informar o endereço do servidor SMTP.");
                }

                this._smtp = value;
            }
        }

        public int Porta
        {
            get { return this._porta; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Favor informar o número da porta SMTP corretamente");
                }
                this._porta = value;
            }
        }

        public bool HabilitarSSL
        {
            get
            {
                return this._habilitarSSL;
            }
            private set
            {
                this._habilitarSSL = value;
            }
        }

        public SMTP(string servidorSmtp, int porta, bool habilitarSSL)
        {
            this.servidorSMTP = servidorSmtp;
            this.Porta = porta;
            this.HabilitarSSL = habilitarSSL;
        }
    }
}
