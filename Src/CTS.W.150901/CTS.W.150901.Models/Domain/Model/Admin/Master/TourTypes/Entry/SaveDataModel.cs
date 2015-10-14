﻿using CTS.Core.Domain.Attr;
using CTS.Core.Domain.Model;
using CTS.W._150901.Models.Domain.Object.Admin.Master;

namespace CTS.W._150901.Models.Domain.Model.Admin.Master.TourTypes.Entry
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class SaveDataModel : BasicInfoModel
    {
        [InputObject(IgnoreAttribute = false)]
        public LocaleModel<TourTypeObject> LocaleModel { get; set; }
    }
}