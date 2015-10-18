using System.Collections.Generic;
using CTS.Core.Domain.Attr;
using CTS.Core.Domain.Model;
using CTS.W._150901.Models.Domain.Object.Client.Booking;

namespace CTS.W._150901.Models.Domain.Model.Client.Booking
{
    /// <summary>
    /// FilterDataModel
    /// </summary>
    public class FilterDataModel : BasicInfoModel
    {
        [OutputList(IgnoreAttribute = false)]
        public IList<RoomTypeObject> ListData { get; set; }
    }
}
