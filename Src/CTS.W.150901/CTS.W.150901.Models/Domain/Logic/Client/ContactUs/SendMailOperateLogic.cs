using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Web.Core.Domain.Logic;
using CTS.Web.Core.Domain.Model;
using CTS.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Model.Client.ContactUs;

namespace CTS.W._150901.Models.Domain.Logic.Client.ContactUs
{
    /// <summary>
    /// SendMailOperateLogic
    /// </summary>
    public class SendMailOperateLogic : IOperateLogic
    {
        #region Invoke Method
        public BasicResponse Invoke(BasicRequest request)
        {
            // Khởi tạo biến cục bộ
            var logic = new SendMailLogic();
            // Convert đối tượng request
            var inputObject = MapHelper.Convert<SendMailDataModel>(request);
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
