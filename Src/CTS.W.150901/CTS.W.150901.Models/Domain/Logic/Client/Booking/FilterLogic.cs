using CTS.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Dao.Client;
using CTS.W._150901.Models.Domain.Model.Client.Booking;

namespace CTS.W._150901.Models.Domain.Logic.Client.Booking
{
    /// <summary>
    /// FilterLogic
    /// </summary>
    public class FilterLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý filter.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public FilterDataModel Execute(FilterDataModel inputObject) {
            // Kiểm tra thông tin
            Check(inputObject);
            // Lấy thông tin
            var resultObject = GetInfo(inputObject);
            // Kết quả trả về
            return resultObject;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Kiểm tra thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(FilterDataModel inputObject) {
        }
        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private FilterDataModel GetInfo(FilterDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var getResult = new FilterDataModel();
            var processDao = new BookingDao();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy danh sách room
            var listData = processDao.GetListRoomTypes();
            // Kết quả trả về
            getResult.ListData = listData;
            return getResult;
        }
        #endregion
    }
}
