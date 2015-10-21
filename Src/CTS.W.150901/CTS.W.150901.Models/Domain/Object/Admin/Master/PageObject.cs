using CTS.Core.Domain.Attr;
using CTS.Core.Domain.Model;

namespace CTS.W._150901.Models.Domain.Object.Admin.Master
{
    /// <summary>
    /// PageObject
    /// </summary>
    public class PageObject : BaseMeta
    {
        [OutputText]
        [InputText(RuleName = "localeCd", MessageParam = "P_CM_00012")]
        public string LocaleCd { get; set; }
        [OutputText]
        [InputText]
        public string PageCd { get; set; }
        [OutputText]
        [InputText(RuleName = "name", MessageParam = "ADM_MA_PAGES_00002")]
        public string PageName { get; set; }
        [OutputText]
        [InputText(RuleName = "searchName", MessageParam = "P_CM_00026")]
        public string SearchName { get; set; }
        // [OutputText]
        // [InputText(RuleName = "slug", MessageParam = "P_CM_00027")]
        // public string Slug { get; set; }
        [OutputText]
        [InputText(RuleName = "notes", MessageParam = "ADM_MA_PAGES_00003")]
        public string Content { get; set; }
        [OutputText(Format = "{0:N0}")]
        [InputText(RuleName = "versionNo", MessageParam = "P_CM_00014")]
        public decimal? VersionNo { get; set; }

        [OutputText]
        public string Notes { get; set; }
        [OutputText]
        public string LocaleName { get; set; }
    }
}
