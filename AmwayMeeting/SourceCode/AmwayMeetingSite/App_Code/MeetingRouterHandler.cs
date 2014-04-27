using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using DAL;
using System.Web.Compilation;
using System.Web.UI;

/// <summary>
/// Summary description for MeetingRouterHandler
/// </summary>
public class MeetingRouterHandler : IRouteHandler
{
    public MeetingRouterHandler()
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
                case "notsupportcost":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/NotSupportCost.aspx", typeof(Page)) as Page;
                    }
                case "search": return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/SearchMeeting.aspx", typeof(Page)) as Page;
                case "supportcost": return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/SupportCost.aspx", typeof(Page)) as Page;
                case "outside": return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/OutSide.aspx", typeof(Page)) as Page;
               
                case "notsuportcostview":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/NotSupportCostView.aspx", typeof(Page)) as Page;
                    }
                default:
                    {
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/Province.aspx", typeof(Page)) as Page;

                    }

            }

        }
        catch
        {
            return null;
        }

    }
}