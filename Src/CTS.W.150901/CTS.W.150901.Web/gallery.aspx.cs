﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Core.Domain.Controller;
using CTS.Web.Core.Domain.Model;
using CTS.Core.Domain.Model;
using LogicPage = CTS.W._150901.Models.Domain.Logic.Client.Page;
using LogicPhoto = CTS.W._150901.Models.Domain.Logic.Client.Photo;

namespace CTS.W._150901.Web
{
    public partial class gallery : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = new BasicRequest();
            request.Add("Slug", "gallery");
            var logic = new LogicPage.InitOperateLogic();
            var response = PageCom.Invoke(logic, request);

            var Pages = PageCom.GetValue<HashMap>(response, "Page");

            ltPageName.Text = PageCom.GetValue<string>(Pages, "PageName");
            ltPageContent.Text = PageCom.GetValue<string>(Pages, "Content");

            Page.Title = PageCom.GetValue<string>(response, "MetaTitle");
            Page.MetaKeywords = PageCom.GetValue<string>(response, "MetaKey");
            Page.MetaDescription = PageCom.GetValue<string>(response, "MetaDescription");
            getPhotos();
        }
        public void getPhotos()
        {
            var logicPhoto = new LogicPhoto.InitOperateLogic();
            var responsePhoto = PageCom.Invoke(logicPhoto, null);
            var listPhotos = PageCom.GetValue<IList<object>>(responsePhoto, "ListPhotos");
            rptPhotos.DataSource = listPhotos;
            rptPhotos.DataBind();
        }
    }
}