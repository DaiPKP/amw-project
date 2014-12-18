<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportCost.aspx.cs" Inherits="Report_ReportCost" %>

<%@ Register Src="~/Report/UserControl/uc_ReportCost.ascx" TagPrefix="uc1" TagName="uc_ReportCost" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_ReportCost runat="server" ID="uc_ReportCost" />
</asp:Content>

