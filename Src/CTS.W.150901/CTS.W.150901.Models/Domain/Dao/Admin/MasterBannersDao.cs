using System;
using System.Collections.Generic;
using System.Data.Common;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Core.Domain.Dao;
using CTS.W._150901.Models.Domain.Common.Dao;
using CTS.W._150901.Models.Domain.Model.Admin.Master.Banners.List;
using CTS.W._150901.Models.Domain.Object.Admin.Master;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Dao.Admin
{
    /// <summary>
    /// MasterBannersDao
    /// </summary>
    public class MasterBannersDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERBANNERSDAO_GETPAGERDATA_SQL = "MasterBannersDao_GetPagerData.sql";
        public const string MASTERBANNERSDAO_GETLISTLOCALE_SQL = "MasterBannersDao_GetListLocale.sql";
        public const string MASTERBANNERSDAO_GETLISTOTHERLOCALE_SQL = "MasterBannersDao_GetListOtherLocale.sql";
        public const string MASTERBANNERSDAO_INSERT_SQL = "MasterBannersDao_Insert.sql";
        public const string MASTERBANNERSDAO_UPDATE_SQL = "MasterBannersDao_Update.sql";

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        public PagerInfoModel<BannerObject> GetPagerData(FilterDataModel inputObject) {
            // Tạo tham số
            var param = new {
                ContextLocale = WebContextHelper.LocaleCd,
                LocaleCd = inputObject.LocaleCd,
                BannerName = inputObject.BannerName,
                DeleteFlag = inputObject.DeleteFlag,
                GrpCdLocales = DataComLogics.GRPCD_CLN_LOCALES,
                GrpCdDeleteFlag = DataComLogics.GRPCD_DELETE_FLAG
            };
            // Tạo đối tượng pager
            var pagerInfo = new PagerInfoModel<BannerObject>();
            // Sao chép thông tin pager
            DataHelper.CopyPagerInfo(inputObject, pagerInfo);
            // Gán tham số
            pagerInfo.Critial = param;
            // Kết quả trả về
            return GetPagerByFile<BannerObject>(MASTERBANNERSDAO_GETPAGERDATA_SQL, pagerInfo);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<BannerObject> GetListLocale(string bannerCd) {
            // Tạo tham số
            var param = new {
                BannerCd = bannerCd
            };
            // Kết quả trả về
            return GetListByFile<BannerObject>(MASTERBANNERSDAO_GETLISTLOCALE_SQL, param);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<BannerObject> GetListOtherLocale(string localeCd, string bannerCd) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                BannerCd = bannerCd
            };
            // Kết quả trả về
            return GetListByFile<BannerObject>(MASTERBANNERSDAO_GETLISTOTHERLOCALE_SQL, param);
        }

        /// <summary>
        /// Thêm thông tin dữ liệu
        /// </summary>
        public int Insert(BannerObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var insertObj = new {
                LocaleCd = param.LocaleCd,
                BannerCd = param.BannerCd,
                BannerName = param.BannerName,
                SearchName = param.SearchName,
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
            return UpdateByFile(MASTERBANNERSDAO_INSERT_SQL, insertObj, transaction);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu
        /// </summary>
        public int Update(BannerObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                BannerCd = param.BannerCd,
                BannerName = param.BannerName,
                SearchName = param.SearchName,
                FileCd = param.FileCd,
                Notes = param.Notes,
                SortKey = param.SortKey,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERBANNERSDAO_UPDATE_SQL, updateObj, transaction);
        }
    }
}
