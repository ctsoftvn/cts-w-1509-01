using System.Linq;
using CTS.Core.Domain.Exceptions;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Core.Domain.Utils;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Com.Domain.Utils;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.W._150901.Models.Domain.Common.Utils;
using CTS.W._150901.Models.Domain.Dao.Admin;
using CTS.W._150901.Models.Domain.Model.Admin.Master.Pages;
using CTS.W._150901.Models.Domain.Object.Admin.Master;

namespace CTS.W._150901.Models.Domain.Logic.Admin.Master.Pages
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
            var metaCom = new MetaCom();
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
                if (DataCheckHelper.IsNull(info.PageCd)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00015", i, "E_MSG_00001", "ADM_MA_PAGES_00001"));
                }
                if (DataCheckHelper.IsNull(info.PageName)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00015", i, "E_MSG_00001", "ADM_MA_PAGES_00002"));
                }
                // if (DataCheckHelper.IsNull(info.Slug)) {
                //     flagError = true;
                //     msgs.Add(MessageHelper.GetMessageForList(
                //         "P_CM_00015", i, "E_MSG_00001", "P_CM_00027"));
                // }
                // Trường hợp lỗi thì đi đến record tiếp theo
                if (flagError) {
                    // Tăng giá trị i
                    i++;
                    // Đi đến record tiếp theo
                    continue;
                }
                // Kiểm tra dữ liệu tồn tại
                var isExist = masterDataCom.IsExistPage(
                    info.LocaleCd, info.PageCd, true);
                var isExistMeta = metaCom.IsExist(
                    info.LocaleCd, W150901Logics.GRPMETA_MA_PAGES, info.PageCd, true);
                if (!isExist || !isExistMeta) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "P_CM_00015", i, "E_MSG_00016", "ADM_MA_PAGES_00004"));
                }
                // Trường hợp lỗi thì đi đến record tiếp theo
                if (flagError) {
                    // Tăng giá trị i
                    i++;
                    // Đi đến record tiếp theo
                    continue;
                }
                // // Kiểm tra giá trị duy nhất
                // var isUnique = masterDataCom.IsUniquePage(info.PageCd, info.Slug);
                // var comparer = new KeyEqualityComparer<PageObject>((k1, k2) =>
                //         k1.PageCd != k2.PageCd
                //         && k1.Slug == k2.Slug
                // );
                // if (!isUnique || inputObject.ListData.Contains(info, comparer)) {
                //     flagError = true;
                //     msgs.Add(MessageHelper.GetMessageForList(
                //         "P_CM_00015", i, "E_MSG_00017", "P_CM_00027"));
                // }
                // // Trường hợp lỗi thì đi đến record tiếp theo
                // if (flagError) {
                //     // Tăng giá trị i
                //     i++;
                //     // Đi đến record tiếp theo
                //     continue;
                // }
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
            var processDao = new MasterPagesDao();
            var localeCom = new LocaleCom();
            var listUpdate = DataHelper.CreateList<PageObject>();
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
                var listLocaleDb = processDao.GetListOtherLocale(basicLocale, info.PageCd);
                // Duyệt danh sách locale
                foreach (var other in listLocaleDb) {
                    // Gán dữ liệu cập nhật
                    other.PageCd = info.PageCd;
                    // other.Slug = info.Slug;
                    // Thêm vào danh sách cập nhật
                    listUpdate.Add(other);
                }
            }
            // Lấy danh sách thông tin locale
            var listOtherLocale = inputObject.ListData.Where(o => o.LocaleCd != basicLocale);
            // Khởi tạo comparer
            var comparer = new KeyEqualityComparer<PageObject>((k1, k2) =>
                k1.PageCd == k2.PageCd
                && k1.LocaleCd == k2.LocaleCd
            );
            // Duyệt danh sách thông tin locale
            foreach (var info in listOtherLocale) {
                if (listUpdate.Contains(info, comparer)) {
                    // Lấy thông tin cập nhật
                    var updateObj = listUpdate.Single(o =>
                            o.LocaleCd == info.LocaleCd
                            && o.PageCd == info.PageCd);
                    var idxObj = listUpdate.IndexOf(updateObj);
                    // Gán dữ liệu cập nhật
                    listUpdate[idxObj].PageName = info.PageName;
                    listUpdate[idxObj].SearchName = info.SearchName;
                    listUpdate[idxObj].Notes = info.Notes;
                } else {
                    // Thêm vào danh sách cập nhật
                    listUpdate.Add(info);
                }
            }// Xử lý tạo transaction
            var transaction = processDao.CreateTransaction();
            // Duyệt danh sách dữ liệu
            foreach (var info in listUpdate) {
                // Xử lý update đối tượng dữ liệu
                processDao.Update(info, transaction);
            }
            // Duyệt danh sách dữ liệu
            foreach (var info in inputObject.ListData) {
                // Xử lý update đối tượng meta
                processDao.UpdateMeta(info, transaction);
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
