<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_OutSideCountry.ascx.cs" Inherits="Meeting_UserControl_uc_OutSideCountry" %>
<div style="min-height: 600px; height: auto">
    <div class="TitlePage">
        ĐĂNG KÝ HỘI HỌP NGOÀI LÃNH THỔ VIỆT NAM
    </div>
    <script type="text/javascript">
        function BindEvents() {
            $(document).ready(function () {
                var objTuNgay = document.getElementById("<%=txtMEETING_STARTDATE.ClientID %>");
                var objDenNgay = document.getElementById("<%=txtMEETING_ENDDATE.ClientID %>");
                var objDepature = document.getElementById("<%=txtDEPARTURE_DATE.ClientID %>");
                var objArrival = document.getElementById("<%=txtARRIVAL_DATE.ClientID %>");
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
                 $(objDepature).datepicker({
                     showOn: "button",
                     buttonImage: "../images/calendar.gif",
                     buttonImageOnly: true
                 }),

               $(objArrival).datepicker({
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
                    var objDepature = document.getElementById("<%=txtDEPARTURE_DATE.ClientID %>");
                    var objArrival = document.getElementById("<%=txtARRIVAL_DATE.ClientID %>");
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
                     $(objDepature).datepicker({
                         showOn: "button",
                         buttonImage: "../images/calendar.gif",
                         buttonImageOnly: true
                     }),

                   $(objArrival).datepicker({
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
                                        <b>I.	I.	THÔNG TIN NGƯỜI ĐĂNG KÝ THAM DỰ VÀ CHỊU TRÁCH NHIỆM MỌI VẤN ĐỀ LIÊN QUAN HỘI HỌP</b>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">Mã số ADA<span style="color: Red">(*)</span>:
                                    <asp:TextBox ID="txtORGANIZER_ADAID" CssClass="txtBox" runat="server" Width="70px" ReadOnly="true"></asp:TextBox>
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
                                            Mã số ADA<span style="color: Red">(*)</span>:
                                    <asp:TextBox ID="txtSPEAKER_ADAID_1" CssClass="txtBox" runat="server" Width="70px"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td align="left" class="tdmeeting3">Họ tên<span style="color: Red">(*)</span>:
                                     <asp:TextBox ID="txtSPEAKER_NAME_1" CssClass="txtBox" runat="server" Width="180px"></asp:TextBox>
                                    </td>
                                    <td class="tdmeeting4"></td>
                                    <td align="left" class="tdmeeting5">Danh hiệu<span style="color: Red">(*)</span>:
                                     <asp:TextBox ID="txtSPEAKER_USERTYPENAME_1" CssClass="txtBox" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td align="left" class="tdmeeting6"></td>
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
                                        <div class="marginLeft10">Tên cuộc họp<span style="color: Red">(*)</span>:</div>

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
                                    <td align="left" class="tdmeeting2">
                                        <div class="marginLeft10">Tên địa điểm họp<span style="color: Red">(*)</span>:</div>

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
                                    <td align="left" class="tdmeeting2">
                                        <div class="marginLeft10">Địa chỉ địa điểm họp<span style="color: Red">(*)</span>:</div>

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
                                    <td align="left" class="tdmeeting2">
                                        <div class="marginLeft10">Quốc gia<span style="color: Red">(*)</span>:</div>

                                    </td>
                                    <td align="left" class="tdmeeting3" colspan="4">
                                        <asp:TextBox ID="txtCOUNTRYNAME" CssClass="txtBox" runat="server" Width="99.2%"></asp:TextBox>
                                    </td>
                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">
                                        <div class="marginLeft10">Ngày đi<span style="color: Red">(*)</span>:</div>

                                    </td>
                                    <td align="left" class="tdmeeting3">
                                        <asp:TextBox ID="txtDEPARTURE_DATE" CssClass="txtBoxDate" runat="server" Width="150px"></asp:TextBox>
                                    <td class="tdmeeting4"></td>
                                    <td class="tdmeeting5">Ngày về<span style="color: Red">(*)</span>:
                                    </td>
                                    <td class="tdmeeting6">
                                        <asp:TextBox ID="txtARRIVAL_DATE" CssClass="txtBoxDate" runat="server" Width="150px"></asp:TextBox>
                                    </td>

                                    <td class="tdmeeting7"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="divClearBothInAdmin"></td>
                                </tr>
                                <tr>
                                    <td class="tdmeeting1"></td>
                                    <td align="left" class="tdmeeting2">
                                        <div class="marginLeft10">Ngày bắt đầu họp<span style="color: Red">(*)</span>:</div>

                                    </td>
                                    <td align="left" class="tdmeeting3">
                                        <asp:TextBox ID="txtMEETING_STARTDATE" CssClass="txtBoxDate" runat="server" Width="150px"></asp:TextBox>
                                    <td class="tdmeeting4"></td>
                                    <td class="tdmeeting5">Ngày kết thúc họp<span style="color: Red">(*)</span>:
                                    </td>
                                    <td class="tdmeeting6">
                                        <asp:TextBox ID="txtMEETING_ENDDATE" CssClass="txtBoxDate" runat="server" Width="150px"></asp:TextBox>
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
