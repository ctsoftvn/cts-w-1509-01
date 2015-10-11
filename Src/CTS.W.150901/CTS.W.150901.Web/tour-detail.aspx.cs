using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Core.Domain.Controller;
using CTS.Web.Core.Domain.Model;
using CTS.W._150901.Models.Domain.Logic.Client.TourDetail;
using CTS.Core.Domain.Model;

namespace CTS.W._150901.Web
{
    public partial class tour_detail : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = new BasicRequest();
            request.Add("Slug", Request["name"]);
            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, request);

            var Tours = PageCom.GetValue<HashMap>(response, "Tour");

            ltTourTitle.Text = PageCom.GetValue<string>(Tours, "TourName");
            ltTourDes.Text = PageCom.GetValue<string>(Tours, "Notes");

            Page.Title = PageCom.GetValue<string>(response, "MetaTitle");
            Page.MetaKeywords = PageCom.GetValue<string>(response, "MetaKey");
            Page.MetaDescription = PageCom.GetValue<string>(response, "MetaDescription");
        }
    }
}