﻿using System.Collections.Generic;
using CTS.Core.Domain.Attr;
using CTS.Core.Domain.Model;
using CTS.W._150901.Models.Domain.Object.Admin.Master;

namespace CTS.W._150901.Models.Domain.Model.Admin.Master.Tours.List
{
    /// <summary>
    /// SaveBatchDataModel
    /// </summary>
    public class SaveBatchDataModel : BasicInfoModel
    {
        [InputList(IgnoreAttribute = false)]
        public IList<TourObject> ListData { get; set; }
    }
}
