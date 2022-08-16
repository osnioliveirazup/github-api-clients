using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using {{inputs.base_namespace}}.Models;
using {{inputs.base_namespace}}.Options;

namespace {{inputs.base_namespace}}.Example
{
    public class {{inputs.client_class}}Example
    {
        private readonly {{inputs.client_class}} _client;

        public {{inputs.client_class}}Example()
        {
            _client = new {{inputs.client_class}}(new HttpClient());
        }

        public async Task<List<GetRepositoriesForUserResponse>> GetRepositoriesForUserAsync(string username)
        {
            // GitHub Api requires a valid User-Agent header to be sent
            // Suggestion is sending (registered) App name or GitHub username
            _client.UserAgent = username;

            var options = new GetRepositoriesForUserOptions
            {
                OwnershipType = OwnershipType.DEFAULT,
                SortBy = SortBy.UPDATED,
                SortDirection = SortDirection.ASC,
                Pagination = new Pagination
                {
                    PerPage = 5,
                    Page = 2
                }
            };

            return await _client.GetRepositoriesForUserAsync(username, options);
        }
    }
}
