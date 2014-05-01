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
             string strdata = requestContext.RouteData.Values["data"] as string;
            string []arrData= strdata.Split('R');
            switch (arrData[0])
            {            
                case "profile": return BuildManager.CreateInstanceFromVirtualPath("~/Distributor/Profile.aspx", typeof(Page)) as Page;
                case "rulesupport": return BuildManager.CreateInstanceFromVirtualPath("~/Distributor/RuleSupport.aspx", typeof(Page)) as Page;
                case "rulenonesupport": return BuildManager.CreateInstanceFromVirtualPath("~/Distributor/RuleNoneSupport.aspx", typeof(Page)) as Page;
                case "ruleoversea": return BuildManager.CreateInstanceFromVirtualPath("~/Distributor/RuleOverSea.aspx", typeof(Page)) as Page;
                case "report":
                    {
                        string strid = "-1";
                        try
                        {
                            strid = arrData[1];
                        }
                        catch
                        {

                            strid = "-1";
                        }

                        HttpContext.Current.Items["id"] = strid;
                        return BuildManager.CreateInstanceFromVirtualPath("~/Distributor/MeetingReport.aspx", typeof(Page)) as Page;
                    }
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