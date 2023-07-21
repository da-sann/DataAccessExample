using AutoMapper;

namespace DataAccessExample.Helpers
{
    public class MapperConfig
    {
        public static void Initialize(IConfigurationProvider provider)
        {
            _instance = provider ?? throw new ArgumentNullException(nameof(provider));
        }
        private static IConfigurationProvider _instance;
        public static IConfigurationProvider Instance
        {
            get
            {
                return _instance ?? throw new NullReferenceException(nameof(_instance));
            }
        }
    }
}
