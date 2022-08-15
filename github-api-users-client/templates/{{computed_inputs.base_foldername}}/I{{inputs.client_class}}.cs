using System.Threading.Tasks;
using {{inputs.base_namespace}}.Models;

namespace {{inputs.base_namespace}}
{
    public interface I{{inputs.client_class}}
    {
        public Task<GetUserResponse> GetUserAsync(string username);
    }
}
