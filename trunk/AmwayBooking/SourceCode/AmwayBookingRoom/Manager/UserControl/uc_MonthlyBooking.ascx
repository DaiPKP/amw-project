<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_MonthlyBooking.ascx.cs" Inherits="Manager_UserControl_uc_MonthlyBooking" %>
<asp:UpdatePanel ID="update" runat="server">
    <ContentTemplate>
        <div style="text-align: center; width: 100%; height: auto; float: right; font-family: Tahoma; color: #4c4c27; font-size: 13px;">
            <div>
                <span class="titleText">Đặt Phòng Theo Tháng</span><br />
                <img src="/Images/line.gif" />
            </div>
            <table style="text-align: left; width: 100%; border: 1px; border-style: solid; color: #4c4c27;" cellpadding="3" cellspacing="0">

                <tr>
                    <td colspan="4" style="text-align: center;">
                        <b>Nhập thông tin người đặt phòng</b>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">Chọn Tháng
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMonth" runat="server" BackColor="#4c4c27"
                            Font-Size="12px" ForeColor="White">
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="padding-left: 15px;">ADA ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtADAID" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">Chọn Năm
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlYear" runat="server" BackColor="#4c4c27"
                            Font-Size="12px" ForeColor="White">
                            <asp:ListItem>2012</asp:ListItem>
                            <asp:ListItem>2013</asp:ListItem>
                            <asp:ListItem>2014</asp:ListItem>
                            <asp:ListItem>2015</asp:ListItem>
                            <asp:ListItem>2016</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="padding-left: 15px;">Họ và tên
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">Chọn thành phố
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCity" runat="server" BackColor="#4c4c27"
                            Font-Size="12px" ForeColor="White" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="padding-left: 15px;">Thư điện tử
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">Chọn trung tâm
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCenter" runat="server" BackColor="#4c4c27"
                            Font-Size="12px" ForeColor="White" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="padding-left: 15px;">Số điện thoại
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">Chọn phòng
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRoom" runat="server" BackColor="#4c4c27"
                            Font-Size="12px" ForeColor="White">
                        </asp:DropDownList>
                    </td>
                    <td style="padding-left: 15px;">Địa chỉ
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">Đối tượng
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem>Distributor</asp:ListItem>
                            <asp:ListItem>Amway</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="padding-left: 15px;">Ghi chú
                    </td>
                    <td>
                        <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" Width="220px"></asp:TextBox>
                    </td>
                    <tr>
                        <td style="padding-left: 15px;">Đã đóng tiền
                        </td>
                        <td>
                            <asp:CheckBox ID="chkPaid" runat="server" />
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <asp:Button ID="btDatPhong" runat="server" Text="Đăng ký" BackColor="#4c4c27"
                            Font-Size="12px" ForeColor="White" OnClick="btDatPhong_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
