using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using DAL;
using System.Web.Compilation;
using System.Web.UI;

/// <summary>
/// Summary description for ManagerRouterHandler
/// </summary>
public class ManagerRouterHandler : IRouteHandler
{
    public ManagerRouterHandler()
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
                case "user": return BuildManager.CreateInstanceFromVirtualPath("~/Manager/User.aspx", typeof(Page)) as Page;
                case "permission": return BuildManager.CreateInstanceFromVirtualPath("~/Manager/Permission.aspx", typeof(Page)) as Page;
                case "department": return BuildManager.CreateInstanceFromVirtualPath("~/Manager/Department.aspx", typeof(Page)) as Page;

                default:
                    {
                        return BuildManager.CreateInstanceFromVirtualPath("~/Manager/User.aspx", typeof(Page)) as Page;

                    }

            }
        }
        catch
        {
            return null;
        }


    }
}