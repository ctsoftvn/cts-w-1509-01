using System;
using System.Collections.Generic;
using System.Data.Common;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Core.Domain.Dao;
using CTS.W._150901.Models.Domain.Common.Dao;
using CTS.W._150901.Models.Domain.Model.Admin.Master.Accoms.List;
using CTS.W._150901.Models.Domain.Object.Admin.Master;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Dao.Admin
{
    /// <summary>
    /// MasterRoomTypesDao
    /// </summary>
    public class MasterAccomsDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERACCOMSDAO_GETPAGERDATA_SQL = "MasterAccomsDao_GetPagerData.sql";
        public const string MASTERACCOMSDAO_GETLISTLOCALE_SQL = "MasterAccomsDao_GetListLocale.sql";
        public const string MASTERACCOMSDAO_GETLISTOTHERLOCALE_SQL = "MasterAccomsDao_GetListOtherLocale.sql";
        public const string MASTERACCOMSDAO_INSERT_SQL = "MasterAccomsDao_Insert.sql";
        public const string MASTERACCOMSDAO_UPDATE_SQL = "MasterAccomsDao_Update.sql";

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        public PagerInfoModel<AccomObject> GetPagerData(FilterDataModel inputObject) {
            // Tạo tham số
            var param = new {
                ContextLocale = WebContextHelper.LocaleCd,
                LocaleCd = inputObject.LocaleCd,
                AccomName = inputObject.AccomName,
                Slug = string.Empty, // inputObject.Slug,
                DeleteFlag = inputObject.DeleteFlag,
                GrpCdLocales = DataComLogics.GRPCD_CLN_LOCALES,
                GrpCdDeleteFlag = DataComLogics.GRPCD_DELETE_FLAG
            };
            // Tạo đối tượng pager
            var pagerInfo = new PagerInfoModel<AccomObject>();
            // Sao chép thông tin pager
            DataHelper.CopyPagerInfo(inputObject, pagerInfo);
            // Gán tham số
            pagerInfo.Critial = param;
            // Kết quả trả về
            return GetPagerByFile<AccomObject>(MASTERACCOMSDAO_GETPAGERDATA_SQL, pagerInfo);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<AccomObject> GetListLocale(string accomCd) {
            // Tạo tham số
            var param = new {
                AccomCd = accomCd
            };
            // Kết quả trả về
            return GetListByFile<AccomObject>(MASTERACCOMSDAO_GETLISTLOCALE_SQL, param);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<AccomObject> GetListOtherLocale(string localeCd, string accomCd) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                AccomCd = accomCd
            };
            // Kết quả trả về
            return GetListByFile<AccomObject>(MASTERACCOMSDAO_GETLISTOTHERLOCALE_SQL, param);
        }

        /// <summary>
        /// Thêm thông tin dữ liệu
        /// </summary>
        public int Insert(AccomObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var insertObj = new {
                LocaleCd = param.LocaleCd,
                AccomCd = param.AccomCd,
                AccomName = param.AccomName,
                SearchName = param.SearchName,
                Slug = string.Empty, // param.Slug,
                FileCd = param.FileCd,
                Notes = param.Notes,
                SortKey = param.SortKey,
                CreateUser = WebContextHelper.UserName,
                CreateDate = sysDate,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERACCOMSDAO_INSERT_SQL, insertObj, transaction);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu
        /// </summary>
        public int Update(AccomObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                AccomCd = param.AccomCd,
                AccomName = param.AccomName,
                SearchName = param.SearchName,
                Slug = string.Empty, // param.Slug,
                FileCd = param.FileCd,
                Notes = param.Notes,
                SortKey = param.SortKey,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERACCOMSDAO_UPDATE_SQL, updateObj, transaction);
        }
    }
}