using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Core.Domain.Attr;

namespace CTS.W._150901.Models.Domain.Object.Client.Photo
{
    public class PhotoObject
    {
        [OutputText]
        public string LocaleCd { get; set; }
        [OutputText]
        public string PhotoCd { get; set; }
        [OutputText]
        public string PhotoName { get; set; }
        [OutputText]
        public string Notes { get; set; }
        [OutputText]
        public string FileCd { get; set; }
    }
}
