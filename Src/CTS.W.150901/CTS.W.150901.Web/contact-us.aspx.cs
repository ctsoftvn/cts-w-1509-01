using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Core.Domain.Controller;
using CTS.Web.Core.Domain.Model;
using CTS.W._150901.Models.Domain.Logic.Client.Page;
using CTS.Core.Domain.Model;

namespace CTS.W._150901.Web
{
    public partial class contact_us : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = new BasicRequest();
            request.Add("Slug", "contact-us");
            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, request);

            var Pages = PageCom.GetValue<HashMap>(response, "Page");

            ltPageName.Text = PageCom.GetValue<string>(Pages, "PageName");
            ltPageContent.Text = PageCom.GetValue<string>(Pages, "Content");

            Page.Title = PageCom.GetValue<string>(response, "MetaTitle");
            Page.MetaKeywords = PageCom.GetValue<string>(response, "MetaKey");
            Page.MetaDescription = PageCom.GetValue<string>(response, "MetaDescription"); 
        }
    }
}