using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150901.Models.Domain.Common.Dao;
using CTS.Data.Core.Domain.Dao;
using CTS.W._150901.Models.Domain.Object.Client.Main;
using CTS.W._150901.Models.Domain.Object.Client.Tour;
using CTS.W._150901.Models.Domain.Object.Client.Page;
using CTS.W._150901.Models.Domain.Object.Client.Room;
using CTS.W._150901.Models.Domain.Object.Client.Service;

namespace CTS.W._150901.Models.Domain.Dao.Client
{
    public class MainDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MAINDAO_GETLISTBANNERS_SQL = "MainDao_GetListBanners.sql";
        public const string MAINDAO_GETLISTTOURSTYPE_SQL = "MainDao_GetListToursType.sql";
        public const string MAINDAO_GETLISTTOURSBYTYPE_SQL = "MainDao_GetListToursByType.sql";
        public const string MAINDAO_GETTOURDETAIL_SQL = "MainDao_GetTourDetail.sql";
        public const string MAINDAO_GETPAGE_SQL = "MainDao_GetPage.sql";
        public const string MAINDAO_GETLISTROOMSTYPE_SQL = "MainDao_GetListRoomsType.sql";
        public const string MAINDAO_GETLISTSERVICES_SQL = "MainDao_GetListServices.sql";
        
        
        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<BannerObject> GetListBanners(String localeCd)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd
            };
            // Kết quả trả về
            return GetListByFile<BannerObject>(MAINDAO_GETLISTBANNERS_SQL, param);
        }
        public IList<TourObject> GetListToursType(String localeCd)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd
            };
            // Kết quả trả về
            return GetListByFile<TourObject>(MAINDAO_GETLISTTOURSTYPE_SQL, param);
        }
        public IList<TourDetailObject> GetListToursByType(String localeCd, String tourTypeCd)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd,
                TypeCd = tourTypeCd
            };
            // Kết quả trả về
            return GetListByFile<TourDetailObject>(MAINDAO_GETLISTTOURSBYTYPE_SQL, param);
        }
        public TourDetailObject GetTourDetail(String localeCd, String slug)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd,
                Slug = slug
            };
            // Kết quả trả về
            return GetObjectByFile<TourDetailObject>(MAINDAO_GETTOURDETAIL_SQL, param);
        }
        public PageObject GetPage(String localeCd, String slug)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd,
                Slug = slug
            };
            // Kết quả trả về
            return GetObjectByFile<PageObject>(MAINDAO_GETPAGE_SQL, param);
        }
        public IList<RoomObject> GetListRoomsType(String localeCd)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd
            };
            // Kết quả trả về
            return GetListByFile<RoomObject>(MAINDAO_GETLISTROOMSTYPE_SQL, param);
        }
        public IList<ServiceObject> GetListServices(String localeCd)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd
            };
            // Kết quả trả về
            return GetListByFile<ServiceObject>(MAINDAO_GETLISTSERVICES_SQL, param);
        }
    }
}
