using Microsoft.Owin.Security.OAuth;
using ProximaFase.Models;
using ProximaFase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ProximaFase.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public UsuarioService _usuarioService;
        public ApplicationOAuthProvider()
        {
            _usuarioService = new UsuarioService(new ProximaFaseContext());
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext c)
        {
            c.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext c)
        {
            // Aqui você deve implementar sua regra de autenticação
            if (_usuarioService.UsuarioExiste(c.UserName, c.Password))
            {
                Claim claim1 = new Claim(ClaimTypes.Name, c.UserName);
                Claim[] claims = new Claim[] { claim1 };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(
                       claims, OAuthDefaults.AuthenticationType);
                c.Validated(claimsIdentity);
            }

            return Task.FromResult<object>(null);
        }
    }
}