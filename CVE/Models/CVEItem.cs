using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVE.Models
{
    public class CVEItem
    {
        public CVEItem(Def_cve_item myItem)
        {
            ID = myItem.Cve.CVE_data_meta.ID;
            severity = myItem.Impact.BaseMetricV3.CvssV3.BaseSeverity.ToString();
            string tempValue = myItem.Cve.Description.Description_data[0].Value;
            if (tempValue.Length > 75)
            {
                tempValue = tempValue.Substring(0, 75) + "...";
            }
            description = tempValue;

        }

        public string ID { get; set; }
        public string severity { get; set; }
        public string description { get; set; }
    }
}