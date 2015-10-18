using System;
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
    /// CalcLogic
    /// </summary>
    public class CalcLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý calc.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public CalcDataModel Execute(CalcDataModel inputObject) {
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
        private void Check(CalcDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var masterDataCom = new MasterDataCom();
            // Kiểm tra bắt buộc
            if (DataCheckHelper.IsNull(inputObject.TypeCd)) {
                throw new SysIgnoreException();
            }
            if (DataCheckHelper.IsNull(inputObject.DateFrom)) {
                throw new SysIgnoreException();
            }
            if (DataCheckHelper.IsNull(inputObject.DateTo)) {
                throw new SysIgnoreException();
            }
            if (DataCheckHelper.IsNull(inputObject.RoomQty)) {
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
        private CalcDataModel GetInfo(CalcDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var getResult = new CalcDataModel();
            var masterDataCom = new MasterDataCom();
            var parameterCom = new ParameterCom();
            var total = decimal.Zero;
            var pickUpPrice = decimal.Zero;
            var seeOffPrice = decimal.Zero;
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy thông tin
            var dataInfo = masterDataCom.GetInfoRoomType(
                WebContextHelper.LocaleCd, inputObject.TypeCd, false);
            // Lấy giá phòng và số ngày thuê
            var price = dataInfo.Price.Value;
            var roomQty = inputObject.RoomQty.Value;
            var days = GetDays(inputObject.DateFrom.Value, inputObject.DateTo.Value);
            // Lấy số tiền dưa đón khách
            if (inputObject.HasPickUp.HasValue && inputObject.HasPickUp.Value) {
                pickUpPrice = parameterCom.GetNumber(W150901Logics.CD_PARAM_CD_BOOKING_PICKUP, true).Value;
            }
            if (inputObject.HasSeeOff.HasValue && inputObject.HasSeeOff.Value) {
                seeOffPrice = parameterCom.GetNumber(W150901Logics.CD_PARAM_CD_BOOKING_SEEOFF, true).Value;
            }
            // Tiến hành tính toán tổng tiền
            total = (price * roomQty * days) + pickUpPrice + seeOffPrice;
            // Gán giá trị trả về
            getResult.Total = total;
            getResult.Price = price;
            getResult.Days = days;
            getResult.PickUpPrice = pickUpPrice;
            getResult.SeeOffPrice = seeOffPrice;
            // Kết quả trả về
            return getResult;
        }

        /// <summary>
        /// Lấy số ngày thuê từ ngày đến và ngày đi
        /// </summary>
        /// <param name="from">Ngày đến</param>
        /// <param name="to">Ngày đi</param>
        /// <returns>Số ngày thuê</returns>
        private decimal GetDays(DateTime from, DateTime to) {
            // Khởi tạo biến cục bộ
            var days = decimal.Zero;
            // Lấy thời gian thuê phòng
            var time = to - from;
            // Gán giá trị trả về
            days = time.Days;
            // Kết quả trả về
            return days;
        }
        #endregion
    }
}
