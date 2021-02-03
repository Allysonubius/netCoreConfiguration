using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Usuario
{
    public class LoginViewModelInput
    {
        public string Login
        {
            get; set;
        }

        public string Senha
        {
            get; set;
        }
    }
}
