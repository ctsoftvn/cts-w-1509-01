﻿using System;
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
        public string TourCd { get; set; }
        [OutputText]
        public string TourName { get; set; }
        [OutputText]
        public string Slug { get; set; }
        [OutputText]
        public string FileCd { get; set; }
        [OutputText]
        public string Summary { get; set; }
        [OutputText]
        public string Notes { get; set; }
    }
}
