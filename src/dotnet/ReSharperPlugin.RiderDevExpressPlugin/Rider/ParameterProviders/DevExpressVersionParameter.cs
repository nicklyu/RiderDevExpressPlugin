using System.Collections.Generic;
using System.Linq;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetExtensions;
using JetBrains.ReSharper.Host.Features.ProjectModel.ProjectTemplates.DotNetTemplates;
using JetBrains.Rider.Model;
using JetBrains.Util;


namespace ReSharperPlugin.RiderDevExpressPlugin.Rider.ParameterProviders
{
    public class DevExpressVersionParameter : DotNetTemplateParameter
    {
        private readonly DevExpressVersionManager myVersionManager;
        private const string DevExpressWinFormsLink = "https://www.devexpress.com/products/net/controls/winforms/";

        public DevExpressVersionParameter(DevExpressVersionManager versionManager)
            : base("DEVersion", "DevExpress Version", null)
        {
            myVersionManager = versionManager;
        }

        public override RdProjectTemplateContent CreateContent(DotNetProjectTemplateExpander expander, IDotNetTemplateContentFactory factory, int index, IDictionary<string, string> context)
        {
            var info = expander.TemplateInfo;
            var versionParameter = info.GetParameter(Name);
            if (versionParameter == null)
            {
                return factory.CreateNextParameters(new[] {expander}, index + 1, context);
            }

            var availableVersions = myVersionManager.GetDevExpressVersions();
            if (availableVersions.IsEmpty())
            {
                var content = factory.CreateNextParameters(new[] {expander}, index + 1, context);
                return new RdProjectTemplateInvalidParameter(Name, PresentableName,
                    "Installed DevExpress is not found", null, DevExpressWinFormsLink, "Install DevExpress", null, content);
            }

            var options = new List<RdProjectTemplateGroupOption>();
            foreach (var version in availableVersions)
            {
                var id = version.ToString();
                var optionContext = new Dictionary<string, string>(context) {{Name, id}};
                var content = factory.CreateNextParameters(new[] {expander}, index + 1, optionContext);
                options.Add(new RdProjectTemplateGroupOption(id, id, null, content));
            }

            return new RdProjectTemplateGroupParameter(Name, PresentableName,
                options.First().Option, Tooltip, options);
        }
    }
}