using System;

namespace EmailService
{
    public class Anexo
    {
        private string _caminhoArquivo;

        public string CaminhoArquivo
        {
            get
            {
                return _caminhoArquivo;
            }
            private set
            {

                if (value == null || string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Favor informar o caminho do arquivo para ser anexado.");
                }

                this._caminhoArquivo = value;
            }
        }

        public Anexo(string caminhoArquivo)
        {
            CaminhoArquivo = caminhoArquivo;
        }
    }
}
