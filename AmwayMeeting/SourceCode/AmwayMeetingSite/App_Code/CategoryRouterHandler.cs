using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using DAL;
using System.Web.Compilation;
using System.Web.UI;

/// <summary>
/// Summary description for CategoryHandler
/// </summary>
public class CategoryRouterHandler : IRouteHandler
{
    public CategoryRouterHandler()
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
                case "province": return BuildManager.CreateInstanceFromVirtualPath("~/Category/Province.aspx", typeof(Page)) as Page;
                case "pax": return BuildManager.CreateInstanceFromVirtualPath("~/Category/Pax.aspx", typeof(Page)) as Page;
                case "paxprovince": return BuildManager.CreateInstanceFromVirtualPath("~/Category/Pax_Province.aspx", typeof(Page)) as Page;
                case "usertype": return BuildManager.CreateInstanceFromVirtualPath("~/Category/UserType.aspx", typeof(Page)) as Page;
                case "policy": return BuildManager.CreateInstanceFromVirtualPath("~/Category/Policy.aspx", typeof(Page)) as Page;
                case "period": return BuildManager.CreateInstanceFromVirtualPath("~/Category/Period.aspx", typeof(Page)) as Page;
                case "quota": return BuildManager.CreateInstanceFromVirtualPath("~/Category/Quota.aspx", typeof(Page)) as Page;
                case "usersystem": return BuildManager.CreateInstanceFromVirtualPath("~/Category/SystemUser.aspx", typeof(Page)) as Page;
                case "usertypeenhance": return BuildManager.CreateInstanceFromVirtualPath("~/Category/UserTypeEnhance.aspx", typeof(Page)) as Page;
               
                default:
                    {
                        return BuildManager.CreateInstanceFromVirtualPath("~/Category/Province.aspx", typeof(Page)) as Page;

                    }

            }

        }
        catch
        {
            return null;
        }

    }
}