﻿using CTS.Core.Domain.Helper;
using CTS.W._150901.Models.Domain.Model.Admin.Master.Banners.List;
using CTS.Web.Core.Domain.Logic;
using CTS.Web.Core.Domain.Model;

namespace CTS.W._150901.Models.Domain.Logic.Admin.Master.Banners.List
{
    /// <summary>
    /// SaveBatchOperateLogic
    /// </summary>
    public class SaveBatchOperateLogic : IOperateLogic
    {
        #region Invoke Method
        public BasicResponse Invoke(BasicRequest request) {
            // Khởi tạo biến cục bộ
            var logic = new SaveBatchLogic();
            // Convert đối tượng request
            var inputObject = MapHelper.Convert<SaveBatchDataModel>(request);
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