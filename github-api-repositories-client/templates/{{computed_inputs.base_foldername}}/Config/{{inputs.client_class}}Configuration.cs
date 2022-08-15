namespace {{inputs.base_namespace}}.Config
{
    public static class {{inputs.client_class}}Configuration
    {
        public const string DefaultUserAgent = "StackSpot GitHub Repositories Api plugin"; // Unregistered!

        public const string BaseUrl = "https://api.github.com/";

        public const string GetRepositoriesForUserEndpoint = "users/{0}/repos"; // GET /users/{username}/repos
    }
}
