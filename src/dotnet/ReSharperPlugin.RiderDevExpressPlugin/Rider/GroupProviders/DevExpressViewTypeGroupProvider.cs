using System.Collections.Generic;
using JetBrains.Application;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetExtensions;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetTemplates;
using Microsoft.TemplateEngine.Edge.Settings;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider.GroupProviders
{
    [ShellComponent]
    public class DevExpressViewTypeGroupProvider : IDotNetTemplateGroupProvider
    {
        private const string ViewTypeTag = "viewType";

        public int Priority => 29;

        public IReadOnlyCollection<DotNetTemplateGroup> Get()
        {
            return new[] {new DevExpressViewTypeGroup()};
        }

        private class DevExpressViewTypeGroup : DotNetTemplateGroup
        {
            public DevExpressViewTypeGroup() : base("View Type", null)
            {
            }

            protected override string GetOption(TemplateInfo info)
            {
                return info.GetTagValue(ViewTypeTag);
            }
        }
    }
}