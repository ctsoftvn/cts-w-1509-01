using System;
using CTS.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Object.Client.Booking;
using CTS.Web.Core.Domain.Controller;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Web
{
    /// <summary>
    /// booking_step_1
    /// </summary>
    public partial class booking_step_1 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Session["CLN.W150901.BookingData"] = null;
            }
            //
            btnBookingStep1.Text = Resources.Strings.CLN_BOOKING_CHECK_AVAILABILITY;
        }
        protected void btnBookingStep1_Click(object sender, EventArgs e) {
            var bookingObj = new BookingObject();
            bookingObj.DateFrom = DataHelper.ConvertInputDate(tbDateFrom.Text);
            bookingObj.DateTo = DataHelper.ConvertInputDate(tbDateTo.Text);
            bookingObj.RoomQty = DataHelper.ConvertInputNumber(cbRoomQty.SelectedValue);
            Session["CLN.W150901.BookingData"] = bookingObj;
            Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-2"));
        }
    }
}