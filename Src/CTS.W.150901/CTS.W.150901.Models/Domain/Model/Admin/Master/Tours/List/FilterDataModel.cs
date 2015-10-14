using CTS.Core.Domain.Attr;
using CTS.Core.Domain.Model;
using CTS.W._150901.Models.Domain.Object.Admin.Master;

namespace CTS.W._150901.Models.Domain.Model.Admin.Master.Tours.List
{
    /// <summary>
    /// FilterDataModel
    /// </summary>
    public class FilterDataModel : PagerInfoModel<TourObject>
    {
        [InputText(RuleName = "name", MessageParam = "ADM_MA_TOURS_00002")]
        public string TourName { get; set; }
        [InputText(RuleName = "slug", MessageParam = "P_CM_00027")]
        public string Slug { get; set; }
        [InputText(RuleName = "code", MessageParam = "ADM_MA_TOURS_00003")]
        public string TourTypeCd { get; set; }
        [InputText(RuleName = "boolean", MessageParam = "P_CM_00002")]
        public bool? DeleteFlag { get; set; }
    }
}