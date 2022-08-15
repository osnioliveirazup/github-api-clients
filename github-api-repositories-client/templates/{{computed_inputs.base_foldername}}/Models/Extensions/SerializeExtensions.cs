using System.Collections.Generic;
using Newtonsoft.Json;

namespace {{inputs.base_namespace}}.Models.Extensions
{
    public static class SerializeExtensions
    {
        public static string ToJson(this List<GetRepositoriesForUserResponse> self)
            => JsonConvert.SerializeObject(self, {{inputs.base_namespace}}.Models.Settings.Converter.Settings);
    }
}
