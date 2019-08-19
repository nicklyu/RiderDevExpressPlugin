using System.Collections.Generic;
using JetBrains.Application;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetExtensions;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetTemplates;
using Microsoft.TemplateEngine.Edge.Settings;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider.GroupProviders
{
    [ShellComponent]
    public class DevExpressTemplateGroupProvider : IDotNetTemplateGroupProvider
    {
        private const string DevExpressTemplateTag = "template";
        public int Priority => 20;

        public IReadOnlyCollection<DotNetTemplateGroup> Get()
        {
            return new[] {new DevExpressTemplateGroup()};
        }

        private class DevExpressTemplateGroup : DotNetTemplateGroup
        {
            protected override bool ShowIfSingleTemplate => true;

            public DevExpressTemplateGroup() : base("Template", null)
            {
            }

            protected override string GetOption(TemplateInfo info)
            {
                return info.GetTagValue(DevExpressTemplateTag);
            }

            protected override IComparer<string> OptionsComparer => StringByLengthComparer.Comparer; // Easiest way for default components view suitable to default DevExpress Template Manager
        }
    }
}