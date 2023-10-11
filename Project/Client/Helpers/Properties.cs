using System.Reflection;

namespace Project.Helpers
{
    public static class Properties
    {

        public static PropertyInfo[]? propertyInfos { get; set; }
    }

    public class ApiSettings
    {        
        public string ApiKey { get; set; }
        public string BackEndApiUrl { get; set; }
        public string ExternalApiUrl { get; set; }
        public string DirectGeocoding { get; set; }

    }
}
