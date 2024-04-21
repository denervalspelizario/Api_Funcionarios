using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API.Model
{
    /*Como a tabela no bd esta employee e nao Employee como esta classe aqui
         é necessario uma alteração usando o dataannotations Table*/
    [Table("employee")]
    public class Employee
    {
        // Propriedades
        [Key] // indicando chave primaria
        public int id { get; private set; }
        public string name { get; private set; }
        public int age { get; private set; }
        public string? photo { get; private set; } // como a foto é opcional adicionei ? para poder ser nulo

        // Construtor
        public Employee(string name, int age, string photo)
        {
            this.name = name;
            this.age = age;
            this.photo = photo;
        }
    }
}
