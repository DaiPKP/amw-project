<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Information.aspx.cs" Inherits="Information" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div style="text-align: center; width:100%; height:auto; float:right; font-size:12px; font-family:Tahoma; color:#4c4c27;">
<asp:UpdatePanel ID="update" runat="server">
    <ContentTemplate> 
    <div>
        <span class="titleText">Lịch Huấn Luyện</span><br />
        <img src="/Images/line.gif" />
    </div>
    <div>
        <FCKeditorV2:FCKeditor ID="FCKeditorLich" runat="server" BasePath="~/fckeditor/" Height="400px">
        </FCKeditorV2:FCKeditor>
    </div>
    <div> 
        <asp:Button ID="btLuuLich" runat="server" Text="Lưu Lịch Huấn Luyện" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" onclick="btLuuLich_Click"/><br />
        <img src="Images/line.gif" />
    </div>
    <div>
        <span class="titleText">Thông Tin Mới</span><br />
        <img src="Images/line.gif" />
    </div>
    <div>
        <FCKeditorV2:FCKeditor ID="FCKeditorThongTin" runat="server" BasePath="~/fckeditor/" Height="400px">
        </FCKeditorV2:FCKeditor>
    </div>
    <div>
        <asp:Button ID="btLuuThongTin" runat="server" Text="Lưu Thông Tin Mới" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" onclick="btLuuThongTin_Click"/><br />        
        <img src="Images/line.gif" />
    </div>
    <div>
        <span class="titleText">Thông Tin Liên Hệ</span><br />
        <img src="Images/line.gif" />
    </div>
    <div>
        <FCKeditorV2:FCKeditor ID="FCKeditorLienHe" runat="server" BasePath="~/fckeditor/" Height="400px">
        </FCKeditorV2:FCKeditor>
    </div>
    <div>
        <asp:Button ID="btLuuTTLienHe" runat="server" Text="Lưu Thông Tin Liên Hệ" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" onclick="btLuuTTLienHe_Click"/><br />        
        <img src="Images/line.gif" />
    </div>
    </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>

