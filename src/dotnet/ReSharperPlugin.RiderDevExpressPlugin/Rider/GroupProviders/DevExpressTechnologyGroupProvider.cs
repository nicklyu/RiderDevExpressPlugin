using System.Collections.Generic;
using JetBrains.Application;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetExtensions;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetTemplates;
using Microsoft.TemplateEngine.Edge.Settings;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider.GroupProviders
{
    [ShellComponent]
    public class DevExpressTechnologyGroupProvider : IDotNetTemplateGroupProvider
    {
        private const string DevExpressTemplateTag = "technology";
        public int Priority => 15;

        public IReadOnlyCollection<DotNetTemplateGroup> Get()
        {
            return new[] {new DevExpressTechnologyGroup()};
        }

        private class DevExpressTechnologyGroup : DotNetTemplateGroup
        {
            protected override bool ShowIfSingleTemplate => true;

            public DevExpressTechnologyGroup() : base("Technology", null)
            {
            }

            protected override string GetOption(TemplateInfo info)
            {
                return info.GetTagValue(DevExpressTemplateTag);
            }
        }
    }
}