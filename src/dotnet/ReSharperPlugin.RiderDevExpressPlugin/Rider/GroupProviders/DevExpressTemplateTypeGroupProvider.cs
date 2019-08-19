using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Application;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetExtensions;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetTemplates;
using Microsoft.TemplateEngine.Edge.Settings;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider.GroupProviders
{
    [ShellComponent]
    public class DevExpressTemplateTypeGroupProvider : IDotNetTemplateGroupProvider
    {
        private const string TemplateTypeTag = "templateType";


        public int Priority => 15;

        public IReadOnlyCollection<DotNetTemplateGroup> Get()
        {
            return new[] {new DevExpressTemplateTypeGroup()};
        }

        private class DevExpressTemplateTypeGroup : DotNetTemplateGroup
        {
            public DevExpressTemplateTypeGroup() : base("Template Type", null)
            {
            }

            protected override string GetOption(TemplateInfo info)
            {
                return info.GetTagValue(TemplateTypeTag);
            }
        }
    }
}