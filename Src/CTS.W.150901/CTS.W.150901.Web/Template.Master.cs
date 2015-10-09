using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Core.Domain.Controller;
using CTS.W._150901.Models.Domain.Logic.Client.Main;
using CTS.Web.Core.Domain.Helper;
using CTS.Data.Com.Domain.Utils;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Data.Com.Domain.Constants;
using CTS.Core.Domain.Constants;
using Resources;

namespace CTS.W._150901.Web
{
    public partial class Template : MasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, null);

            var listLocales = PageCom.GetValue<IList<object>>(response, "CboLocales");
            rptLanguages.DataSource = listLocales;
            rptLanguages.DataBind();

            var listBanners = PageCom.GetValue<IList<object>>(response, "ListBanner");
            rptBanners.DataSource = listBanners;
            rptBanners.DataBind();


            ltSlogan.Text = PageCom.GetValue<string>(response, "Slogan");
            ltCopyright.Text = PageCom.GetValue<string>(response, "Copyright");
            ltAdderess.Text = PageCom.GetValue<string>(response, "Address");

            lkMenuHotel1.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl1");
            lkMenuHotel2.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl2");
            lkMenuHotel3.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl3");
            lkMenuHotel4.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl4");

            lkHotel1.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl1");
            lkHotel1.ToolTip = Convert.ToString(Strings.CLN_MASTER_HOTEL_1_TEXT);
            lkHotel2.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl2");
            lkHotel2.ToolTip = Convert.ToString(Strings.CLN_MASTER_HOTEL_2_TEXT);
            lkHotel3.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl3");
            lkHotel3.ToolTip = Convert.ToString(Strings.CLN_MASTER_HOTEL_3_TEXT);
            lkHotel4.NavigateUrl = PageCom.GetValue<string>(response, "HotelUrl4");
            lkHotel4.ToolTip = Convert.ToString(Strings.CLN_MASTER_HOTEL_4_TEXT);

            lkTwitter.NavigateUrl = PageCom.GetValue<string>(response, "TwitterUrl");
            lkGoogle.NavigateUrl = PageCom.GetValue<string>(response, "GoogleUrl");
            lkFacebook.NavigateUrl = PageCom.GetValue<string>(response, "FacebookUrl");
            lkYoutube.NavigateUrl = PageCom.GetValue<string>(response, "YoutubeUrl");
        }
        protected void lbtnLanguage_Command(object sender, CommandEventArgs e)
        {
            var homePage = "/index";
            var newLang = string.Format("/{0}/", Convert.ToString(e.CommandArgument));
            var oldLang = string.Format("/{0}/", WebContextHelper.LocaleCd);
            var strRawURL = Request.RawUrl;
            strRawURL = strRawURL.Replace("/index.aspx", homePage);
            //strRawURL = strRawURL.Replace("/about-us.aspx", "/gioi-thieu");
            //strRawURL = strRawURL.Replace("/contact-us.aspx", "/lien-he");
            if (strRawURL.TrimEnd('/').Length == 0)
            {
                strRawURL = oldLang.TrimEnd('/') + homePage;
            }
            if (newLang != oldLang)
            {
                if (strRawURL.IndexOf(oldLang) < 0)
                {
                    strRawURL = newLang + strRawURL.TrimStart('/');
                }
                else
                {
                    strRawURL = strRawURL.Replace(oldLang, newLang);
                }
            }
            var baseUrl = string.Format("{0}://{1}{2}/", Request.Url.Scheme, Request.Url.Authority, Request.ApplicationPath.TrimEnd('/'));
            if (!string.IsNullOrEmpty(baseUrl))
            {
                strRawURL = baseUrl + strRawURL.TrimStart('/');
            }
            Response.Redirect(strRawURL, true);
        }
    }
}