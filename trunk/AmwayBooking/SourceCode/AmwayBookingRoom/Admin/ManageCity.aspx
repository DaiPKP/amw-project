<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageCity.aspx.cs" Inherits="Admin_ManageCity" %>

<%@ Register Src="~/Admin/UserControl/uc_ManageCity.ascx" TagPrefix="uc1" TagName="uc_ManageCity" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_ManageCity runat="server" ID="uc_ManageCity" />
</asp:Content>

