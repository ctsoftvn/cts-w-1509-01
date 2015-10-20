using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Core.Domain.Controller;

namespace CTS.W._150901.Web
{
    public partial class booking_fail : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = Resources.Strings.CLN_BOOKING_PAGE;
        }
    }
}