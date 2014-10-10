<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SupportCostForeignerClone.ascx.cs" Inherits="Meeting_UserControl_uc_SupportCostForeignerClone" %>

<div class="TitlePage">
    ĐƠN ĐĂNG KÝ HỘI HỌP
        <br />
    (HỖ TRỢ CHI PHÍ & DIỄN GIẢ NGƯỜI NƯỚC NGOÀI)

</div>
<div class="TitlePageSub">
    ĐƠN ĐĂNG KÝ HỘI HỌP PHẢI NỘP CHO AMWAY PHÊ DUYỆT TỐI THIỂU 30
        <br />
    NGÀY LÀM VIỆC TRƯỚC NGÀY TỔ CHỨC HỘI HỌP

</div>
<script type="text/javascript">
    function BindEvents() {
        $(document).ready(function () {
            var objTuNgay = document.getElementById("<%=txtMEETING_DATE.ClientID %>");
            var objSend = document.getElementById("<%=txtSEND_INVITATION_DATE.ClientID %>");
            $(objTuNgay).datepicker({
                showOn: "button",
                buttonImage: "../images/calendar.gif",
                buttonImageOnly: true
            }),
           $(objSend).datepicker({
               showOn: "button",
               buttonImage: "../images/calendar.gif",
               buttonImageOnly: true
           });
        });
    }
</script>
<script type="text/javascript">
    function maxPayment(objTotal) {
        var objMaxPayment = document.getElementById("<%=hdfMAXPAYMENT.ClientID %>");
        var objAmwPay = document.getElementById("<%=lblAMWAY_PAY.ClientID %>");
        var objDistributor = document.getElementById("<%=lblDISTRIBUTOR_PAY.ClientID %>");
        var MaxPayment = 0;
        var AmwayPay = 0;
        var Total = 0;
        var DistributorPay = 0;
        if (parseFloat(replaceAll(objMaxPayment.value, ',', '')) > 0) {
            MaxPayment = parseFloat(replaceAll(objMaxPayment.value, ',', ''));
            Total = parseFloat(replaceAll(objTotal.value, ',', ''));
            // tinh tien theo 80%
            AmwayPay = Math.round(Total * 0.8);
            if (AmwayPay > MaxPayment) {
                AmwayPay = MaxPayment;
            }
            DistributorPay = Total - AmwayPay;
            objAmwPay.innerHTML = addCommasString(AmwayPay);
            objDistributor.innerHTML = addCommasString(DistributorPay);
        }
        else {
            return;
        }

    }
    function CheckWater(obj) {
        var value = parseFloat(replaceAll(obj.value, ',', ''));
        if (value > 25000) {
            value = 25000;
        }
        obj.value = addCommasString(value);
        return;
    }
    function CheckFood(obj) {
        var value = parseFloat(replaceAll(obj.value, ',', ''));
        if (value > 30000) {
            value = 30000;
        }
        obj.value = addCommasString(value);
        return;
    }
</script>
<asp:Panel runat="server" ID="hehe">
    <fieldset>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <script>
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_endRequest(function () {
                        BindEvents();
                    });

                    $(function () {
                        var objTuNgay = document.getElementById("<%=txtMEETING_DATE.ClientID %>");
                        var objSend = document.getElementById("<%=txtSEND_INVITATION_DATE.ClientID %>");
                        $(objTuNgay).datepicker({
                            showOn: "button",
                            buttonImage: "../images/calendar.gif",
                            buttonImageOnly: true
                        }),
                       $(objSend).datepicker({
                           showOn: "button",
                           buttonImage: "../images/calendar.gif",
                           buttonImageOnly: true
                       });
                    });
                </script>

                <asp:Panel runat="server" ID="pnlSearch">
                    <div style="text-align: left; width: 100%">
                        <table width="100%">
                            <tr>
                                <td colspan="6">
                                    <b>I.	THÔNG TIN NGƯỜI TỔ CHỨC (NGƯỜI TỔ CHỨC CHỊU TRÁCH NHIỆM MỌI VẤN ĐỀ LIÊN QUAN ĐẾN HỘI HỌP, LÀ NGƯỜI LIÊN LẠC TRỰC TIẾP VỚI AMWAY)</b>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td class="tdmeeting2"></td>
                                <td class="tdmeeting3"></td>
                                <td class="tdmeeting4"></td>
                                <td class="tdmeeting5"></td>
                                <td class="tdmeeting6"></td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Mã số ADA<span style="color: Red">(*)</span>:
                                    <asp:TextBox ID="txtORGANIZER_ADAID" CssClass="txtBox" runat="server" Width="70px"></asp:TextBox>
                                    <asp:HiddenField ID="hdfORGANIZER_USERID" runat="server"></asp:HiddenField>
                                    &nbsp;
                                </td>
                                <td align="left" class="tdmeeting3" colspan="3">Họ tên:
                                     <asp:Label ID="lblORGANIZER_NAME" runat="server" CssClass="lblMeeting"></asp:Label>
                                </td>

                                <td align="left" class="tdmeeting6">Danh hiệu:
                                     <asp:Label ID="lblORGANIZER_USERTYPENAME" runat="server" CssClass="lblMeeting"></asp:Label>
                                    <asp:HiddenField ID="hdfORGANIZER_USERTYPEID" runat="server"></asp:HiddenField>
                                </td>

                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2" colspan="4">Mọi thông tin liên lạc qua mail:
                                   <asp:Label ID="lblORGANIZER_EMAIL" runat="server" CssClass="lblMeeting"></asp:Label>
                                </td>
                                <td align="left" class="tdmeeting6">Số điện thoại:
                                   <asp:Label ID="lblORGANIZER_TELEPHONE" runat="server" CssClass="lblMeeting"></asp:Label>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2" colspan="5">Địa điểm cư ngụ:
                                   <asp:Label ID="lblORGANIZER_ADDRESS" runat="server" CssClass="lblMeeting"></asp:Label>
                                </td>
                                <td class="tdmeeting7"></td>

                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td class="tdmeeting2" colspan="5">
                                    <div style="margin-left: 5px;">
                                        <b>1.	Loại hội họp:</b>
                                    </div>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">
                                    <div class="marginLeft10">
                                        Chọn pax<span style="color: Red">(*)</span>:
                                    <asp:DropDownList ID="ddlPAXID" runat="server" Width="100px" Height="22px" CssClass="txtBox" AutoPostBack="True" OnSelectedIndexChanged="ddlPAXID_SelectedIndexChanged">
                                        <asp:ListItem Value="default" Text="100 pax" />
                                    </asp:DropDownList>
                                        <asp:HiddenField ID="hdfPAXID_OLD" runat="server"></asp:HiddenField>
                                    </div>
                                </td>
                                <td align="left" class="tdmeeting3" colspan="2">Chọn tỉnh thành<span style="color: Red">(*)</span>:
                                     <asp:DropDownList ID="ddlPROVINCEID" runat="server" Width="150px" Height="22px" CssClass="txtBox" AutoPostBack="True" OnSelectedIndexChanged="ddlPROVINCEID_SelectedIndexChanged">
                                     </asp:DropDownList>
                                </td>
                                <td align="left" class="tdmeeting5" colspan="2">Chọn Quận huyện<span style="color: Red">(*)</span>:
                                    <asp:DropDownList ID="ddlDISTRICTID" runat="server" Width="150px" Height="22px" CssClass="txtBox" AutoPostBack="True" OnSelectedIndexChanged="ddlDISTRICTID_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="Panel1">
                    <div style="text-align: left; width: 100%">
                        <table width="100%">
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td class="tdmeeting2" colspan="5">
                                    <div style="margin-left: 5px;">
                                        <b>2.	Sử dụng chỉ tiêu đăng ký hội họp của:</b>
                                    </div>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>

                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">
                                    <div class="marginLeft10">
                                        1. Mã số ADA:
                                    <asp:TextBox ID="txtCO_ORGANIZER_ADAID_1" CssClass="txtBox" runat="server" Width="70px"></asp:TextBox>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_USERID_1" runat="server"></asp:HiddenField>
                                        <div class="divImgCheckIcon10">
                                            <asp:ImageButton ID="ImgBtnCO_ORGANIZER_ADA1_CHECK" runat="server" Height="23px"
                                                ImageUrl="~/images/search.png" Width="26px" OnClick="ImgBtnCO_ORGANIZER_ADA1_CHECK_Click" />
                                        </div>
                                    </div>
                                </td>
                                <td align="left" class="tdmeeting3">Họ tên:
                                     <asp:Label ID="lblCO_ORGANIZER_NAME_1" runat="server" CssClass="lblMeeting"></asp:Label>

                                </td>
                                <td class="tdmeeting4"></td>
                                <td align="left" class="tdmeeting5">Danh hiệu:
                                     <asp:Label ID="lblCO_ORGANIZER_USERTYPENAME_1" runat="server" CssClass="lblMeeting"></asp:Label>
                                    <asp:HiddenField ID="hdfCO_ORGANIZER_USERTYPEID_1" runat="server"></asp:HiddenField>
                                </td>
                                <td align="left" class="tdmeeting6">
                                    <div id="divCO_ORGANIZER_QUOTA_1" runat="server" visible="false">
                                        Tình trạng:
                                      <asp:ImageButton ID="ImgBtnCO_ORGANIZER_OK_1" runat="server" Height="14px"
                                          ImageUrl="~/images/check.png" Width="14px" Visible="false" />
                                        <asp:ImageButton ID="ImgBtnCO_ORGANIZER_ERROR_1" runat="server" Height="14px"
                                            ImageUrl="~/images/error.png" Width="14px" Visible="false"
                                            AlternateText="Quota Expire, Click Here to borrow quota !" />
                                        <asp:Label ID="lblCO_ORGANIZER_OK_1" runat="server" CssClass="lblOk"></asp:Label>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_QUOTA_CHECK_1" runat="server"></asp:HiddenField>
                                    </div>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">
                                    <div class="marginLeft10">
                                        2. Mã số ADA:
                                    <asp:TextBox ID="txtCO_ORGANIZER_ADAID_2" CssClass="txtBox" runat="server" Width="70px"></asp:TextBox>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_USERID_2" runat="server"></asp:HiddenField>
                                        <div class="divImgCheckIcon10">
                                            <asp:ImageButton ID="ImgBtnCO_ORGANIZER_ADA2_CHECK" runat="server" Height="23px"
                                                ImageUrl="~/images/search.png" Width="26px" OnClick="ImgBtnCO_ORGANIZER_ADA2_CHECK_Click" />
                                        </div>
                                    </div>
                                </td>
                                <td align="left" class="tdmeeting3">Họ tên:
                                    <asp:Label ID="lblCO_ORGANIZER_NAME_2" runat="server" CssClass="lblMeeting"></asp:Label>

                                </td>
                                <td class="tdmeeting4"></td>
                                <td align="left" class="tdmeeting5">Danh hiệu:
                                    <asp:Label ID="lblCO_ORGANIZER_USERTYPENAME_2" runat="server" CssClass="lblMeeting"></asp:Label>
                                    <asp:HiddenField ID="hdfCO_ORGANIZER_USERTYPEID_2" runat="server"></asp:HiddenField>
                                </td>
                                <td align="left" class="tdmeeting6">
                                    <div id="divCO_ORGANIZER_QUOTA_2" runat="server" visible="false">
                                        Tình trạng:
                                      <asp:ImageButton ID="ImgBtnCO_ORGANIZER_OK_2" runat="server" Height="14px"
                                          ImageUrl="~/images/check.png" Width="14px" Visible="false" />
                                        <asp:ImageButton ID="ImgBtnCO_ORGANIZER_ERROR_2" runat="server" Height="14px"
                                            ImageUrl="~/images/error.png" Width="14px" Visible="false"
                                            AlternateText="Quota Expire, Click Here to borrow quota !" />
                                        <asp:Label ID="lblCO_ORGANIZER_OK_2" runat="server" CssClass="lblOk"></asp:Label>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_QUOTA_CHECK_2" runat="server"></asp:HiddenField>
                                    </div>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">
                                    <div class="marginLeft10">
                                        3. Mã số ADA:
                                    <asp:TextBox ID="txtCO_ORGANIZER_ADAID_3" CssClass="txtBox" runat="server" Width="70px"></asp:TextBox>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_USERID_3" runat="server"></asp:HiddenField>
                                        <div class="divImgCheckIcon10">
                                            <asp:ImageButton ID="ImgBtnCO_ORGANIZER_ADA3_CHECK" runat="server" Height="23px"
                                                ImageUrl="~/images/search.png" Width="26px" OnClick="ImgBtnCO_ORGANIZER_ADA3_CHECK_Click" />
                                        </div>
                                    </div>
                                </td>
                                <td align="left" class="tdmeeting3">Họ tên:
                                     <asp:Label ID="lblCO_ORGANIZER_NAME_3" runat="server" CssClass="lblMeeting"></asp:Label>

                                </td>
                                <td class="tdmeeting4"></td>
                                <td align="left" class="tdmeeting5">Danh hiệu:
                                     <asp:Label ID="lblCO_ORGANIZER_USERTYPENAME_3" runat="server" CssClass="lblMeeting"></asp:Label>
                                    <asp:HiddenField ID="hdfCO_ORGANIZER_USERTYPEID_3" runat="server"></asp:HiddenField>

                                </td>
                                <td align="left" class="tdmeeting6">
                                    <div id="divCO_ORGANIZER_QUOTA_3" runat="server" visible="false">
                                        Tình trạng:
                                      <asp:ImageButton ID="ImgBtnCO_ORGANIZER_OK_3" runat="server" Height="14px"
                                          ImageUrl="~/images/check.png" Width="14px" Visible="false" />
                                        <asp:ImageButton ID="ImgBtnCO_ORGANIZER_ERROR_3" runat="server" Height="14px"
                                            ImageUrl="~/images/error.png" Width="14px" Visible="false"
                                            AlternateText="Quota Expire, Click Here to borrow quota !" />
                                        <asp:Label ID="lblCO_ORGANIZER_OK_3" runat="server" CssClass="lblOk"></asp:Label>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_QUOTA_CHECK_3" runat="server"></asp:HiddenField>
                                    </div>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="Panel2">
                    <div style="text-align: left; width: 100%">
                        <table width="100%">
                            <tr>
                                <td colspan="6">
                                    <b>II.	THÔNG TIN CUỘC HỌP</b><span style="color: Red"> (Là thông tin được gửi cho Sở Công Thương để xin phép hội họp. Vui lòng kê khai chính xác, bằng tiếng Việt và có dấu)</span>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Tên cuộc họp<span style="color: Red">(*)</span>:
                                    
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:TextBox ID="txtMEETINGNAME" CssClass="txtBox" runat="server" Width="99.2%"></asp:TextBox>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Số lượng người tham dự ước lượng<span style="color: Red">(*)</span>:
                                    
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:TextBox ID="txtNUMBER_OF_PARTICIPANT" CssClass="txtNumberBoxLeft" runat="server" Width="99.2%" onKeyUp="addCommas(event,this);"></asp:TextBox>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Chọn địa điểm họp<span style="color: Red">(*)</span>:
                                    
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:DropDownList ID="ddlPLACE" runat="server" Width="99.8%" Height="22px" CssClass="txtBox" AutoPostBack="True" OnSelectedIndexChanged="ddlPLACE_SelectedIndexChanged">
                                    </asp:DropDownList>

                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Tên địa điểm họp<span style="color: Red">(*)</span>:
                                    
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:TextBox ID="txtMEETING_PLACE_NAME" CssClass="txtBox" runat="server" Width="99.2%"></asp:TextBox>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Địa chỉ địa điểm họp<span style="color: Red">(*)</span>:
                                    
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:TextBox ID="txtMEETING_ADDRESS" CssClass="txtBox" runat="server" Width="99.2%"></asp:TextBox>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Ngày họp<span style="color: Red">(*)</span>:
                                     
                                </td>
                                <td align="left" class="tdmeeting3" colspan="2">
                                    <asp:TextBox ID="txtMEETING_DATE" CssClass="txtBoxDate" runat="server" Width="150px"></asp:TextBox>
                                <td align="left" class="tdmeeting5" colspan="2">Giờ họp(tối đa là 4 giờ)<span style="color: Red">(*)</span>:
                                        <div style="float: right; margin-right: 4px;">
                                            <asp:TextBox ID="txtMEETING_TIME" runat="server" Width="150px" CssClass="txtBox"></asp:TextBox>
                                        </div>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Hình thức thanh toán<span style="color: Red">(*)</span>:
                                    
                                        
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:DropDownList ID="ddlFORMS_OF_PAYMENTID" runat="server" Width="99.8%" Height="22px" CssClass="txtBox">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Giấy mời<span style="color: Red">(*)</span>:
                                    
                                        
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:DropDownList ID="ddlINVITATIONID" runat="server" Width="99.8%" Height="22px" CssClass="txtBox">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Biểu ngữ<span style="color: Red">(*)</span>:
                                    
                                      
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:DropDownList ID="ddlBANNERID" runat="server" Width="99.8%" Height="22px" CssClass="txtBox">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Ngày phát giấy mời<span style="color: Red">(*)</span>:
                                      
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:TextBox ID="txtSEND_INVITATION_DATE" CssClass="txtBoxDate" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Phiếu nước uống<span style="color: Red">(*)</span>:
                                    
                                    
                                </td>
                                <td align="left" class="tdmeeting3">
                                    <asp:DropDownList ID="ddlWATER" runat="server" Width="70px" Height="22px" CssClass="txtBox">
                                        <asp:ListItem Value="False" Text="Không" />
                                        <asp:ListItem Value="True" Text="Có" />
                                    </asp:DropDownList>
                                </td>
                                <td class="tdmeeting4"></td>
                                <td align="left" class="tdmeeting5" colspan="2">Giá phiếu nước uống:
                                        <div style="float: right">
                                            <asp:TextBox ID="txtWATER_PRICE" CssClass="txtNumberBox" runat="server" Width="140px" onKeyUp="CheckWater(this);"></asp:TextBox>
                                            đồng/phiếu.
                                        </div>
                                </td>

                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Phiếu thức ăn<span style="color: Red">(*)</span>:
                                    
                                </td>
                                <td align="left" class="tdmeeting3">
                                    <asp:DropDownList ID="ddlFOOD" runat="server" Width="70px" Height="22px" CssClass="txtBox">
                                        <asp:ListItem Value="False" Text="Không" />
                                        <asp:ListItem Value="True" Text="Có" />
                                    </asp:DropDownList>
                                </td>
                                <td class="tdmeeting4"></td>
                                <td align="left" class="tdmeeting5" colspan="2">Giá phiếu thức ăn:
                                        <div style="float: right">
                                            <asp:TextBox ID="txtFOOD_PRICE" CssClass="txtNumberBox" runat="server" Width="140px" onKeyUp="CheckFood(this);"></asp:TextBox>
                                            đồng/phiếu.
                                        </div>
                                </td>

                                <td class="tdmeeting7"></td>
                            </tr>

                            <tr>
                                <td colspan="7">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <b>III.	NỘI DUNG PHÁT BIỂU CỦA DIỄN GIẢ NGƯỜI NƯỚC NGOÀI</b>

                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Đề tài phát biểu chính:
                                    
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:TextBox ID="txtSPEAKER_TITLE_1" CssClass="txtBox" runat="server" Width="99.2%"></asp:TextBox>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>

                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Mã số ADA:
                                    <asp:TextBox ID="txtSPEAKER_ADAID_1" CssClass="txtBox" runat="server" Width="70px"></asp:TextBox>
                                </td>
                                <td align="left" class="tdmeeting3">Họ tên:
                                     <asp:TextBox ID="txtSPEAKER_NAME_1" CssClass="txtBox" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td class="tdmeeting4"></td>
                                <td align="left" class="tdmeeting5">Danh hiệu:
                                     <asp:TextBox ID="txtSPEAKER_USERTYPENAME_1" CssClass="txtBox" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td align="left" class="tdmeeting6">
                                    <div style="float: right; margin-right: 4px">
                                        Quốc tịch:
                                             <asp:TextBox ID="txtSPEAKER_NATION_1" CssClass="txtBox" runat="server" Width="150px"></asp:TextBox>

                                    </div>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Đề tài phát biểu chính:
                                    
                                </td>
                                <td align="left" class="tdmeeting3" colspan="4">
                                    <asp:TextBox ID="txtSPEAKER_TITLE_2" CssClass="txtBox" runat="server" Width="99.2%"></asp:TextBox>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>

                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Mã số ADA:
                                    <asp:TextBox ID="txtSPEAKER_ADAID_2" CssClass="txtBox" runat="server" Width="70px"></asp:TextBox>
                                </td>
                                <td align="left" class="tdmeeting3">Họ tên:
                                     <asp:TextBox ID="txtSPEAKER_NAME_2" CssClass="txtBox" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td class="tdmeeting4"></td>
                                <td align="left" class="tdmeeting5">Danh hiệu:
                                     <asp:TextBox ID="txtSPEAKER_USERTYPENAME_2" CssClass="txtBox" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td align="left" class="tdmeeting6">
                                    <div style="float: right; margin-right: 4px">
                                        Quốc tịch:
                                             <asp:TextBox ID="txtSPEAKER_NATION_2" CssClass="txtBox" runat="server" Width="150px"></asp:TextBox>

                                    </div>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <b>IV.	CHI PHÍ</b>
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Tổng chi phí<span style="color: Red">(*)</span>:
                                    
                                </td>
                                <td align="right" class="tdmeeting3">
                                    <asp:TextBox ID="txtTOTAL_PAY" CssClass="txtNumberBox" runat="server" Width="198px" onKeyUp="addCommas(event,this);maxPayment(this);"></asp:TextBox>&nbsp;(VNĐ)
                                        <asp:HiddenField ID="hdfMAXPAYMENT" runat="server" />
                                </td>
                                <td class="tdmeeting4"></td>
                                <td align="left" class="tdmeeting5"></td>
                                <td align="left" class="tdmeeting6"></td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdmeeting1"></td>
                                <td align="left" class="tdmeeting2">Số tiền Amway trả:
                                    
                                </td>
                                <td align="right" class="tdmeeting3">
                                    <asp:Label ID="lblAMWAY_PAY" CssClass="lblMeeting" runat="server" Width="180px"></asp:Label>&nbsp;(VNĐ)
                                </td>
                                <td class="tdmeeting4"></td>
                                <td align="left" class="tdmeeting5">Số tiền nhà phân phối trả:
                                    
                                </td>
                                <td align="right" class="tdmeeting6">
                                    <asp:Label ID="lblDISTRIBUTOR_PAY" CssClass="lblMeeting" runat="server" Width="180px"></asp:Label>&nbsp;(VNĐ)
                                </td>
                                <td class="tdmeeting7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr id="trWarning" runat="server" visible="false">
                                <td colspan="7">
                                    <hr />
                                    <div style="text-align: left;">
                                        <asp:Label ID="lblWarning" runat="server" CssClass="Alerting" Text=""></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <hr />
                                    <div style="text-align: left;">
                                        <asp:CheckBox runat="server" ID="chkAgree" CssClass="Agree" Text="Tôi chịu trách nhiệm tuân thủ tất cả các quy định nêu trên và hiểu rằng đơn xin hội họp của tôi chỉ có hiệu lực khi được Amway chấp thuận và đơn này có thể sẽ bị hủy bỏ nếu tôi không tuân thủ Các Quy Tắc Ứng Xử của Amway cũng như Luật Pháp Việt Nam. Tôi cam kết rằng tất cả các thông tin cung cấp là trung thực và chính xác. Tôi sẽ hoàn toàn chịu trách nhiệm trước Amway cũng như cơ quan pháp luật đối với tất cả các hoạt động có liên quan đến buổi họp này. " />

                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <hr />
                                    <div style="text-align: center;">
                                        <br />
                                        <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr id="trSave" runat="server" visible="false">
                                <td colspan="7">
                                    <div style="text-align: center;">
                                        <br />
                                        <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Đăng ký" OnClick="btnSave_Click" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

                <asp:HiddenField runat="server" ID="hdfID" />
                <asp:HiddenField ID="hdfReported" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Panel runat="server" ID="Panel4">
            <div style="text-align: left; width: 100%">
                <table width="100%">
                    <tr id="trReport" runat="server" visible="false">
                        <td>
                            <div style="text-align: center;">
                                <br />
                                <asp:Button CssClass="btn_admin" ID="btnReport" runat="server" Text="Báo cáo" Visible="true" OnClick="btnReport_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button CssClass="btn_admin" ID="btnClone" runat="server" Text="Sao chép" OnClick="btnClone_Click"/>
                                 </div>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel3">
            <div style="text-align: left; width: 100%">
                <table width="100%">
                    <tr>
                        <td colspan="6">
                            <hr />
                            <b>* Các thông tin hội họp đính kèm nộp cho Amway</b>
                        </td>
                        <td class="tdmeeting7"></td>
                    </tr>
                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>
                    <tr>
                        <td class="tdmeeting1"></td>
                        <td align="left" class="tdmeeting2" colspan="4">
                            <div class="marginLeft10">
                                -	Hộ chiếu của diễn giả người nước ngoài
                            </div>

                        </td>
                        <td class="tdmeeting7"></td>
                    </tr>
                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>
                    <tr>
                        <td class="tdmeeting1"></td>
                        <td align="left" class="tdmeeting2" colspan="4">
                            <div class="marginLeft10">
                                -	Nội dung chương trình (Lưu trình)
                            </div>
                        </td>
                        <td class="tdmeeting7"></td>
                    </tr>
                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>
                    <tr>
                        <td class="tdmeeting1"></td>
                        <td align="left" class="tdmeeting2" colspan="4">
                            <div class="marginLeft10">
                                -	Nội dung phát biếu của diễn giả người nước ngoài.
                            </div>
                        </td>
                        <td class="tdmeeting7"></td>
                    </tr>
                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>
                    <tr>
                        <td class="tdmeeting1"></td>
                        <td align="left" class="tdmeeting2" colspan="4">
                            <div class="marginLeft10">
                                -	Thư hoặc Email xác nhận của diễn giả người nước ngoài qua Việt Nam tham dư và chia sẽ hội họp.
                            </div>

                        </td>
                        <td class="tdmeeting7"></td>
                    </tr>
                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>
                    <tr>
                        <td class="tdmeeting1"></td>
                        <td align="left" class="tdmeeting2" colspan="4">
                            <div class="marginLeft10">
                                -	Danh sách 10 người có cấp bậc cao nhất trong buổi họp (Họ tên, danh hiệu)
                            </div>

                        </td>
                        <td class="tdmeeting7"></td>
                    </tr>

                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>
                    <tr>
                        <td class="tdmeeting1"></td>
                        <td align="left" class="tdmeeting2" colspan="4">
                            <div class="marginLeft10">
                                -	Danh sách số lượng người tham dự hội họp (Họ tên, số chứng minh thư)
                            </div>

                        </td>
                        <td class="tdmeeting7"></td>
                    </tr>
                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>

                </table>
            </div>
        </asp:Panel>

    </fieldset>
</asp:Panel>
