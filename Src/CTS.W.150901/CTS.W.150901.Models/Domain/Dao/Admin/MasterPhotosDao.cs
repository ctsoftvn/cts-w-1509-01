using System;
using System.Collections.Generic;
using System.Data.Common;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Core.Domain.Dao;
using CTS.W._150901.Models.Domain.Common.Dao;
using CTS.W._150901.Models.Domain.Model.Admin.Master.Photos.List;
using CTS.W._150901.Models.Domain.Object.Admin.Master;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Dao.Admin
{
    /// <summary>
    /// MasterPhotosDao
    /// </summary>
    public class MasterPhotosDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERPHOTOSDAO_GETPAGERDATA_SQL = "MasterPhotosDao_GetPagerData.sql";
        public const string MASTERPHOTOSDAO_GETLISTLOCALE_SQL = "MasterPhotosDao_GetListLocale.sql";
        public const string MASTERPHOTOSDAO_GETLISTOTHERLOCALE_SQL = "MasterPhotosDao_GetListOtherLocale.sql";
        public const string MASTERPHOTOSDAO_INSERT_SQL = "MasterPhotosDao_Insert.sql";
        public const string MASTERPHOTOSDAO_UPDATE_SQL = "MasterPhotosDao_Update.sql";

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        public PagerInfoModel<PhotoObject> GetPagerData(FilterDataModel inputObject) {
            // Tạo tham số
            var param = new {
                ContextLocale = WebContextHelper.LocaleCd,
                LocaleCd = inputObject.LocaleCd,
                PhotoName = inputObject.PhotoName,
                DeleteFlag = inputObject.DeleteFlag,
                GrpCdLocales = DataComLogics.GRPCD_CLN_LOCALES,
                GrpCdDeleteFlag = DataComLogics.GRPCD_DELETE_FLAG
            };
            // Tạo đối tượng pager
            var pagerInfo = new PagerInfoModel<PhotoObject>();
            // Sao chép thông tin pager
            DataHelper.CopyPagerInfo(inputObject, pagerInfo);
            // Gán tham số
            pagerInfo.Critial = param;
            // Kết quả trả về
            return GetPagerByFile<PhotoObject>(MASTERPHOTOSDAO_GETPAGERDATA_SQL, pagerInfo);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<PhotoObject> GetListLocale(string photoCd) {
            // Tạo tham số
            var param = new {
                PhotoCd = photoCd
            };
            // Kết quả trả về
            return GetListByFile<PhotoObject>(MASTERPHOTOSDAO_GETLISTLOCALE_SQL, param);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<PhotoObject> GetListOtherLocale(string localeCd, string photoCd) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                PhotoCd = photoCd
            };
            // Kết quả trả về
            return GetListByFile<PhotoObject>(MASTERPHOTOSDAO_GETLISTOTHERLOCALE_SQL, param);
        }

        /// <summary>
        /// Thêm thông tin dữ liệu
        /// </summary>
        public int Insert(PhotoObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var insertObj = new {
                LocaleCd = param.LocaleCd,
                PhotoCd = param.PhotoCd,
                PhotoName = param.PhotoName,
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
            return UpdateByFile(MASTERPHOTOSDAO_INSERT_SQL, insertObj, transaction);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu
        /// </summary>
        public int Update(PhotoObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                PhotoCd = param.PhotoCd,
                PhotoName = param.PhotoName,
                SearchName = param.SearchName,
                FileCd = param.FileCd,
                Notes = param.Notes,
                SortKey = param.SortKey,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERPHOTOSDAO_UPDATE_SQL, updateObj, transaction);
        }
    }
}