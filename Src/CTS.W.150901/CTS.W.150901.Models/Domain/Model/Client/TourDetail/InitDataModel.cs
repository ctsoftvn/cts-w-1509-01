using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Core.Domain.Model;
using CTS.Core.Domain.Attr;
using CTS.W._150901.Models.Domain.Object.Client.Tour;

namespace CTS.W._150901.Models.Domain.Model.Client.TourDetail
{
    public class InitDataModel : BasicInfoModel
    {
        [OutputObject(IgnoreAttribute = false)]
        public TourObject Tour { get; set; }
        [InputText]
        public string Slug { get; set; }
        [OutputText]
        public string MetaKey { get; set; }
        [OutputText]
        public string MetaTitle { get; set; }
        [OutputText]
        public string MetaDescription { get; set; }
    }
}
