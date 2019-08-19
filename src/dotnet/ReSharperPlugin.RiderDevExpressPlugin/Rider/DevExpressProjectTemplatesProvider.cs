using System.Collections.Generic;
using JetBrains.Application;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetTemplates;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider
{
    [ShellComponent]
    public class DevExpressProjectTemplatesProvider : IDotNetTemplateSource
    {
        private readonly FileSystemPath myTemplatesDirectoryPath;

        public DevExpressProjectTemplatesProvider()
        {
            var assemblyLocation = FileSystemPath.Parse(typeof(DevExpressProjectTemplatesProvider).Assembly.Location);
            myTemplatesDirectoryPath = assemblyLocation.Parent/ "templates";
        }

        public IReadOnlyCollection<FileSystemPath> GetSources(bool creatingSolution)
        {
            return new[] {myTemplatesDirectoryPath / "19.1"};
        }
    }
}