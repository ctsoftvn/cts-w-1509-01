using System.Collections.Generic;
using CTS.Core.Domain.Model;
using CTS.Data.Core.Domain.Dao;

namespace CTS.W._150901.Models.Domain.Common.Dao
{
    /// <summary>
    /// MasterDataComDao
    /// </summary>
    public class MasterDataComDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERDATACOMDAO_ISUNIQUEROOMTYPE_SQL = "MasterDataComDao_IsUniqueRoomType.sql";
        public const string MASTERDATACOMDAO_GETINFOROOMTYPE_SQL = "MasterDataComDao_GetInfoRoomType.sql";
        public const string MASTERDATACOMDAO_GETDIVROOMTYPE_SQL = "MasterDataComDao_GetDivRoomType.sql";
        public const string MASTERDATACOMDAO_ISUNIQUETOURTYPE_SQL = "MasterDataComDao_IsUniqueTourType.sql";
        public const string MASTERDATACOMDAO_GETINFOTOURTYPE_SQL = "MasterDataComDao_GetInfoTourType.sql";
        public const string MASTERDATACOMDAO_GETDIVTOURTYPE_SQL = "MasterDataComDao_GetDivTourType.sql";
        public const string MASTERDATACOMDAO_ISUNIQUETOUR_SQL = "MasterDataComDao_IsUniqueTour.sql";
        public const string MASTERDATACOMDAO_GETINFOTOUR_SQL = "MasterDataComDao_GetInfoTour.sql";
        public const string MASTERDATACOMDAO_ISUNIQUESERVICE_SQL = "MasterDataComDao_IsUniqueService.sql";
        public const string MASTERDATACOMDAO_GETINFOSERVICE_SQL = "MasterDataComDao_GetInfoService.sql";
        public const string MASTERDATACOMDAO_GETINFOBANNER_SQL = "MasterDataComDao_GetInfoBanner.sql";
        public const string MASTERDATACOMDAO_GETINFOPHOTO_SQL = "MasterDataComDao_GetInfoPhoto.sql";

        public const string MASTERDATACOMDAO_ISUNIQUEPAGE_SQL = "MasterDataComDao_IsUniquePage.sql";
        public const string MASTERDATACOMDAO_GETINFOPAGE_SQL = "MasterDataComDao_GetInfoPage.sql";

        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueRoomType(string typeCd, string slug) {
            // Tạo tham số
            var param = new {
                TypeCd = typeCd,
                Slug = slug
            };
            // Kết quả trả về
            var count = GetCountByFile(MASTERDATACOMDAO_ISUNIQUEROOMTYPE_SQL, param);
            // Kết quả trả về
            return count == 0;
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MARoomType GetInfoRoomType(string localeCd, string typeCd, bool ignoreDeleteFlag) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                TypeCd = typeCd,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetObjectByFile<MARoomType>(MASTERDATACOMDAO_GETINFOROOMTYPE_SQL, param);
        }

        /// <summary>
        /// Lấy danh sách code
        /// </summary>
        public IList<KeyValueObject> GetDivRoomType(string localeCd, string[] skipCodes, bool ignoreDeleteFlag) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                SkipCodes = skipCodes,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetListByFile<KeyValueObject>(MASTERDATACOMDAO_GETDIVROOMTYPE_SQL, param);
        }

        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueTourType(string typeCd, string slug) {
            // Tạo tham số
            var param = new {
                TypeCd = typeCd,
                Slug = slug
            };
            // Kết quả trả về
            var count = GetCountByFile(MASTERDATACOMDAO_ISUNIQUETOURTYPE_SQL, param);
            // Kết quả trả về
            return count == 0;
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MATourType GetInfoTourType(string localeCd, string typeCd, bool ignoreDeleteFlag) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                TypeCd = typeCd,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetObjectByFile<MATourType>(MASTERDATACOMDAO_GETINFOTOURTYPE_SQL, param);
        }

        /// <summary>
        /// Lấy danh sách code
        /// </summary>
        public IList<KeyValueObject> GetDivTourType(string localeCd, string[] skipCodes, bool ignoreDeleteFlag) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                SkipCodes = skipCodes,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetListByFile<KeyValueObject>(MASTERDATACOMDAO_GETDIVTOURTYPE_SQL, param);
        }

        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueTour(string tourCd, string slug) {
            // Tạo tham số
            var param = new {
                TourCd = tourCd,
                Slug = slug
            };
            // Kết quả trả về
            var count = GetCountByFile(MASTERDATACOMDAO_ISUNIQUETOUR_SQL, param);
            // Kết quả trả về
            return count == 0;
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MATour GetInfoTour(string localeCd, string tourCd, bool ignoreDeleteFlag) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                TourCd = tourCd,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetObjectByFile<MATour>(MASTERDATACOMDAO_GETINFOTOUR_SQL, param);
        }

        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueService(string serviceCd, string slug) {
            // Tạo tham số
            var param = new {
                ServiceCd = serviceCd,
                Slug = slug
            };
            // Kết quả trả về
            var count = GetCountByFile(MASTERDATACOMDAO_ISUNIQUESERVICE_SQL, param);
            // Kết quả trả về
            return count == 0;
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MAService GetInfoService(string localeCd, string serviceCd, bool ignoreDeleteFlag) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                ServiceCd = serviceCd,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetObjectByFile<MAService>(MASTERDATACOMDAO_GETINFOSERVICE_SQL, param);
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MABanner GetInfoBanner(string localeCd, string bannerCd, bool ignoreDeleteFlag) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                BannerCd = bannerCd,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetObjectByFile<MABanner>(MASTERDATACOMDAO_GETINFOBANNER_SQL, param);
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MAPhoto GetInfoPhoto(string localeCd, string photoCd, bool ignoreDeleteFlag) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                PhotoCd = photoCd,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetObjectByFile<MAPhoto>(MASTERDATACOMDAO_GETINFOPHOTO_SQL, param);
        }

        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniquePage(string pageCd, string slug) {
            // Tạo tham số
            var param = new {
                PageCd = pageCd,
                Slug = slug
            };
            // Kết quả trả về
            var count = GetCountByFile(MASTERDATACOMDAO_ISUNIQUEPAGE_SQL, param);
            // Kết quả trả về
            return count == 0;
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MAPage GetInfoPage(string localeCd, string pageCd, bool ignoreDeleteFlag) {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                PageCd = pageCd,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetObjectByFile<MAPage>(MASTERDATACOMDAO_GETINFOPAGE_SQL, param);
        }
    }
}