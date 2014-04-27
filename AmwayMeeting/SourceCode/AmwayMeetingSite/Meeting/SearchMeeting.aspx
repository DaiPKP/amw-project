<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="SearchMeeting.aspx.cs" Inherits="Meeting_SearchMeeting" %>

<%@ Register src="UserControl/uc_SearchMeeting.ascx" tagname="uc_SearchMeeting" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
   
    <uc1:uc_SearchMeeting ID="uc_SearchMeeting1" runat="server" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
