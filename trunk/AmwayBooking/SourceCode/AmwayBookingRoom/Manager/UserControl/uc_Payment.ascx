<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Payment.ascx.cs" Inherits="Manager_UserControl_uc_Payment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script src="/scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#btPrint").click(function (e) {
            CallPrint();
        });
    });
    function CallPrint() {
        var prtContent = document.getElementById('divPrint');
        var WinPrint = window.open('', '', 'letf=0,top=0,width=800,height=600,toolbar=0,scrollbars=0,status=0');
        WinPrint.document.write("<html>")
        WinPrint.document.write("<head>")
        WinPrint.document.write('<link href= "/Styles/StyleSheet.css" rel="stylesheet" type="text/css" />')
        WinPrint.document.write("</head>")
        WinPrint.document.write("<body>")
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.write("</body>")
        WinPrint.document.write("</html>")
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
        prtContent.innerHTML = strOldOne;
    }
</script>

<div style="text-align: center; width: 100%; height: auto; float: right; font-size: 12px; font-family: Tahoma; color: #4c4c27;">
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
            <div>
                <span class="titleText">Lập Phiếu Thu</span><br />
                <img src="/Images/line.gif" />
            </div>
            <div>
                ADA ID 
        <asp:TextBox ID="txtADAID" runat="server" Width="50px"></asp:TextBox>
                Thành phố 
        <asp:DropDownList ID="ddlCity" runat="server" Width="200px">
        </asp:DropDownList>
                Từ ngày 
        <asp:TextBox ID="txtFormDate" runat="server" Width="100px"></asp:TextBox>
                <asp:CalendarExtender ID="txtFormDate_CalendarExtender" runat="server"
                    Enabled="True" TargetControlID="txtFormDate">
                </asp:CalendarExtender>
                Đến ngày
        <asp:TextBox ID="txtToDate" runat="server" Width="100px"></asp:TextBox>
                <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server"
                    Enabled="True" TargetControlID="txtToDate">
                </asp:CalendarExtender>
                <asp:Button ID="btLapPhieuThu" runat="server" Text="Lập phiếu thu" BackColor="#4c4c27"
                    Font-Size="12px" ForeColor="White" OnClick="btLapPhieuThu_Click" />
            </div>
            <img src="Images/line.gif" /><br />
            <div style="height: 10px;"></div>
            <asp:Panel ID="panelPhieuThu" runat="server" Visible="false">
                <div id="divPrint">

                    <span class="titleText">PHIẾU THU HỘI HỌP TẠI</span><br />
                    <span class="titleText">
                        <asp:Label ID="lbCenterName" runat="server" Text=""></asp:Label>
                    </span>
                    <br />
                    <div style="height: 10px;"></div>
                    <div style="font-size: 14px; text-align: left;">
                        Tên nhà phân phối đăng ký:
                <asp:Label ID="lbDistributor" runat="server" Text=""></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                ADA:<asp:Label ID="lbADAID" runat="server" Text=""></asp:Label>
                        <div style="height: 10px;"></div>
                        <table border="0" class="borderTable" width="100%" cellpadding="2" cellspacing="0">
                            <asp:Repeater ID="repeat" runat="server">
                                <HeaderTemplate>
                                    <tr>
                                        <td class="TDTopPhieuThu">Địa điểm họp
                                        </td>
                                        <td class="TDTopPhieuThu">Ngày họp
                                        </td>
                                        <td class="TDTopPhieuThu">Thời gian
                                        </td>
                                        <td class="TDTopPhieuThu">Giá tiền
                                        </td>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="TDPhieuThu">
                                            <%# DataBinder.Eval(Container.DataItem, "RoomName")%>
                                        </td>
                                        <td class="TDPhieuThu">
                                            <%# DataBinder.Eval(Container.DataItem, "Date")%>
                                        </td>
                                        <td class="TDPhieuThu">
                                            <%# DataBinder.Eval(Container.DataItem, "Time")%>
                                        </td>
                                        <td class="TDPhieuThu">
                                            <%#string.Format("{0:0,0 VNĐ}", DataBinder.Eval(Container.DataItem, "Price"))%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <td colspan="3" class="TDPhieuThu">Tổng tiền
                                </td>
                                <td class="TDPhieuThu">
                                    <asp:Label ID="lbTotal" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="100%">
                            <tr>
                                <td style="text-align: center; width: 50%;">Ngày 
                            <asp:Label ID="lbDay" runat="server" Text=""></asp:Label>
                                    tháng  
                            <asp:Label ID="lbMonth" runat="server" Text=""></asp:Label>
                                    năm 
                            <asp:Label ID="lbYear" runat="server" Text=""></asp:Label><br />
                                    Người đề nghị
                            <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    Lê Thị Kim My
                                </td>
                                <td style="text-align: center; width: 50%;">Ngày 
                            <asp:Label ID="lbday2" runat="server" Text=""></asp:Label>
                                    tháng  
                            <asp:Label ID="lbMonth2" runat="server" Text=""></asp:Label>
                                    năm 
                            <asp:Label ID="lbYear2" runat="server" Text=""></asp:Label><br />
                                    Người nhận
                            <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>
                <asp:Button ID="btPrint" OnClientClick="javascript:CallPrint();" runat="server" Text="In Phiếu Thu" BackColor="#4c4c27"
                    Font-Size="12px" ForeColor="White" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
