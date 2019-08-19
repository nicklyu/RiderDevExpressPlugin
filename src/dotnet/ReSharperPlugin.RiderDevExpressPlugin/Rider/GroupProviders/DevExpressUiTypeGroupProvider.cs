using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Application;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetExtensions;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetTemplates;
using Microsoft.TemplateEngine.Edge.Settings;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider.GroupProviders
{
    [ShellComponent]
    public class DevExpressUiTypeGroupProvider : IDotNetTemplateGroupProvider
    {
        private const string UiTypeTag = "uiType";

        public int Priority => 28;

        public IReadOnlyCollection<DotNetTemplateGroup> Get()
        {
            return new[] {new DevExpressUiTypeGroup()};
        }

        private class DevExpressUiTypeGroup : DotNetTemplateGroup
        {
            public DevExpressUiTypeGroup() : base("UI Type", null)
            {
            }

            protected override string GetOption(TemplateInfo info)
            {
                return info.GetTagValue(UiTypeTag);
            }
        }
    }
}