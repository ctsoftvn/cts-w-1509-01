using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Core.Domain.Attr;

namespace CTS.W._150901.Models.Domain.Object.Client.Tour
{
    public class TourObject
    {
        [OutputText]
        public string LocaleCd { get; set; }
        [OutputText]
        public string TypeCd { get; set; }
        [OutputText]
        public string TypeName { get; set; }
        [OutputText]
        public string Slug { get; set; }
        [OutputText]
        public string FileCd { get; set; }
        [OutputText]
        public string TourImage { get; set; }
        [OutputText]
        public string Notes { get; set; }
        [OutputList(IgnoreAttribute = false)]
        public IList<TourDetailObject> ListTourByType { get; set; }
    }
}
