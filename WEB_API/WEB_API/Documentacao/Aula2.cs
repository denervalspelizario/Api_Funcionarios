/*
 - Criando um api com ASPNET.CORE  Enviar e Baixar Arquivos AULA [2]
 
 - [2] Para poder enviar e receber arquivos pela api precisamos fazer algumas 
       alteraçoes em EmployeeController faça a alteração em Post o parametro
       adicionando o FromForm

 - [2] Depois va para EmployeeViewModel e adicione a propriedade para adicionar
       arquivos pois anteriomente somente estava Name e Age 
 
 - [2] Crie uma pasta chamada Storage
       Obs: será nesta pasta onde fica os arquivos, no banco fica apenas 
            o caminho dos arquivos  
 
 - [2] Depois de criar a pasta volte no controller EmployeeController e no
       post adicione o codigo para  guardar o arquivo adicionado no storage e o caminho 
       dela no banco de dados

 - [2] Neste projeto vamos criar uma rota para baixar a foto(que esta no Storage) de acordo 
       com a requisição, vá em IEmployeeRepository e adicione um metodo que retorna 
       apenas 1 funcionario de acordo com o id passado
       depois vá em Infraestrutura > EmployeeRepository e implemente a interface que falta
       que no caso sera a Employee que retorna os dados de funcionario baseado no id passado,
       então va para Controllers > EmployeeController  e crie a nova rota
 
 
 
 
 
 
 
 
 
 
 
 
 
 */