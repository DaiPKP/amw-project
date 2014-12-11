<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_rpt_GetTotalCostByLocation.ascx.cs" Inherits="Reports_UserControl_uc_rpt_GetTotalCostByLocation" %>
<div style="height: auto; text-align:left;">
    <div style="text-align:left; font-size:14px; font-weight:bold; color: #008080; margin-left:20px;">
        BÁO CÁO SỐ CHI PHÍ MEETING TẠI 1 VENUE
    </div>
    <asp:Panel runat="server" ID="Panel1">
        <asp:Panel runat="server" ID="pnlSearch">
            <div style="text-align: left; width: 100%">
                <table  width="50%">
                    <tr>
                        <td style ="text-align:right; padding-right:5px; color: #008080; font-weight:bold;">
                            Chọn Quí Tài Chính
                        </td>
                        <td style ="text-align:left; padding-right:5px;">
                            <asp:DropDownList ID="ddlPERIODID" CssClass="txtBox" runat="server" Width="101%" Height="22px">
                            </asp:DropDownList>
                        </td>
                        <td style ="text-align:left; padding-left:5px;">
                            <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Xuất Báo Cáo" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
            </div>
        </asp:Panel>
    </asp:Panel>
</div>