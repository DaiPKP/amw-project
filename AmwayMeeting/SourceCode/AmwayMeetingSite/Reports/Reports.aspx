<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports_Reports" %>

<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCost.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCost" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostByDistributor.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostByDistributor" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostByLocation.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostByLocation" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostByPax.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostByPax" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostByPIN.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostByPIN" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostByProvince.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostByProvince" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostBySystem.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostBySystem" %>









<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="TitlePage">
       DANH SÁCH BÁO CÁO
    </div>
    <div style="text-align:left;">
        <uc1:uc_rpt_GetTotalCost runat="server" ID="uc_rpt_GetTotalCost" />
        <uc1:uc_rpt_GetTotalCostByDistributor runat="server" ID="uc_rpt_GetTotalCostByDistributor" />
        <uc1:uc_rpt_GetTotalCostByLocation runat="server" ID="uc_rpt_GetTotalCostByLocation" />
        <uc1:uc_rpt_GetTotalCostByPax runat="server" ID="uc_rpt_GetTotalCostByPax" />
        <uc1:uc_rpt_GetTotalCostByPIN runat="server" ID="uc_rpt_GetTotalCostByPIN" />
        <uc1:uc_rpt_GetTotalCostByProvince runat="server" ID="uc_rpt_GetTotalCostByProvince" />
        <uc1:uc_rpt_GetTotalCostBySystem runat="server" ID="uc_rpt_GetTotalCostBySystem" />
    </div>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" Runat="Server">   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" Runat="Server">
</asp:Content>

