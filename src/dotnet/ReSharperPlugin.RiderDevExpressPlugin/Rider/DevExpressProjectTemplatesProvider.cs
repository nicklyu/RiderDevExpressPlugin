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
        private readonly RiderDevExpressPluginModel myPluginModel;

        public DevExpressProjectTemplatesProvider(RiderDevExpressPluginModel pluginModel)
        {
            myPluginModel = pluginModel;
        }

        public IReadOnlyCollection<FileSystemPath> GetSources(bool creatingSolution)
        {
            var path = myPluginModel.PluginTemplatesPath.Value;
            return null;
        }
    }
}