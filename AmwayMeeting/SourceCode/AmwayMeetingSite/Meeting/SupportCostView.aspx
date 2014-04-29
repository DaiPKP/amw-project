<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="SupportCostView.aspx.cs" Inherits="Meeting_SupportCostView" %>

<%@ Register src="UserControl/uc_SupportCostView.ascx" tagname="uc_SupportCostView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
   
    <uc1:uc_SupportCostView ID="uc_SupportCostView1" runat="server" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
