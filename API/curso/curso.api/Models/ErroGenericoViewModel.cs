using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models
{
    public class ErroGenericoViewModel
    {
        public IEnumerable<string> Mensagem
        {
            get ;
            
        }

        public ErroGenericoViewModel(IEnumerable<string> mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
