using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Core.Domain.Controller;
using CTS.W._150901.Models.Domain.Logic.Client.Page;
using CTS.Core.Domain.Model;
using CTS.Web.Core.Domain.Model;

namespace CTS.W._150901.Web
{
    public partial class index : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = new BasicRequest();
            request.Add("Slug", "index");
            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, request);

            var Pages = PageCom.GetValue<HashMap>(response, "Page");

            ltPageName.Text = PageCom.GetValue<string>(Pages, "PageName");
            ltPageContent.Text = PageCom.GetValue<string>(Pages, "Content");

        }
    }
}