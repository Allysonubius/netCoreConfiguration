using curso.api.Business.Entity;
using curso.api.Filter;
using curso.api.Infra.Data;
using curso.api.Models;
using curso.api.Models.Banco;
using curso.api.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NPoco.Expressions;
using OpenXmlPowerTools;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase{
        
        private object usuarioViewModelOutput;

        /// <summary>
        /// Login do usuário.
        /// </summary>
        /// <param name="loginViewModelInput"></param>
        /// <returns>Retorna ok no ato de login do usuário</returns>
        [SwaggerResponse(statusCode:200, description:"Sucesso ao autenticar.",Type= typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode:400, description: "Campos obrigatórios.", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode:500, description: "Erro interno no servidor.", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("login")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput) {

            var usuarioViewModelOutput = new UsuarioViewModelOutput(){
                Codigo = 1,
                Login = "Allyson",
                Email = "Allyson@email.com"
            };

            var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>!9$Es(X!5g@;ef!5sbk:jH\\2.}8ZP'qY#7");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor{

                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email,usuarioViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok( new {
                Token = token,
                Usuario = usuarioViewModelOutput
            });
        }

        /// <summary>
        /// Registro do usuário.
        /// </summary>
        /// <param name="registrarViewModelInput"></param>
        /// <returns>Retorna criado registro novo do usuário.</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao autenticar.", Type = typeof(RegistrarViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios.", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno no servidor.", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistrarViewModelInput registrarViewModelInput){

            var options = new DbContextOptionsBuilder<CursoDbContext>();
            options.UseSqlServer("Server=localhost;Database=CURSO;user=sa;password=App@223020");
            CursoDbContext contexto = new CursoDbContext(options);
            //Convertendo 
            var usuario = new Usuario();
            usuario.Email = registrarViewModelInput.Login;
            usuario.Senha = registrarViewModelInput.Senha;
            usuario.Email = registrarViewModelInput.Email;

            _ = contexto.Usuario.Add(usuario);
            contexto.SaveChanges();

            return Created("Registro realizado com sucesso ! ", registrarViewModelInput);
        }
    }
}
