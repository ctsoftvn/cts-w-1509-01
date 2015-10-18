using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Core.Domain.Controller;
using CTS.W._150901.Models.Domain.Common.Utils;
using CTS.Web.Core.Domain.Helper;
using CTS.Data.Com.Domain.Utils;
using CTS.Core.Domain.Helper;

namespace CTS.W._150901.Web
{
    public partial class booking_step_3 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //getRooms();
                var sDatefrom = Session["CLN.W150901.Booking.DateFrom"].ToString();
                var sDateto = Session["CLN.W150901.Booking.DateTo"].ToString();
                ltDatefrom.Text = sDatefrom;
                ltDateto.Text = sDateto;
                var datefrom = DataHelper.ConvertInputDate(sDatefrom);
                var dateto = DataHelper.ConvertInputDate(sDateto);
                var nights = dateto - datefrom;
                hdNights.Value = nights.Value.Days.ToString();
                getRooms();
            }
        }
        public void getRooms()
        {
            var roomCd = Session["CLN.W150901.Booking.RoomCd"].ToString();
            var dataCom = new MasterDataCom();
            var param = new ParameterCom();
            var dataInfo = dataCom.GetInfoRoomType(WebContextHelper.LocaleCd, roomCd, false);
            ltTypeName.Text = dataInfo.TypeName;

            hdRoomPrice.Value = dataInfo.Price.ToString();
            var pickupPrice = param.GetNumber("ma.params.booking.pickup", true);
            var seeoffPrice = param.GetNumber("ma.params.booking.seeoff", true);
            if (!pickupPrice.HasValue)
            {
                pickupPrice = Decimal.Zero;
            }
            if (!seeoffPrice.HasValue)
            {
                seeoffPrice = Decimal.Zero;
            }
            hdPickup.Value = pickupPrice.ToString();
            hdSeeoff.Value = seeoffPrice.ToString();
            ltPickup.Text = pickupPrice.ToString();
            ltSeeoff.Text = seeoffPrice.ToString();
        }
        protected void booking_step3_Click(object sender, EventArgs e)
        {
            Session["CLN.W150901.Booking.FirstName"] = tbFirstName.Text;
            Session["CLN.W150901.Booking.LastName"] = tbLastName.Text;
            Session["CLN.W150901.Booking.Email"] = tbEmail.Text;
            Session["CLN.W150901.Booking.Phone"] = tbPhone.Text;
            Session["CLN.W150901.Booking.Address"] = tbAddress.Text;
            Session["CLN.W150901.Booking.StateCounty"] = tbStateCounty.Text;
            Session["CLN.W150901.Booking.City"] = tbCity.Text;
            Session["CLN.W150901.Booking.Country"] = tbCountry.Text;
            Session["CLN.W150901.Booking.Request"] = tbNotes.Text;

            Session["CLN.W150901.Booking.PickupPrice"] = pickup.Checked;
            Session["CLN.W150901.Booking.SeeoffPrice"] = seeoff.Checked;

            
            Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-4"));
        }
    }
}