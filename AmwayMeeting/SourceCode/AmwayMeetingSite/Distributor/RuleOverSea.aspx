<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="RuleOverSea.aspx.cs" Inherits="Distributor_RuleOverSea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>


            <div style="text-align: center;">
                <table width="100%;" border="1px" style="font-size: 14px;">
                    <tr>
                        <td>
                            <br />
                            <span class="title">CÁC QUY ĐỊNH CHUNG</span><br />
                            <br />
                            <div class="TitleLevel1">
                                1.	Các quy định hội họp dưới đây áp dụng cho tất cả các Nhà Phân Phối Amway đăng ký tham dự hội họp ngoài lãnh thổ Việt Nam nhằm bổ sung kiến thức và phát triển kinh doanh Amway tại Việt Nam.<br />
                                2.	Người đăng ký tham dự hội họp phải là Nhà Phân Phối đạt cấp bậc Silver Producer trở lên mới được quyền đăng ký tổ chức hội họp nước ngoài.<br />
                                3.	Thời hạn đăng ký: Nộp hồ sơ đăng ký tham dự hội họp ngoài lãnh thổ Việt Nam cho Amway trước 10 ngày làm việc.<br />
                                4.	Amway cho phép các nhà phân phối đạt cấp bậc Silver Producer trở lên được phép tham dự hội họp tại nước ngoài 2 lần/1năm.<br />
                                5.	Nhà phân phối được phép tham dự hội họp ngoài lãnh thổ Việt Nam sau khi nhận được chấp thuận từ công ty TNHH Amway Việt Nam.<br />
                                6.	Tất cả các cuộc họp phải tuân thủ các Quy Tắc Ứng Xử của Amway và Luật Pháp hiện hành tại quốc gia nơi diễn ra hội họp.<br />

                            </div>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <span class="title">HÌNH THỨC XỬ LÝ NẾU KHÔNG TUÂN THỦ QUY ĐỊNH</span><br />
                            <br />

                            <div class="TitleLevel1">
                                1.	Amway Việt Nam có quyền từ chối không cho phép Nhà Phân Phối được đăng ký hội họp trong tương lai nếu Nhà Phân Phối không tuân thủ các quy định về hội họp, các Quy Tắc Ứng Xử của Amway và Luật Pháp Việt Nam.<br />
                                2.	Những hành vi vi phạm sẽ phải chịu những hình thức xử lý phù hợp, bao gồm nhưng không giới hạn việc:<br />
                                <div class="TitleLevel1">
                                    •	Đình chỉ quyền được đăng ký tham dự hội họp.<br />
                                    •	Không được công nhận thành tích.<br />
                                    •	Không được mời tham dự các chuyến du lịch tưởng thưởng.<br />
                                    •	Đình chỉ Vai Trò Phân Phối (bao gồm việc không công nhận thành tích trong tháng bị đình chỉ).<br />
                                    •	Chấm dứt Vai Trò Phân Phối.<br />

                                </div>
                                <br />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <div class="title">
                                SỬA ĐỔI QUY ĐỊNH
                            </div>
                            <br />
                            <div class="TitleLevel1">
                                1.	Quy định này sẽ được Amway Việt Nam xem xét và có thể được điều chỉnh tùy theo từng thời điểm để đảm bảo nhu cầu phát triển hoạt động kinh doanh cũng như những nỗ lực để tuân thủ luật pháp và các quy định của Việt Nam. Nhà Phân Phối sẽ được thông báo nếu có bất cứ sự thay đổi nào trong quy định này.<br />
                                2.	Quy định này không dựa trên bất cứ thành kiến nào và không trái với bất cứ điều khoản hoặc quy định nào của các Quy Tắc Ứng Xử của Amway.<br />
                            </div>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <div class="title">
                                CAM KẾT
                            </div>
                            <div class="TitleLevel1">
                                <span style="font-weight: bold;">Người đăng ký</span>
                                <br />
                                <div class="TitleLevel1">
                                    Tôi chịu trách nhiệm tuân thủ tất cả các quy định trên và hiểu rằng đơn xin hội họp ngoài ngoài lãnh thổ Việt Nam của tôi chỉ có hiệu lực khi được Amway chấp thuận và đơn này có thể sẽ bị hủy bỏ nếu tôi không tuân thủ các Quy Tắc Ứng Xử của Amway. Tôi cam kết rằng tất cả các thông tin cung cấp là trung thực và chính xác. Tôi sẽ hoàn toàn chịu trách nhiệm trước Amway cũng như cơ quan pháp luật đối với tất cả các hoạt động có liên quan đến buổi họp này. 
                                </div>
                            </div>
                            <br />
                        </td>
                    </tr>
                </table>
                <table style="text-align: left;">
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkConfirm" runat="server" />
                        </td>
                        <td>
                            <span class="Agree">Tôi đã đọc, hiểu và cam kết thực hiện theo đúng những qui định trên.
                            </span>
                        </td>
                    </tr>
                </table>
                <span class="Alerting">
                    <asp:Label ID="lbMess" Text="" runat="server" /></span><br />
                <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Đăng Ký" OnClick="btnSave_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>

