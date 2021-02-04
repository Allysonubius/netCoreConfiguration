using curso.api.Filter;
using curso.api.Models;
using curso.api.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using NPoco.Expressions;
using OpenXmlPowerTools;
using Swashbuckle.AspNetCore.Annotations;
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
        /// <summary>
        /// teste
        /// </summary>
        /// <param name="loginViewModelInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode:200, description:"Sucesso ao autenticar.",Type= typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode:400, description: "Campos obrigatórios.", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode:500, description: "Erro interno no servidor.", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("login")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return Ok( loginViewModelInput);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrarViewModelInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar.", Type = typeof(RegistrarViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios.", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno no servidor.", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistrarViewModelInput registrarViewModelInput)
        {
            
            return Created("Registro realizado com sucesso ! ", registrarViewModelInput);
        }
    }
}
