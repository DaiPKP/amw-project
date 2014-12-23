<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageRejectBooking.aspx.cs" Inherits="ManageBookingRoom" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .web_dialog_overlay
        {
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
        .web_dialog
        {
            
            position: fixed;
            width: 380px;
            height: 330px;
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
        .web_dialog_title
        {
            border-bottom: solid 2px #4c4c27;
            background-color: #4c4c27;
            padding: 4px;
            color: White;
            font-weight:bold;
        }
        .web_dialog_title a
        {
            color: White;
            text-decoration: none;
        }
        .align_right
        {
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
                e.preventDefault();
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="text-align: center; width:100%; height:auto; float:right; font-family:Tahoma; color:#4c4c27; font-size:13px;">
    <span class="titleText">Danh Sách Đặt Phòng</span><br />
        <img src="/Images/line.gif" />
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
        
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#4c4c27" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Code" 
            DataSourceID="SqlDataSourceManageBooking">
            <Columns>
                <asp:TemplateField ItemStyle-Width = "10px" HeaderText = "">
                   <ItemTemplate>
                       <asp:LinkButton ID="lnkEdit" runat="server" Text = "Xem" OnClick = "Edit"></asp:LinkButton>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Date" HeaderText="Ngày" SortExpression="Date" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="ADA_ID" HeaderText="ADA ID" 
                    SortExpression="ADA_ID" />
                <asp:BoundField DataField="ADA_Name" HeaderText="Họ tên" 
                    SortExpression="ADA_Name" />
                <asp:BoundField DataField="Phone" HeaderText="Điện thoại" SortExpression="Phone" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Address" HeaderText="Địa chỉ" 
                    SortExpression="Address" />
                <asp:BoundField DataField="RoomCode" HeaderText="Mã phòng" 
                    SortExpression="RoomCode" />
                <asp:BoundField DataField="Section" HeaderText="Buổi" 
                    SortExpression="Section" />
                <asp:BoundField DataField="Status" HeaderText="Trạng thái" 
                    SortExpression="Status" />
                <asp:BoundField DataField="Code" HeaderText="Code" 
                    SortExpression="Code" />
            </Columns>
            <FooterStyle BackColor="#4c4c27" ForeColor="#003399" />
            <HeaderStyle BackColor="#4c4c27" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#4c4c27" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
      
    <asp:Panel ID="panel" runat="server" Visible="true" style = "display:none; width:100%; height:100%;">     
    <div id="dialog" class="web_dialog">
        <table style="text-align:left; width: 100%; border: 0px; color:#4c4c27;" cellpadding="3" cellspacing="0">
            <tr>
                <td colspan="2" class="web_dialog_title">Thông Tin Đặt Phòng</td>
            </tr>
            <tr>
                <td style="padding-left: 15px;">
                ADA ID
                </td>
                <td>
                    <asp:Label ID="txtADAID" runat="server" Width="220px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 15px;">
                    Họ và tên
                </td>
                <td>
                    <asp:Label ID="txtName" runat="server" Width="220px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 15px;">
                    Địa chỉ
                </td>
                <td>
                    <asp:Label ID="txtAddress" runat="server" Width="220px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 15px;">
                    Thư điện tử
                </td>
                <td>
                    <asp:Label ID="txtEmail" runat="server" Width="220px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 15px;">
                    Số điện thoại
                </td>
                <td>
                    <asp:Label ID="txtPhone" runat="server" Width="220px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 15px;">
                    Mã phòng
                </td>
                <td>
                    <asp:Label ID="lbRoomCode" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 15px;">
                    Ngày hội họp
                </td>
                <td>
                    <asp:Label ID="lbDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 15px;">
                    Giờ hội họp
                </td>
                <td>
                    <asp:Label ID="lbSection" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 15px;">
                    Trạng thái
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
                <%--    <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" onclick="btnUpdate_Click"/>--%>
                    <asp:Button ID="Button2" runat="server" Text="Thoát" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White"/>
                </td>
            </tr>
        </table>    
    </div>
    </asp:Panel>   
    <asp:ModalPopupExtender ID="popup" TargetControlID="Button1" runat="server" PopupControlID="panel">
    </asp:ModalPopupExtender> 
    <asp:Button ID="Button1" runat="server" Text="Button" style = "display:none"/>
    </ContentTemplate>
    </asp:UpdatePanel>
        <asp:SqlDataSource ID="SqlDataSourceManageBooking" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AmwayBookingRoomDBConnectionString %>" 
            SelectCommand="SELECT * FROM [RegistryRoom] where [Status] = 'N'"></asp:SqlDataSource>
    </div>
</asp:Content>

