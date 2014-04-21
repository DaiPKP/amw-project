<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="Pax_Province.aspx.cs" Inherits="Category_Pax_Province" %>

<%@ Register src="UserControl/uc_Pax_Province.ascx" tagname="uc_Pax_Province" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">
    
    <uc1:uc_Pax_Province ID="uc_Pax_Province1" runat="server" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" Runat="Server">
</asp:Content>

