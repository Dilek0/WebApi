using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DilekSaylan.WepApiDemo.CustomMiddlewares
{
    public class AuthenticationMiddleware
    {
       
        private readonly RequestDelegate _next; //for move on next middleware
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        //the invoke method corresponding middleware when the request occurs
        //we can access to request or response information with HttpContext object
        public async Task Invoke(HttpContext context)
        {
           string authHeader = context.Request.Headers["Authorization"];//reached Authorization header

            //if not exist Authorization header move on next middleware
            if (authHeader == null)
            {
                await _next(context);
                return;
            }
            //token  dilek:12345
            if (authHeader!=null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                
                var credentialString = "";
                var token = authHeader.Substring(6).Trim() ;//dilek:12345
                try
                {
                    credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));  //encoding authHeader
                }
                catch 
                {
                    context.Response.StatusCode = 500;
                }
                
                var credentials = credentialString.Split(':');
               
                if(credentials[0] == "dilek" && credentials[1]=="12345")
                {
                    var claims = new[] { new Claim("name", credentials[0]),

                        new Claim(ClaimTypes.Role,"Admin")
                    };
                   
                    var identity = new ClaimsIdentity(claims,"basic");
                    context.User = new ClaimsPrincipal(identity);
                }
            }
            else
            {
                context.Response.StatusCode = 401;
            }
            await _next(context);
        }
    }
}
