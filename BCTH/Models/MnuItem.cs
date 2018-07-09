using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCTH.Models
{
    public class MnuItem
    {
        /// <summary>
        /// Lop trung gian map menu
        /// </summary>
        public string Id { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string ParentId { get; set; }
        public string OrderIndex { get; set; }
        public string Icon { get; set; }
    }
}