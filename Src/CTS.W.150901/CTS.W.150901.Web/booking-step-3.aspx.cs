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
            Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-4"));
        }
        private BasicResponse GetInfo(string typeCd) {
            var request = new BasicRequest();
            request.Add("TypeCd", typeCd);
            var logic = new GetOperateLogic();
            var response = PageCom.Invoke(logic, request);
            return response;
        }
        private void ClearData() {
            var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
            bookingObj.ClearStep3();
            Session["CLN.W150901.BookingData"] = bookingObj;
        }
    }
}