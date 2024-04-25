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

/*[3] Alterando a configura��o do swagger para aceitar a autentica��o isso � opcional
      se for usar Insomminia ou Postamn n�o precisa */
builder.Services.AddSwaggerGen(c =>
{
    //c.OperationFilter<SwaggerDefaultValues>();

    // Definindo o tipo de autentica��o
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Requerimento de autentica��o
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
   Toda vez que eu fizer uma transa��o  a minha interface IEmployeeRepository
   vai implementar a classe EmployeeRepository */
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();


// [3] CODIGO DE VALIDA��O DO TOKEN
var key = Encoding.ASCII.GetBytes(WEB_API.Key.Secret);

builder.Services.AddAuthentication(x =>
{
    /* Definindo qual metodo para fazer a autentica��o NO CASO SERA O JWT
       OBS PRECISEI INSTALAR O PACOTE Microsoft.AspNetCore.Authentication.JwtBearer 
       PARA CHAMAR OS METODOS JwtBearerDefaults */
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    // Processo do JWT como ser� feito a autentica��o
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false; // indicando que no momento n�o precisa de https
    x.SaveToken = true; // use o Savetoken

    x.TokenValidationParameters = new TokenValidationParameters // Indicando os parametros do Token
    {
        ValidateIssuerSigningKey = true, // tera valida��o de assinatura
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
