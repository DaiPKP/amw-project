<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Home_Default" %>

<%@ Register Src="~/Home/UserControl/uc_Home.ascx" TagPrefix="uc1" TagName="uc_Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_Home runat="server" ID="uc_Home" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

