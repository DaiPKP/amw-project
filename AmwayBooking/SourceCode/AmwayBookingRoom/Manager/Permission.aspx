<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Permission.aspx.cs" Inherits="Manager_Permission" %>

<%@ Register src="UserControl/uc_Permission.ascx" tagname="uc_Permission" tagprefix="uc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <uc1:uc_Permission ID="uc_Permission1" runat="server" />
</asp:Content>
