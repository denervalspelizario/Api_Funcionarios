using Microsoft.EntityFrameworkCore;
using WEB_API.Model;

namespace WEB_API.Infraestrutura
{
    /* Essa classe vamos fazer o contexto para linkar com o banco de dados
       ela vai herdar a classe DbContext do EntityFramework */
    public class ConnectionContext : DbContext
    {
        // Essa propriedade Employees que meio que faz o mapeamento
        public DbSet<Employee> Employees { get; set; }


        /*Aqui será o método onde eu sobreescrever OnConfiguring e adicionar os dados 
        do banco que eu criei antes de iniciar o projeto no caso o banco PrimeiraAPI
        conferir os dados pelo beekeeper */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost" +
                "Port=5432;Database=PrimeiraAPI;" +
                "User Id=postgres;" +
                "Password=vaval0645;"); 
    }
}
