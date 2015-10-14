using System.Linq;
using CTS.Core.Domain.Exceptions;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Core.Domain.Utils;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Com.Domain.Utils;
using CTS.W._150901.Models.Domain.Common.Utils;
using CTS.W._150901.Models.Domain.Dao.Admin;
using CTS.W._150901.Models.Domain.Model.Admin.Master.TourTypes.Entry;
using CTS.W._150901.Models.Domain.Object.Admin.Master;

namespace CTS.W._150901.Models.Domain.Logic.Admin.Master.TourTypes.Entry
{
    /// <summary>
    /// SaveLogic
    /// </summary>
    public class SaveLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý save.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public SaveDataModel Execute(SaveDataModel inputObject) {
            // Kiểm tra thông tin
            Check(inputObject);
            // Lưu thông tin
            var resultObject = SaveInfo(inputObject);
            // Kết quả trả về
            return resultObject;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Kiểm tra thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(SaveDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var masterDataCom = new MasterDataCom();
            var localeCom = new LocaleCom();
            var msgs = DataHelper.CreateList<Message>();
            // Lấy ngôn ngữ chuẩn
            var basicLocale = localeCom.GetDefault(DataComLogics.CD_APP_CD_CLN);
            // Lấy đối tượng dữ liệu
            var dataInfo = inputObject.LocaleModel.DataInfo;
            var listLocale = inputObject.LocaleModel.ListLocale;
            // Kiểm tra bắt buộc
            if (DataCheckHelper.IsNull(dataInfo.LocaleCd)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "P_CM_00012"));
            }
            if (DataCheckHelper.IsNull(dataInfo.TypeCd)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_MA_TOURTYPES_00001"));
            }
            if (DataCheckHelper.IsNull(dataInfo.TypeName)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_MA_TOURTYPES_00002"));
            }
            if (DataCheckHelper.IsNull(dataInfo.Slug)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "P_CM_00027"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Kiểm tra locale hợp lệ
            if (dataInfo.LocaleCd != basicLocale) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00030"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Kiểm tra dữ liệu tồn tại
            var isExist = masterDataCom.IsExistTourType(
                dataInfo.LocaleCd, dataInfo.TypeCd, true);
            // Kiểm tra dữ liệu tồn tại trường hợp status là add
            if (inputObject.IsAdd && (isExist)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00017", "ADM_MA_TOURTYPES_00004"));
            }
            // Kiểm tra dữ liệu tồn tại trường hợp status là edit
            if (inputObject.IsEdit && (!isExist)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00016", "ADM_MA_TOURTYPES_00004"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Kiểm tra giá trị duy nhất
            var isUnique = masterDataCom.IsUniqueTourType(dataInfo.TypeCd, dataInfo.Slug);
            if (!isUnique) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00017", "P_CM_00027"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Khởi tạo biến dùng trong loop
            var i = 1;
            var flagError = false;
            // Duyệt danh sách ngôn ngữ
            foreach (var info in listLocale) {
                // Gán trạng thái lỗi bằng false
                flagError = false;
                // Kiểm tra bắt buộc
                if (DataCheckHelper.IsNull(info.LocaleCd)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00020", i, "E_MSG_00001", "P_CM_00012"));
                }
                if (DataCheckHelper.IsNull(info.TypeName)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00020", i, "E_MSG_00001", "ADM_MA_TOURTYPES_00002"));
                }
                // Trường hợp lỗi thì đi đến record tiếp theo
                if (flagError) {
                    // Tăng giá trị i
                    i++;
                    // Đi đến record tiếp theo
                    continue;
                }
                // Kiểm tra giá trị duy nhất
                var comparer = new KeyEqualityComparer<TourTypeObject>((k1, k2) =>
                        k1.RowNo != k2.RowNo
                        && k1.LocaleCd == k2.LocaleCd
                );
                if (dataInfo.LocaleCd == info.LocaleCd || listLocale.Contains(info, comparer)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00020", i, "E_MSG_00017", "P_CM_00012"));
                }
                // Trường hợp lỗi thì đi đến record tiếp theo
                if (flagError) {
                    // Tăng giá trị i
                    i++;
                    // Đi đến record tiếp theo
                    continue;
                }
                // Tăng giá trị i
                i++;
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
        }

        /// <summary>
        /// Lưu thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private SaveDataModel SaveInfo(SaveDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var saveResult = new SaveDataModel();
            var processDao = new MasterTourTypesDao();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, saveResult);
            // Lấy đối tượng dữ liệu
            var dataInfo = inputObject.LocaleModel.DataInfo;
            var listLocale = inputObject.LocaleModel.ListLocale;
            // Lấy danh sách dữ liệu đa ngôn ngữ
            var listLocaleDb = processDao.GetListLocale(dataInfo.TypeCd);
            // Khởi tạo comparer
            var comparer = new KeyEqualityComparer<TourTypeObject>((k1, k2) =>
                k1.TypeCd == k2.TypeCd
                && k1.LocaleCd == k2.LocaleCd
            );
            // Xử lý tạo transaction
            var transaction = processDao.CreateTransaction();
            // Lưu đối tượng dữ liệu
            if (inputObject.IsAdd) {
                // Xử lý insert đối tượng dữ liệu
                processDao.Insert(dataInfo, transaction);
                // Duyệt danh sách locale
                foreach (var info in listLocale) {
                    // Gán dữ liệu cập nhật
                    info.TypeCd = dataInfo.TypeCd;
                    info.Slug = dataInfo.Slug;
                    info.FileCd = dataInfo.FileCd;
                    info.SortKey = dataInfo.SortKey;
                    info.DeleteFlag = dataInfo.DeleteFlag;
                    // Xử lý insert đối tượng dữ liệu
                    processDao.Insert(info, transaction);
                }
            } else {
                // Xử lý update đối tượng dữ liệu
                processDao.Update(dataInfo, transaction);
                // Duyệt danh sách locale
                foreach (var info in listLocale) {
                    // Gán dữ liệu cập nhật
                    info.TypeCd = dataInfo.TypeCd;
                    info.Slug = dataInfo.Slug;
                    info.FileCd = dataInfo.FileCd;
                    info.SortKey = dataInfo.SortKey;
                    info.DeleteFlag = dataInfo.DeleteFlag;
                    // Trường hợp không tồn tại dữ liệu
                    if (listLocaleDb.Contains(info, comparer)) {
                        // Xử lý update đối tượng dữ liệu
                        processDao.Update(info, transaction);
                    } else {
                        // Xử lý insert đối tượng dữ liệu
                        processDao.Insert(info, transaction);
                    }
                }
            }
            // Xử lý lưu các thay đổi từ transaction
            processDao.CommitTransaction(transaction);
            // Thêm thông báo thành công
            saveResult.AddMessage("I_MSG_00004");
            // Kết quả trả về
            return saveResult;
        }
        #endregion
    }
}
