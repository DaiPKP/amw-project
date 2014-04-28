<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_NotSupportCost.ascx.cs" Inherits="Meeting_UserControl_uc_NotSupportCost" %>
<div style="min-height: 800px; height: auto">
    <div class="TitlePage">
        ĐĂNG KÝ HỘI HỌP KHÔNG HỖ TRỢ CHI PHÍ
    </div>
    <script type="text/javascript">
        function BindEvents() {
            $(document).ready(function () {
                var objTuNgay = document.getElementById("<%=txtMEETING_STARTDATE.ClientID %>");
                var objDenNgay = document.getElementById("<%=txtMEETING_ENDDATE.ClientID %>");
                var objSend = document.getElementById("<%=txtSEND_INVITATION_DATE.ClientID %>");
                $(objTuNgay).datepicker({
                    showOn: "button",
                    buttonImage: "../images/calendar.gif",
                    buttonImageOnly: true
                }),
                $(objDenNgay).datepicker({
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script>
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {
                    BindEvents();
                });

                $(function () {
                    var objTuNgay = document.getElementById("<%=txtMEETING_STARTDATE.ClientID %>");
                    var objDenNgay = document.getElementById("<%=txtMEETING_ENDDATE.ClientID %>");
                    var objSend = document.getElementById("<%=txtSEND_INVITATION_DATE.ClientID %>");
                    $(objTuNgay).datepicker({
                        showOn: "button",
                        buttonImage: "../images/calendar.gif",
                        buttonImageOnly: true
                    }),
                    $(objDenNgay).datepicker({
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
            <asp:Panel runat="server" ID="hehe">
                <fieldset>
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
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Mã số ADA<span style="color: Red">(*)</span>:
                                    <asp:TextBox ID="txtORGANIZER_ADAID" CssClass="txtBox" runat="server" Width="70px"></asp:TextBox>
                                        <asp:HiddenField ID="hdfORGANIZER_USERID" runat="server"></asp:HiddenField>
                                        &nbsp;
                                    </td>
                                    <td align="left" class="tdmeeting3">Họ tên:
                                     <asp:Label ID="lblORGANIZER_NAME" runat="server" CssClass="lblMeeting"></asp:Label>
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">Danh hiệu:
                                     <asp:Label ID="lblORGANIZER_USERTYPENAME" runat="server" CssClass="lblMeeting"></asp:Label>
                                        <asp:HiddenField ID="hdfORGANIZER_USERTYPEID" runat="server"></asp:HiddenField>
                                    </td>
                                    <td class="tdmeeting6">
                                        
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2" colspan="3">Mọi thông tin liên lạc qua mail:
                                   <asp:Label ID="lblORGANIZER_EMAIL" runat="server" CssClass="lblMeeting"></asp:Label>
                                    </td>
                                    <td align="left" class="tdmeeting5" colspan="2">Số điện thoại:
                                   <asp:Label ID="lblORGANIZER_TELEPHONE" runat="server" CssClass="lblMeeting"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2" colspan="5">Địa chỉ nhân thư ủy quyền:
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
                                        </div>
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="2">Chọn tỉnh thành<span style="color: Red">(*)</span>:
                                     <asp:DropDownList ID="ddlPROVINCEID" runat="server" Width="150px" Height="22px" CssClass="txtBox" AutoPostBack="True" OnSelectedIndexChanged="ddlPROVINCEID_SelectedIndexChanged">
                                     </asp:DropDownList>
                                    </td>
                                    <td align="left" class="tdmeeting5">
                                        <div id="divORGANIZER_QUOTA_BTN" runat="server" visible="false">
                                            <asp:ImageButton ID="ImgBtnORGANIZER_CHECK" runat="server" Height="23px"
                                                ImageUrl="~/images/search.png" Width="26px" OnClick="ImgBtnORGANIZER_CHECK_Click" />

                                        </div>
                                    </td>
                                    <td align="left" class="tdmeeting6">
                                        <div id="divORGANIZER_QUOTA" runat="server" visible="false">
                                            Tình trạng Quota:
                                      <asp:ImageButton ID="ImgBtnORGANIZER_OK" runat="server" Height="14px"
                                          ImageUrl="~/images/check.png" Width="14px" Visible="false" />
                                            <asp:ImageButton ID="ImgBtnORGANIZER_ERROR" runat="server" Height="14px"
                                                ImageUrl="~/images/error.png" Width="14px" Visible="false"
                                                AlternateText="Quota Expire, Click Here to borrow quota !" />
                                            <asp:HiddenField ID="hdfORGANIZER_QUOTA_CHECK" runat="server"></asp:HiddenField>
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
                    <asp:Panel runat="server" ID="Panel1">
                        <div style="text-align: left; width: 100%">
                            <table width="100%">
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td class="tdmeeting2" colspan="5">
                                        <div style="margin-left: 5px;">
                                            <b>2.	Người đồng tổ chức (Người đồng chịu trách nhiệm mọi vấn đề liên quan đến hội họp)</b>
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
                                            Tình trạng Quota:
                                      <asp:ImageButton ID="ImgBtnCO_ORGANIZER_OK_1" runat="server" Height="14px"
                                          ImageUrl="~/images/check.png" Width="14px" Visible="false" />
                                            <asp:ImageButton ID="ImgBtnCO_ORGANIZER_ERROR_1" runat="server" Height="14px"
                                                ImageUrl="~/images/error.png" Width="14px" Visible="false"
                                                AlternateText="Quota Expire, Click Here to borrow quota !" />
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
                                            Tình trạng Quota:
                                      <asp:ImageButton ID="ImgBtnCO_ORGANIZER_OK_2" runat="server" Height="14px"
                                          ImageUrl="~/images/check.png" Width="14px" Visible="false" />
                                            <asp:ImageButton ID="ImgBtnCO_ORGANIZER_ERROR_2" runat="server" Height="14px"
                                                ImageUrl="~/images/error.png" Width="14px" Visible="false"
                                                AlternateText="Quota Expire, Click Here to borrow quota !" />
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
                                            Tình trạng Quota:
                                      <asp:ImageButton ID="ImgBtnCO_ORGANIZER_OK_3" runat="server" Height="14px"
                                          ImageUrl="~/images/check.png" Width="14px" Visible="false" />
                                            <asp:ImageButton ID="ImgBtnCO_ORGANIZER_ERROR_3" runat="server" Height="14px"
                                                ImageUrl="~/images/error.png" Width="14px" Visible="false"
                                                AlternateText="Quota Expire, Click Here to borrow quota !" />
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
                                        <b>II.	THÔNG TIN CUỘC HỌP</b>
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
                                    <td align="left" class="tdmeeting2">Số người tham dự<span style="color: Red">(*)</span>:
                                    
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:TextBox ID="txtNUMBER_OF_PARTICIPANT" CssClass="txtNumberBox" runat="server" Width="99.2%" onKeyUp="addCommas(event,this);"></asp:TextBox>
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
                                    <td align="left" class="tdmeeting3">Tỉnh thành:
                                        <asp:DropDownList ID="ddlPROVINCE_PLACE" CssClass="txtBox" runat="server" Width="140px" Height="22px" AutoPostBack="True" OnSelectedIndexChanged="ddlPROVINCE_PLACE_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5" colspan="2">Địa điểm:
                                        
                                        <asp:DropDownList ID="ddlPLACE" runat="server" Width="408.8px" Height="22px" CssClass="txtBox" AutoPostBack="True" OnSelectedIndexChanged="ddlPLACE_SelectedIndexChanged">
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
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:TextBox ID="txtMEETING_STARTDATE" CssClass="txtBoxDate" runat="server" Width="100px"></asp:TextBox>
                                        đến&nbsp;&nbsp;
                                        <asp:TextBox ID="txtMEETING_ENDDATE" CssClass="txtBoxDate" runat="server" Width="100px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        Giờ họp(không quá 22 giờ)<span style="color: Red">(*)</span>:
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
                                    <td align="left" class="tdmeeting5" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            Giá phiếu nước uống:
                                        <div style="float: right">
                                            <asp:TextBox ID="txtWATER_PRICE" CssClass="txtNumberBox" runat="server" Width="140px" onKeyUp="addCommas(event,this);"></asp:TextBox>
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
                                    <td align="left" class="tdmeeting5" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            Giá phiếu thức ăn:
                                        <div style="float: right">
                                            <asp:TextBox ID="txtFOOD_PRICE" CssClass="txtNumberBox" runat="server" Width="140px" onKeyUp="addCommas(event,this);"></asp:TextBox>
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
                                        <b>III.	NỘI DUNG PHÁT BIỂU CỦA DIỄN GIẢ <asp:CheckBox ID="chkForeigner" Checked="false" runat="server" />NGƯỜI NƯỚC NGOÀI</b>
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
                                     <asp:TextBox ID="txtSPEAKER_NAME_2" CssClass="txtBox" runat="server" Width="150px"></asp:TextBox>
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
                                    <td colspan="7">
                                        <hr />
                                        <div style="text-align: center;">
                                            <br />
                                            <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
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
                </fieldset>
            </asp:Panel>
            <asp:HiddenField runat="server" ID="hdfID" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
