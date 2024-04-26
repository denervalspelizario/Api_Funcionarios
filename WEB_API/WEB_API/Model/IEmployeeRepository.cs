namespace WEB_API.Model
{
    public interface IEmployeeRepository
    {
        // Metodos
        void Add(Employee employee); // Adicionando Funcionarios

        List<Employee> GetAll(); // Listando Funcionarios

        /* [4] Este metodo ira listar todos igual ao GetAll porem recebera 2 parametros
               (numero da pagina(pageNumber) e quantidade quantidade de itens que será 
               retornado(pageQuantity)) para fazer a paginação */
        List<Employee> GetAllPag(int pageNumber, int pageQuantity);

        Employee? Get(int id); // [2] Retorna um funcionario pode retorna nulo
    }
}
