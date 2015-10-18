using System;
using CTS.Core.Domain.Attr;
using CTS.Core.Domain.Model;

namespace CTS.W._150901.Models.Domain.Model.Client.Booking
{
    /// <summary>
    /// CalcDataModel
    /// </summary>
    public class CalcDataModel : BasicInfoModel
    {
        [InputText]
        public string TypeCd { get; set; }
        [InputText]
        public DateTime? DateFrom { get; set; }
        [InputText]
        public DateTime? DateTo { get; set; }
        [InputText]
        public decimal? RoomQty { get; set; }
        [InputText]
        public bool? HasPickUp { get; set; }
        [InputText]
        public bool? HasSeeOff { get; set; }

        [OutputText(Format = "{0:N0}")]
        public decimal? Total { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? Days { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? Price { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? PickUpPrice { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? SeeOffPrice { get; set; }
    }
}
