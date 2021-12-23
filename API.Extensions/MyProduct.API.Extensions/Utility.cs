using System.Linq;
using System.Reflection;

namespace MyProduct.API.Extensions
{
    internal static class Utility
    {
        private static string CurrentServiceName;

        /// <summary>
        /// To get the CurrentServicename
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentServiceName()
        {
            if (string.IsNullOrWhiteSpace(CurrentServiceName))
            {
                //Taking second last strings from a service
                var currentAssembly = Assembly.GetEntryAssembly();
                var serviceName = currentAssembly.FullName.Split(",").FirstOrDefault();

                if (serviceName.Contains("."))
                    serviceName = serviceName.Split(".").TakeLast(2).FirstOrDefault();

                CurrentServiceName = serviceName;
            }

            return CurrentServiceName;
        }
    }
}
