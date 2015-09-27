using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Core.Domain.Attr;

namespace CTS.W._150901.Models.Domain.Object.Client.Page
{
    public class PageObject
    {
        [OutputText]
        public string LocaleCd { get; set; }
        [OutputText]
        public string PageCd { get; set; }
        [OutputText]
        public string PageName { get; set; }
        [OutputText]
        public string Slug { get; set; }
        [OutputText]
        public string Content { get; set; }
    }
}
