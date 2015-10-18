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
using CTS.W._150901.Models.Domain.Common.Constants;

namespace CTS.W._150901.Web
{
    public partial class booking_step_4 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //getRooms();
                getRooms();
            }
            var companyCom = new CompanyCom();
            ltPhone.Text = companyCom.GetString("en", W150901Logics.CD_INFO_CD_PHONE, false);
            ltAddress.Text = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_ADDRESS, false);
            ltEmail.Text = companyCom.GetString("en", W150901Logics.CD_INFO_CD_EMAIL_RESERVE, false);
        }
        public void getRooms()
        {
            var dataCom = new MasterDataCom();
            var param = new ParameterCom();
            var roomCd = Session["CLN.W150901.Booking.RoomCd"].ToString();
            var sDatefrom = Session["CLN.W150901.Booking.DateFrom"].ToString();
            var sDateto = Session["CLN.W150901.Booking.DateTo"].ToString();

            var dataInfo = dataCom.GetInfoRoomType(WebContextHelper.LocaleCd, roomCd, false);
            ltTypeName.Text = dataInfo.TypeName;
            ltAdult.Text = dataInfo.AdultPerRoom.ToString();
            ltDatefrom.Text = sDatefrom;
            ltDateto.Text = sDateto;

            var roomPrice = dataInfo.Price;
            var datefrom = DataHelper.ConvertInputDate(sDatefrom);
            var dateto = DataHelper.ConvertInputDate(sDateto);
            var dates = dateto - datefrom;
            var nights = dates.Value.Days;
            var pickupPrice = param.GetNumber("ma.params.booking.pickup", true);
            var seeoffPrice = param.GetNumber("ma.params.booking.seeoff", true);
            if (!pickupPrice.HasValue || !(bool)Session["CLN.W150901.Booking.PickupPrice"])
            {
                pickupPrice = Decimal.Zero;
            }
            if (!seeoffPrice.HasValue || !(bool)Session["CLN.W150901.Booking.SeeoffPrice"])
            {
                seeoffPrice = Decimal.Zero;
            }
            var total = (roomPrice * nights) + pickupPrice + seeoffPrice;

            ltTotal.Text = total.ToString() + "$";

        }
    }
}