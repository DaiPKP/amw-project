<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="Quota.aspx.cs" Inherits="Category_Quota" %>

<%@ Register Src="~/Category/UserControl/uc_SearchQuota.ascx" TagPrefix="uc1" TagName="uc_SearchQuota" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <uc1:uc_searchquota runat="server" id="uc_SearchQuota" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" Runat="Server">
</asp:Content>

