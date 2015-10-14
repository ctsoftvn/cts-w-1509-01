using CTS.Core.Domain.Exceptions;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Com.Domain.Utils;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.W._150901.Models.Domain.Common.Utils;
using CTS.W._150901.Models.Domain.Dao.Admin;
using CTS.W._150901.Models.Domain.Model.Admin.Master.Tours.Entry;
using CTS.W._150901.Models.Domain.Object.Admin.Master;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Logic.Admin.Master.Tours.Entry
{
    /// <summary>
    /// InitLogic
    /// </summary>
    public class InitLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý init.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public InitDataModel Execute(InitDataModel inputObject) {
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
        private void Check(InitDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var masterDataCom = new MasterDataCom();
            var localeCom = new LocaleCom();
            var msgs = DataHelper.CreateList<Message>();
            // Lấy ngôn ngữ chuẩn
            var basicLocale = localeCom.GetDefault(DataComLogics.CD_APP_CD_CLN);
            // Trường hợp status là edit
            if (inputObject.IsEdit) {
                if (DataCheckHelper.IsNull(inputObject.TourCd)) {
                    msgs.Add(MessageHelper.GetMessage(
                        "E_MSG_00013", "ADM_MA_TOURS_00001"));
                }
                // Kiểm tra danh sách lỗi
                if (!DataCheckHelper.IsNull(msgs)) {
                    throw new ExecuteException(msgs);
                }
                // Khởi tạo biến cục bộ
                var metaCom = new MetaCom();
                // Kiểm tra dữ liệu tồn tại
                var isExist = masterDataCom.IsExistTour(
                    basicLocale, inputObject.TourCd, true);
                var isExistMeta = metaCom.IsExist(
                    basicLocale, W150901Logics.GRPMETA_MA_TOURS, inputObject.TourCd, true);
                if (!isExist || !isExistMeta) {
                    msgs.Add(MessageHelper.GetMessage(
                        "E_MSG_00016", "ADM_MA_TOURS_00005"));
                }
                // Kiểm tra danh sách lỗi
                if (!DataCheckHelper.IsNull(msgs)) {
                    throw new ExecuteException(msgs);
                }
            }
        }

        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private InitDataModel GetInfo(InitDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var getResult = new InitDataModel();
            var processDao = new MasterToursDao();
            var masterDataCom = new MasterDataCom();
            var localeCom = new LocaleCom();
            var codeCom = new CodeCom();
            var localeModel = new LocaleModel<TourObject>();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy ngôn ngữ chuẩn
            var basicLocale = localeCom.GetDefault(DataComLogics.CD_APP_CD_CLN);
            // Trường hợp status là edit hoặc copy
            if (inputObject.IsEdit || inputObject.IsCopy) {
                // Khởi tạo biến cục bộ
                var metaCom = new MetaCom();
                var listData = DataHelper.CreateList<TourObject>();
                // Lấy danh sách dữ liệu đa ngôn ngữ
                var listLocale = processDao.GetListLocale(inputObject.TourCd);
                // Khởi tạo biến dùng trong loop
                var rowNo = 0;
                var localeName = string.Empty;
                // Duyệt danh sách dữ liệu đa ngôn ngữ
                foreach (var info in listLocale) {
                    // Lấy thông tin tên
                    localeName = codeCom.GetName(
                        WebContextHelper.LocaleCd, DataComLogics.GRPCD_CLN_LOCALES, info.LocaleCd, false);
                    // Lấy thông tin meta
                    var metaInfo = metaCom.GetInfo(
                        info.LocaleCd, W150901Logics.GRPMETA_MA_TOURS, info.TourCd, true);
                    // Lấy số dòng
                    if (info.LocaleCd != basicLocale) {
                        info.RowNo = rowNo++;
                    }
                    // Gán thông tin dữ liệu
                    info.LocaleName = localeName;
                    info.MetaTitle = metaInfo.MetaTitle;
                    info.MetaDesc = metaInfo.MetaDesc;
                    info.MetaKeys = metaInfo.MetaKeys;
                    // Xóa thông tin khi sao chép
                    if (inputObject.IsCopy) {
                        info.TourName = string.Empty;
                        info.SearchName = string.Empty;
                    }
                    // Thêm vào danh sách kết quả
                    listData.Add(info);
                }
                // Tiến hành convert đối tượng locale
                localeModel = DataHelper.ToLocaleModel(basicLocale, listData);
            }
            // Khởi tạo giá trị init
            if (inputObject.IsAdd) {
                localeModel.DataInfo.TourCd = DataHelper.GetUniqueKey();
                localeModel.DataInfo.TourName = string.Empty;
                localeModel.DataInfo.SearchName = string.Empty;
                localeModel.DataInfo.Slug = string.Empty;
                localeModel.DataInfo.TourTypeCd = string.Empty;
                localeModel.DataInfo.LocaleCd = basicLocale;
                localeModel.DataInfo.SortKey = decimal.One;
                localeModel.DataInfo.DeleteFlag = false;
                if (inputObject.IsAddInit) {
                    localeModel.ListLocale.Clear();
                }
            }
            // Lấy danh sách code
            var listLocales = codeCom.GetDiv(
                WebContextHelper.LocaleCd, DataComLogics.GRPCD_CLN_LOCALES, basicLocale, false, false);
            var listTourTypes = masterDataCom.GetDivTourType(
                basicLocale, null, false, false);
            var listDeleteFlag = codeCom.GetDivDeleteFlag(WebContextHelper.LocaleCd, false);
            // Lấy giá trị combo
            var cbLocales = DataHelper.ToComboItems(listLocales, string.Empty);
            var cbTourTypes = DataHelper.ToComboItems(
                listTourTypes, localeModel.DataInfo.TourTypeCd);
            var cbDeleteFlag = DataHelper.ToComboItems(
                listDeleteFlag, localeModel.DataInfo.DeleteFlag);
            // Gán giá trị trả về
            getResult.BasicLocale = basicLocale;
            getResult.LocaleModel = localeModel;
            getResult.CboLocales = cbLocales.ListItems;
            getResult.CboLocalesSeleted = cbLocales.SeletedValue;
            getResult.CboTourTypes = cbTourTypes.ListItems;
            getResult.LocaleModel.DataInfo.TourTypeCd = cbTourTypes.SeletedValue;
            getResult.CboDeleteFlag = cbDeleteFlag.ListItems;
            getResult.LocaleModel.DataInfo.DeleteFlag = cbDeleteFlag.SeletedValueBoolean;
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}