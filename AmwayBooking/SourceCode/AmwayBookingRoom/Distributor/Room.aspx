<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Room.aspx.cs" Inherits="Distributor_Room" %>

<%@ Register Src="~/Distributor/UserControl/uc_Room.ascx" TagPrefix="uc1" TagName="uc_Room" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_Room runat="server" ID="uc_Room" />
</asp:Content>

