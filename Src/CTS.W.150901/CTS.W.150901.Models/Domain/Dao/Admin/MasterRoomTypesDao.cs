using System;
using System.Collections.Generic;
using System.Data.Common;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Core.Domain.Dao;
using CTS.W._150901.Models.Domain.Common.Dao;
using CTS.W._150901.Models.Domain.Model.Admin.Master.RoomTypes.List;
using CTS.W._150901.Models.Domain.Object.Admin.Master;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Dao.Admin
{
    /// <summary>
    /// MasterRoomTypesDao
    /// </summary>
    public class MasterRoomTypesDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERROOMTYPESDAO_GETPAGERDATA_SQL = "MasterRoomTypesDao_GetPagerData.sql";
        public const string MASTERROOMTYPESDAO_GETLISTLOCALE_SQL = "MasterRoomTypesDao_GetListLocale.sql";
        public const string MASTERROOMTYPESDAO_GETLISTOTHERLOCALE_SQL = "MasterRoomTypesDao_GetListOtherLocale.sql";
        public const string MASTERROOMTYPESDAO_INSERT_SQL = "MasterRoomTypesDao_Insert.sql";
        public const string MASTERROOMTYPESDAO_UPDATE_SQL = "MasterRoomTypesDao_Update.sql";

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        public PagerInfoModel<RoomTypeObject> GetPagerData(FilterDataModel inputObject) {
            // Tạo tham số
            var param = new {
                ContextLocale = WebContextHelper.LocaleCd,
                LocaleCd = inputObject.LocaleCd,
                TypeName = inputObject.TypeName,
                Slug = inputObject.Slug,
                DeleteFlag = inputObject.DeleteFlag,
                GrpCdLocales = DataComLogics.GRPCD_CLN_LOCALES,
                GrpCdDeleteFlag = DataComLogics.GRPCD_DELETE_FLAG
            };
            // Tạo đối tượng pager
            var pagerInfo = new PagerInfoModel<RoomTypeObject>();
            // Sao chép thông tin pager
            DataHelper.CopyPagerInfo(inputObject, pagerInfo);
            // Gán tham số
            pagerInfo.Critial = param;
            // Kết quả trả về
            return GetPagerByFile<RoomTypeObject>(MASTERROOMTYPESDAO_GETPAGERDATA_SQL, pagerInfo);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<RoomTypeObject> GetListLocale(string typeCd) {
            // Tạo tham số
            var param = new {
                TypeCd = typeCd
            };
            // Kết quả trả về
            return GetListByFile<RoomTypeObject>(MASTERROOMTYPESDAO_GETLISTLOCALE_SQL, param);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<RoomTypeObject> GetListOtherLocale(string localeCd, string typeCd) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                TypeCd = typeCd
            };
            // Kết quả trả về
            return GetListByFile<RoomTypeObject>(MASTERROOMTYPESDAO_GETLISTOTHERLOCALE_SQL, param);
        }

        /// <summary>
        /// Thêm thông tin dữ liệu
        /// </summary>
        public int Insert(RoomTypeObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var insertObj = new {
                LocaleCd = param.LocaleCd,
                TypeCd = param.TypeCd,
                TypeName = param.TypeName,
                SearchName = param.SearchName,
                Slug = param.Slug,
                Price = param.Price,
                AdultPerRoom = param.AdultPerRoom,
                FileCd = param.FileCd,
                Notes = string.Empty,
                SortKey = param.SortKey,
                CreateUser = WebContextHelper.UserName,
                CreateDate = sysDate,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERROOMTYPESDAO_INSERT_SQL, insertObj, transaction);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu
        /// </summary>
        public int Update(RoomTypeObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                TypeCd = param.TypeCd,
                TypeName = param.TypeName,
                SearchName = param.SearchName,
                Slug = param.Slug,
                Price = param.Price,
                AdultPerRoom = param.AdultPerRoom,
                FileCd = param.FileCd,
                SortKey = param.SortKey,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERROOMTYPESDAO_UPDATE_SQL, updateObj, transaction);
        }
    }
}