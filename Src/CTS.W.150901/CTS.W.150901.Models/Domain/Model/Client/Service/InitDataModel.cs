﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Core.Domain.Model;
using CTS.Core.Domain.Attr;
using CTS.W._150901.Models.Domain.Object.Client.Service;

namespace CTS.W._150901.Models.Domain.Model.Client.Service
{
    public class InitDataModel : BasicInfoModel
    {
        [OutputList(IgnoreAttribute = false)]
        public IList<ServiceObject> ListServices { get; set; }
        [OutputText]
        public string MetaKey { get; set; }
        [OutputText]
        public string MetaTitle { get; set; }
        [OutputText]
        public string MetaDescription { get; set; }
    }
}
