using CTS.Core.Domain.Helper;
using CTS.Data.Com.Domain.Utils;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.W._150901.Models.Domain.Model.Client.Booking;
using CTS.W._150901.Models.Domain.Object.Client.Booking;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Logic.Client.Booking
{
    /// <summary>
    /// SendLogic
    /// </summary>
    public class SendLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý send.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public SendDataModel Execute(SendDataModel inputObject)
        {
            // Kiểm tra thông tin
            Check(inputObject);
            // Gửi thông tin
            var resultObject = SendInfo(inputObject);
            // Kết quả trả về
            return resultObject;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Kiểm tra thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(SendDataModel inputObject)
        {
        }

        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private SendDataModel SendInfo(SendDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var sendResult = new SendDataModel();
            var companyCom = new CompanyCom();
            var dataInfo = HttpHelper.GetSession("CLN.W150901.BookingData") as BookingObject;
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, sendResult);
            // Lấy đường dẫn server
            var serverPath = HttpHelper.MapPath("/stg/tmpl/email/" + WebContextHelper.LocaleCd + "/reservation.html");
            // Tiến hành đọc file template
            var tmpl = FileHelper.ToString(serverPath);
            // Lấy thông tin dữ liệu
            var mailFrom = dataInfo.Email;
            var mailTo = companyCom.GetString(
                W150901Logics.CD_LOCALE_CD_EN, W150901Logics.CD_INFO_CD_EMAIL_RESERVE, false);
            var passTo = companyCom.GetString(
                W150901Logics.CD_LOCALE_CD_EN, W150901Logics.CD_INFO_CD_EMAIL_RESERVE_PASSWORD, false);
            var host = companyCom.GetString(
                W150901Logics.CD_LOCALE_CD_EN, W150901Logics.CD_INFO_CD_HOST, false);
            var subject = NameHelper.GetNameString("CLN_RESERVE_SUBJECT");
            var body = DataHelper.FormatString(tmpl, dataInfo);
            // Lấy thông tin main
            var smtp = MailHelper.CreateSmtpClient(host);
            var mmsg = MailHelper.CreateMailMessage(mailFrom, mailTo, subject, body);
            var smtpRely = MailHelper.CreateSmtpClient(host, mailTo, passTo);
            var mmsgRely = MailHelper.CreateMailMessage(mailTo, mailFrom, subject, body);
            // Tiến hành gửi mail
            MailHelper.SendMail(smtp, mmsg);
            MailHelper.SendMail(smtpRely, mmsgRely);
            // Kết quả trả về
            return sendResult;
        }
        #endregion
    }
}
