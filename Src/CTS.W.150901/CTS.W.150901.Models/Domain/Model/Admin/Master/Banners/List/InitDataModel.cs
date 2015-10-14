using System.Collections.Generic;
using CTS.Core.Domain.Attr;
using CTS.Core.Domain.Model;

namespace CTS.W._150901.Models.Domain.Model.Admin.Master.Banners.List
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class InitDataModel : BasicInfoModel
    {
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboLocales { get; set; }
        [OutputText]
        public string CboLocalesSeleted { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboDeleteFlag { get; set; }
        [OutputText]
        public bool? CboDeleteFlagSeleted { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboGrdDeleteFlag { get; set; }
        [OutputText]
        public string BasicLocale { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? Limit { get; set; }
    }
}
