using Microsoft.AspNetCore.Mvc;
using WEB_API.Model;
using WEB_API.ViewModel;

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


        /* Metodo Get 
           que retorna status 200 mais a lista de todos os funcioanrios asicionados na tabela employee */
        [HttpGet]
        public IActionResult Get() 
        {
            // pegando a lista de funcionarios e adicionando na variável employee
            var employee = _employeeRepository.GetAll();

            // retorno Ok que é um metodo de IActionResult que retorna um status 200 e a lista de funcionarios
            return Ok(employee);
        }


        /* Metodo POST 
           que retorna IActionResult e recebe como parametro um tipo
           EmployeeViewModel(name e age) e adiciona os dados de um funcionario a tabela employee*/
        /*[2] Para receber adicionar uma anotação no parametro adicionando [FromForm] isto fara
              com que a adição de dados sera feita como se fosse um formulario mesmo */
        [HttpPost]
        public IActionResult Add([FromForm]EmployeeViewModel employeeView)
        {
            /*[2] Criando uma variavel que pega o caminho onde o arquivo photo foi salvo
                  Esse Combine vai montar uma especie de Url  */    
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);


            /*[2] Para salvar o arquivo crie um objeto fileStream que será usado para
                  acessar e manipular o arquivo */
            using Stream fileStream = new FileStream(filePath, FileMode.Create);

            /*[2] Copiando os dados de Photo e adicionando essa copia em fileStream */
            employeeView.Photo.CopyTo(fileStream);

            /* employee um objeto que instancia a classe Employee que tem por estrutura 3 dados 
               name age e photo(que neste caso será null)*/
            //[2] Anteriormente na aula 1 o ultimo campo era null depois de criar a estrutura
            // para receber os dados  retirei o null e adicionei o filePath
            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

            // adicionado o objeto employee no repository de funcionarios
            _employeeRepository.Add(employee);

            // retornando Ok que é um metodo de IActionResult que retorta um status 200
            return Ok();
        }

        /* [2] Método Post  
         * Que retorna a foto do usuario de acordo com o ID passado
         * Como essa rota tambem é um post eu preciso definir um novo nome dela*/
        [HttpPost]
        [Route("{id}/download")] //[2] Definindo nome da rota
        public IActionResult DownloadPhoto(int id)
        {
            // Estou pegando o funcionario atravez do metodo get
            var employee = _employeeRepository.Get(id);

            /* Usando o metodo File que vai gerar um arquivo baseado no caminho da foto(arquivo) 
               do user escolhido pelo id  */
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            /* retornando um File um dado sobre o parametro 
               1 - defino qual é o dado , 2 - defino qual o formato do dado que eu quero retornar */
            return File(dataBytes, "image/png");
        }
    }
}
