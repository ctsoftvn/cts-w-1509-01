using System;
using CTS.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Logic.Client.Booking;
using CTS.W._150901.Models.Domain.Object.Client.Booking;
using CTS.Web.Core.Domain.Controller;
using CTS.Web.Core.Domain.Helper;
using CTS.Web.Core.Domain.Model;
using Resources;

namespace CTS.W._150901.Web
{
    /// <summary>
    /// booking_step_3
    /// </summary>
    public partial class booking_step_3 : PageBase
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
                    || !bookingObj.IsCompleteStep2()) {
                    Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-fail"));
                    return;
                }
                ltDateFrom.Text = DataHelper.ToString(Formats.FM_DATE, bookingObj.DateFrom);
                ltDateTo.Text = DataHelper.ToString(Formats.FM_DATE, bookingObj.DateTo);
                hdRoomQty.Value = DataHelper.ToString(Formats.FM_NUMBER, bookingObj.RoomQty);
                hdDays.Value = DataHelper.ToString(Formats.FM_NUMBER, bookingObj.GetDays());
                var response = GetInfo(bookingObj.TypeCd);
                ltTypeName.Text = PageCom.GetValue(response, "TypeName");
                ltPickUp.Text = PageCom.GetValue(response, "PickUpPrice");
                ltSeeOff.Text = PageCom.GetValue(response, "SeeOffPrice");
                hdPrice.Value = PageCom.GetValue(response, "Price");
                hdPickUpPrice.Value = PageCom.GetValue(response, "PickUpPrice");
                hdSeeOffPrice.Value = PageCom.GetValue(response, "SeeOffPrice");
                ClearData();
            }
            btnBookingStep3.Text = Strings.CLN_BOOKING_FORM_BOOK_NOW;
        }
        protected void btnBookingStep3_Click(object sender, EventArgs e) {
            SetInputInfo();
            SetTypeInfo();
            SetCalcInfo();
            var logic = new SendOperateLogic();
            var response = PageCom.Invoke(logic, null);
            if (response.ResultFlag) {
                Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-4"));
            } else {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "<script> alert('" + Strings.CLN_ALERT_ERROR + "'); </script>");
            }
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
        private void SetInputInfo() {
            var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
            bookingObj.FirstName = tbFirstName.Text;
            bookingObj.LastName = tbLastName.Text;
            bookingObj.Email = tbEmail.Text;
            bookingObj.Phone = tbPhone.Text;
            bookingObj.Address = tbAddress.Text;
            bookingObj.StateCounty = tbStateCounty.Text;
            bookingObj.City = tbCity.Text;
            bookingObj.Country = tbCountry.Text;
            bookingObj.Request = tbNotes.Text;
            bookingObj.PickUp = chkPickUp.Checked;
            bookingObj.SeeOff = chkSeeOff.Checked;
            Session["CLN.W150901.BookingData"] = bookingObj;
        }
        private void SetTypeInfo() {
            var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
            var response = GetInfo(bookingObj.TypeCd);
            bookingObj.TypeName = PageCom.GetValue(response, "TypeName");
            bookingObj.AdultPerRoom = DataHelper.ConvertInputNumber(PageCom.GetValue(response, "AdultPerRoom"));
            Session["CLN.W150901.BookingData"] = bookingObj;
        }
        private void SetCalcInfo() {
            var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
            var response = CalcInfo(bookingObj);
            bookingObj.Total = DataHelper.ConvertInputNumber(PageCom.GetValue(response, "Total"));
            bookingObj.Days = DataHelper.ConvertInputNumber(PageCom.GetValue(response, "Days"));
            bookingObj.Price = DataHelper.ConvertInputNumber(PageCom.GetValue(response, "Price"));
            bookingObj.PickUpPrice = DataHelper.ConvertInputNumber(PageCom.GetValue(response, "PickUpPrice"));
            bookingObj.SeeOffPrice = DataHelper.ConvertInputNumber(PageCom.GetValue(response, "SeeOffPrice"));
            Session["CLN.W150901.BookingData"] = bookingObj;
        }
        private void ClearData() {
            var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
            bookingObj.ClearStep3();
            Session["CLN.W150901.BookingData"] = bookingObj;
        }
    }
}