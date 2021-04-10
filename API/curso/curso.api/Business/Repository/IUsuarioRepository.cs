using curso.api.Business.Entity;
using curso.api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Business.Repository
{
    interface IUsuarioRepository 
    {
        void AdicionarUser(Usuario usuario);
        void Commit(Usuario usuario);
    }
}
