<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ManageCity.ascx.cs" Inherits="Admin_UserControl_uc_ManageCity" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div style="text-align: center; width: 100%; height: auto; float: right; font-size: 12px; font-family: Tahoma; color: #4c4c27;">
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
            <div>
                <span class="titleText">Quản lý thông tin thành phố</span><br />
                <img src="/Images/line.gif" />
                <br />
                <table width="100%" style="margin-left:auto; margin-right:auto;">
                    <tr>
                        <td class="td_title" width="45%">
                            Mã thành phố
                        </td>
                        <td class="td_value">
                            <asp:TextBox ID="txtCityCode" MaxLength="10" runat="server"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">
                            Tên thành phố
                        </td>
                        <td class="td_value">

                            <asp:TextBox ID="txtCityName" MaxLength="100" runat="server"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">
                            Trạng thái
                        </td>
                        <td class="td_value">

                            <asp:CheckBox ID="CheckBox1" runat="server" />

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">

                            <asp:Button CssClass="button" ID="Button1" runat="server" Text="Tìm Kiếm" />

                            <asp:Button CssClass="button" ID="Button2" runat="server" Text="Tạo Mới" />

                            <asp:Button CssClass="button" ID="Button3" runat="server" Text="Xóa Trắng" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>