using System.Web;
using CTS.W._150901.Models.Domain.Common.Constants;
using CTS.W._150901.Models.Domain.Logic.Admin.Master.Photos.Entry;
using CTS.Web.Core.Domain.Controller;
using CTS.Web.Core.Domain.Model;

namespace CTS.W._150901.Web.adm.hdl.ma.photos
{
    /// <summary>
    /// Summary description for entry
    /// </summary>
    public class entry : HandlerBase
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
                case "Save":
                    response = Save(context, HandlerCom.Params);
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
            config.RoleCd = W150901Logics.CD_ROLE_CD_ADM_MA_PHT_EN_VIEW;
            // Tiến hành gọi logic
            var response = HandlerCom.Invoke(logic, request, config);
            // Kết quả xử lý
            return response;
        }
        /// <summary>
        /// Xử lý filter
        /// </summary>
        private BasicResponse Save(HttpContext context, BasicRequest request) {
            // Khai báo biến cục bộ
            var logic = new SaveOperateLogic();
            var config = new BasicConfig();
            // Gán giá trị config
            config.RoleCd = W150901Logics.CD_ROLE_CD_ADM_MA_PHT_EN_UPDATE;
            // Tiến hành gọi logic
            var response = HandlerCom.Invoke(logic, request, config);
            // Kết quả xử lý
            return response;
        }
        #endregion
    }
}