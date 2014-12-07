<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_rpt_GetSessionByProvince.ascx.cs" Inherits="Reports_UserControl_uc_rpt_GetSessionByProvince" %>
<div style="height: auto">
    <div style="text-align: left; font-size: 14px; font-weight: bold; color: #008080; margin-left: 20px;">
        BÁO CÁO TỔNG HỢP & LIỆT KÊ CÁC TRƯỜNG HỢP EXCEPTIONAL CASE
    </div>
    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            BindEvents();
        });

        $(function () {
            var objTuNgay = document.getElementById("<%=txtFROM_DATE.ClientID %>");
            var objDenNgay = document.getElementById("<%=txtTO_DATE.ClientID %>");
            $(objTuNgay).datepicker({
                showOn: "button",
                buttonImage: "../images/calendar.gif",
                buttonImageOnly: true
            }),
           $(objDenNgay).datepicker({
               showOn: "button",
               buttonImage: "../images/calendar.gif",
               buttonImageOnly: true
           });
        });
    </script>
    <asp:Panel runat="server" ID="pnlSearch">
        <div style="text-align: center; width: 100%">
            <table>
                <tr>
                    <%--<td style="text-align: right; padding-right: 5px; color: #008080; font-weight: bold;">Chọn Loại Hội Họp
                    </td>
                    <td style="text-align: left; padding-right: 5px;">
                        <asp:DropDownList ID="ddlMEETINGTYPEID" CssClass="txtBox" runat="server" Width="101%" Height="22px">
                        </asp:DropDownList>
                    </td>--%>
                    <td style="text-align: right; padding-right: 5px; color: #008080; font-weight: bold;">Từ Ngày
                    </td>
                    <td style="text-align: left; padding-right: 5px;">
                        <asp:TextBox ID="txtFROM_DATE" CssClass="txtBoxDate" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td style="text-align: right; padding-right: 5px; color: #008080; font-weight: bold;">Đến Ngày
                    </td>
                    <td style="text-align: left; padding-right: 5px;">
                        <asp:TextBox ID="txtTO_DATE" CssClass="txtBoxDate" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td style="text-align: right; padding-right: 5px; color: #008080; font-weight: bold;">Có người nước ngoài
                    </td>
                    <td style="text-align: left; padding-left: 5px;">
                        <asp:CheckBox ID="chk_FOREIGNER" runat="server"/>
                    </td>
                    <td style="text-align: left; padding-left: 5px;">
                        <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Xuất Báo Cáo" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
        </div>
    </asp:Panel>
</div>
