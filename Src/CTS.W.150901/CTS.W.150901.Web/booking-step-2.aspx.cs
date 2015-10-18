using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Core.Domain.Controller;
using CTS.W._150901.Models.Domain.Logic.Client.Room;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Web
{
    public partial class booking_step_2 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var langBooking = Session["CLN.W150901.Booking.LangBooking"];
                if (langBooking == null || langBooking.ToString() != WebContextHelper.LocaleCd)
                {
                    //clear all session
                    Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-1"));
                }
                getRooms();
                var sDatefrom = Session["CLN.W150901.Booking.DateFrom"].ToString();
                var sDateto = Session["CLN.W150901.Booking.DateTo"].ToString();
                ltDatefrom.Text = sDatefrom;
                ltDateto.Text = sDateto;
                datefrom.Text = sDatefrom;
                dateto.Text = sDateto;
            }

        }
        public void getRooms()
        {
            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, null);
            var listRooms = PageCom.GetValue<IList<object>>(response, "ListRoomType");
            rptRooms.DataSource = listRooms;
            rptRooms.DataBind();
        }
        protected void lnkSelectRoom_Command(object sender, CommandEventArgs e)
        {
            Session["CLN.W150901.Booking.RoomCd"] = Convert.ToString(e.CommandArgument);
            Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-3"));
        }
        protected void booking_step2_Click(object sender, EventArgs e)
        {
            Session["CLN.W150901.Booking.DateFrom"] = datefrom.Text;
            Session["CLN.W150901.Booking.DateTo"] = dateto.Text;
            Response.Redirect(string.Format("/{0}/{1}", WebContextHelper.LocaleCd, "booking-step-2"));
        }

    }
}