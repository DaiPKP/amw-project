<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ViewBooking.ascx.cs" Inherits="Manager_UserControl_ViewBooking" %>
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

<div style="text-align: center; width: 100%; height: auto; float: right;">
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
            <div>
                <span class="titleText">Tình Trạng Phòng Họp</span><br />
                <hr />
            </div>

            <div >
                Chọn Thành Phố 
            <asp:DropDownList ID="ddlCity" runat="server"
                Font-Size="12px" AutoPostBack="True"
                OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
            </asp:DropDownList>
                &nbsp; Chọn Trung Tâm
            <asp:DropDownList ID="ddlCenter" runat="server"
                Font-Size="12px" AutoPostBack="True"
                OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged">
            </asp:DropDownList>
                &nbsp; Chọn Phòng
            <asp:DropDownList ID="ddlRoom" runat="server"
                Font-Size="12px">
            </asp:DropDownList>
                <br />
                Chọn Tháng
            <asp:DropDownList ID="ddlMonth" runat="server">
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
                &nbsp; Chọn Năm
            <asp:DropDownList ID="ddlYear" runat="server">
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

                &nbsp;
            <asp:Button ID="btXemLich" CssClass="btn_admin" runat="server" Text="Xem Lịch" OnClick="btXemLich_Click" />
            </div>
            <hr />
            <div style="font-size: 12px; font-family: Tahoma; color: #4c4c27;">
                <table border="0" width="100%" cellpadding="2" cellspacing="0" class="borderTable">
                    <asp:Repeater ID="repeat" runat="server" OnItemCommand="repeat_ItemCommand">
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
                            <tr style='<%# Eval("Weekend")=="Y"?"background-color:White;  color:red; ": "background-color:White;  color:#4c4c27;" %>'>
                                <td class="borderTD" style="text-align: right;">
                                    <%# DataBinder.Eval(Container.DataItem, "Ngay")%>
                                </td>
                                <td class="borderTD">
                                    <%--<%# DataBinder.Eval(Container.DataItem, "Ca1")%>--%>
                                    <asp:LinkButton ID="btClick" Style="color: Blue; text-decoration: none;" CommandName="Ca1" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Ngay")%>' runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Ca1").ToString() == ""%>' Text="Phòng Vẫn Còn Trống"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" Style='<%# DataBinder.Eval(Container.DataItem, "Weekend").ToString() == "Y"?"color:Red; text-decoration:none;": "color:#4c4c27; text-decoration:none;" %>' CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Code1")%>' runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Ca1").ToString() != ""%>' Text='<%# DataBinder.Eval(Container.DataItem, "Ca1")%>'></asp:LinkButton>
                                    <img src="/Images/ok.png" style='<%# DataBinder.Eval(Container.DataItem, "Paid1").ToString() == "Y"?"width:15px;height:15px;float:right;": "display:none;" %>' />
                                </td>
                                <td class="borderTD">
                                    <%--<%# DataBinder.Eval(Container.DataItem, "Ca2")%>--%>
                                    <asp:LinkButton ID="Label1" Style="color: Blue; text-decoration: none;" CommandName="Ca2" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Ngay")%>' runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Ca2").ToString() == ""%>'>Phòng Vẫn Còn Trống</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" Style='<%# DataBinder.Eval(Container.DataItem, "Weekend").ToString() == "Y"?"color:Red; text-decoration:none;": "color:#4c4c27; text-decoration:none;" %>' CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Code2")%>' runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Ca2").ToString() != ""%>' Text='<%# DataBinder.Eval(Container.DataItem, "Ca2")%>'></asp:LinkButton>
                                    <img src="/Images/ok.png" style='<%# DataBinder.Eval(Container.DataItem, "Paid2").ToString() == "Y"?"width:15px;height:15px;float:right;": "display:none;" %>' />
                                </td>
                                <td class="borderTD">
                                    <%--<%# DataBinder.Eval(Container.DataItem, "Ca3")%>--%>
                                    <asp:LinkButton ID="Label2" Style="color: Blue; text-decoration: none;" CommandName="Ca3" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Ngay")%>' runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Ca3").ToString() == ""%>'>Phòng Vẫn Còn Trống</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" Style='<%# DataBinder.Eval(Container.DataItem, "Weekend").ToString() == "Y"?"color:Red; text-decoration:none;": "color:#4c4c27; text-decoration:none;" %>' CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Code3")%>' runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Ca3").ToString() != ""%>' Text='<%# DataBinder.Eval(Container.DataItem, "Ca3")%>'></asp:LinkButton>
                                    <img src="/Images/ok.png" style='<%# DataBinder.Eval(Container.DataItem, "Paid3").ToString() == "Y"?"width:15px;height:15px;float:right;": "display:none;" %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <br />
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
</div>
