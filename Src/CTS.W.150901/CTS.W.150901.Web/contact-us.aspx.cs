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
using CTS.W._150901.Models.Domain.Logic.Client.ContactUs;
using Resources;

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
        protected void btnSubmit_Command(object sender, CommandEventArgs e)
        {
            var request = new BasicRequest();
            request.Add("Name", txtName.Text);
            request.Add("Phone", txtPhone.Text);
            request.Add("Email", txtEmail.Text);
            request.Add("Description", txtDescription.Text);
            var logic = new SendMailOperateLogic();
            var response = PageCom.Invoke(logic, request);
            if (response.ResultFlag)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "<script> alert('" + Strings.CLN_ALERT_SUCCESS + "'); </script>");
                clearControls();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "<script> alert('" + Strings.CLN_ALERT_ERROR + "'); </script>");
            }

        }

        private void clearControls()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtDescription.Text = "";
        }
    }
}