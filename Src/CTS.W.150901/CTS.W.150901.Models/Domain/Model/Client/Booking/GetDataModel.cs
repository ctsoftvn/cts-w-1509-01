using CTS.Core.Domain.Attr;
using CTS.Core.Domain.Model;

namespace CTS.W._150901.Models.Domain.Model.Client.Booking
{
    /// <summary>
    /// GetDataModel
    /// </summary>
    public class GetDataModel : BasicInfoModel
    {
        [InputText]
        [OutputText]
        public string TypeCd { get; set; }
        [OutputText]
        public string TypeName { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? Price { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? AdultPerRoom { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? SeeOffPrice { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? PickUpPrice { get; set; }
    }
}
