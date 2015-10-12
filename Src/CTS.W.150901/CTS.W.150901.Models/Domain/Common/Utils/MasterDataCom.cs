using System.Collections.Generic;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.Data.Com.Domain.Constants;
using CTS.W._150901.Models.Domain.Common.Dao;

namespace CTS.W._150901.Models.Domain.Common.Utils
{
    /// <summary>
    /// MasterDataCom
    /// </summary>
    public class MasterDataCom
    {
        private readonly MasterDataComDao _comDao;
        public MasterDataCom() { _comDao = new MasterDataComDao(); }

        /// <summary>
        /// Kiểm tra dữ liệu tồn tại
        /// </summary>
        public bool IsExistRoomType(string localeCd, string typeCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(typeCd)) {
                return true;
            }
            // Lấy thông tin dữ liệu
            var dataInfo = GetInfoRoomType(localeCd, typeCd, ignoreDeleteFlag);
            // Kết quả trả về
            return dataInfo != null;
        }
        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueRoomType(string typeCd, string slug) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(typeCd)
                || DataCheckHelper.IsNull(slug)) {
                return true;
            }
            // Kết quả trả về
            return _comDao.IsUniqueRoomType(typeCd, slug);
        }
        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MARoomType GetInfoRoomType(string localeCd, string typeCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(typeCd)) {
                return null;
            }
            // Kết quả trả về
            return _comDao.GetInfoRoomType(localeCd, typeCd, ignoreDeleteFlag);
        }
        /// <summary>
        /// Lấy danh sách code
        /// </summary>
        public IList<KeyValueObject> GetDivRoomType(string localeCd, string skipCode, bool nullValue, bool ignoreDeleteFlag) {
            // Khởi tạo biến cục bộ
            var skipCodes = new string[0];
            var listResult = new List<KeyValueObject>();
            // Lấy danh sách skip code trong trường hợp skip code khác null
            if (skipCode != null) {
                skipCodes = skipCode.Split(DataComLogics.DELIMITER_SKIP_CODE);
            }
            // Tạo giá trị trắng trong trường hợp có thêm giá trị trắng
            if (nullValue) {
                listResult.Add(new KeyValueObject());
            }
            // Lấy danh sách code
            var listData = _comDao.GetDivRoomType(localeCd, skipCodes, ignoreDeleteFlag);
            // Thêm danh sách code vào danh sách kết quả
            listResult.AddRange(listData);
            // Kết quả trả về
            return listResult;
        }
        /// <summary>
        /// Kiểm tra dữ liệu tồn tại
        /// </summary>
        public bool IsExistTourType(string localeCd, string typeCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(typeCd)) {
                return true;
            }
            // Lấy thông tin dữ liệu
            var dataInfo = GetInfoTourType(localeCd, typeCd, ignoreDeleteFlag);
            // Kết quả trả về
            return dataInfo != null;
        }
        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueTourType(string typeCd, string slug) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(typeCd)
                || DataCheckHelper.IsNull(slug)) {
                return true;
            }
            // Kết quả trả về
            return _comDao.IsUniqueTourType(typeCd, slug);
        }
        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MATourType GetInfoTourType(string localeCd, string typeCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(typeCd)) {
                return null;
            }
            // Kết quả trả về
            return _comDao.GetInfoTourType(localeCd, typeCd, ignoreDeleteFlag);
        }
        /// <summary>
        /// Lấy danh sách code
        /// </summary>
        public IList<KeyValueObject> GetDivTourType(string localeCd, string skipCode, bool nullValue, bool ignoreDeleteFlag) {
            // Khởi tạo biến cục bộ
            var skipCodes = new string[0];
            var listResult = new List<KeyValueObject>();
            // Lấy danh sách skip code trong trường hợp skip code khác null
            if (skipCode != null) {
                skipCodes = skipCode.Split(DataComLogics.DELIMITER_SKIP_CODE);
            }
            // Tạo giá trị trắng trong trường hợp có thêm giá trị trắng
            if (nullValue) {
                listResult.Add(new KeyValueObject());
            }
            // Lấy danh sách code
            var listData = _comDao.GetDivTourType(localeCd, skipCodes, ignoreDeleteFlag);
            // Thêm danh sách code vào danh sách kết quả
            listResult.AddRange(listData);
            // Kết quả trả về
            return listResult;
        }
        /// <summary>
        /// Kiểm tra dữ liệu tồn tại
        /// </summary>
        public bool IsExistTour(string localeCd, string tourCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(tourCd)) {
                return true;
            }
            // Lấy thông tin dữ liệu
            var dataInfo = GetInfoTour(localeCd, tourCd, ignoreDeleteFlag);
            // Kết quả trả về
            return dataInfo != null;
        }
        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueTour(string tourCd, string slug) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(tourCd)
                || DataCheckHelper.IsNull(slug)) {
                return true;
            }
            // Kết quả trả về
            return _comDao.IsUniqueTour(tourCd, slug);
        }
        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MATour GetInfoTour(string localeCd, string tourCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(tourCd)) {
                return null;
            }
            // Kết quả trả về
            return _comDao.GetInfoTour(localeCd, tourCd, ignoreDeleteFlag);
        }
        /// <summary>
        /// Kiểm tra dữ liệu tồn tại
        /// </summary>
        public bool IsExistService(string localeCd, string serviceCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(serviceCd)) {
                return true;
            }
            // Lấy thông tin dữ liệu
            var dataInfo = GetInfoService(localeCd, serviceCd, ignoreDeleteFlag);
            // Kết quả trả về
            return dataInfo != null;
        }
        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueService(string serviceCd, string slug) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(serviceCd)
                || DataCheckHelper.IsNull(slug)) {
                return true;
            }
            // Kết quả trả về
            return _comDao.IsUniqueService(serviceCd, slug);
        }
        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MAService GetInfoService(string localeCd, string serviceCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(serviceCd)) {
                return null;
            }
            // Kết quả trả về
            return _comDao.GetInfoService(localeCd, serviceCd, ignoreDeleteFlag);
        }

        /// <summary>
        /// Kiểm tra dữ liệu tồn tại
        /// </summary>
        public bool IsExistBanner(string localeCd, string bannerCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(bannerCd)) {
                return true;
            }
            // Lấy thông tin dữ liệu
            var dataInfo = GetInfoBanner(localeCd, bannerCd, ignoreDeleteFlag);
            // Kết quả trả về
            return dataInfo != null;
        }
        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MABanner GetInfoBanner(string localeCd, string bannerCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(bannerCd)) {
                return null;
            }
            // Kết quả trả về
            return _comDao.GetInfoBanner(localeCd, bannerCd, ignoreDeleteFlag);
        }

        /// <summary>
        /// Kiểm tra dữ liệu tồn tại
        /// </summary>
        public bool IsExistPhoto(string typeCd, string categoryCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(typeCd)
                || DataCheckHelper.IsNull(categoryCd)) {
                return true;
            }
            // Lấy thông tin dữ liệu
            var dataInfo = GetInfoPhoto(typeCd, categoryCd, ignoreDeleteFlag);
            // Kết quả trả về
            return dataInfo != null;
        }
        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MAPhoto GetInfoPhoto(string typeCd, string categoryCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(typeCd)
                || DataCheckHelper.IsNull(categoryCd)) {
                return null;
            }
            // Kết quả trả về
            return _comDao.GetInfoPhoto(typeCd, categoryCd, ignoreDeleteFlag);
        }
        /// <summary>
        /// Kiểm tra dữ liệu tồn tại
        /// </summary>
        public bool IsExistPage(string localeCd, string pageCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(pageCd)) {
                return true;
            }
            // Lấy thông tin dữ liệu
            var dataInfo = GetInfoPage(localeCd, pageCd, ignoreDeleteFlag);
            // Kết quả trả về
            return dataInfo != null;
        }
        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniquePage(string pageCd, string slug) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(pageCd)
                || DataCheckHelper.IsNull(slug)) {
                return true;
            }
            // Kết quả trả về
            return _comDao.IsUniqueService(pageCd, slug);
        }
        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MAPage GetInfoPage(string localeCd, string pageCd, bool ignoreDeleteFlag) {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(pageCd)) {
                return null;
            }
            // Kết quả trả về
            return _comDao.GetInfoPage(localeCd, pageCd, ignoreDeleteFlag);
        }
    }
}