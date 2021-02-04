using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Banco{
    public class UsuarioViewModelOutput{
        public int Codigo { 
            get;
            set; 
        }
        public string Login { 
            get;
            set; 
        }
        public string Email { 
            get; 
            set; 
        }
    }
}
