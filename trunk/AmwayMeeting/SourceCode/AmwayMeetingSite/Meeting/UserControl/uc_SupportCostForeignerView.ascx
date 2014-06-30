<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SupportCostForeignerView.ascx.cs" Inherits="Meeting_UserControl_uc_SupportCostForeignerView" %>
<div style="min-height: 800px; height: auto">
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                    <td align="left" class="tdmeeting2">Mã số ADA:
                                    <asp:Label ID="lblORGANIZER_ADAID" CssClass="lblMeeting" runat="server" Width="70px"></asp:Label>
                                        <asp:HiddenField ID="hdfORGANIZER_ADAID" runat="server"></asp:HiddenField>
                                        &nbsp;

                                        <div class="divImgCheckIcon">
                                        </div>
                                    </td>
                                    <td align="left" class="tdmeeting3">Họ tên:
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
                                            Tên pax:
                                    <asp:Label ID="lblPAXNAME" runat="server" CssClass="lblMeeting"></asp:Label>
                                        </div>
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="2">Tỉnh thành:
                                    <asp:Label ID="lblPROVINCENAME" runat="server" CssClass="lblMeeting"></asp:Label>
                                    </td>
                                    <td align="left" class="tdmeeting5" colspan="2">Quận huyện:
                                    <asp:Label ID="lblDISTRICTNAME" runat="server" CssClass="lblMeeting"></asp:Label>
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
                                    <asp:Label ID="lblCO_ORGANIZER_ADAID_1" CssClass="lblMeeting" runat="server" Width="70px"></asp:Label>
                                            <asp:HiddenField ID="hdfCO_ORGANIZER_ADAID_1" runat="server"></asp:HiddenField>
                                            <div class="divImgCheckIcon10">
                                            </div>
                                        </div>
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="3">Họ tên:
                                     <asp:Label ID="lblCO_ORGANIZER_NAME_1" runat="server" CssClass="lblMeeting"></asp:Label>

                                    </td>                                   
                                    <td align="left" class="tdmeeting6">Danh hiệu:
                                     <asp:Label ID="lblCO_ORGANIZER_USERTYPENAME_1" runat="server" CssClass="lblMeeting"></asp:Label>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_USERTYPEID_1" runat="server"></asp:HiddenField>
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
                                    <asp:Label ID="lblCO_ORGANIZER_ADAID_2" CssClass="lblMeeting" runat="server" Width="70px"></asp:Label>
                                            <asp:HiddenField ID="hdfCO_ORGANIZER_ADAID_2" runat="server"></asp:HiddenField>
                                            <div class="divImgCheckIcon10">
                                            </div>
                                        </div>
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="3">Họ tên:
                                    <asp:Label ID="lblCO_ORGANIZER_NAME_2" runat="server" CssClass="lblMeeting"></asp:Label>

                                    </td>
                                   
                                    <td align="left" class="tdmeeting6">Danh hiệu:
                                    <asp:Label ID="lblCO_ORGANIZER_USERTYPENAME_2" runat="server" CssClass="lblMeeting"></asp:Label>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_USERTYPEID_2" runat="server"></asp:HiddenField>
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
                                    <asp:Label ID="lblCO_ORGANIZER_ADAID_3" CssClass="lblMeeting" runat="server" Width="70px"></asp:Label>
                                            <asp:HiddenField ID="hdfCO_ORGANIZER_ADAID_3" runat="server"></asp:HiddenField>
                                            <div class="divImgCheckIcon10">
                                            </div>
                                        </div>
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="3">Họ tên:
                                     <asp:Label ID="lblCO_ORGANIZER_NAME_3" runat="server" CssClass="lblMeeting"></asp:Label>

                                    </td>
                                    
                                    <td align="left" class="tdmeeting6" >Danh hiệu:
                                     <asp:Label ID="lblCO_ORGANIZER_USERTYPENAME_3" runat="server" CssClass="lblMeeting"></asp:Label>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_USERTYPEID_3" runat="server"></asp:HiddenField>

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
                                    <td align="left" class="tdmeeting2">Tên cuộc họp:
                                    
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:Label ID="lblMEETINGNAME" CssClass="lblMeeting" runat="server" Width="99.2%"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Số người tham dự:
                                    
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:Label ID="lblNUMBER_OF_PARTICIPANT" CssClass="lblMeeting" runat="server" Width="99.2%"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Tên địa điểm họp:
                                    
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:Label ID="lblMEETING_PLACE_NAME" CssClass="lblMeeting" runat="server" Width="99.2%"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Địa chỉ địa điểm họp:
                                    
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:Label ID="lblMEETING_ADDRESS" CssClass="lblMeeting" runat="server" Width="99.2%"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Ngày họp:
                                     
                                    </td>

                                    <td align="left" class="tdmeeting3" colspan="2">
                                        <asp:Label ID="lblMEETING_DATE" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
                                    <td align="left" class="tdmeeting5" colspan="2">Giờ họp(tối đa là 4 giờ):
                                        <div style="float: right; margin-right: 4px;">
                                            <asp:Label ID="lblMEETING_TIME" runat="server" Width="250px" CssClass="lblMeeting"></asp:Label>
                                        </div>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Hình thức thanh toán:
                                    
                                        
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:Label ID="lblFORMS_OF_PAYMENT" runat="server" Width="350px" CssClass="lblMeeting"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Giấy mời:
                                    
                                        
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:Label ID="lblINVITATIONNAME" runat="server" Width="350px" CssClass="lblMeeting"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Biểu ngữ:
                                    
                                      
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:Label ID="lblBANNERNAME" runat="server" Width="350px" CssClass="lblMeeting"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Ngày phát giấy mời:
                                      
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:Label ID="lblSEND_INVITATION_DATE" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Phiếu nước uống:
                                    
                                    
                                    </td>
                                    <td align="left" class="tdmeeting3">
                                        <asp:Label ID="lblWATER" CssClass="lblMeeting" runat="server" Width="70px"></asp:Label>
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5" colspan="2">
                                            Giá phiếu nước uống:
                                        <div style="float: right">
                                            <asp:Label ID="lblWATER_PRICE" CssClass="lblMeeting" runat="server" Width="140px"></asp:Label>
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
                                    <td align="left" class="tdmeeting2">Phiếu thức ăn:</td>
                                    <td align="left" class="tdmeeting3">
                                        <asp:Label ID="lblFOOD" CssClass="lblMeeting" runat="server" Width="70px"></asp:Label>
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5" colspan="2">
                                            Giá phiếu thức ăn:
                                        <div style="float: right">
                                            <asp:Label ID="lblFOOD_PRICE" CssClass="lblMeeting" runat="server" Width="140px"></asp:Label>
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
                                        <asp:Label ID="lblSPEAKER_TITLE_1" CssClass="lblMeeting" runat="server" Width="99.2%"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>

                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Mã số ADA:
                                    <asp:Label ID="lblSPEAKER_ADAID_1" CssClass="lblMeeting" runat="server" Width="70px"></asp:Label>
                                    </td>
                                    <td align="left" class="tdmeeting3">Họ tên:
                                     <asp:Label ID="lblSPEAKER_NAME_1" CssClass="lblMeeting" runat="server" Width="180px"></asp:Label>
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5"> Danh hiệu:
                                     <asp:Label ID="lblSPEAKER_USERTYPENAME_1" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
                                        </td>
                                    <td align="left" class="tdmeeting6">
                                        <div style="float: right; margin-right: 4px">
                                             Quốc tịch:
                                             <asp:Label ID="lblSPEAKER_NATION_1" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
                                        
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
                                        <asp:Label ID="lblSPEAKER_TITLE_2" CssClass="lblMeeting" runat="server" Width="99.2%"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>

                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Mã số ADA:
                                    <asp:Label ID="lblSPEAKER_ADAID_2" CssClass="lblMeeting" runat="server" Width="70px"></asp:Label>
                                    </td>
                                    <td align="left" class="tdmeeting3">Họ tên:
                                     <asp:Label ID="lblSPEAKER_NAME_2" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5"> Danh hiệu:
                                     <asp:Label ID="lblSPEAKER_USERTYPENAME_2" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
                                        </td>
                                    <td align="left" class="tdmeeting6">
                                        <div style="float: right; margin-right: 4px">
                                             Quốc tịch:
                                             <asp:Label ID="lblSPEAKER_NATION_2" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
                                       
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
                                    <td align="left" class="tdmeeting2">Tổng chi phí:
                                    
                                    </td>
                                    <td align="right" class="tdmeeting3">
                                        <asp:Label ID="lblTOTAL_PAY" CssClass="lblMeeting" runat="server" Width="180px"></asp:Label>&nbsp;(VNĐ)                                       
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
                                    <td colspan="7">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <b>V.	DUYỆT ĐĂNG KÝ</b>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Phê duyệt<span style="color: Red">(*)</span>:                                        
                                    </td>
                                    <td align="left" class="tdmeeting3">
                                        <asp:DropDownList ID="ddlSTATUS_MEETING_REGISTERID" CssClass="txtBox" runat="server" Width="140px" Height="22px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">Ghi chú: </td>
                                    <td align="left" class="tdmeeting6">
                                        <asp:TextBox ID="txtCOMMENTS" CssClass="txtBox" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox></td>
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
                                        <b>VI.	CẬP NHẬP TÌNH TRẠNG CHI PHÍ</b>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Tình trạng:                                        
                                    </td>
                                    <td align="left" class="tdmeeting3">
                                        <asp:DropDownList ID="ddlSTATUS_MEETING_PAYMENTID" CssClass="txtBox" runat="server" Width="140px" Height="22px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">Tình trạng chi phí: </td>
                                    <td align="left" class="tdmeeting6">
                                        <asp:Label ID="lblSTATTUS_MEETING_PAYMENTNAME" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label></td>
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
                                            <asp:CheckBox runat="server" ID="chkAgree" Enabled="false" CssClass="Agree" Text="Tôi chịu trách nhiệm tuân thủ tất cả các quy định trên và hiểu rằng đơn xin hội họp của tôi chỉ có hiệu lực khi được Amway chấp thuận và đơn này có thể sẽ bị hủy bỏ nếu tôi không tuân thủ các Quy Tắc Ứng Xử của Amway cũng như Luật Pháp Việt Nam. Tôi cam kết rằng tất cả các thông tin cung cấp là trung thực và chính xác. Tôi sẽ hoàn toàn chịu trách nhiệm trước Amway cũng như cơ quan pháp luật đối với tất cả các hoạt động có liên quan đến buổi họp này." />

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
                                <tr>
                                    <td colspan="7">
                                        <div style="text-align: center;">
                                            <br />
                                            <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Duyệt đăng ký" OnClick="btnSave_Click" />
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
            <asp:HiddenField runat="server" ID="hdfID" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
