using CTS.Core.Domain.Attr;

namespace CTS.W._150901.Models.Domain.Object.Admin.Master
{
    /// <summary>
    /// TourTypeObject
    /// </summary>
    public class TourTypeObject
    {
        [OutputText(Format = "{0:N0}")]
        [InputText(RuleName = "rowNo", MessageParam = "P_CM_00025")]
        public decimal? RowNo { get; set; }
        [OutputText]
        [InputText(RuleName = "localeCd", MessageParam = "P_CM_00012")]
        public string LocaleCd { get; set; }
        [OutputText]
        [InputText(RuleName = "code", MessageParam = "ADM_MA_TOURTYPES_00001")]
        public string TypeCd { get; set; }
        [OutputText]
        [InputText(RuleName = "name", MessageParam = "ADM_MA_TOURTYPES_00002")]
        public string TypeName { get; set; }
        [OutputText]
        [InputText(RuleName = "searchName", MessageParam = "P_CM_00026")]
        public string SearchName { get; set; }
        [OutputText]
        [InputText(RuleName = "slug", MessageParam = "P_CM_00027")]
        public string Slug { get; set; }
        [OutputText]
        [InputText(RuleName = "fileCd", MessageParam = "ADM_MA_TOURTYPES_00003")]
        public string FileCd { get; set; }
        [OutputText(Format = "{0:N0}")]
        [InputText(RuleName = "sortKey", MessageParam = "P_CM_00013")]
        public decimal? SortKey { get; set; }
        [OutputText(Format = "{0:N0}")]
        [InputText(RuleName = "versionNo", MessageParam = "P_CM_00014")]
        public decimal? VersionNo { get; set; }
        [OutputText]
        [InputText(RuleName = "boolean", MessageParam = "P_CM_00002")]
        public bool? DeleteFlag { get; set; }

        [OutputText]
        public string LocaleName { get; set; }
        [OutputText]
        public string DeleteFlagName { get; set; }
    }
}
