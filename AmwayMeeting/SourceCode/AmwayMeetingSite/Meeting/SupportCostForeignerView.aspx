<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="SupportCostForeignerView.aspx.cs" Inherits="Meeting_SupportCostForeignerView" %>

<%@ Register src="UserControl/uc_SupportCostForeignerView.ascx" tagname="uc_SupportCostForeignerView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
   
    <uc1:uc_SupportCostForeignerView ID="uc_SupportCostForeignerView1" runat="server" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
