using System;
using CTS.Core.Domain.Helper;
using CTS.Data.Com.Domain.Utils;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.W._150901.Models.Domain.Logic.Client.Booking;
using CTS.W._150901.Models.Domain.Object.Client.Booking;
using CTS.Web.Core.Domain.Controller;
using CTS.Web.Core.Domain.Helper;
using CTS.Web.Core.Domain.Model;
using Resources;

namespace CTS.W._150901.Web
{
    public partial class booking_step_4 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session["CLN.W150901.BookingData"] == null
                    || Session["CLN.W150901.BookingData"].GetType() != typeof(BookingObject)) {
                    Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-fail"));
                    return;
                }
                var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
                if (!bookingObj.IsCompleteStep1()
                    || !bookingObj.IsCompleteStep2()
                    || !bookingObj.IsCompleteStep3()) {
                    Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-fail"));
                    return;
                }
                ltDateFrom.Text = DataHelper.ToString(Formats.FM_DATE, bookingObj.DateFrom);
                ltDateTo.Text = DataHelper.ToString(Formats.FM_DATE, bookingObj.DateTo);
                var response = GetInfo(bookingObj.TypeCd);
                ltTypeName.Text = PageCom.GetValue(response, "TypeName");
                ltMaxAdult.Text = PageCom.GetValue(response, "AdultPerRoom");
                var calcResponse = CalcInfo(bookingObj);
                ltTotal.Text = PageCom.GetValue(calcResponse, "Total");
            }
            var companyCom = new CompanyCom();
            ltPhone.Text = companyCom.GetString("en", W150901Logics.CD_INFO_CD_PHONE, false);
            ltAddress.Text = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_ADDRESS, false);
            ltEmail.Text = companyCom.GetString("en", W150901Logics.CD_INFO_CD_EMAIL_RESERVE, false);
        }
        private BasicResponse GetInfo(string typeCd) {
            var request = new BasicRequest();
            request.Add("TypeCd", typeCd);
            var logic = new GetOperateLogic();
            var response = PageCom.Invoke(logic, request);
            return response;
        }
        private BasicResponse CalcInfo(BookingObject bookingObj) {
            var request = new BasicRequest();
            request.Add("TypeCd", bookingObj.TypeCd);
            request.Add("DateFrom", bookingObj.DateFrom);
            request.Add("DateTo", bookingObj.DateTo);
            request.Add("RoomQty", bookingObj.RoomQty);
            request.Add("HasPickUp", bookingObj.PickUp);
            request.Add("HasSeeOff", bookingObj.SeeOff);
            var logic = new CalcOperateLogic();
            var response = PageCom.Invoke(logic, request);
            return response;
        }
    }
}