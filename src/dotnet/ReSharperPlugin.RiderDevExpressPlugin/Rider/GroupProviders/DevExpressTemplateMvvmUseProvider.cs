using System.Collections.Generic;
using JetBrains.Application;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetExtensions;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetTemplates;
using Microsoft.TemplateEngine.Edge.Settings;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider.GroupProviders
{
    [ShellComponent]
    public class DevExpressTemplateMvvmUseProvider : IDotNetTemplateGroupProvider
    {
        private const string TemplateTypeTag = "mvvm";

        public int Priority => 25;


        public IReadOnlyCollection<DotNetTemplateGroup> Get()
        {
            return new[] {new DevExpressTemplateTypeGroup()};
        }

        private class DevExpressTemplateTypeGroup : DotNetTemplateGroup
        {
            public DevExpressTemplateTypeGroup() : base("MVVM Ready", null)
            {
            }

            protected override string GetOption(TemplateInfo info)
            {
                return info.GetTagValue(TemplateTypeTag);
            }
        }
    }
}