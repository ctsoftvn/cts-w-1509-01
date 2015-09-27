using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150901.Models.Domain.Model.Client.Tours;
using CTS.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Dao.Client;
using CTS.Web.Core.Domain.Helper;
using CTS.Data.Com.Domain.Utils;
using CTS.Core.Domain.Model;
using CTS.W._150901.Models.Domain.Common.Constants;

namespace CTS.W._150901.Models.Domain.Logic.Client.Tours
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
            // Lấy danh sách loại tour
            var listTourType = processDao.GetListToursType(WebContextHelper.LocaleCd);
            foreach (var tour in listTourType)
            {
                tour.TourImage = storageFileCom.GetFileName(
                    WebContextHelper.LocaleCd,
                    tour.FileCd,
                    false);
                // lay danh sach tour theo loai
                tour.ListTourByType = processDao.GetListToursByType(WebContextHelper.LocaleCd,tour.TypeCd);
            }

            // Lấy thông tin seo
            var infoSeo = metaCom.GetInfo(WebContextHelper.LocaleCd, W150901Logics.GRPSEO_CLN_PAGES, W150901Logics.CD_SEO_CD_PAGE_TOUR, false);
            metaInfo.MetaTitle = infoSeo.MetaTitle;
            metaInfo.MetaKeys = infoSeo.MetaKeys;
            metaInfo.MetaDesc = infoSeo.MetaDesc;
            // Kết quả trả về
            getResult.ListTourType = listTourType;
            getResult.MetaTitle = metaInfo.MetaTitle;
            getResult.MetaKey = metaInfo.MetaKeys;
            getResult.MetaDescription = metaInfo.MetaDesc;
            return getResult;
        }
        #endregion
    }
}
