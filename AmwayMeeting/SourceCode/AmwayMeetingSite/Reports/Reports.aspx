<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports_Reports" %>

<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCost.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCost" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostByDistributor.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostByDistributor" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostByLocation.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostByLocation" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostByPax.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostByPax" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostByPIN.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostByPIN" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostByProvince.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostByProvince" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetTotalCostBySystem.ascx" TagPrefix="uc1" TagName="uc_rpt_GetTotalCostBySystem" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_ListMeeting.ascx" TagPrefix="uc1" TagName="uc_rpt_ListMeeting" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetSessionByPax.ascx" TagPrefix="uc1" TagName="uc_rpt_GetSessionByPax" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_GetSessionByProvince.ascx" TagPrefix="uc1" TagName="uc_rpt_GetSessionByProvince" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_Summary_Number_of_Participant.ascx" TagPrefix="uc1" TagName="uc_rpt_Summary_Number_of_Participant" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_Summary_Spend.ascx" TagPrefix="uc1" TagName="uc_rpt_Summary_Spend" %>
<%@ Register Src="~/Reports/UserControl/uc_rpt_Summary_Session_Expense.ascx" TagPrefix="uc1" TagName="uc_rpt_Summary_Session_Expense" %>








<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="TitlePage">
       DANH SÁCH BÁO CÁO
    </div>
    <HR />
    <div style="text-align:left;">
        <uc1:uc_rpt_GetTotalCost runat="server" ID="uc_rpt_GetTotalCost" />
        <HR />
        <uc1:uc_rpt_GetTotalCostByDistributor runat="server" ID="uc_rpt_GetTotalCostByDistributor" />
        <HR />
        <uc1:uc_rpt_GetTotalCostByLocation runat="server" ID="uc_rpt_GetTotalCostByLocation" />
        <HR />
        <uc1:uc_rpt_GetTotalCostByPax runat="server" ID="uc_rpt_GetTotalCostByPax" />
        <HR />
        <uc1:uc_rpt_GetTotalCostByPIN runat="server" ID="uc_rpt_GetTotalCostByPIN" />
        <HR />
        <uc1:uc_rpt_GetTotalCostByProvince runat="server" ID="uc_rpt_GetTotalCostByProvince" />
        <HR />
        <uc1:uc_rpt_GetTotalCostBySystem runat="server" ID="uc_rpt_GetTotalCostBySystem" />
        <HR />
        <uc1:uc_rpt_ListMeeting runat="server" id="uc_rpt_ListMeeting" />
        <hr />
        <uc1:uc_rpt_GetSessionByPax runat="server" ID="uc_rpt_GetSessionByPax" />
        <HR />
        <uc1:uc_rpt_GetSessionByProvince runat="server" ID="uc_rpt_GetSessionByProvince" />
        <hr />
        <uc1:uc_rpt_Summary_Number_of_Participant runat="server" ID="uc_rpt_Summary_Number_of_Participant" />
        <hr />
        <uc1:uc_rpt_Summary_Spend runat="server" ID="uc_rpt_Summary_Spend" />
        <hr />
        <uc1:uc_rpt_Summary_Session_Expense runat="server" ID="uc_rpt_Summary_Session_Expense" />
        <hr />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" Runat="Server">   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" Runat="Server">
</asp:Content>

