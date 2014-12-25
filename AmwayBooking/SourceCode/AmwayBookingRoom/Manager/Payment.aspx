<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<%@ Register Src="~/Manager/UserControl/uc_Payment.ascx" TagPrefix="uc1" TagName="uc_Payment" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_Payment runat="server" id="uc_Payment" />
</asp:Content>


