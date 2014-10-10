<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="SupportCostClone.aspx.cs" Inherits="Meeting_SupportCostClone" %>

<%@ Register src="UserControl/uc_SupportCostClone.ascx" tagname="uc_SupportCostClone" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
   
    
    <uc1:uc_SupportCostClone ID="uc_SupportCostClone1" runat="server" />
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
