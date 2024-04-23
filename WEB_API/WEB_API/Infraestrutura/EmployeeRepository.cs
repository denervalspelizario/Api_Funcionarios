using WEB_API.Model;

namespace WEB_API.Infraestrutura
{
    // Aqui sera feito toda a implementação da interface IEmployeeRepository
    public class EmployeeRepository : IEmployeeRepository
    {
        // Chamando a propriedade que recebe os dados do contexto do bd 
        private readonly ConnectionContext _context = new ConnectionContext();
        
        // Metodo de adição de funcionario
        public void Add(Employee dadoFuncioanrio)
        {
             /* Recebendo os dados do funcionando pelo pelo parametro(dadoFuncionario)
              e atravez do _context acesso a tabela de funcionario(Employees)
             e usando o método Add adiciono a tabela os dados do funcionario(dadoFuncionario)*/
            _context.Employees.Add(dadoFuncioanrio);

            // Salvando a alteração
            _context.SaveChanges();
        }


        // Método que lista todos os funcionarios
        public List<Employee> GetAll()
        {
            /* Atravéz do _context acessa a tabela de funcionarios(Employees) e 
               usando o metodo ToList retorna todos os funcioanrios listados */
            return _context.Employees.ToList();
        }

        // [2] Método que retorna os dados de um funcionario especifico
        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
