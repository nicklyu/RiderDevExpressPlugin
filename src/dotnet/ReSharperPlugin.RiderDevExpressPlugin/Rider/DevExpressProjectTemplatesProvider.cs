using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using JetBrains.Annotations;
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
        public DevExpressProjectTemplatesProvider()
        {
            var assemblyLocation = FileSystemPath.Parse(typeof(DevExpressProjectTemplatesProvider).Assembly.Location);
            myTemplatesDirectoryPath = assemblyLocation.Parent / "templates";
        }

        public IReadOnlyCollection<FileSystemPath> GetSources(bool creatingSolution)
        {
            return new[] {myTemplatesDirectoryPath};
        }
    }
}