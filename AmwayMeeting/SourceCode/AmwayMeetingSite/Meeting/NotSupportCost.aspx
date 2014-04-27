<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="NotSupportCost.aspx.cs" Inherits="Meeting_NotSupportCost" %>

<%@ Register src="UserControl/uc_NotSupportCost.ascx" tagname="uc_NotSupportCost" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
   
    <uc1:uc_NotSupportCost ID="uc_NotSupportCost1" runat="server" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
