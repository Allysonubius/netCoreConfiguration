using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Usuario
{
    public class RegistrarViewModelInput
    {
        [Required(ErrorMessage ="Campo Login obrigatório.")]
        public string Login
        {
            get; set;
        }

        [Required(ErrorMessage = "Campo Email obrigatório.")]
        public string Email
        {
            get; set;
        }

        [Required(ErrorMessage = "Campo Senha obrigatório.")]
        public string Senha
        {
            get; set;
        }
    }
}
