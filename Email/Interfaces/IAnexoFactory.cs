using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Interfaces
{
    public interface IAnexoFactory
    {
        List<Anexo> criarAnexos(string[] caminhoAnexos);
    }
}
