using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
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
    /// booking_step_2
    /// </summary>
    public partial class booking_step_2 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session["CLN.W150901.BookingData"] == null
                    || Session["CLN.W150901.BookingData"].GetType() != typeof(BookingObject)) {
                    Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-fail"));
                    return;
                }
                var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
                if (!bookingObj.IsCompleteStep1()) {
                    Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-fail"));
                    return;
                }
                ltDateFrom.Text = DataHelper.ToString(Formats.FM_DATE, bookingObj.DateFrom);
                ltDateTo.Text = DataHelper.ToString(Formats.FM_DATE, bookingObj.DateTo);
                tbDateFrom.Text = DataHelper.ToString(Formats.FM_DATE, bookingObj.DateFrom);
                tbDateTo.Text = DataHelper.ToString(Formats.FM_DATE, bookingObj.DateTo);
                var response = Filter();
                var listData = PageCom.GetValue<IList<object>>(response, "ListData");
                rptRoomTypes.DataSource = listData;
                rptRoomTypes.DataBind();
                ClearData();
            }
            //
            btnBookingStep2.Text = Resources.Strings.CLN_BOOKING_CHECK_AVAILABILITY;
        }
        protected void lnkSelectRoomType_Command(object sender, CommandEventArgs e) {
            var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
            bookingObj.TypeCd = Convert.ToString(e.CommandArgument);
            Session["CLN.W150901.BookingData"] = bookingObj;
            Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-3"));
        }
        protected void btnBookingStep2_Click(object sender, EventArgs e) {
            var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
            bookingObj.DateFrom = DataHelper.ConvertInputDate(tbDateFrom.Text);
            bookingObj.DateTo = DataHelper.ConvertInputDate(tbDateTo.Text);
            Session["CLN.W150901.BookingData"] = bookingObj;
            Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-2"));
        }
        private BasicResponse Filter() {
            var logic = new FilterOperateLogic();
            var response = PageCom.Invoke(logic, null);
            return response;
        }
        private void ClearData() {
            var bookingObj = Session["CLN.W150901.BookingData"] as BookingObject;
            bookingObj.ClearStep2();
            bookingObj.ClearStep3();
            Session["CLN.W150901.BookingData"] = bookingObj;
        }
    }
}