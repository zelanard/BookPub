using System.Text.Json;

namespace Utils
{
    public static class ObjectExtensions
    {
        private static readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };
        public static string ToJson(this object obj, bool indented = false)
        {
            if (indented)
            {
                return JsonSerializer.Serialize(obj, options);
            }
            else
            {
                return JsonSerializer.Serialize(obj);
            }
        }
    }
}
