using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WEB_API.Model;

namespace WEB_API.Services
{
    // [3] Esta classe será responsavel por gerar o token
    public class TokenService
    {
        public static object GenerateToken(Employee employee)
        {

            // [3] CONFIGURANDO O TOKEN

            /* [3] chamando a chave privada criada la no Key.cs
                   ja adicionando uma nova criptografia */
            var key = Encoding.ASCII.GetBytes(Key.Secret);

            // [3] configurando meu token
            var tokenConfig = new SecurityTokenDescriptor
            {
                /* [3] Definindo o meu payload, estou dizendo que vou salvar dentro do meu 
                       token o id do funcionario(employee.id) */
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("employeeId", employee.id.ToString())
                }),

                // [3] definindo o tempo de expiração do token
                Expires = DateTime.UtcNow.AddHours(3),


                /*  [3] dfinindo o TIPO de assinatura, no jwt temos que determinar além da chave 
                        privada (key) temos de indicar o tipo de criptografia
                        no caso foi de finido HmacSha256Signature */
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                                     SecurityAlgorithms.HmacSha256Signature)
            };

            /* [3] ATÉ AQUI FOI O PROCESSO DE CONFIGURAR O TOKEN, DAQUI PARA BAIXO SERÁ O PROCESSO
                   DE GERAR O TOKEN DE FATO */


            // [3] instaciamos classe(JwtSecurityTokenHandler) que é responsável por gerar e manipular tokens JWT.
            var tokenHandler = new JwtSecurityTokenHandler();

            // [3] Aqui, criamos o token JWT usando o tokenConfig que configuramos anteriormente.
            var token = tokenHandler.CreateToken(tokenConfig);

            // [3] Escrevemos o token JWT como uma string.
            var tokenString = tokenHandler.WriteToken(token);

            /* [3] O PROCESSO DE DE CRIAR O TOKEN É
                   CONFIGURA O TOKEN > CRIA O TOKEN > ADICIONA A CONFIGS AO TOKEN > 
                   TRANFORMA TOKEN EM STRING > RETORNA O TOKEN  */


            /* [3] retornamos um objeto anônimo contendo a string do token JWT.
                Este objeto é então retornado como resultado da chamada do método GenerateToken.*/
            return new 
            {
                token = tokenString
            };
        }
    }
}
