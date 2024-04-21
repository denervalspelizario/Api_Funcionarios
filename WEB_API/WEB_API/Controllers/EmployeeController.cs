using Microsoft.AspNetCore.Mvc;
using WEB_API.Model;

namespace WEB_API.Controllers
{
    [ApiController]
    [Route("api/v1/employee")] // indicando o nome da rota
    public class EmployeeController : ControllerBase
    {
        /* chamando a interface IEmployeeRepository lembrando que ela tem 2 metodos
           1 de adicionar um funcionario e 2 de listar funcionarios */
        private readonly IEmployeeRepository _employeeRepository;

        /* Construtor QUE RECEBE COMO PARAMETRO IEmployeeRepository lembre-se 
           TODA VEZ QUE VC FOR USAR UM METODO COMO TIPO DE UMA PROPRIEDADE 
           COMO O CASO ACIMA VC SEMPRE TEM QUE GERAR ESSE CONSTRUTOR SENÃO NÃO FUNCIONA */
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
