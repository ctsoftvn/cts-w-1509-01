﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Data.Com.Domain.Constants;
using CTS.Data.Core.Domain.Dao;
using CTS.W._150901.Models.Domain.Common.Dao;
using CTS.W._150901.Models.Domain.Model.Admin.Master.Services.List;
using CTS.W._150901.Models.Domain.Object.Admin.Master;
using CTS.Web.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Dao.Admin
{
    /// <summary>
    /// MasterRoomTypesDao
    /// </summary>
    public class MasterServicesDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERSERVICESDAO_GETPAGERDATA_SQL = "MasterServicesDao_GetPagerData.sql";
        public const string MASTERSERVICESDAO_GETLISTLOCALE_SQL = "MasterServicesDao_GetListLocale.sql";
        public const string MASTERSERVICESDAO_GETLISTOTHERLOCALE_SQL = "MasterServicesDao_GetListOtherLocale.sql";
        public const string MASTERSERVICESDAO_INSERT_SQL = "MasterServicesDao_Insert.sql";
        public const string MASTERSERVICESDAO_UPDATE_SQL = "MasterServicesDao_Update.sql";

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        public PagerInfoModel<ServiceObject> GetPagerData(FilterDataModel inputObject) {
            // Tạo tham số
            var param = new {
                ContextLocale = WebContextHelper.LocaleCd,
                LocaleCd = inputObject.LocaleCd,
                ServiceName = inputObject.ServiceName,
                Slug = string.Empty, // inputObject.Slug,
                DeleteFlag = inputObject.DeleteFlag,
                GrpCdLocales = DataComLogics.GRPCD_CLN_LOCALES,
                GrpCdDeleteFlag = DataComLogics.GRPCD_DELETE_FLAG
            };
            // Tạo đối tượng pager
            var pagerInfo = new PagerInfoModel<ServiceObject>();
            // Sao chép thông tin pager
            DataHelper.CopyPagerInfo(inputObject, pagerInfo);
            // Gán tham số
            pagerInfo.Critial = param;
            // Kết quả trả về
            return GetPagerByFile<ServiceObject>(MASTERSERVICESDAO_GETPAGERDATA_SQL, pagerInfo);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<ServiceObject> GetListLocale(string serviceCd) {
            // Tạo tham số
            var param = new {
                ServiceCd = serviceCd
            };
            // Kết quả trả về
            return GetListByFile<ServiceObject>(MASTERSERVICESDAO_GETLISTLOCALE_SQL, param);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<ServiceObject> GetListOtherLocale(string localeCd, string serviceCd) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                ServiceCd = serviceCd
            };
            // Kết quả trả về
            return GetListByFile<ServiceObject>(MASTERSERVICESDAO_GETLISTOTHERLOCALE_SQL, param);
        }

        /// <summary>
        /// Thêm thông tin dữ liệu
        /// </summary>
        public int Insert(ServiceObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var insertObj = new {
                LocaleCd = param.LocaleCd,
                ServiceCd = param.ServiceCd,
                ServiceName = param.ServiceName,
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
            return UpdateByFile(MASTERSERVICESDAO_INSERT_SQL, insertObj, transaction);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu
        /// </summary>
        public int Update(ServiceObject param, DbTransaction transaction) {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                ServiceCd = param.ServiceCd,
                ServiceName = param.ServiceName,
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
            return UpdateByFile(MASTERSERVICESDAO_UPDATE_SQL, updateObj, transaction);
        }
    }
}