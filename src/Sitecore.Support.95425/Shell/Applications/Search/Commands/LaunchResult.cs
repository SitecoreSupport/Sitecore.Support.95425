using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Shell.Framework.Pipelines;
using System;

namespace Sitecore.Support.Shell.Applications.Search.Commands
{
    public class LaunchResult : Command
    {
        public override void Execute(CommandContext context)
        {
            Assert.IsNotNull(context, "context");
            string text = context.Parameters["url"];
            Assert.IsNotNullOrEmpty(text, "url");
            text = StringUtil.DecodeMessageParameter(text);
            LaunchSearchResultArgs args = new LaunchSearchResultArgs(text);
            args.Parameters.Add("la", context.Parameters["la"]);
            Context.ClientPage.Start("uiLaunchSearchResult", args);
        }
    }
}