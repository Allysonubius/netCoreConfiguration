using curso.api.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return Created(" ", loginViewModelInput);
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(RegistrarViewModelInput registrarViewModelInput)
        {
            return Created(" ", registrarViewModelInput);
        }
    }
}
