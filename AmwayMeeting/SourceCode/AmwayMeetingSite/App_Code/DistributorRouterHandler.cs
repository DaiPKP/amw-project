using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using DAL;
using System.Web.Compilation;
using System.Web.UI;

/// <summary>
/// Summary description for DistributorRouterHandler
/// </summary>
public class DistributorRouterHandler : IRouteHandler
{
    public DistributorRouterHandler()
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
                case "profile": return BuildManager.CreateInstanceFromVirtualPath("~/Distributor/Profile.aspx", typeof(Page)) as Page;

                default:
                    {
                        return BuildManager.CreateInstanceFromVirtualPath("~/Distributor/Profile.aspx", typeof(Page)) as Page;
                    }

            }
        }
        catch
        {
            return null;
        }


    }
}