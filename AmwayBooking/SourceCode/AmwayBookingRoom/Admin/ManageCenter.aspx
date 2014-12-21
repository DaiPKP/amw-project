<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageCenter.aspx.cs" Inherits="Admin_ManageCenter" %>

<%@ Register Src="~/Admin/UserControl/uc_ManageCenter.ascx" TagPrefix="uc1" TagName="uc_ManageCenter" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_ManageCenter runat="server" ID="uc_ManageCenter" />
</asp:Content>

