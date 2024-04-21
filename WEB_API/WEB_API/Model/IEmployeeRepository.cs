namespace WEB_API.Model
{
    public interface IEmployeeRepository
    {
        // Metodos
        void Add(Employee employee); // Adicionando Funcionarios

        List<Employee> Get(); // Listando Funcionarios
    }
}
