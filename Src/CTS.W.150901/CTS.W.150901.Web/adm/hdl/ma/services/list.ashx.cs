using System.Web;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.W._150901.Models.Domain.Logic.Admin.Master.Services.List;
using CTS.Web.Core.Domain.Controller;
using CTS.Web.Core.Domain.Model;

namespace CTS.W._150901.Web.adm.hdl.ma.services
{
    /// <summary>
    /// Summary description for list
    /// </summary>
    public class list : HandlerBase
    {
        #region ProcessRequest Method
        /// <summary>
        /// Thực thi xử lý
        /// </summary>
        /// <param name="context">Đối tượng context</param>
        public override void ProcessExecute(HttpContext context) {
            // Khai báo biến cục bộ
            var response = new BasicResponse();
            // Tiến hành thực thi xử lý
            switch (HandlerCom.Action) {
                case "InitLayout":
                    response = InitLayout(context, HandlerCom.Params);
                    context.Response.Write(response.ToStringify());
                    break;
                case "Filter":
                    response = Filter(context, HandlerCom.Params);
                    context.Response.Write(response.ToStringify());
                    break;
                case "SaveBatch":
                    response = SaveBatch(context, HandlerCom.Params);
                    context.Response.Write(response.ToStringify());
                    break;
                default:
                    break;
            }
            // Kết thúc response
            context.Response.End();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Xử lý init
        /// </summary>
        private BasicResponse InitLayout(HttpContext context, BasicRequest request) {
            // Khai báo biến cục bộ
            var logic = new InitOperateLogic();
            var config = new BasicConfig();
            // Gán giá trị config
            config.RoleCd = W150901Logics.CD_ROLE_CD_ADM_MA_SRV_LI_VIEW;
            // Tiến hành gọi logic
            var response = HandlerCom.Invoke(logic, request, config);
            // Kết quả xử lý
            return response;
        }
        /// <summary>
        /// Xử lý filter
        /// </summary>
        private BasicResponse Filter(HttpContext context, BasicRequest request) {
            // Khai báo biến cục bộ
            var logic = new FilterOperateLogic();
            var config = new BasicConfig();
            // Gán giá trị config
            config.RoleCd = W150901Logics.CD_ROLE_CD_ADM_MA_SRV_LI_FILTER;
            // Tiến hành gọi logic
            var response = HandlerCom.Invoke(logic, request, config);
            // Kết quả xử lý
            return response;
        }
        /// <summary>
        /// Xử lý save đồng loạt
        /// </summary>
        private BasicResponse SaveBatch(HttpContext context, BasicRequest request) {
            // Khai báo biến cục bộ
            var logic = new SaveBatchOperateLogic();
            var config = new BasicConfig();
            // Gán giá trị config
            config.RoleCd = W150901Logics.CD_ROLE_CD_ADM_MA_SRV_LI_UPDATE;
            // Tiến hành gọi logic
            var response = HandlerCom.Invoke(logic, request, config);
            // Kết quả xử lý
            return response;
        }
        #endregion
    }
}