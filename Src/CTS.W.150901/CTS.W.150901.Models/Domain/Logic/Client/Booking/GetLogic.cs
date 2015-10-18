using CTS.Core.Domain.Exceptions;
using CTS.Core.Domain.Helper;
using CTS.Data.Com.Domain.Utils;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.W._150901.Models.Domain.Common.Utils;
using CTS.W._150901.Models.Domain.Model.Client.Booking;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Logic.Client.Booking
{
    /// <summary>
    /// GetLogic
    /// </summary>
    public class GetLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý get.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public GetDataModel Execute(GetDataModel inputObject) {
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
        private void Check(GetDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var masterDataCom = new MasterDataCom();
            // Kiểm tra bắt buộc
            if (DataCheckHelper.IsNull(inputObject.TypeCd)) {
                throw new SysIgnoreException();
            }
            // Kiểm tra dữ liệu tồn tại
            var isExist = masterDataCom.IsExistRoomType(
                WebContextHelper.LocaleCd, inputObject.TypeCd, false);
            if (!isExist) {
                throw new SysIgnoreException();
            }
        }
        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private GetDataModel GetInfo(GetDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var getResult = new GetDataModel();
            var masterDataCom = new MasterDataCom();
            var parameterCom = new ParameterCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy thông tin
            var dataInfo = masterDataCom.GetInfoRoomType(
                WebContextHelper.LocaleCd, inputObject.TypeCd, false);
            var pickUpPrice = parameterCom.GetNumber(W150901Logics.CD_PARAM_CD_BOOKING_PICKUP, true);
            var seeOffPrice = parameterCom.GetNumber(W150901Logics.CD_PARAM_CD_BOOKING_SEEOFF, true);
            // Gán giá trị trả về
            getResult.TypeCd = dataInfo.TypeCd;
            getResult.TypeName = dataInfo.TypeName;
            getResult.Price = dataInfo.Price;
            getResult.AdultPerRoom = dataInfo.AdultPerRoom;
            getResult.PickUpPrice = pickUpPrice;
            getResult.SeeOffPrice = seeOffPrice;
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
