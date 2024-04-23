namespace WEB_API.Model
{
    public interface IEmployeeRepository
    {
        // Metodos
        void Add(Employee employee); // Adicionando Funcionarios

        List<Employee> GetAll(); // Listando Funcionarios

        Employee? Get(int id); // [2] Retorna um funcionario pode retorna nulo
    }
}
