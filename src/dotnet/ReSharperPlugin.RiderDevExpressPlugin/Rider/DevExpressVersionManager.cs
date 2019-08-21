using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Application;
using JetBrains.Metadata.Reader.API;
using JetBrains.Metadata.Utils;
using JetBrains.Util;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider
{
    [ShellComponent]
    public class DevExpressVersionManager
    {
        private readonly ILogger myLogger;
        private IReadOnlyCollection<DevExpressVersion> myCachedVersions;

        public DevExpressVersionManager(ILogger logger)
        {
            myLogger = logger;
        }

        [NotNull]
        public IReadOnlyCollection<DevExpressVersion> GetDevExpressVersions()
        {
            return myCachedVersions ?? (myCachedVersions = DiscoverDevExpressVersions());
        }

        private IReadOnlyCollection<DevExpressVersion> DiscoverDevExpressVersions()
        {
            var supportedVersions = new List<DevExpressVersion>();
            var gacAssemblyResolver = DotNetFrameworkGacAssemblyResolver.CreateOnCurrentRuntimeGac(GacResolvePreferences.MatchSameOrNewer);
            foreach (var version in DevExpressVersion.SupportedVersions)
            {
                myLogger.Verbose("Searching for DevExpress '{0}' design assembly", version);
                var targetAssemblyName = AssemblyNameInfo.Parse($"DevExpress.Win.Projects.{version}.Design");
                var assemblyPath = gacAssemblyResolver.TryResolveAssemblyPath(targetAssemblyName);
                if (assemblyPath != null)
                {
                    myLogger.Verbose("DevExpress for version '{0}' found", version);
                    supportedVersions.Add(version);
                }
            }

            return supportedVersions;
        }
    }
}