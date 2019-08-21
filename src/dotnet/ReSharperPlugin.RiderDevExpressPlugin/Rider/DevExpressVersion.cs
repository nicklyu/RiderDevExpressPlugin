using System.Collections.Generic;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider
{
    public class DevExpressVersion
    {
        private readonly string myVersion;

        private DevExpressVersion(string version)
        {
            this.myVersion = version;
        }

        public override string ToString()
        {
            return myVersion;
        }

        private static DevExpressVersion V191 => new DevExpressVersion("v19.1");
        private static DevExpressVersion V182 => new DevExpressVersion("v18.2");
        private static DevExpressVersion V181 => new DevExpressVersion("v18.1");
        private static DevExpressVersion V172 => new DevExpressVersion("v17.2");
        private static DevExpressVersion V171 => new DevExpressVersion("v17.1");


        public static IEnumerable<DevExpressVersion> SupportedVersions => new[]
        {
            V191,
            V182,
            V181,
            V172,
            V171,
        };
    }
}