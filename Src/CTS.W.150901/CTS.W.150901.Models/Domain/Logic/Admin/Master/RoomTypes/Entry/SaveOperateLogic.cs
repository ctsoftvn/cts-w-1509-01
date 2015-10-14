using CTS.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Model.Admin.Master.RoomTypes.Entry;
using CTS.Web.Core.Domain.Logic;
using CTS.Web.Core.Domain.Model;

namespace CTS.W._150901.Models.Domain.Logic.Admin.Master.RoomTypes.Entry
{
    /// <summary>
    /// SaveOperateLogic
    /// </summary>
    public class SaveOperateLogic : IOperateLogic
    {
        #region Invoke Method
        public BasicResponse Invoke(BasicRequest request) {
            // Khởi tạo biến cục bộ
            var logic = new SaveLogic();
            // Convert đối tượng request
            var inputObject = MapHelper.Convert<SaveDataModel>(request);
            // Thực thi xử lý logic
            var resultObject = logic.Execute(inputObject);
            // Convert đối tượng response
            var response = MapHelper.Convert<BasicResponse>(resultObject);
            // Kết quả trả về
            return response;
        }
        #endregion
    }
}
