using EmailService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class AnexoFactory : IAnexoFactory
    {
        public List<Anexo> criarAnexos(string[] caminhoAnexos)
        {
            if (caminhoAnexos == null)
            {
                throw new ArgumentException("Favor informar os caminhos dos anexos para criação dos mesmos.");
            }

            List<Anexo> listaAnexo = new List<Anexo>();

            foreach (string caminho in caminhoAnexos)
            {
                if (caminho != null && !string.IsNullOrEmpty(caminho.Trim()))
                {
                    Anexo anexo = new Anexo(caminho.Trim());
                    listaAnexo.Add(anexo);
                }
            }

            return listaAnexo;
        }
    }
}
