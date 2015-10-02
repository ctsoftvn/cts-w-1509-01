﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Core.Domain.Model;
using CTS.Core.Domain.Attr;
using CTS.W._150901.Models.Domain.Object.Client.Tour;

namespace CTS.W._150901.Models.Domain.Model.Client.Tours
{
    public class InitDataModel : BasicInfoModel
    {
        [OutputList(IgnoreAttribute = false)]
        public IList<TourObject> ListTourType { get; set; }
        [OutputText]
        public string MetaKey { get; set; }
        [OutputText]
        public string MetaTitle { get; set; }
        [OutputText]
        public string MetaDescription { get; set; }
    }
}