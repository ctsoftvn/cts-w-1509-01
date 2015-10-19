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
                //
                var companyCom = new CompanyCom();
                ltPhone.Text = companyCom.GetString(W150901Logics.CD_LOCALE_CD_EN, W150901Logics.CD_INFO_CD_PHONE, false);
                ltEmail.Text = companyCom.GetString(W150901Logics.CD_LOCALE_CD_EN, W150901Logics.CD_INFO_CD_EMAIL_RESERVE, false);
                ltAddress.Text = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_ADDRESS, false);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e) {
            GetCalcInfo();
            var logic = new SendOperateLogic();
            var response = PageCom.Invoke(logic, null);
            if (response.ResultFlag) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "<script> alert('" + Strings.CLN_ALERT_SUCCESS + "'); </script>");
            } else {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "<script> alert('" + Strings.CLN_ALERT_ERROR + "'); </script>");
            }
            Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-1"));
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
        public void GetCalcInfo() {
            var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
            var calcResponse = CalcInfo(bookingObj);
            bookingObj.Total = DataHelper.ConvertInputNumber(PageCom.GetValue(calcResponse, "Total"));
            bookingObj.Days = DataHelper.ConvertInputNumber(PageCom.GetValue(calcResponse, "Days"));
            bookingObj.Price = DataHelper.ConvertInputNumber(PageCom.GetValue(calcResponse, "Price"));
            bookingObj.PickUpPrice = DataHelper.ConvertInputNumber(PageCom.GetValue(calcResponse, "PickUpPrice"));
            bookingObj.SeeOffPrice = DataHelper.ConvertInputNumber(PageCom.GetValue(calcResponse, "SeeOffPrice"));
            Session["CLN.W150901.BookingData"] = bookingObj;
        }
    }
}