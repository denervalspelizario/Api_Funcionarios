using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WEB_API.Controllers
{
    /* [6]  Rota de tratamento de erro  */
    [ApiExplorerSettings(IgnoreApi = true)] // [6] indicando que não faz parte dos metodos da api
    public class TrowControllerController : ControllerBase
    {
        /*[6] define que a ação HandleError será acessada quando uma requisição for feita para 
         * a rota /error. quando ocorrer um erro na aplicação e o middleware 
         * de tratamento de erros redirecionar para essa rota, esta ação será executada.*/
        [Route("/error")]


        /*[6] Quando essa ação é acionada, ela retorna um resultado representando um erro genérico 
         * usando o método Problem(). Este padrão é comumente usado em APIs para lidar com erros 
         * de forma consistente e fornecer respostas padronizadas para os clientes.*/
        public IActionResult HandleError() => Problem();


        /*[6] Se erro for dentro da area de desenvolvimento*/
        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
            [FromServices] IHostEnvironment hostEnvironment)
        {
            // [6]
            if(!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            // [6] acessando a exception(erro) para saber qual sera o problema
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;


            // [6] Retorna o metodo Problema dizendo..
            return Problem(
                
                // [6] Qual é o erro de maneira detalhada 
                detail: exceptionHandlerFeature.Error.StackTrace,
                
                // [6] Qual o titulo de problema
                title: exceptionHandlerFeature.Error.Message
         
                );
        }
    }
}
