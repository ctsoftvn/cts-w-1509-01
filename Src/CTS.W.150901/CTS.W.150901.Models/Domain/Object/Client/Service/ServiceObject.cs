using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Core.Domain.Attr;

namespace CTS.W._150901.Models.Domain.Object.Client.Service
{
    public class ServiceObject
    {
        [OutputText]
        public string LocaleCd { get; set; }
        [OutputText]
        public string ServiceCd { get; set; }
        [OutputText]
        public string ServiceName { get; set; }
        [OutputText]
        public string Slug { get; set; }
        [OutputText]
        public string FileCd { get; set; }
        [OutputText]
        public string ServiceImage { get; set; }
        [OutputText]
        public string Notes { get; set; }

    }
}
