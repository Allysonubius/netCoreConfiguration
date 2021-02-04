﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Usuario
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage ="O login é obrigatório.")]
        public string Login
        {
            get; 
            set;
        }

        [Required(ErrorMessage = "A senha é obrigatório.")]
        public string Senha
        {
            get; 
             set;
        }
    }
}
