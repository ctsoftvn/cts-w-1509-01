using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150901.Models.Domain.Model.Client.TourDetail;
using CTS.W._150901.Models.Domain.Dao.Client;
using CTS.Data.Com.Domain.Utils;
using CTS.Core.Domain.Helper;
using CTS.Web.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.Core.Domain.Model;

namespace CTS.W._150901.Models.Domain.Logic.Client.TourDetail
{
    /// <summary>
    /// InitLogic
    /// </summary>
    public class InitLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý init.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public InitDataModel Execute(InitDataModel inputObject)
        {
            // Kiểm tra thông tin
            Check(inputObject);
            // Lấy thông tin
            var resultObject = GetInfo(inputObject);
            // Kết quả trả về
            return resultObject;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Kiểm tra thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(InitDataModel inputObject)
        {

        }
        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private InitDataModel GetInfo(InitDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var getResult = new InitDataModel();
            var processDao = new MainDao();
            var storageFileCom = new StorageFileCom();
            var metaCom = new MetaCom();
            var metaInfo = new BaseMeta();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy tour
            var tour = processDao.GetTourDetail(WebContextHelper.LocaleCd, inputObject.Slug);

            // Lấy thông tin seo
            var infoSeo = metaCom.GetInfo(WebContextHelper.LocaleCd, W150901Logics.GRPMETA_MA_TOURS, tour.TourCd, false);
            metaInfo.MetaTitle = infoSeo.MetaTitle;
            metaInfo.MetaKeys = infoSeo.MetaKeys;
            metaInfo.MetaDesc = infoSeo.MetaDesc;
            // Kết quả trả về
            getResult.Tour = tour;
            getResult.MetaTitle = metaInfo.MetaTitle;
            getResult.MetaKey = metaInfo.MetaKeys;
            getResult.MetaDescription = metaInfo.MetaDesc;
            return getResult;
        }
        #endregion
    }
}
