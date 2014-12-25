<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Room.ascx.cs" Inherits="Distributor_UserControl_uc_Room" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .web_dialog_overlay {
        position: fixed;
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
        height: 100%;
        width: 100%;
        margin: 0;
        padding: 0;
        background: #000000;
        opacity: .15;
        filter: alpha(opacity=15);
        -moz-opacity: .15;
        z-index: 101;
    }

    .web_dialog {
        position: fixed;
        width: 380px;
        height: 435px;
        top: 30%;
        left: 50%;
        margin-left: -190px;
        margin-top: -100px;
        background-color: #ffe6f8;
        border: 2px solid #4c4c27;
        padding: 0px;
        z-index: 102;
        font-family: Verdana;
        font-size: 10pt;
    }

    .web_dialog_title {
        border-bottom: solid 2px #4c4c27;
        background-color: #4c4c27;
        padding: 4px;
        color: White;
        font-weight: bold;
    }

        .web_dialog_title a {
            color: White;
            text-decoration: none;
        }

    .align_right {
        text-align: right;
    }
</style>
<script src="scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#btnShowSimple").click(function (e) {
            ShowDialog(false);
            e.preventDefault();
        });

        $(".btnShowModal").click(function (e) {
            ShowDialog(true);
            //                e.preventDefault();
        });

        $("#btnClose").click(function (e) {
            HideDialog();
            e.preventDefault();
        });

        $("#btDatPhong").click(function (e) {
            HideDialog();
            e.preventDefault();
        });
    });
    function ShowDialog(modal) {
        $("#overlay").show();
        $("#dialog").fadeIn(300);

        if (modal) {
            $("#overlay").unbind("click");
        }
        else {
            $("#overlay").click(function (e) {
                HideDialog();
            });
        }
    }

    function HideDialog() {
        $("#overlay").hide();
        $("#dialog").fadeOut(300);
    }
</script>
<asp:UpdatePanel ID="update" runat="server">
    <ContentTemplate>
        <div style="text-align: center; width: 100%; height: auto; color: #4c4c27; font-size: 15px;">
            <div style="text-align: center;">
                <br />
                <span class="titleText">Thông Tin Phòng Họp 
                <asp:Label ID="lbRoomName" runat="server" Text="Label"></asp:Label></span>
                <br />
                <hr />
            </div>
            <div style="text-align: center; border: 0px; border-style: double; width:100%;">
                <table style="text-align: left; margin-left: auto; margin-right: auto; width:80%;">
                    <tr>
                        <td class="td_title">Mã phòng:</td>
                        <td class="td_value">
                            <asp:Label ID="lbMaPhong" runat="server" Text=""></asp:Label></td>
                        <td class="td_title">Tên phòng:</td>
                        <td class="td_value">
                            <asp:Label ID="lbTenPhong" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_title">Số người:</td>
                        <td class="td_value">
                            <asp:Label ID="lbSucChua" runat="server" Text=""></asp:Label></td>
                        <td class="td_title">Giá thuê theo tháng:</td>
                        <td class="td_value">
                            <asp:Label ID="lbGiaThang" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_title">Giá từ thứ 2 đến thứ 6, 8h-12h:</td>
                        <td class="td_value">
                            <asp:Label ID="lbGiaPhong" runat="server" Text=""></asp:Label></td>
                        <td class="td_title">Giá thứ 7 và chủ nhật, 8h-12h:</td>
                        <td class="td_value">
                            <asp:Label ID="lbGiaCuoiTuan" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_title">Giá từ thứ 2 đến thứ 6, 13h-17h:</td>
                        <td class="td_value">
                            <asp:Label ID="lbGiaChieuThuong" runat="server" Text=""></asp:Label></td>
                        <td class="td_title">Giá thứ 7 và chủ nhật, 13h-17h:</td>
                        <td class="td_value">
                            <asp:Label ID="lbGiaChieuCuoi" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_title">Giá từ thứ 2 đến thứ 6, 18h-22h:</td>
                        <td class="td_value">
                            <asp:Label ID="lbGiaToiThuong" runat="server" Text=""></asp:Label></td>
                        <td class="td_title">Giá thứ 7 và chủ nhật, 18h-22h:</td>
                        <td class="td_value">
                            <asp:Label ID="lbGiaToiCuoi" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                <br />
            </div>
            <div style="text-align: center; width: 100%; font-family: Tahoma; color: #4c4c27; font-size: 12px; font-weight: bold;">
                Chọn tháng&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:DropDownList ID="ddlThang" runat="server" Height="22px">
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
                &nbsp;&nbsp;&nbsp;&nbsp; Chọn năm&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlNam" runat="server" 
                Font-Bold="True" Height="22px">
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
                &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button CssClass="btn_admin" ID="btXemLich" runat="server" Font-Bold="True" OnClick="btXemLich_Click"
                Text="Xem Lịch" />
            </div>
            <br />
            <hr />
            <div style="display: table; width:100%;">
                <table border="0" width="100%" cellpadding="2" cellspacing="0" class="borderTable">
                    <asp:Repeater ID="repeat" runat="server" onitemcommand="repeat_ItemCommand">
                        <HeaderTemplate>
                            <tr style="background-color: #4c4c27; color: White;">
                                <th>Ngày
                                </th>
                                <th>Từ 8 giờ đến 12 giờ
                                </th>
                                <th>Từ 13 giờ đến 17 giờ
                                </th>
                                <th>Từ 18 giờ đến 22 giờ
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>

                            <!--<tr style= "background-color:White;  color:#4c4c27; "> -->
                            <tr style='<%# Eval("Weekend")=="Y"?"background-color:White;  color:red; ": "background-color:White;  color:#4c4c27;" %>'>
                                <td class="borderTD" style="text-align: right; width:15%;">
                                    <%# DataBinder.Eval(Container.DataItem, "Ngay")%>
                                </td>
                                <td class="borderTD">
                                    <asp:LinkButton ID="btClick" Style="color: Blue; text-decoration: none;" CommandName="Ca1" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Ngay")%>' runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Ca1").ToString() == ""%>' Text="Phòng Vẫn Còn Trống"></asp:LinkButton>
                                    <%# DataBinder.Eval(Container.DataItem, "Ca1")%>
                                </td>
                                <td class="borderTD">
                                    <asp:LinkButton ID="Label1" style = "color:Blue; text-decoration:none;" CommandName="Ca2" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Ngay")%>' runat="server" Visible = '<%# DataBinder.Eval(Container.DataItem, "Ca2").ToString() == ""%>'>Phòng Vẫn Còn Trống</asp:LinkButton>
                                    <%# DataBinder.Eval(Container.DataItem, "Ca2")%>
                                </td>
                                <td class="borderTD">
                                    <asp:LinkButton ID="Label2" style = "color:Blue; text-decoration:none;" CommandName="Ca3" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Ngay")%>' runat="server" Visible = '<%# DataBinder.Eval(Container.DataItem, "Ca3").ToString() == ""%>'>Phòng Vẫn Còn Trống</asp:LinkButton>
                                    <%# DataBinder.Eval(Container.DataItem, "Ca3")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <br />
            </div>
        </div>

        <asp:Panel ID="panel" runat="server" Style="display: none;">
            <div id="overlay" class="web_dialog_overlay"></div>
            <div id="dialog" class="web_dialog">
                <table style="text-align: left; width: 100%; border: 0px; color: #4c4c27;" cellpadding="3" cellspacing="0">
                    <tr>
                        <td colspan="2" class="web_dialog_title">Đặt Phòng Họp</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <b>Nhập thông tin người đặt phòng</b>
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
                    </tr>
                    <tr>
                        <td style="padding-left: 15px;">ADA ID
                        </td>
                        <td>
                            <asp:TextBox ID="txtADAID" runat="server" Width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px;">Họ và tên
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px;">Địa chỉ
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px;">Thư điện tử
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px;">Số điện thoại
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" Width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px;">Ngày hội họp
                        </td>
                        <td>
                            <asp:Label ID="lbDate" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px;">Giờ hội họp
                        </td>
                        <td>
                            <asp:Label ID="lbSection" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px;">Ghi chú
                        </td>
                        <td>
                            <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" Width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px;">Đã đóng tiền
                        </td>
                        <td>
                            <asp:CheckBox ID="chkPaid" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px;">Trạng thái
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem>Y</asp:ListItem>
                                <asp:ListItem>N</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="btDatPhong" runat="server" Text="Đăng ký" BackColor="#4c4c27"
                                Font-Size="12px" ForeColor="White" OnClick="btDatPhong_Click" />
                            <asp:Button ID="btCapNhat" runat="server" Text="Cập nhật" BackColor="#4c4c27"
                                Font-Size="12px" ForeColor="White" OnClick="btCapNhat_Click" />
                            <asp:Button ID="btThoat" runat="server" Text="Thoát" BackColor="#4c4c27"
                                Font-Size="12px" ForeColor="White" OnClick="btThoat_Click" />
                        </td>
                    </tr>
                </table>

            </div>
        </asp:Panel>
        <asp:ModalPopupExtender ID="popup" TargetControlID="Button1" runat="server" PopupControlID="panel">
        </asp:ModalPopupExtender>
        <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none;" />
    </ContentTemplate>
</asp:UpdatePanel>
