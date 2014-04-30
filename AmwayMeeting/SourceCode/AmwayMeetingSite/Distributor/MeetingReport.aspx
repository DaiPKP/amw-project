<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="MeetingReport.aspx.cs" Inherits="Distributor_MeetingReport" %>

<%@ Register src="UserControl/uc_MeetingReport.ascx" tagname="uc_MeetingReport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <uc1:uc_MeetingReport ID="uc_MeetingReport1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" Runat="Server">
</asp:Content>

