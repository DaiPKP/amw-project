<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_rpt_GetTotalCost.ascx.cs" Inherits="Reports_UserControl_uc_rpt_GetTotalCost" %>
<div style="height: auto">
    <div style="text-align:left; font-size:14px; font-weight:bold; color: #008080; margin-left:20px;">
        BÁO CÁO % CHI PHÍ THỰC TẾ VÀ NGÂN SÁCH
    </div>
    <asp:Panel runat="server" ID="Panel1">
        <asp:Panel runat="server" ID="pnlSearch">
            <div style="text-align: left; margin-left:20px; width: 100%">
                <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Xuất Báo Cáo" OnClick="btnSave_Click" />
                <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
            </div>
        </asp:Panel>
    </asp:Panel>
</div>
