using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150901.Models.Domain.Model.Client.Main;
using CTS.Data.Com.Domain.Utils;
using CTS.Web.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.Core.Domain.Model;
using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Constants;
using CTS.Data.Core.Domain.Constants;
using CTS.Data.Com.Domain.Constants;
using CTS.W._150901.Models.Domain.Dao.Client;

namespace CTS.W._150901.Models.Domain.Logic.Client.Main
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
            var companyCom = new CompanyCom();
            var codeCom = new CodeCom();
            var metaInfo = new BaseMeta();
            var processDao = new MainDao();
            var localeCom = new LocaleCom();
            var storageFileCom = new StorageFileCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy ngôn ngữ chuẩn
            var basicLocale = localeCom.GetDefault(DataComLogics.CD_APP_CD_CLN);
            // Lấy danh sách ngôn ngữ
            var listLocales = codeCom.GetDiv(WebContextHelper.LocaleCd, DataComLogics.GRPCD_CLN_LOCALES, null, false, false);
            // Lấy giá trị combo
            var cbLocales = DataHelper.ToComboItems(listLocales, basicLocale);
            // Lấy danh sách banner
            var listBanner = processDao.GetListBanners(WebContextHelper.LocaleCd);

            // Lấy field
            var logoFileCd = companyCom.GetString("en", W150901Logics.CD_INFO_CD_LOGO_FILE_CD, false);

            var companyName = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_COMPANY_NAME, false);
            var slogan = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_SLOGAN, false);
            var address = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_ADDRESS, false);
            var copyright = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_COPYRIGHT, false);

            var twitterUrl = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_TWITTER_URL, false);
            var googleUrl = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_GOOGLE_URL, false);
            var facebookUrl = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_FACEBOOK_URL, false);
            var youtubeUrl = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_YOUTUBE_URL, false);

            var hotelurl1 = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_HOTEL_URL_1, false);
            var hotelurl2 = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_HOTEL_URL_2, false);
            var hotelurl3 = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_HOTEL_URL_3, false);
            var hotelurl4 = companyCom.GetString(WebContextHelper.LocaleCd, W150901Logics.CD_INFO_CD_HOTEL_URL_4, false);

            // Gán giá trị trả về
            getResult.Logo = logoFileCd;
            getResult.CompanyName = companyName;
            getResult.Slogan = slogan;
            getResult.Address = address;
            getResult.Copyright = copyright;
            getResult.TwitterUrl = twitterUrl;
            getResult.FacebookUrl = facebookUrl;
            getResult.GoogleUrl = googleUrl;
            getResult.YoutubeUrl = youtubeUrl;
            getResult.HotelUrl1 = hotelurl1;
            getResult.HotelUrl2 = hotelurl2;
            getResult.HotelUrl3 = hotelurl3;
            getResult.HotelUrl4 = hotelurl4;
            getResult.ListBanner = listBanner;
            getResult.CboLocales = cbLocales.ListItems;
            getResult.CboLocalesSeleted = cbLocales.SeletedValue;

            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
