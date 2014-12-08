<%@ Application Language="C#" %>

<script runat="server">
    Functions func = new Functions();
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application["FCKeditor:UserFilesPath"] = "../../../../../File/";
        Application.Add("demOnline", 0);
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        Application.Remove("demOnline");
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Session["lang"] = "vi-VN";
        int dem = (int)Application.Get("demOnline");
        dem++;
        Application.Set("demOnline", dem);
        string xmlfile = Server.MapPath("Count.xml");
        func.Write("~/Count.xml", int.Parse(func.ReadXML("~/Count.xml")));
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        int dem = (int)Application.Get("demOnline");
        dem--;
        Application.Set("demOnline", dem);
    }
       
</script>
