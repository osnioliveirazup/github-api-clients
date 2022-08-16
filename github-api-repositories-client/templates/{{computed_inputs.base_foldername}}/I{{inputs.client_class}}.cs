using System.Collections.Generic;
using System.Threading.Tasks;
using {{inputs.base_namespace}}.Models;
using {{inputs.base_namespace}}.Options;

namespace {{inputs.base_namespace}}
{
    public interface I{{inputs.client_class}}
    {
        public Task<List<GetRepositoriesForUserResponse>> GetRepositoriesForUserAsync(string username);

        public Task<List<GetRepositoriesForUserResponse>> GetRepositoriesForUserAsync(string username, GetRepositoriesForUserOptions options);
    }
}
