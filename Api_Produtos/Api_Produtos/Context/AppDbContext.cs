using Api_Produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Produtos.Context
{
    // ADICIONANDO A CLASSE APPDBCONTEXT POR HERANCA OS METODOS DO DBCONTEXT DO ENTITYFRAMEWORKCORE
    /*
     Essa classe AppDbContext é essencial para o funcionamento do Entity Framework Core em sua aplicação ASP.NET Core. 
     Ela define o contexto do banco de dados e fornece acesso aos objetos DbSet que representam as tabelas do banco de dados, 
     permitindo que você execute operações de CRUD e consultas LINQ nos dados do banco de dados.
     */
    public class AppDbContext : DbContext
    {
        // CONSTRUTOR
        // RESPONSÁVEL POR COMUNICAR MINHAS ENTIDADES E O BANCO RELACIONAL
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        // PRORPRIEDADES
        /* Define uma propriedade categorias que representa uma coleção de objetos da entidade Categoria. 
         * Esta propriedade será mapeada para uma tabela chamada categorias no banco de dados */
        public DbSet <Categoria> categorias { get; set; }
        public DbSet <Produto>  produtos { get; set; }
    }
}
