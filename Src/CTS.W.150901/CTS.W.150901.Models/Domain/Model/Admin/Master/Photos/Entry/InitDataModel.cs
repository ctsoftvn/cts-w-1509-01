using System.Collections.Generic;
using CTS.Core.Domain.Attr;
using CTS.Core.Domain.Model;
using CTS.W._150901.Models.Domain.Object.Admin.Master;

namespace CTS.W._150901.Models.Domain.Model.Admin.Master.Photos.Entry
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class InitDataModel : BasicInfoModel
    {
        [InputText(RuleName = "code", MessageParam = "ADM_MA_PHOTOS_00001")]
        public string PhotoCd { get; set; }
        [OutputText]
        public string BasicLocale { get; set; }
        [OutputObject(IgnoreAttribute = false)]
        public LocaleModel<PhotoObject> LocaleModel { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboDeleteFlag { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboLocales { get; set; }
        [OutputText]
        public string CboLocalesSeleted { get; set; }
    }
}
