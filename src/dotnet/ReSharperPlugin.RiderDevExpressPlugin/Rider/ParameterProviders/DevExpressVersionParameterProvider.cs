using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Application;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetExtensions;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider.ParameterProviders
{
    [ShellComponent]
    public class DevExpressVersionParameterProvider : IDotNetTemplateParameterProvider
    {
        private readonly DevExpressVersionManager myVersionManager;

        public DevExpressVersionParameterProvider([NotNull] DevExpressVersionManager versionManager)
        {
            myVersionManager = versionManager;
        }

        public int Priority => 5;

        public IReadOnlyCollection<DotNetTemplateParameter> Get()
        {
            return new[] {new DevExpressVersionParameter(myVersionManager)};
        }
    }
}