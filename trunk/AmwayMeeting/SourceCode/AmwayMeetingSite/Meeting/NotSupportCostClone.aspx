<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="NotSupportCostClone.aspx.cs" Inherits="Meeting_NotSupportCostClone" %>

<%@ Register src="UserControl/uc_NotSupportCostClone.ascx" tagname="uc_NotSupportCostClone" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
 
    <uc1:uc_NotSupportCostClone ID="uc_NotSupportCostClone1" runat="server" />
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
