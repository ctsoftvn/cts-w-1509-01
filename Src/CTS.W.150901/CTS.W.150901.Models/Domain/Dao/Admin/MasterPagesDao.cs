using System;
using System.Collections.Generic;
using System.Data.Common;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Core.Domain.Dao;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.W._150901.Models.Domain.Common.Dao;
using CTS.W._150901.Models.Domain.Model.Admin.Master.Pages;
using CTS.W._150901.Models.Domain.Object.Admin.Master;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Dao.Admin
{
    /// <summary>
    /// MasterPagesDao
    /// </summary>
    public class MasterPagesDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERPAGESDAO_GETPAGERDATA_SQL = "MasterPagesDao_GetPagerData.sql";
        public const string MASTERPAGESDAO_GETLISTOTHERLOCALE_SQL = "MasterPagesDao_GetListOtherLocale.sql";
        public const string MASTERPAGESDAO_UPDATE_SQL = "MasterPagesDao_Update.sql";
        public const string MASTERPAGESDAO_UPDATEMETA_SQL = "MasterPagesDao_UpdateMeta.sql";

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        public PagerInfoModel<PageObject> GetPagerData(FilterDataModel inputObject) {
            // Tạo tham số
            var param = new {
                LocaleCd = inputObject.LocaleCd,
                ContextLocale = WebContextHelper.LocaleCd,
                GrpCdLocales = DataComLogics.GRPCD_CLN_LOCALES,
                GrpMetaMaPages = W150901Logics.GRPMETA_MA_PAGES
            };
            // Tạo đối tượng pager
            var pagerInfo = new PagerInfoModel<PageObject>();
            // Sao chép thông tin pager
            DataHelper.CopyPagerInfo(inputObject, pagerInfo);
            // Gán tham số
            pagerInfo.Critial = param;
            // Kết quả trả về
            return GetPagerByFile<PageObject>(MASTERPAGESDAO_GETPAGERDATA_SQL, pagerInfo);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<PageObject> GetListOtherLocale(string localeCd, string pageCd) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                PageCd = pageCd
            };
            // Kết quả trả về
            return GetListByFile<PageObject>(MASTERPAGESDAO_GETLISTOTHERLOCALE_SQL, param);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu
        /// </summary>
        public int Update(PageObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                PageCd = param.PageCd,
                PageName = param.PageName,
                SearchName = param.SearchName,
                // Slug = param.Slug,
                Content = param.Content,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERPAGESDAO_UPDATE_SQL, updateObj, transaction);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu meta
        /// </summary>
        public int UpdateMeta(PageObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                GroupCd = W150901Logics.GRPMETA_MA_PAGES,
                MetaCd = param.PageCd,
                MetaTitle = param.MetaTitle,
                MetaDesc = param.MetaDesc,
                MetaKeys = param.MetaKeys,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERPAGESDAO_UPDATEMETA_SQL, updateObj, transaction);
        }
    }
}