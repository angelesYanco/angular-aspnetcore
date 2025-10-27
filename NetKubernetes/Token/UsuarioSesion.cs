using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetKubernetes.Token
{
    public class UsuarioSesion
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioSesion(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string ObtenerUsuarioSesion()
        {
            var userName = _httpContextAccessor.HttpContext!.User?.Claims?
                            .FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            return userName!;
        }
    }
}