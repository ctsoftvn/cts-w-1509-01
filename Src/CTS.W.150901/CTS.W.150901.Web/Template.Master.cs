using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CTS.W._150901.Models.Domain.Logic.Client.Main;
using CTS.Web.Core.Domain.Controller;
using CTS.Web.Core.Domain.Helper;
using Resources;

namespace CTS.W._150901.Web
{
    public partial class Template : MasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e) {

            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, null);

            var listLocales = PageCom.GetValue<IList<object>>(response, "CboLocales");
            rptLanguages.DataSource = listLocales;
            rptLanguages.DataBind();

            var listBanners = PageCom.GetValue<IList<object>>(response, "ListBanner");
            rptBanners.DataSource = listBanners;
            rptBanners.DataBind();

            //var logoUrl = "/file-manager?fcd=" + PageCom.GetValue<string>(response, "Logo") + "&lang=en&s=normal";
            //imgLogo.ImageUrl = logoUrl;
            ltSlogan.Text = PageCom.GetValue<string>(response, "Slogan");
            ltCopyright.Text = PageCom.GetValue<string>(response, "Copyright");
            ltAdderess.Text = PageCom.GetValue<string>(response, "Address");

            lkMenuHotel1.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl1");
            lkMenuHotel2.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl2");
            lkMenuHotel3.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl3");
            lkMenuHotel4.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl4");

            lkHotel1.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl1");
            lkHotel2.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl2");
            lkHotel3.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl3");
            lkHotel4.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl4");
            lkHotel1.ToolTip = Convert.ToString(Strings.CLN_MASTER_HOTEL_1_TEXT);
            lkHotel2.ToolTip = Convert.ToString(Strings.CLN_MASTER_HOTEL_2_TEXT);
            lkHotel3.ToolTip = Convert.ToString(Strings.CLN_MASTER_HOTEL_3_TEXT);
            lkHotel4.ToolTip = Convert.ToString(Strings.CLN_MASTER_HOTEL_4_TEXT);

            lkMobiHotel1.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl1");
            lkMobiHotel2.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl2");
            lkMobiHotel3.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl3");
            lkMobiHotel4.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl4");

            lkTwitter.NavigateUrl = PageCom.GetValue<string>(response, "TwitterUrl");
            lkGoogle.NavigateUrl = PageCom.GetValue<string>(response, "GoogleUrl");
            lkFacebook.NavigateUrl = PageCom.GetValue<string>(response, "FacebookUrl");
            lkYoutube.NavigateUrl = PageCom.GetValue<string>(response, "YoutubeUrl");
        }

        protected void lbtnLanguage_Command(object sender, CommandEventArgs e) {
            var lang = Convert.ToString(e.CommandArgument);
            var rawUrl = HttpHelper.GetRawUrl(lang, "index");
            Response.Redirect(rawUrl, true);
        }
    }
}