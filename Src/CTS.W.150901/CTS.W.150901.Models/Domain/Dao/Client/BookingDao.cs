using System.Collections.Generic;
using CTS.Data.Core.Domain.Dao;
using CTS.W._150901.Models.Domain.Common.Dao;
using CTS.W._150901.Models.Domain.Object.Client.Booking;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Dao.Client
{
    /// <summary>
    /// BookingDao
    /// </summary>
    public class BookingDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string BOOKINGDAO_GETLISTROOMTYPES_SQL = "BookingDao_GetListRoomTypes.sql";

        /// <summary>
        /// Lấy thông tin
        /// </summary>
        public IList<RoomTypeObject> GetListRoomTypes() {
            // Tạo tham số
            var param = new {
                LocaleCd = WebContextHelper.LocaleCd
            };
            // Kết quả trả về
            return GetListByFile<RoomTypeObject>(BOOKINGDAO_GETLISTROOMTYPES_SQL, param);
        }
    }
}
