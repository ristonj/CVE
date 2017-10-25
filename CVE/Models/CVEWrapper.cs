using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVE.Models
{
    public class CVEWrapper
    {
        public int count { get; set; }
        public List<CVEItem> items { get; set; }
    }
}