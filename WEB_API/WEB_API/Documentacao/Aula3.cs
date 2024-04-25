/*
  - Criando um api com ASPNET.CORE  Implementando o JWT na API AULA [3]

  - [3] A primeira coisa é instalar os pacotes no nugget pacotes 
        Microsoft.IdentityModel.Tokens  versao 6,25
        System.IdentityModel.Tokens.Jwt versão 6,25
        Microsoft.AspNetCore.Authentication.JwtBearer 

  - [3] Após a instalcao dos pacotes vamos criar a classe Key nela tera uma chave privada

  - [3] Crie uma pasta Services dentro dela crie uma classe (TokenService) nela será feito
        o processo de CONFIGURAR E GERAR  o token
  
  - [3] Após configurar e gerar o token precisamos validar o mesmo , isso sera feito em program.cs
        observar o codigo que estara lá em destaque com o simbolo [3] , além disso foi adicionado
        um codigo para o swagger poder aceitar a autenticação via JWT também estará destacado com [3]

  - [3] Agora vamos criar um novo controller vazio chamado AuthController ou seja será uma rota
        apenas para autenticação(LOGIN) nesta rota o usuario ira fazer a autenticação

  - [3] Logo depois da criação dessa rota vamos PROTEGER AS DEMAIS ROTAS , então vamos em
        EmployeeController e acima de todas as rotas ou pelo menos aquelas que eu preciso
        de segurança adiciono [Authorize] 
 
 
 
 
 */