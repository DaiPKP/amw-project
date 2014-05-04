<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_MeetingReport.ascx.cs" Inherits="Distributor_UserControl_uc_MeetingReport" %>
<script type="text/javascript">
    $(document).ready(function () {
        $(".OVERVIEW").jRating({
            length: 5,
            rateMax: 5,
            sendRequest: false,
            decimalLength: 0,
            onClick: function (element, rate) {
                //alert('Success. Value selected : ' + rate);
                $("#<%=hdfRATING_OVERVIEW.ClientID%>").val(rate);
            }
        });

        $(".ROOM").jRating({
            length: 5,
            rateMax: 5,
            sendRequest: false,
            decimalLength: 0,
            onClick: function (element, rate) {
                //alert('Success. Value selected : ' + rate);
                $("#<%=hdfRATING_ROOM.ClientID%>").val(rate);
            }
        });

        $(".USE").jRating({
            length: 5,
            rateMax: 5,
            sendRequest: false,
            decimalLength: 0,
            onClick: function (element, rate) {
                //alert('Success. Value selected : ' + rate);
                $("#<%=hdfRATING_SUPPORT_USE.ClientID%>").val(rate);
            }
        });

        $(".CHANGE").jRating({
            length: 5,
            rateMax: 5,
            sendRequest: false,
            decimalLength: 0,
            onClick: function (element, rate) {
                //alert('Success. Value selected : ' + rate);
                $("#<%=hdfRATING_SUPPORT_CHANGE.ClientID%>").val(rate);
            }
        });

        $(".SUMMARY").jRating({
            length: 5,
            rateMax: 5,
            sendRequest: false,
            decimalLength: 0,
            onClick: function (element, rate) {
                //alert('Success. Value selected : ' + rate);
                $("#<%=hdfRATING_SUMMARY.ClientID%>").val(rate);
            }
        });

    });
</script>
<div style="min-height: 800px; height: auto">
    <div class="TitlePage">
        BÁO CÁO SAU HỘI HỌP
    </div>
    <br />
    <div style="text-align:center; font-weight:bold; color: #008080; font-size:16px;">
        BÁO CÁO SAU HỘI HỌP PHẢI NỘP CHO AMWAY CHẬM NHẤT LÀ 07 NGÀY SAU KHI TỔ CHỨC HỘI HỌP.<br />
        KHÔNG ĐƯỢC ĐĂNG KÝ HỘI HỌP TIẾP THEO NẾU CHƯA NỘP BÁO CÁO SAU HỘI HỌP CỦA LẦN HỘI HỌP TRƯỚC
    </div>
    <br />
    <hr style="width:80%;"/>
    <br />
    <asp:Panel ID="thuchi" runat="server">
        <div class="menuTitle">
            Chi Tiết Thu Chi
        </div>
        <fieldset>
            <table style="width:100%;">
                <tr>
                    <td colspan="2" style="width:50%; text-align:center; font-weight:bold; text-decoration:underline;">
                        BÁO CÁO THU
                    </td>
                    <td colspan="2" style="text-align:center; font-weight:bold; text-decoration:underline;">
                        BÁO CÁO CHI
                    </td>
                </tr>
                <tr>
                    <td class="td_title_2">
                        Số lượng giấy mời đã phát
                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txtINVITE_QUANTITY" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                    <td class="td_title_2">
                        20% phí thuê phòng họp
                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txt20_PERCENT" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                </tr>
                <tr>
                    <td class="td_title_2">
                        Số lượng phiếu nước uống
                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txtWATER_QUANTITY" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                    <td class="td_title_2">
                        Chi phí in thư mời
                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txtPRINTING_INVITATION" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                </tr>
                <tr>
                    <td class="td_title_2">
                        Số lượng phiếu ăn
                    </td>
                    <td class="td_value_2">
                        
                        <asp:TextBox ID="txtFOOD_QUANTITY" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ
                        
                    </td>
                    <td class="td_title_2">
                        Chi phí khác
                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txtOTHER1" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                </tr>
                <tr>
                    <td class="td_title_2">
                        Tổng số tiền thu nước uống
                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txtSUMMARY_WATER" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                    <td class="td_title_2">

                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txtOTHER2" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                </tr>
                <tr>
                    <td class="td_title_2">
                        Tổng số tiền thu thức ăn
                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txtSUMMARY_FOOD" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                    <td class="td_title_2">

                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txtOTHER3" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                </tr>
                <tr>
                    <td class="td_title_2">

                    </td>
                    <td class="td_value_2">

                    </td>
                    <td class="td_title_2">

                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txtOTHER4" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                </tr>
                <tr>
                    <td class="td_title_2">

                    </td>
                    <td class="td_value_2">

                    </td>
                    <td class="td_title_2">

                    </td>
                    <td class="td_value_2">

                        <asp:TextBox ID="txtOTHER5" runat="server" CssClass="txtNumberBox" Width="70%" onKeyUp="addCommas(event,this);">0</asp:TextBox> VNĐ

                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <br />
    <asp:Panel ID="upd" runat="server">
        <div class="menuTitle">
            Đánh Giá Về Địa Điểm Tổ Chức Hội Thảo
        </div>
        <fieldset>
            <table style="width:100%;">
                <tr>
                    <td colspan="2" style="font-weight:bold; margin-left:20px; font-size:13px;">
                        Anh/chị chọn mức độ hài lòng về địa điểm tổ chức theo thang điểm sau:
                    </td>
                </tr>
                <tr>
                    <td style="width:30%; text-align:right; margin-right:10px;">
                        <asp:Image id ="star1" runat="server" ImageUrl="~/images/Star/1star.jpg"/>
                    </td>
                    <td style="text-align:left; margin-left:10px;">
                        Rất không hài lòng
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; margin-right:10px;">
                        <asp:Image id ="star2" runat="server" ImageUrl="~/images/Star/2star.jpg"/>
                    </td>
                    <td style="text-align:left; margin-left:10px;">
                        Không hài lòng
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; margin-right:10px;">
                        <asp:Image id ="star3" runat="server" ImageUrl="~/images/Star/3star.jpg"/>
                    </td>
                    <td style="text-align:left; margin-left:10px;">
                        Bình thường
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; margin-right:10px;">
                        <asp:Image id ="star4" runat="server" ImageUrl="~/images/Star/4star.jpg"/>
                    </td>
                    <td style="text-align:left; margin-left:10px;">
                        Hài lòng
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; margin-right:10px;">
                        <asp:Image id ="star5" runat="server" ImageUrl="~/images/Star/5star.jpg"/>
                    </td>
                    <td style="text-align:left; margin-left:10px;">
                        Rất hài lòng
                    </td>
                </tr>
            </table><br />
            <div style="padding-left:10px;">
                <span style="font-weight:bold;">I. Đánh gía về cơ sở vật chất tại địa điểm các anh chị tổ chức hội thảo.</span> <br /><br />
                <span style="margin-left:10px;">1. Về tổng quan, cơ sở vật chất là đầy đủ và hiện đại:</span><br />
                
			    <div class="OVERVIEW" style="margin-left:30px;" data-average=<%=hdfRATING_OVERVIEW.Value.ToString()%> data-id="2"></div> 
		        
                <span style="margin-left:10px;">2. Cảm nhận của anh/chị về không gian phòng họp:</span><br />

                <div class="ROOM" style="margin-left:30px;" data-average=<%=hdfRATING_ROOM.Value.ToString()%> data-id="2"></div> 

                <span style="margin-left:10px;">Ý kiến khác(ghi rõ)</span><br />
                <asp:TextBox ID="txtOTHER_COMMENT_ROOM" runat="server" Width="50%" TextMode="MultiLine" Rows="3"></asp:TextBox><br /><br />
                <span style="font-weight:bold;">II. Đánh giá về thái độ phục vụ tại địa điểm tổ chức.</span> <br /><br />
                <span style="margin-left:10px;">1. Nhân viên tại địa điểm đã hỗ trợ tốt anh/chị trong quá trình sử dụng phòng hội thảo.</span><br />

                <div class="USE" style="margin-left:30px;" data-average=<%=hdfRATING_SUPPORT_USE.Value.ToString()%> data-id="2"></div> 

                <span style="margin-left:10px;">2. Nhân viên tại địa điểm đã hỗ trợ tốt anh/chị khi đặt phòng, đổi phòng.</span><br />

                <div class="CHANGE" style="margin-left:30px;" data-average=<%=hdfRATING_SUPPORT_CHANGE.Value.ToString()%> data-id="2"></div> 

                <span style="margin-left:10px;">Ý kiến khác(ghi rõ)</span><br />
                <asp:TextBox ID="txtOTHER_COMMENT_STAFT" runat="server" Width="50%" TextMode="MultiLine" Rows="3"></asp:TextBox><br /><br />
                <span style="font-weight:bold;">III. Nhìn chung anh/ chị đánh giá mức độ hài lòng về Địa điểm tổ chức theo mức thang điểm.</span> <br />

                <div class="SUMMARY" style="margin-left:30px;" data-average=<%=hdfRATING_SUMMARY.Value.ToString()%> data-id="2"></div> 

                <table>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkConfirm" runat="server" />
                        </td>
                        <td>                            
                            <span class="Agree">
                                Tôi cam kết rằng tất cả các thông tin cung cấp trên là trung thực và chính xác. Tôi sẽ hoàn toàn chịu trách nhiệm trước Amway cũng như cơ quan pháp luật đối với tất cả các hoạt động có liên quan đến buổi họp này.
                            </span>
                        </td>
                    </tr>
                </table>
                <span class="Alerting"><asp:Label ID ="lbMess" Text="" runat ="server"/></span><br />
                <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Báo Cáo" OnClick="btnSave_Click"/>
            </div>
        </fieldset>
    </asp:Panel>
    <asp:HiddenField id="hdfRATING_OVERVIEW" runat="server" Value="0"/>
    <asp:HiddenField id="hdfRATING_ROOM" runat="server" Value="0"/>
    <asp:HiddenField id="hdfRATING_SUPPORT_USE" runat="server" Value="0"/>
    <asp:HiddenField id="hdfRATING_SUPPORT_CHANGE" runat="server" Value="0"/>
    <asp:HiddenField id="hdfRATING_SUMMARY" runat="server" Value="0"/>
    <asp:HiddenField id="hdfMEETING_ID" runat="server" Value="0"/>
    <asp:HiddenField id="hdfID" runat="server" Value="0"/>
</div>
