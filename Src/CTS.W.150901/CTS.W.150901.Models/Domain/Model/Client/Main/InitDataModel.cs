using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Core.Domain.Model;
using CTS.Core.Domain.Attr;
using CTS.W._150901.Models.Domain.Object.Client.Main;

namespace CTS.W._150901.Models.Domain.Model.Client.Main
{
    public class InitDataModel : BasicInfoModel
    {
        [OutputList(IgnoreAttribute = false)]
        public IList<BannerObject> ListBanner { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboLocales { get; set; }
        [OutputText]
        public string CboLocalesSeleted { get; set; }

        [OutputText]
        public string MetaKey { get; set; }
        [OutputText]
        public string MetaTitle { get; set; }
        [OutputText]
        public string MetaDescription { get; set; }
        [OutputText]
        public string CompanyName { get; set; }
        [OutputText]
        public string Logo { get; set; }
        [OutputText]
        public string Slogan { get; set; }
        [OutputText]
        public string Copyright { get; set; }
        [OutputText]
        public string Address { get; set; }
        [OutputText]
        public string FacebookUrl { get; set; }
        [OutputText]
        public string TwitterUrl { get; set; }
        [OutputText]
        public string GoogleUrl { get; set; }
        [OutputText]
        public string YoutubeUrl { get; set; }
        [OutputText]
        public string HotelUrl1 { get; set; }
        [OutputText]
        public string HotelUrl2 { get; set; }
        [OutputText]
        public string HotelUrl3 { get; set; }
        [OutputText]
        public string HotelUrl4 { get; set; }
    }
}
