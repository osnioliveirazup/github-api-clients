using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using {{inputs.base_namespace}}.Config;
using {{inputs.base_namespace}}.Models;
using {{inputs.base_namespace}}.Options;

namespace {{inputs.base_namespace}}
{
    public class {{inputs.client_class}} : I{{inputs.client_class}}
    {
        private readonly HttpClient _httpClient;

        public string UserAgent { get; set; } = {{inputs.client_class}}Configuration.DefaultUserAgent;

        public {{inputs.client_class}}(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            _httpClient.BaseAddress = new Uri({{inputs.client_class}}Configuration.BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github+json")
            );
        }

        //
        // Documentation:
        // https://docs.github.com/en/rest/repos/repos#list-repositories-for-a-user
        //
        public async Task<List<GetRepositoriesForUserResponse>> GetRepositoriesForUserAsync(string username)
        {
            return await GetRepositoriesForUserAsync(username, GetRepositoriesForUserOptions.DefaultOptions());
        }

        public async Task<List<GetRepositoriesForUserResponse>> GetRepositoriesForUserAsync(string username, GetRepositoriesForUserOptions options)
        {
            var endpoint = string.Format({{inputs.client_class}}Configuration.GetRepositoriesForUserEndpoint, username);
            var uri = $"{endpoint}?{options.ToQueryString()}";

            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                // GitHub Api requires a valid User-Agent header to be sent
                // Suggestion is sending (registered) App name or GitHub username
                httpRequestMessage.Headers.Add("User-Agent", UserAgent);

                using (var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage))
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    return await httpResponseMessage.Content.ReadAsAsync<List<GetRepositoriesForUserResponse>>();
                }
            }
        }
    }
}
