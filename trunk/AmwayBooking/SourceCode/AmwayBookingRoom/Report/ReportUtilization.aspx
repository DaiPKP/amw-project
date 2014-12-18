<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportUtilization.aspx.cs" Inherits="Report_ReportUtilization" %>

<%@ Register Src="~/Report/UserControl/uc_ReportUtilization.ascx" TagPrefix="uc1" TagName="uc_ReportUtilization" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_ReportUtilization runat="server" id="uc_ReportUtilization" />
</asp:Content>

