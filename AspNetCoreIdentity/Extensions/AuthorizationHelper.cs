using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Extensions
{
    public class PermisssaoNecessaria : IAuthorizationRequirement
    {
        public string Permissao { get; set; }

        public PermisssaoNecessaria(string permissao)
        {
            Permissao = permissao;
        }
    }

    public class PermissaoNecessariaHandler : AuthorizationHandler<PermisssaoNecessaria>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermisssaoNecessaria requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Permissao" && c.Value.Contains(requirement.Permissao)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}