/*
  - Criando um api com ASPNET.CORE AULA 1

  - Crie um banco de dados postgress no beekeeper e neste banco de dados crie uma tabela  com os campos
    id - name - age - photo
 
  - Usando o Nugget instalar os pacotes Npgsql.EntityFramework(atentar a versao usei aversao 7.0) e Microsoft.EntityFrameworkCore
 
  - Crie uma pasta chamada Model e crie a classe Employee é nesta pasta que sera criada a modelagem dos dados 
    baseado na tabela employee criada la no postgrees

  - Após fazer o codigo das tabelas la no Employee, vamos fazer o repository 
    *  Um repository é uma classe ou interface que fornece uma abstração sobre a fonte de dados, 
    *  seja ela um banco de dados, um serviço web, um arquivo, etc. 
    *  Ele define métodos para realizar operações de CRUD (Create, Read, Update, Delete) e 
    *  oculta os detalhes de implementação específicos da fonte de dados.
    
    Na pasta Model crie uma interface chamada IEmployeeRepository e crie os metodos
 
  - Crie uma pasta chamada Infraestrutura e crie uma classe chamada ConnectionContext
    nela será feito os metodos que vao se  a conetar com o banco de dados

  - Após criar ConnectionContext na mesma pasta(Infraestrutura) crie outra classe chamada
    EmployeeRepository que será aonde será feita a implementação da interface IEmployeeRepository

  - Agora no projeto o instrutor alega que vai trabalhar com algumas injeções de dependência
    e por isso ele foi em Program.cs e adicionou um codigo que estará com registro [ID]

  - Na pasta Controller crie um controller vazio chamado EmployeeController este sera o controller
    onde tera a logica com os gets, posts e delets da api 
    
    OBS: para melhorar o projeto atributos usados no EmployeeController serao feitos na pasta
         ViewModel na classe EmployeeViewModel     
    
  
   
 
 
 
 
 
 
 
 
 */