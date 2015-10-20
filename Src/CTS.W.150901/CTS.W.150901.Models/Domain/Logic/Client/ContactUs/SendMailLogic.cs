using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150901.Models.Domain.Model.Client.ContactUs;
using CTS.Data.Com.Domain.Utils;
using CTS.Core.Domain.Helper;
using CTS.Web.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Common.Constants;
using System.Net.Mail;
using CTS.W._150901.Models.Resources.Strings;

namespace CTS.W._150901.Models.Domain.Logic.Client.ContactUs
{
    /// <summary>
    /// InitLogic
    /// </summary>
    public class SendMailLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý init.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public SendMailDataModel Execute(SendMailDataModel inputObject)
        {
            // Kiểm tra thông tin
            Check(inputObject);
            // Lấy thông tin
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
        private void Check(SendMailDataModel inputObject)
        {

        }

        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private SendMailDataModel SendInfo(SendMailDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var getResult = new SendMailDataModel();
            var companyCom = new CompanyCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy thông tin dữ liệu
            var fileTemplate = FileHelper.ToString(HttpHelper.MapPath("/stg/tmpl/email/contact-us.html"));
            var emailContact = companyCom.GetString(W150901Logics.CD_LOCALE_CD_EN, W150901Logics.CD_INFO_CD_EMAIL_CONTACT, false);
            var host = companyCom.GetString(W150901Logics.CD_LOCALE_CD_EN, W150901Logics.CD_INFO_CD_HOST, false);
            var subject = NameHelper.GetNameString("CLN_CONTACT_SUBJECT");
            var body = new StringBuilder(fileTemplate);
            body.Replace("{Name}", inputObject.Name);
            body.Replace("{Phone}", inputObject.Phone);
            body.Replace("{Email}", inputObject.Email);
            body.Replace("{Description}", inputObject.Description);

            // Tiến hành send mail
            var smtp = MailHelper.CreateSmtpClient(host);
            var mail = MailHelper.CreateMailMessage(inputObject.Email, emailContact, subject, body.ToString());
            MailHelper.SendMail(smtp, mail);
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
