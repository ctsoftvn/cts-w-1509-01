using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150901.Models.Domain.Model.Client.Service;
using CTS.W._150901.Models.Domain.Dao.Client;
using CTS.Data.Com.Domain.Utils;
using CTS.Core.Domain.Model;
using CTS.Core.Domain.Helper;
using CTS.Web.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Common.Constants;

namespace CTS.W._150901.Models.Domain.Logic.Client.Service
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
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy danh sách room
            var listSerives = processDao.GetListServices(WebContextHelper.LocaleCd);

            // Kết quả trả về
            getResult.ListServices = listSerives;
            return getResult;
        }
        #endregion
    }
}
