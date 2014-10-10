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
                case "notsupportcostclone":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/NotSupportCostClone.aspx", typeof(Page)) as Page;
                    }
                case "notsupportcostforeigner":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/NotSupportCostForeigner.aspx", typeof(Page)) as Page;
                    }
                case "notsupportcostforeignerclone":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/NotSupportCostForeignerClone.aspx", typeof(Page)) as Page;
                    }
                case "search": return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/SearchMeeting.aspx", typeof(Page)) as Page;
                case "xuq": return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/XuatUyQuyen.aspx", typeof(Page)) as Page;

                case "supportcost":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/SupportCost.aspx", typeof(Page)) as Page;
                    }
                case "supportcostclone":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/SupportCostClone.aspx", typeof(Page)) as Page;
                    }
                case "supportcostforeigner":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/SupportCostForeigner.aspx", typeof(Page)) as Page;
                    }
                case "supportcostforeignerclone":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/SupportCostForeignerClone.aspx", typeof(Page)) as Page;
                    }  
                case "outsidecountry":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/OutSideCountry.aspx", typeof(Page)) as Page;
               
                    }
                case "outsidecountryclone":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/OutSideCountryClone.aspx", typeof(Page)) as Page;

                    }
                case "outsidecountryview":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/OutSideCountryView.aspx", typeof(Page)) as Page;
                    }
                    
                case "notsupportcostview":
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
                case "notsupportcostforeignerview":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/NotSupportCostForeignerView.aspx", typeof(Page)) as Page;
                    }
                case "supportcostview":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/SupportCostView.aspx", typeof(Page)) as Page;
                    }
                case "supportcostforeignerview":
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
                        return BuildManager.CreateInstanceFromVirtualPath("~/Meeting/SupportCostForeignerView.aspx", typeof(Page)) as Page;
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