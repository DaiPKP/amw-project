<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoute(System.Web.Routing.RouteTable.Routes);
    }
    void RegisterRoute(System.Web.Routing.RouteCollection routes)
    {
        routes.Add("MANAGER", new System.Web.Routing.Route("manager/{data}", new ManagerRouterHandler()));
        routes.Add("CATEGORY", new System.Web.Routing.Route("category/{data}", new CategoryRouterHandler()));
        routes.Add("MEETING", new System.Web.Routing.Route("meeting/{data}", new MeetingRouterHandler()));
    }
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
