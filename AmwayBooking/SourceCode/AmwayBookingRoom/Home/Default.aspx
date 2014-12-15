<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Home_Default" %>

<%@ Register Src="~/Home/UserControl/uc_Home.ascx" TagPrefix="uc1" TagName="uc_Home" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>

    <div>
        <uc1:uc_Home runat="server" ID="uc_Home" />
    </div>

</body>
</html>
