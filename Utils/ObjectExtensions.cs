using System.Collections;
using System.Reflection;
using System.Text.Json;

namespace Utils
{
    /// <include file = 'Documentation/ObjectExtensions.xml' path='doc/objectextensions/member[@name="T:Utils.ObjectExtensions"]' />
    public static class ObjectExtensions
    {
        private static readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };

        /// <include file = 'Documentation/ObjectExtensions.xml' path='doc/objectextensions/member[@name="M:Utils.ObjectExtensions.ToJson"]' />
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

        /// <include file = 'Documentation/ObjectExtensions.xml' path='doc/objectextensions/member[@name="M:Utils.ObjectExtensions.HasProperties"]' />
        public static bool HasProperties(this object obj)
        {
            if (obj == null) return false;

            var type = obj.GetType();

            // Check if it's a dictionary (ExpandoObject included)
            if (obj is IDictionary dictionary)
            {
                return dictionary.Count > 0;
            }

            // Check if it's a collection
            if (obj is IEnumerable enumerable && !(obj is string))
            {
                return enumerable.Cast<object>().Any();
            }

            // Standard property check
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            return properties.Length > 0 && properties.Any(p => p.GetValue(obj) != null);
        }
    }
}