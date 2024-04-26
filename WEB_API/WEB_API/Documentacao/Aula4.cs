/*
  - Criando um api com ASPNET.CORE / PAGINAÇÃO[4] / LOGGER[5] / TRATAMENTO DE ERROS[6]

    [4]PAGINCAO
  - [4] Vamos iniciar com a Paginação va em Model > IEmployeeRepository e faca o metodo
        que ira ser a base da rota para fazer a paginação
   
  - [4] Depois va em EmployeeRepository e usando a base do metodo criado no IEmployeeRepository
        defina a logica da rota

  - [4] Assim que foi definido a logica da rota, vamos de fato criar a nova rota no EmployeeController
        la sera criado a rota com o metodo definido no EmployeeRepository 

    [5] LOGGER
  - [5] Va em EmployeeController  e adicione a propriedade ILOgger, adicionar no construtor e depois
        adicionar a propriedade e a logica do _lloger na rota que vc deseja neste caso vamos fazer
        no Get lá tera 2 logs 


  - [6] Tratamento de Erros
    [6] em Controllers adicione um novo controlador vazio chamado ThrowController atentar que ele
        sera ignorado pela api só sera tivado quando ocorrer um erro, nele terao 2 tipos de rota 
        de erro 1 - a de erro geral  e 2 erro na area de desenvolvimento

  - [6] Proximo passo ir em Program.cs e la direcionar os erros atravez do metodo 
        UseExceptionHandler, direcionando erros tanto em area de produção quanto desenvolvimento
  
 
 
 
 */