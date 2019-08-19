using System.Collections.Generic;
using JetBrains.Application;
using JetBrains.Metadata.Reader.API;
using JetBrains.Metadata.Utils;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetTemplates;
using JetBrains.Util;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider
{
    [ShellComponent]
    public class DevExpressProjectTemplatesProvider : IDotNetTemplateSource
    {
        private readonly FileSystemPath myTemplatesDirectoryPath;

        private readonly List<string> mySupportedVersions = new List<string>
        {
            "19.1"
        };

        public DevExpressProjectTemplatesProvider()
        {
            var assemblyLocation = FileSystemPath.Parse(typeof(DevExpressProjectTemplatesProvider).Assembly.Location);
            myTemplatesDirectoryPath = assemblyLocation.Parent / "templates";
        }

        public IReadOnlyCollection<FileSystemPath> GetSources(bool creatingSolution)
        {
            var gacAssemblyResolver = DotNetFrameworkGacAssemblyResolver.CreateOnCurrentRuntimeGac(GacResolvePreferences.MatchSameOrNewer);

            var templatesDirectoriesList = new List<FileSystemPath>();
            foreach (var supportedVersion in mySupportedVersions)
            {
                var targetAssemblyName = AssemblyNameInfo.Parse($"DevExpress.Win.Projects.v{supportedVersion}.Design");
                var assemblyPath = gacAssemblyResolver.TryResolveAssemblyPath(targetAssemblyName);
                if (assemblyPath != null)
                {
                    templatesDirectoriesList.Add(myTemplatesDirectoryPath / supportedVersion);
                }
            }


            return templatesDirectoriesList;
        }
    }
}