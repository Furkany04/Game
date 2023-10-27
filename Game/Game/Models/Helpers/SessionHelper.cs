using Newtonsoft.Json;

namespace Game.Models.Helpers
{
    public static class SessionHelper
    {
        public static int Count { get; set; }
        public static string navType { get; set; }
        public static void SetAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
