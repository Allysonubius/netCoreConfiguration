using curso.api.Business.Entity;
using curso.api.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Infra.Data.Repository
{
    interface UsuarioRepository : IUsuarioRepository
    {
        CursoDbContext contexto { get; set; }

        public void Adicionar(Usuario usuario)
        {
            contexto.Usuario.Add(usuario);
        }

        public void Commit()
        {
            contexto.SaveChanges();
        }
    }
}
