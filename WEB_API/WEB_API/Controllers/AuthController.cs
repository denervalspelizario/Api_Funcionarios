using Microsoft.AspNetCore.Mvc;
using WEB_API.Services;

namespace WEB_API.Controllers
{
    // [3] ROTA DE LOGIN(AUTENTICAÇÃO)
    [ApiController]        // Definfindo que é um controller
    [Route("api/v1/login")] // nome da rota
    public class AuthController : Controller 
    {
        // Rota tipo Post que receberá pelo body 2 argumentos
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Se o user e a senha for estes que eu adicionei
            if(username == "vaval" && password == "vaval0645")
            {
                // gero o token a partir de um funcionario vazio
                var token = TokenService.GenerateToken(new Model.Employee());

                // Retorno metodo OK(status 200) com o dados do token gerado
                return Ok(token);
            }

            // se caso user for incorreto então retorno o metodo BadRequest com a msg abaixo
            return BadRequest("username or password invalid");
        }
    }
}
