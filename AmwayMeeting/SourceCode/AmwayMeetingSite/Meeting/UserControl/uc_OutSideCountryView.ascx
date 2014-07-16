﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_OutSideCountryView.ascx.cs" Inherits="Meeting_UserControl_uc_OutSideCountryView" %>
<div style="min-height: 600px; height: auto">
    <div class="TitlePage">
        DUYỆT ĐĂNG KÝ HỘI HỌP NGOÀI LÃNH THỔ VIỆT NAM
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
                                        <b>I.	I.	THÔNG TIN NGƯỜI ĐĂNG KÝ THAM DỰ VÀ CHỊU TRÁCH NHIỆM MỌI VẤN ĐỀ LIÊN QUAN HỘI HỌP</b>
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
                                    <asp:Label ID="lblORGANIZER_ADAID" CssClass="lblMeeting" runat="server" Width="70px" ReadOnly="true"></asp:Label>
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
                                    <td class="tdmeeting2" colspan="5">
                                        <div style="margin-left: 5px;">
                                            <b>1.	Thông tin người tổ chức:</b>
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
                                            Mã số ADA:
                                    <asp:Label ID="lblSPEAKER_ADAID_1" CssClass="lblMeeting" runat="server" Width="70px"></asp:Label>
                                        </div>
                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="3">Họ tên:
                                     <asp:Label ID="lblSPEAKER_NAME_1" CssClass="lblMeeting" runat="server" Width="180px"></asp:Label>
                                    </td>
                                   
                                    <td align="left" class="tdmeeting6">Danh hiệu:
                                     <asp:Label ID="lblSPEAKER_USERTYPENAME_1" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
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
                                            <b>2.	Thông tin cuộc họp:</b>
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
                                        <div class="marginLeft10">Tên cuộc họp:</div>

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
                                    <td align="left" class="tdmeeting2">
                                        <div class="marginLeft10">Tên địa điểm họp:</div>

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
                                    <td align="left" class="tdmeeting2">
                                        <div class="marginLeft10">Địa chỉ địa điểm họp:</div>

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
                                    <td align="left" class="tdmeeting2">
                                        <div class="marginLeft10">Quốc gia:</div>

                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:Label ID="lblCOUNTRYNAME" CssClass="lblMeeting" runat="server" Width="99.2%"></asp:Label>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">
                                        <div class="marginLeft10">Ngày đi:</div>

                                    </td>
                                    <td align="left" class="tdmeeting3">
                                        <asp:Label ID="lblDEPARTURE_DATE" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
                                    <td class="tdmeeting4"></td>
                                    <td class="tdmeeting5">Ngày về:
                                    </td>
                                    <td class="tdmeeting6">
                                        <asp:Label ID="lblARRIVAL_DATE" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
                                    </td>

                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">
                                        <div class="marginLeft10">Ngày bắt đầu họp:</div>

                                    </td>
                                    <td align="left" class="tdmeeting3">
                                        <asp:Label ID="lblMEETING_STARTDATE" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
                                    <td class="tdmeeting4"></td>
                                    <td class="tdmeeting5">Ngày kết thúc họp:
                                    </td>
                                    <td class="tdmeeting6">
                                        <asp:Label ID="lblMEETING_ENDDATE" CssClass="lblMeeting" runat="server" Width="150px"></asp:Label>
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
                                        <b>IV.	DUYỆT ĐĂNG KÝ</div></b>
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
                                    <td align="left" class="tdmeeting6"><asp:TextBox ID="txtCOMMENTS" CssClass="txtBox" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox></td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>                               
                                <tr id="trWarning" runat="server" visible="false">
                                    <td colspan="7">
                                        <hr />
                                        <div style="text-align: left;">
                                            <asp:Label ID="lblWarning" runat="server" CssClass="Alerting" Text="(*) Đối với cuộc họp này bạn phải đăng ký trước 10 ngày"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7">
                                        <hr />
                                        <div style="text-align: center;">
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
            <asp:HiddenField runat="server" ID="hdfReported" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
