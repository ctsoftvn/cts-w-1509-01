using System;
using CTS.W._150901.Models;
using CTS.Web.CompanyInfos;
using CTS.Web.FileManager;
using CTS.Web.Parameters;
using CTS.Web.UploadFile;
using CTS.Web.Users;
using CTS.Core.Domain.Helper;

namespace CTS.W._150901.Web
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e) {
            // Code that runs on application startup
           
        }

        void Application_End(object sender, EventArgs e) {
            //  Code that runs on application shutdown
        }

        void Application_Error(object sender, EventArgs e) {
            // Code that runs when an unhandled error occurs
        }

        void Session_Start(object sender, EventArgs e) {
            // Code that runs when a new session is started
            AppHelper.ClearAllResources();
            WebUsers.ApplyResources();
            WebFileManager.ApplyResources();
            WebUploadFile.ApplyResources();
            WebCompanyInfos.ApplyResources();
            WebParameters.ApplyResources();
            W150901.ApplyResources();
        }

        void Session_End(object sender, EventArgs e) {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }

    }
}