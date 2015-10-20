using System;
using System.Collections.Generic;
using System.Data.Common;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Com.Domain.Utils;
using CTS.Data.Core.Domain.Dao;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.W._150901.Models.Domain.Common.Dao;
using CTS.W._150901.Models.Domain.Model.Admin.Master.Tours.List;
using CTS.W._150901.Models.Domain.Object.Admin.Master;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Dao.Admin
{
    /// <summary>
    /// MasterToursDao
    /// </summary>
    public class MasterToursDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERTOURSDAO_GETPAGERDATA_SQL = "MasterToursDao_GetPagerData.sql";
        public const string MASTERTOURSDAO_GETLISTLOCALE_SQL = "MasterToursDao_GetListLocale.sql";
        public const string MASTERTOURSDAO_GETLISTOTHERLOCALE_SQL = "MasterToursDao_GetListOtherLocale.sql";
        public const string MASTERTOURSDAO_INSERT_SQL = "MasterToursDao_Insert.sql";
        public const string MASTERTOURSDAO_INSERTMETA_SQL = "MasterToursDao_InsertMeta.sql";
        public const string MASTERTOURSDAO_UPDATE_SQL = "MasterToursDao_Update.sql";
        public const string MASTERTOURSDAO_UPDATEMETA_SQL = "MasterToursDao_UpdateMeta.sql";

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        public PagerInfoModel<TourObject> GetPagerData(FilterDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var localeCom = new LocaleCom();
            // Lấy ngôn ngữ chuẩn
            var basicLocale = localeCom.GetDefault(DataComLogics.CD_APP_CD_CLN);
            // Tạo tham số
            var param = new {
                ContextLocale = WebContextHelper.LocaleCd,
                BasicLocale = basicLocale,
                LocaleCd = inputObject.LocaleCd,
                TourName = inputObject.TourName,
                Slug = inputObject.Slug,
                DeleteFlag = inputObject.DeleteFlag,
                GrpCdLocales = DataComLogics.GRPCD_CLN_LOCALES,
                GrpCdDeleteFlag = DataComLogics.GRPCD_DELETE_FLAG,
                GrpMetaMaTours = W150901Logics.GRPMETA_MA_TOURS
            };
            // Tạo đối tượng pager
            var pagerInfo = new PagerInfoModel<TourObject>();
            // Sao chép thông tin pager
            DataHelper.CopyPagerInfo(inputObject, pagerInfo);
            // Gán tham số
            pagerInfo.Critial = param;
            // Kết quả trả về
            return GetPagerByFile<TourObject>(MASTERTOURSDAO_GETPAGERDATA_SQL, pagerInfo);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<TourObject> GetListLocale(string tourCd) {
            // Tạo tham số
            var param = new {
                TourCd = tourCd
            };
            // Kết quả trả về
            return GetListByFile<TourObject>(MASTERTOURSDAO_GETLISTLOCALE_SQL, param);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<TourObject> GetListOtherLocale(string localeCd, string tourCd) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                TourCd = tourCd
            };
            // Kết quả trả về
            return GetListByFile<TourObject>(MASTERTOURSDAO_GETLISTOTHERLOCALE_SQL, param);
        }

        /// <summary>
        /// Thêm thông tin dữ liệu
        /// </summary>
        public int Insert(TourObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var insertObj = new {
                LocaleCd = param.LocaleCd,
                TourCd = param.TourCd,
                TourName = param.TourName,
                SearchName = param.SearchName,
                Slug = param.Slug,
                FileCd = param.FileCd,
                Summary = param.Summary,
                Notes = param.Notes,
                SortKey = param.SortKey,
                CreateUser = WebContextHelper.UserName,
                CreateDate = sysDate,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERTOURSDAO_INSERT_SQL, insertObj, transaction);
        }

        /// <summary>
        /// Thêm thông tin dữ liệu meta
        /// </summary>
        public int InsertMeta(TourObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var insertObj = new {
                LocaleCd = param.LocaleCd,
                GroupCd = W150901Logics.GRPMETA_MA_TOURS,
                MetaCd = param.TourCd,
                MetaName = param.TourName,
                MetaTitle = param.MetaTitle,
                MetaDesc = param.MetaDesc,
                MetaKeys = param.MetaKeys,
                Notes = string.Empty,
                SortKey = decimal.Zero,
                CreateUser = WebContextHelper.UserName,
                CreateDate = sysDate,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERTOURSDAO_INSERTMETA_SQL, insertObj, transaction);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu
        /// </summary>
        public int Update(TourObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                TourCd = param.TourCd,
                TourName = param.TourName,
                SearchName = param.SearchName,
                Slug = param.Slug,
                FileCd = param.FileCd,
                Summary = param.Summary,
                Notes = param.Notes,
                SortKey = param.SortKey,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERTOURSDAO_UPDATE_SQL, updateObj, transaction);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu meta
        /// </summary>
        public int UpdateMeta(TourObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                GroupCd = W150901Logics.GRPMETA_MA_TOURS,
                MetaCd = param.TourCd,
                MetaTitle = param.MetaTitle,
                MetaDesc = param.MetaDesc,
                MetaKeys = param.MetaKeys,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERTOURSDAO_UPDATEMETA_SQL, updateObj, transaction);
        }
    }
}