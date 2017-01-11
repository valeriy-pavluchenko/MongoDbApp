using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MongoDbApp.Web.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetAppSettings(this IConfiguration configuration, string name)
        {
            if (configuration == null)
            {
                return (string)null;
            }

            var section = configuration.GetSection("AppSettings");

            if (section == null)
            {
                return (string)null;
            }

            return section[name];
        }

        public static JObject GetSettingsObject(this IConfiguration configuration, string name)
        {
            if (configuration == null)
            {
                return (JObject)null;
            }

            var section = configuration.GetSection("AppSettings");

            if (section == null)
            {
                return (JObject)null;
            }

            return JsonConvert.DeserializeObject<JObject>(section.Value);
        }
    }
}
