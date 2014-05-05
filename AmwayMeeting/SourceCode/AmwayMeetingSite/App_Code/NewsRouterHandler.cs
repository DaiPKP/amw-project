using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using DAL;
using System.Web.Compilation;
using System.Web.UI;

/// <summary>
/// Summary description for NewsRouterHandler
/// </summary>
public class NewsRouterHandler : IRouteHandler
{
    public NewsRouterHandler()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        try
        {
            string data = requestContext.RouteData.Values["data"] as string;
            switch (data)
            {
                case "0":
                    return BuildManager.CreateInstanceFromVirtualPath("~/News/News0.aspx", typeof(Page)) as Page;
                case "1":

                    return BuildManager.CreateInstanceFromVirtualPath("~/News/News1.aspx", typeof(Page)) as Page;
                case "2":
                    return BuildManager.CreateInstanceFromVirtualPath("~/News/News2.aspx", typeof(Page)) as Page;
                default:
                    {
                        return BuildManager.CreateInstanceFromVirtualPath("~/News/News0.aspx", typeof(Page)) as Page;

                    }

            }

        }
        catch
        {
            return null;
        }

    }
}