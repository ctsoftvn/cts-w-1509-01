using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Core.Domain.Model;
using CTS.Core.Domain.Attr;

namespace CTS.W._150901.Models.Domain.Model.Client.ContactUs
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class SendMailDataModel : BasicInfoModel
    {
        [InputText]
        public string Name { get; set; }
        [InputText]
        public string Phone { get; set; }
        [InputText(RuleName = "email", MessageParam = "CLN.CONTACTUS.00001")]
        public string Email { get; set; }
        [InputText]
        public string Description { get; set; }

    }
}
