<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="SupportCost.aspx.cs" Inherits="Meeting_SupportCost" %>

<%@ Register src="UserControl/uc_SupportCost.ascx" tagname="uc_SupportCost" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
   
    
    <uc1:uc_SupportCost ID="uc_SupportCost1" runat="server" />
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
