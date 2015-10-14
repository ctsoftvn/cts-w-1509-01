using CTS.Core.Domain.Helper;
using CTS.Core.Domain.Model;
using CTS.W._150901.Models.Domain.Dao.Admin;
using CTS.W._150901.Models.Domain.Model.Admin.Master.TourTypes.List;
using CTS.W._150901.Models.Domain.Object.Admin.Master;

namespace CTS.W._150901.Models.Domain.Logic.Admin.Master.TourTypes.List
{
    /// <summary>
    /// FilterLogic
    /// </summary>
    public class FilterLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý filter.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public FilterDataModel Execute(FilterDataModel inputObject) {
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
        private void Check(FilterDataModel inputObject) {
        }

        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private FilterDataModel GetInfo(FilterDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var getResult = new FilterDataModel();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy đối tượng pager
            var pagerData = GetPagerData(inputObject);
            // Gán giá trị trả về
            getResult.ListData = pagerData.ListData;
            getResult.Total = pagerData.Total;
            // Kết quả trả về
            return getResult;
        }

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        private PagerInfoModel<TourTypeObject> GetPagerData(FilterDataModel inputObject) {
            // Khởi tạo biến cục bộ
            var pagerResult = new PagerInfoModel<TourTypeObject>();
            var processDao = new MasterTourTypesDao();
            // Lấy đối tượng pager
            var pagerData = processDao.GetPagerData(inputObject);
            // Gán giá trị trả về
            pagerResult.ListData = pagerData.ListData;
            pagerResult.Total = pagerData.Total;
            // Kết quả trả về
            return pagerResult;
        }
        #endregion
    }
}
