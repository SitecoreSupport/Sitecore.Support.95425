using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Shell.Framework;
using Sitecore.Shell.Framework.Pipelines;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.Shell.Framework.Pipelines
{
    public class LaunchSearchResult
    {
        public void OpenItem(LaunchSearchResultArgs args)
        {
            Assert.IsNotNull(args, "args");
            ItemUri itemUri = ItemUri.Parse(args.Url);
            itemUri = new ItemUri(ID.Parse(args.Url), Language.Parse(args.Parameters["la"]), itemUri.Version, itemUri.DatabaseName);
            if (itemUri == null)
            {
                SheerResponse.Alert("Cannot launch result: " + args.Url + ". Format unknown.", new string[0]);
                return;
            }
            Item item = Database.GetItem(itemUri);
            if (item != null && item.TemplateID == TemplateIDs.Application)
            {
                Windows.RunApplication(item);
                return;
            }
            UrlString urlString = new UrlString();
            urlString.Add("fo", itemUri.ItemID.ToString());
            itemUri.AddToUrlString(urlString);
            Windows.RunApplication("Content Editor", urlString.ToString());
        }
    }
}