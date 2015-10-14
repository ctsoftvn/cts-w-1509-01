using System.Linq;
using CTS.Core.Domain.Exceptions;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Core.Domain.Utils;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Com.Domain.Utils;
using CTS.W._150901.Models.Domain.Common.Utils;
using CTS.W._150901.Models.Domain.Dao.Admin;
using CTS.W._150901.Models.Domain.Model.Admin.Master.TourTypes.List;
using CTS.W._150901.Models.Domain.Object.Admin.Master;

namespace CTS.W._150901.Models.Domain.Logic.Admin.Master.TourTypes.List
{
    /// <summary>
    /// SaveBatchLogic
    /// </summary>
    public class SaveBatchLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý save.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public SaveBatchDataModel Execute(SaveBatchDataModel inputObject) {
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
        private void Check(SaveBatchDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var masterDataCom = new MasterDataCom();
            var msgs = DataHelper.CreateList<Message>();
            // Kiểm tra bắt buộc
            if (DataCheckHelper.IsNull(inputObject.ListData)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "P_CM_00015"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Khởi tạo biến dùng trong loop
            var i = 1;
            // Duyệt danh sách dữ liệu
            foreach (var info in inputObject.ListData) {
                // Khởi tạo biến cục bộ
                var flagError = false;
                // Kiểm tra bắt buộc
                if (DataCheckHelper.IsNull(info.LocaleCd)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00015", i, "E_MSG_00001", "P_CM_00012"));
                }
                if (DataCheckHelper.IsNull(info.TypeCd)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00015", i, "E_MSG_00001", "ADM_MA_TOURTYPES_00001"));
                }
                if (DataCheckHelper.IsNull(info.TypeName)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00015", i, "E_MSG_00001", "ADM_MA_TOURTYPES_00002"));
                }
                if (DataCheckHelper.IsNull(info.Slug)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00015", i, "E_MSG_00001", "P_CM_00027"));
                }
                // Trường hợp lỗi thì đi đến record tiếp theo
                if (flagError) {
                    // Tăng giá trị i
                    i++;
                    // Đi đến record tiếp theo
                    continue;
                }
                // Kiểm tra dữ liệu tồn tại
                var isExist = masterDataCom.IsExistTourType(
                    info.LocaleCd, info.TypeCd, true);
                if (!isExist) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00015", i, "E_MSG_00016", "ADM_MA_TOURTYPES_00004"));
                }
                // Trường hợp lỗi thì đi đến record tiếp theo
                if (flagError) {
                    // Tăng giá trị i
                    i++;
                    // Đi đến record tiếp theo
                    continue;
                }
                // Kiểm tra giá trị duy nhất
                var isUnique = masterDataCom.IsUniqueTourType(info.TypeCd, info.Slug);
                var comparer = new KeyEqualityComparer<TourTypeObject>((k1, k2) =>
                        k1.TypeCd != k2.TypeCd
                        && k1.Slug == k2.Slug
                );
                if (!isUnique || inputObject.ListData.Contains(info, comparer)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00015", i, "E_MSG_00017", "P_CM_00027"));
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
        private SaveBatchDataModel SaveInfo(SaveBatchDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var saveResult = new SaveBatchDataModel();
            var processDao = new MasterTourTypesDao();
            var localeCom = new LocaleCom();
            var listUpdate = DataHelper.CreateList<TourTypeObject>();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, saveResult);
            // Lấy ngôn ngữ chuẩn
            var basicLocale = localeCom.GetDefault(DataComLogics.CD_APP_CD_CLN);
            // Lấy danh sách thông tin locale chuẩn
            var listBasicLocale = inputObject.ListData.Where(o => o.LocaleCd == basicLocale);
            // Duyệt danh sách thông tin locale chuẩn
            foreach (var info in listBasicLocale) {
                // Thêm vào danh sách cập nhật
                listUpdate.Add(info);
                // Lấy danh sách locale
                var listLocaleDb = processDao.GetListOtherLocale(basicLocale, info.TypeCd);
                // Duyệt danh sách locale
                foreach (var other in listLocaleDb) {
                    // Gán dữ liệu cập nhật
                    other.TypeCd = info.TypeCd;
                    other.Slug = info.Slug;
                    other.FileCd = info.FileCd;
                    other.SortKey = info.SortKey;
                    other.DeleteFlag = info.DeleteFlag;
                    // Thêm vào danh sách cập nhật
                    listUpdate.Add(other);
                }
            }
            // Lấy danh sách thông tin locale
            var listOtherLocale = inputObject.ListData.Where(o => o.LocaleCd != basicLocale);
            // Khởi tạo comparer
            var comparer = new KeyEqualityComparer<TourTypeObject>((k1, k2) =>
                k1.TypeCd == k2.TypeCd
                && k1.LocaleCd == k2.LocaleCd
            );
            // Duyệt danh sách thông tin locale
            foreach (var info in listOtherLocale) {
                if (listUpdate.Contains(info, comparer)) {
                    // Lấy thông tin cập nhật
                    var updateObj = listUpdate.Single(o =>
                            o.LocaleCd == info.LocaleCd
                            && o.TypeCd == info.TypeCd);
                    var idxObj = listUpdate.IndexOf(updateObj);
                    // Gán dữ liệu cập nhật
                    listUpdate[idxObj].TypeName = info.TypeName;
                    listUpdate[idxObj].SearchName = info.SearchName;
                } else {
                    // Thêm vào danh sách cập nhật
                    listUpdate.Add(info);
                }
            }
            // Xử lý tạo transaction
            var transaction = processDao.CreateTransaction();
            // Duyệt danh sách dữ liệu
            foreach (var info in listUpdate) {
                // Xử lý update đối tượng dữ liệu
                processDao.Update(info, transaction);
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