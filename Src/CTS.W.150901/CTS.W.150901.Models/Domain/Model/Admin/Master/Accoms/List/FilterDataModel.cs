﻿using CTS.Core.Domain.Attr;
using CTS.Core.Domain.Model;
using CTS.W._150901.Models.Domain.Object.Admin.Master;

namespace CTS.W._150901.Models.Domain.Model.Admin.Master.Accoms.List
{
    /// <summary>
    /// FilterDataModel
    /// </summary>
    public class FilterDataModel : PagerInfoModel<AccomObject>
    {
        [InputText(RuleName = "name", MessageParam = "ADM_MA_ACCOMS_00002")]
        public string AccomName { get; set; }
        // [InputText(RuleName = "slug", MessageParam = "P_CM_00027")]
        // public string Slug { get; set; }
        [InputText(RuleName = "boolean", MessageParam = "P_CM_00002")]
        public bool? DeleteFlag { get; set; }
    }
}