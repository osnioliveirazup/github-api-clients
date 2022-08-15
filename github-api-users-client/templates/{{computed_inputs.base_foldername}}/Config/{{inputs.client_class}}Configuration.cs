namespace {{inputs.base_namespace}}.Config
{
    public static class {{inputs.client_class}}Configuration
    {
        public const string DefaultUserAgent = "StackSpot GitHub Users Api plugin"; // Unregistered!

        public const string BaseUrl = "https://api.github.com/";

        public const string GetUserEndpoint = "users/{0}"; // GET /users/{username}
    }
}
