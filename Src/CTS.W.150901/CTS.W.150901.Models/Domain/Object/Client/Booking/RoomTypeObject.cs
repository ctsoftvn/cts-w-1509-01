using CTS.Core.Domain.Attr;

namespace CTS.W._150901.Models.Domain.Object.Client.Booking
{
    /// <summary>
    /// RoomTypeObject
    /// </summary>
    public class RoomTypeObject
    {
        [OutputText]
        public string TypeCd { get; set; }
        [OutputText]
        public string TypeName { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? Price { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? AdultPerRoom { get; set; }
        [OutputText]
        public string FileCd { get; set; }
    }
}
