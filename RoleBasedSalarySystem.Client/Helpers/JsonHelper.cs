using System.Text.Json;

namespace RoleBasedSalarySystem.Client.Helpers
{
    public static class JsonHelper<T> where T : class
    {
        private static JsonSerializerOptions Options => new JsonSerializerOptions 
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static T Deserialize(string json)
        {
            return JsonSerializer.Deserialize<T>(json, Options);
        }

        public static string Serialize(T obj)
        {
            return JsonSerializer.Serialize(obj, Options);
        }
    }
}
