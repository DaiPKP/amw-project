<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SupportCostView.ascx.cs" Inherits="Meeting_UserControl_uc_NotSupportCostView" %>
<div style="min-height: 800px; height: auto">
    <div class="TitlePage">
        DUYỆT ĐĂNG KÝ HỘI HỌP HỖ TRỢ CHI PHÍ
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
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">Danh hiệu:
                                     <asp:Label ID="lblORGANIZER_USERTYPENAME" runat="server" CssClass="lblMeeting"></asp:Label>
                                        <asp:HiddenField ID="hdfORGANIZER_USERTYPEID" runat="server"></asp:HiddenField>
                                    </td>
                                    <td class="tdmeeting6"></td>
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
                                            Tên pax:
                                    <asp:Label ID="lblPAXNAME" runat="server" CssClass="lblMeeting"></asp:Label>
                                        </div>
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="2">Tỉnh thành:
                                    <asp:Label ID="lblPROVINCENAME" runat="server" CssClass="lblMeeting"></asp:Label>
                                    </td>
                                    <td align="left" class="tdmeeting5">
                                        
                                    </td>
                                    <td align="left" class="tdmeeting6">
                                        &nbsp;</td>
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
                                            <b>2.	Người đồng tổ chức (Người đồng chịu trách nhiệm mọi vấn đề liên quan đến hội họp) hoặc sử dụng chỉ tiêu đăng ký hội họp của:</b>
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
                                    <td align="left" class="tdmeeting3">Họ tên:
                                     <asp:Label ID="lblCO_ORGANIZER_NAME_1" runat="server" CssClass="lblMeeting"></asp:Label>

                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">Danh hiệu:
                                     <asp:Label ID="lblCO_ORGANIZER_USERTYPENAME_1" runat="server" CssClass="lblMeeting"></asp:Label>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_USERTYPEID_1" runat="server"></asp:HiddenField>
                                    </td>
                                    <td align="left" class="tdmeeting6">
                                        &nbsp;</td>
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
                                    <td align="left" class="tdmeeting3">Họ tên:
                                    <asp:Label ID="lblCO_ORGANIZER_NAME_2" runat="server" CssClass="lblMeeting"></asp:Label>

                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">Danh hiệu:
                                    <asp:Label ID="lblCO_ORGANIZER_USERTYPENAME_2" runat="server" CssClass="lblMeeting"></asp:Label>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_USERTYPEID_2" runat="server"></asp:HiddenField>
                                    </td>
                                    <td align="left" class="tdmeeting6">
                                        &nbsp;</td>
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
                                    <td align="left" class="tdmeeting3">Họ tên:
                                     <asp:Label ID="lblCO_ORGANIZER_NAME_3" runat="server" CssClass="lblMeeting"></asp:Label>

                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">Danh hiệu:
                                     <asp:Label ID="lblCO_ORGANIZER_USERTYPENAME_3" runat="server" CssClass="lblMeeting"></asp:Label>
                                        <asp:HiddenField ID="hdfCO_ORGANIZER_USERTYPEID_3" runat="server"></asp:HiddenField>

                                    </td>
                                    <td align="left" class="tdmeeting6">
                                        &nbsp;</td>
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
                                    <td align="left" class="tdmeeting5" colspan="2">Giờ họp(tối đa là 4 giờ)<span style="color: Red">(*)</span>:
                                        <div style="float: right; margin-right: 4px;">
                                            <asp:Label ID="lblMEETING_TIME" runat="server" Width="150px" CssClass="lblMeeting"></asp:Label>
                                        </div>
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
                                    <td align="left" class="tdmeeting5" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                    <td align="left" class="tdmeeting5" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                        <b>III.	NỘI DUNG PHÁT BIỂU CỦA DIỄN GIẢ <asp:Label ID="lblFOREIGNER" runat="server" Width="200px"></asp:Label></b>
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
                                    <td align="left" class="tdmeeting5">Danh hiệu:
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
                                    <td align="left" class="tdmeeting5">Danh hiệu:
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
                                    <td align="left" class="tdmeeting2">Tổng chi phí<span style="color: Red">(*)</span>:
                                    
                                    </td>
                                    <td align="right" class="tdmeeting3">
                                        <asp:Label ID="lblTOTAL_PAY" CssClass="lblMeeting" runat="server" Width="180px"></asp:Label>&nbsp;(VNĐ)                                       
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">                                    
                                    </td>
                                    <td align="left" class="tdmeeting6">
                                    </td>
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
                                        <asp:Label id="lblAMWAY_PAY" CssClass="lblMeeting" runat="server" Width="180px"></asp:Label>&nbsp;(VNĐ)
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">Số tiền nhà phân phối trả:
                                    
                                    </td>
                                    <td align="right" class="tdmeeting6">
                                        <asp:Label id="lblDISTRIBUTOR_PAY" CssClass="lblMeeting" runat="server" Width="180px" ></asp:Label>&nbsp;(VNĐ)
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
                                    <td align="left" class="tdmeeting5">Tình trạng đăng ký: </td>
                                    <td align="left" class="tdmeeting6"><asp:Label ID="lblSTATTUS_MEETING_REGISTERNAME" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label></td>
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
                                    <td align="left" class="tdmeeting2">Tình trạng<span style="color: Red">(*)</span>:                                        
                                    </td>
                                    <td align="left" class="tdmeeting3">
                                        <asp:DropDownList ID="ddlSTATUS_MEETING_PAYMENTID" CssClass="txtBox" runat="server" Width="140px" Height="22px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">Tình trạng chi phí: </td>
                                    <td align="left" class="tdmeeting6"><asp:Label ID="lblSTATTUS_MEETING_PAYMENTNAME" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label></td>
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
                                            <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Duyệt đăng ký" OnClick="btnSave_Click" />
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
