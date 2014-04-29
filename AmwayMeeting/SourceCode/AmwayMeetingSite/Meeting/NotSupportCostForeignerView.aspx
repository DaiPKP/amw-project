<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="NotSupportCostForeignerView.aspx.cs" Inherits="Meeting_NotSupportCostForeignerView" %>

<%@ Register src="UserControl/uc_NotSupportCostForeignerView.ascx" tagname="uc_NotSupportCostForeignerView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
   
    <uc1:uc_NotSupportCostForeignerView ID="uc_NotSupportCostForeignerView1" runat="server" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
