using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WEB_API.Infraestrutura;
using WEB_API.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

/*[3] Alterando a configuração do swagger para aceitar a autenticação isso é opcional
      se for usar Insomminia ou Postamn não precisa */
builder.Services.AddSwaggerGen(c =>
{
    //c.OperationFilter<SwaggerDefaultValues>();

    // Definindo o tipo de autenticação
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Requerimento de autenticação
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
    {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        },
        new List<string>()
        }
    });
});







/* [ID] 
   Toda vez que eu fizer uma transação  a minha interface IEmployeeRepository
   vai implementar a classe EmployeeRepository */
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();


// [3] CODIGO DE VALIDAÇÃO DO TOKEN
var key = Encoding.ASCII.GetBytes(WEB_API.Key.Secret);

builder.Services.AddAuthentication(x =>
{
    /* Definindo qual metodo para fazer a autenticação NO CASO SERA O JWT
       OBS PRECISEI INSTALAR O PACOTE Microsoft.AspNetCore.Authentication.JwtBearer 
       PARA CHAMAR OS METODOS JwtBearerDefaults */
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    // Processo do JWT como será feito a autenticação
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false; // indicando que no momento não precisa de https
    x.SaveToken = true; // use o Savetoken

    x.TokenValidationParameters = new TokenValidationParameters // Indicando os parametros do Token
    {
        ValidateIssuerSigningKey = true, // tera validação de assinatura
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Ambiente de desenvolvimento 
{
    /* [6] Se estiver dentro do ambiente de desenvolvimento redireciono todos os
     * meu erros para a rota error-development */
    app.UseExceptionHandler("/error-development");

    app.UseSwagger();
    app.UseSwaggerUI();
}
else  // [6] Se estiver for do desenvolvimento ou seja se for em produção
{
    app.UseExceptionHandler("/error"); //[6] os erros serão direcionandos para rota error
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
