using curso.api.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.api.Controllers{

    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursosController : ControllerBase{

        /// <summary>
        /// Criar novos cursos.
        /// </summary>
        /// <param name="registrarViewModelInput"></param>
        /// <returns>Retorna criado os dados do curso.</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar um novo curso.")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado.")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno no servidor.")]
        [HttpPost]
        [Route("criar")]
        public IActionResult Post(CursosViewModelInput cursosViewModelInput){
            var CodigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", cursosViewModelInput);
        }

        /// <summary>
        /// Exibir cursos.
        /// </summary>
        /// <param name="registrarViewModelInput"></param>
        /// <returns>Retorna ok e dados do curso do usuários.</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos.")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado.")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno no servidor.")]
        [HttpGet]
        [Route("obter")]
        public async Task<IActionResult> Get(){

            var cursos =new List<CursosViewModelOutput>();
            var CodigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            cursos.Add(new CursosViewModelOutput()
            {
                Login = CodigoUsuario.ToString(),
                Descricao = "Teste",
                Nome = "Teste"
            });
            return Ok(cursos);
        }
    }
}
