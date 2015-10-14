using CTS.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Model.Admin.Master.Pages;
using CTS.Web.Core.Domain.Logic;
using CTS.Web.Core.Domain.Model;

namespace CTS.W._150901.Models.Domain.Logic.Admin.Master.Pages
{
    /// <summary>
    /// InitOperateLogic
    /// </summary>
    public class InitOperateLogic : IOperateLogic
    {
        #region Invoke Method
        public BasicResponse Invoke(BasicRequest request) {
            // Khởi tạo biến cục bộ
            var logic = new InitLogic();
            // Convert đối tượng request
            var inputObject = MapHelper.Convert<InitDataModel>(request);
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
