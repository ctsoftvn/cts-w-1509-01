using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Core.Domain.Controller;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Web
{
    public partial class booking_step_1 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void booking_step1_Click(object sender, EventArgs e)
        {
            Session["CLN.W150901.Booking.DateForm"] = datefrom.Text;
            Session["CLN.W150901.Booking.DateTo"] = dateto.Text;
            Session["CLN.W150901.Booking.RoomQty"] = room_qty.SelectedValue;
            Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-2"));
        }

      
    }
}